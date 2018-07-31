using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class WallController : MonoBehaviour
{

    private Tilemap tileMap;
    public int hp = 5;
    // Use this for initialization
    void Awake()
    {
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
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Up, FloorFullFacing.Down, FloorFullFacing.Left, FloorFullFacing.Right },
                FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft, FloorCornerFacing.UpRight, FloorCornerFacing.DownLeft, FloorCornerFacing.DownRight },
                AnimatorName = "8F",
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = "8F" }

            };
            GameData.AddGameTile(tilePos, tileData);


            CreateNewWall(tilePos, new Vector3Int(tilePos.x, tilePos.y + 1, 0));
            CreateNewWall(tilePos, new Vector3Int(tilePos.x + 1, tilePos.y + 1, 0));
            //CreateNewWall(tilePos, new Vector3Int(tilePos.x, tilePos.y - 1, 0));
            //CreateNewWall(tilePos, new Vector3Int(tilePos.x + 1, tilePos.y, 0));
            //CreateNewWall(tilePos, new Vector3Int(tilePos.x - 1, tilePos.y, 0));
        }

    }
    private void CreateNewWall(Vector3Int fromWallDir, Vector3Int newWallDir)
    {
        Vector3Int upWallDir = new Vector3Int(newWallDir.x, newWallDir.y + 1, 0);
        Vector3Int downWallDir = new Vector3Int(newWallDir.x, newWallDir.y - 1, 0);
        Vector3Int rightWallDir = new Vector3Int(newWallDir.x + 1, newWallDir.y, 0);
        Vector3Int leftWallDir = new Vector3Int(newWallDir.x - 1, newWallDir.y, 0);
        TileInfo newWall = null;
        TileInfo fromWall = null;
        TileInfo upWall = null;
        TileInfo downWall = null;
        TileInfo rightWall = null;
        TileInfo leftWall = null;

        if (GameData.GameTiles.ContainsKey(newWallDir))
        {
            newWall = GameData.GameTiles[newWallDir];
        }
        // Get TileInfo in cardinal directions
        if (fromWallDir == upWallDir)
        {
            if (GameData.GameTiles.ContainsKey(fromWallDir))
            {
                fromWall = GameData.GameTiles[fromWallDir];
                upWall = fromWall;
            }
            if (GameData.GameTiles.ContainsKey(downWallDir))
            {
                downWall = GameData.GameTiles[downWallDir];
            }
            if (GameData.GameTiles.ContainsKey(rightWallDir))
            {
                rightWall = GameData.GameTiles[rightWallDir];
            }
            if (GameData.GameTiles.ContainsKey(leftWallDir))
            {
                leftWall = GameData.GameTiles[leftWallDir];
            }
        }
        else if (fromWallDir == downWallDir)
        {
            if (GameData.GameTiles.ContainsKey(fromWallDir))
            {
                fromWall = GameData.GameTiles[fromWallDir];
                downWall = fromWall;
            }
            if (GameData.GameTiles.ContainsKey(upWallDir))
            {
                upWall = GameData.GameTiles[upWallDir];
            }
            if (GameData.GameTiles.ContainsKey(rightWallDir))
            {
                rightWall = GameData.GameTiles[rightWallDir];
            }
            if (GameData.GameTiles.ContainsKey(leftWallDir))
            {
                leftWall = GameData.GameTiles[leftWallDir];
            }
        }
        else if (fromWallDir == rightWallDir)
        {
            if (GameData.GameTiles.ContainsKey(fromWallDir))
            {
                fromWall = GameData.GameTiles[fromWallDir];
                rightWall = fromWall;
            }
            if (GameData.GameTiles.ContainsKey(upWallDir))
            {
                upWall = GameData.GameTiles[upWallDir];
            }
            if (GameData.GameTiles.ContainsKey(downWallDir))
            {
                downWall = GameData.GameTiles[downWallDir];
            }
            if (GameData.GameTiles.ContainsKey(leftWallDir))
            {
                leftWall = GameData.GameTiles[leftWallDir];
            }
        }
        else if (fromWallDir == leftWallDir)
        {
            if (GameData.GameTiles.ContainsKey(fromWallDir))
            {
                fromWall = GameData.GameTiles[fromWallDir];
                leftWall = fromWall;
            }
            if (GameData.GameTiles.ContainsKey(upWallDir))
            {
                upWall = GameData.GameTiles[upWallDir];
            }
            if (GameData.GameTiles.ContainsKey(downWallDir))
            {
                downWall = GameData.GameTiles[downWallDir];
            }
            if (GameData.GameTiles.ContainsKey(rightWallDir))
            {
                rightWall = GameData.GameTiles[rightWallDir];
            }
        }
        bool upWallSide = true;
        bool downWallSide = true;
        bool leftWallSide = true;
        bool rightWallSide = true;

        if (upWall == null)
        {
            upWallSide = true;
        }
        else
        {
            foreach (FloorFullFacing f in upWall.FloorFullFacings)
            {
                if (f == FloorFullFacing.Up)
                {
                    upWallSide = false;
                }
            }
            foreach (FloorCornerFacing f in upWall.FloorCornerFacings)
            {
                if (f == FloorCornerFacing.UpLeft || f == FloorCornerFacing.UpRight)
                {
                    upWallSide = false;
                }
            }
        }
        if (downWall == null)
        {
            downWallSide = true;
        }
        else
        {
            foreach (FloorFullFacing f in downWall.FloorFullFacings)
            {
                if (f == FloorFullFacing.Down)
                {
                    downWallSide = false;
                }
            }
            foreach (FloorCornerFacing f in downWall.FloorCornerFacings)
            {
                if (f == FloorCornerFacing.DownLeft || f == FloorCornerFacing.DownRight)
                {
                    downWallSide = false;
                }
            }
        }
        if (leftWall == null)
        {
            leftWallSide = true;
        }
        else
        {
            foreach (FloorFullFacing f in leftWall.FloorFullFacings)
            {
                if (f == FloorFullFacing.Left)
                {
                    leftWallSide = false;
                }
            }
            foreach (FloorCornerFacing f in leftWall.FloorCornerFacings)
            {
                if (f == FloorCornerFacing.UpLeft || f == FloorCornerFacing.DownLeft)
                {
                    leftWallSide = false;
                }
            }
        }
        if (rightWall == null)
        {
            rightWallSide = true;
        }
        else
        {
            foreach (FloorFullFacing f in rightWall.FloorFullFacings)
            {
                if (f == FloorFullFacing.Right)
                {
                    rightWallSide = false;
                }
            }
            foreach (FloorCornerFacing f in rightWall.FloorCornerFacings)
            {
                if (f == FloorCornerFacing.UpRight || f == FloorCornerFacing.DownRight)
                {
                    rightWallSide = false;
                }
            }
        }



        if (upWallSide && leftWallSide && rightWallSide && (!downWallSide)) 
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();

            newTile.gameObject = Globals.prefab_2FIC;
            tileMap.SetTile(newWallDir, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = newWallDir,
                WorldLocation = tileMap.CellToWorld(newWallDir),
                Rotation = RotationStrings.Base,
                Flipped = false,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Down },
                FloorCornerFacings = new FloorCornerFacing[] { },
                AnimatorName = Globals.prefab_2CIC.name,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_2CIC.name }

            };
            GameData.AddGameTile(newWallDir, tileData);
        }  // Replace with 2FIC
        else if (downWallSide && leftWallSide && rightWallSide && (!upWallSide)) 
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();

            newTile.gameObject = Globals.prefab_2FIC;
            tileMap.SetTile(newWallDir, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = newWallDir,
                WorldLocation = tileMap.CellToWorld(newWallDir),
                Rotation = RotationStrings.UpsideDown,
                Flipped = false,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Up },
                FloorCornerFacings = new FloorCornerFacing[] { },
                AnimatorName = Globals.prefab_2CIC.name,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_2CIC.name }

            };
            GameData.AddGameTile(newWallDir, tileData);
        }  // Replace with 2FIC
        else if (downWallSide && upWallSide && rightWallSide && (!leftWallSide))
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();

            newTile.gameObject = Globals.prefab_2FIC;
            tileMap.SetTile(newWallDir, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = newWallDir,
                WorldLocation = tileMap.CellToWorld(newWallDir),
                Rotation = RotationStrings.CounterClockwise,
                Flipped = false,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Left },
                FloorCornerFacings = new FloorCornerFacing[] { },
                AnimatorName = Globals.prefab_2CIC.name,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_2CIC.name }

            };
            GameData.AddGameTile(newWallDir, tileData);
        }  // Replace with 2FIC
        else if (downWallSide && upWallSide && leftWallSide && (!rightWallSide))
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();

            newTile.gameObject = Globals.prefab_2FIC;
            tileMap.SetTile(newWallDir, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = newWallDir,
                WorldLocation = tileMap.CellToWorld(newWallDir),
                Rotation = RotationStrings.Clockwise,
                Flipped = false,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Right },
                FloorCornerFacings = new FloorCornerFacing[] { },
                AnimatorName = Globals.prefab_2CIC.name,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_2CIC.name }

            };
            GameData.AddGameTile(newWallDir, tileData);
        }  // Replace with 2FIC
        else if ((upWallSide && leftWallSide) && (!rightWallSide && !downWallSide))
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();

            newTile.gameObject = Globals.prefab_3IC;
            tileMap.SetTile(newWallDir, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = newWallDir,
                WorldLocation = tileMap.CellToWorld(newWallDir),
                Rotation = RotationStrings.Base,
                Flipped = false,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Down },
                FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownRight },
                AnimatorName = Globals.prefab_3IC.name,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

            };
            GameData.AddGameTile(newWallDir, tileData);
        }
        else if (upWallSide && rightWallSide && (!leftWallSide && !downWallSide))
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();

            newTile.gameObject = Globals.prefab_3IC;
            tileMap.SetTile(newWallDir, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = newWallDir,
                WorldLocation = tileMap.CellToWorld(newWallDir),
                Rotation = RotationStrings.Base,
                Flipped = true,
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = WallTypes.PlaceHolder,
                FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Down },
                FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownLeft },
                AnimatorName = Globals.prefab_3IC.name,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

            };
            GameData.AddGameTile(newWallDir, tileData);
        }
    }
}


