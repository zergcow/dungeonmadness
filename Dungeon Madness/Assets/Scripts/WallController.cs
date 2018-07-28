using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class WallController : MonoBehaviour {

    private Tilemap tileMap;
    public int hp = 5;
	// Use this for initialization
	void Awake () {
    }
    void Start()
    {
        tileMap = GetComponentInParent<Tilemap>();
        Vector3Int curPos = Vector3Int.RoundToInt(transform.localPosition);
        if (GameData.GameTiles.ContainsKey(curPos))
        {
            // Get TileInfo for tile at position
            TileInfo curTile = GameData.GameTiles[curPos];
            //Set Tile Resource Type using Animator
            Animator tileAni = gameObject.GetComponent<Animator>();
            tileAni.StartPlayback();
            tileAni.PlayInFixedTime(curTile.AnimatorName, 0, (float)curTile.ResourceType / 10);

            //Set required tile rotation
            gameObject.transform.Rotate(GameData.RotationTypes[curTile.Rotation]);
            if (curTile.Flipped)
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x *= -1;
                gameObject.transform.localScale = newScale;
            }
        }
    }

    private void OnMouseDown()
    {
        DamageWall(1);
    }
    public void DamageWall(int loss)
    {
        hp -= loss;

        if (hp <= 0)
        {
            // Process Essence from current tile





            // End Process Essence


            //change destroyed tile into a floor
            var newTile = ScriptableObject.CreateInstance<Tile>();
            Vector3Int tilePos = new Vector3Int(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.y), 0);

            newTile.gameObject = Globals.prefab_8F;
            tileMap.SetTile(tilePos, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = tilePos,
                WorldLocation = tileMap.CellToWorld(tilePos),
                Rotation = RotationStrings.Base,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                AnimatorName = "8F",
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = "8F" }

            };
            GameData.AddGameTile(tilePos, tileData);
            for (int x = -1; x <= 1; x++)  //order x=-1/y=-1|y=0|y=+1  x=0/y=-1|y=0|y=+1  x=+1/y=-1|y=0|y=+1
            {
                for (int y = -1; y <= 1; y++)
                {
                    SetTileInDirection(tilePos, x, y);
                }
            }
        }

    }
    private void GetTileInDirection(int x, int y, Vector3Int findPos, ref TileInfo checkTilePlus, ref TileInfo checkTileMinus)
    {

        Vector3Int checkTilePlusPos;
        Vector3Int checkTilePlusMinus;
        if (x == 0)
        {
            checkTilePlusPos = new Vector3Int(findPos.x + 1, findPos.y, 0);
            checkTilePlusMinus = new Vector3Int(findPos.x - 1, findPos.y, 0);
            if (GameData.GameTiles.ContainsKey(checkTilePlusPos))
            {
                checkTilePlus = GameData.GameTiles[checkTilePlusPos];
            }
            if (GameData.GameTiles.ContainsKey(checkTilePlusMinus))
            {
                checkTileMinus = GameData.GameTiles[checkTilePlusMinus];
            }
        }
        else if (y == 0)
        {
            checkTilePlusPos = new Vector3Int(findPos.x, findPos.y + 1, 0);
            checkTilePlusMinus = new Vector3Int(findPos.x, findPos.y - 1, 0);
            if (GameData.GameTiles.ContainsKey(checkTilePlusPos))
            {
                checkTilePlus = GameData.GameTiles[checkTilePlusPos];
            }
            if (GameData.GameTiles.ContainsKey(checkTilePlusMinus))
            {
                checkTileMinus = GameData.GameTiles[checkTilePlusMinus];
            }
        }
    }
    private void SetTileInDirection(Vector3Int tilePos, int x, int y)
    {
        Vector3Int findPos = new Vector3Int(tilePos.x + x, tilePos.y + y, 0);
        TileInfo ti = null;
        if (GameData.GameTiles.ContainsKey(findPos))
        {
            ti = GameData.GameTiles[findPos];
        }
        if (ti == null)  // New Cell
        {
            if ((x == 0) || (y == 0)) // Cardinal directions only
            {
                TileInfo checkTilePlus = null;
                TileInfo checkTileMinus = null;

                GetTileInDirection(x, y, findPos, ref checkTilePlus, ref checkTileMinus);
                if (checkTilePlus == null && checkTileMinus == null)  // surrounded by no tiles
                {
                    Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_2FIC);
                }
                else if (checkTilePlus != null && checkTileMinus != null)
                {
                    // each side has some kind of tile
                }
                else if (checkTilePlus != null && checkTileMinus == null)
                {
                    GetTileInDirection(x, y, checkTilePlus.LocalPlace, ref checkTilePlus, ref checkTileMinus);
                    if (x == 0)
                    {
                        if (checkTilePlus == null) 
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, y == 1 ? true : false);
                        }
                        else if (checkTileMinus == null)
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, y == 1 ? false : true);
                        }
                    }
                    else if (y == 0)
                    {
                        if (checkTilePlus == null) 
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, x == 1 ? false : true);
                        }
                        else if (checkTileMinus == null)
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, x == 1 ? true : false);
                        }
                    }
                }
                else if (checkTilePlus == null && checkTileMinus != null)
                {
                    GetTileInDirection(x, y, checkTileMinus.LocalPlace, ref checkTilePlus, ref checkTileMinus);
                    if (x == 0)
                    {
                        if (checkTilePlus == null)  
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, y == 1 ? true : false);
                        }
                        else if (checkTileMinus == null)
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, y == 1 ? false : true);
                        }
                    }
                    else if (y == 0)
                    {
                        if (checkTilePlus == null) 
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, x == 1 ? false : true);
                        }
                        else if (checkTileMinus == null)
                        {
                            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_3IC, x == 1 ? true : false);
                        }
                    }
                }
            }
        }
        else if (ti.AnimatorName == "4W")
        {
            /*
                Determine Direction of new and set new rotation/flip      
             */
        }
    }


}
