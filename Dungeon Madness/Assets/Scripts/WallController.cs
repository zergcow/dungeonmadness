using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Scripts;

public class WallController : MonoBehaviour {

    private Tilemap tileMap;
    public int hp = 5;
	// Use this for initialization
	void Awake () {
    }
    void Start()
    {
        tileMap = GetComponentInParent<Tilemap>();
        if (GameData.GameTiles.ContainsKey(transform.localPosition))
        {
            // Get TileInfo for tile at position
            TileInfo curTile = GameData.GameTiles[transform.localPosition];
            //Set Tile Resource Type using Animator
            Animator tileAni = gameObject.GetComponent<Animator>();
            tileAni.StartPlayback();
            tileAni.PlayInFixedTime(curTile.AnimatorName, 0, (float)curTile.ResourceType / 10);

            //Set required tile rotation
            gameObject.transform.Rotate(GameData.RotationTypes[curTile.Rotation]);
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
            //change destroyed tile into a floor
            var newTile = ScriptableObject.CreateInstance<Tile>();
            Vector3Int tilePos = new Vector3Int(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.y), 0);

            newTile.gameObject = Globals.prefab_8F[Random.Range(0, Globals.prefab_8F.Length)];
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
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    CheckTileInDirection(tilePos, x, y);
                }
            }
        }

    }

    private void CheckTileInDirection(Vector3 tilePos, int x, int y)
    {
        Vector3 findPos = new Vector3(tilePos.x + x, tilePos.y + y, 0);
        TileInfo ti = GameData.GameTiles[findPos];
        if (ti == null)  // New Cell
        {

        }
        else if (ti.BaseObjectData.Name == "4W")
        {
            if (ti.Rotation == RotationStrings.Base)
            {
                //DO NOTHING
            }
            else if (ti.Rotation == RotationStrings.Clockwise)
            {
                // CREATE 6COC BASE
            }
            else if (ti.Rotation == RotationStrings.CounterClockwise)
            {
                // CREATE 6COC COUNTERCLOCKWISE
            }
            else if (ti.Rotation == RotationStrings.Flipped)
            {
                // CREATE 8S
            }
        }
    }


}
