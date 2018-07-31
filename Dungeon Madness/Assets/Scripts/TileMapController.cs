using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class TileMapController : MonoBehaviour {
    


    private Tilemap tileMap;

	// Use this for initialization
	void Start () {
        tileMap = GetComponent<Tilemap>();

        int roomHeight = 6;
        int roomWidth = 8;
        int offsetX = -3; //set sw corner room start
        int offsetY = -3; //set sw corner room start

        CreateRoom(roomWidth, roomHeight, offsetX, offsetY);
    }

    private void CreateRoom(int roomWidth, int roomHeight, int offsetX, int offsetY)
    {
        try
        {

            int maxX = offsetX;
            int maxY = offsetY;
            int minX = offsetX;
            int minY = offsetY;
            for (int x = 0; x < roomWidth; x++)
            {
                int tileX = offsetX + x;
                if (maxX < tileX)
                {
                    maxX = tileX;
                }
                if (minX > tileX)
                {
                    minX = tileX;
                }
                for (int y = 0; y < roomHeight; y++)
                {
                    int tileY = offsetY + y;
                    if (maxY < tileY)
                    {
                        maxY = tileY;
                    }
                    if (minY > tileY)
                    {
                        minY = tileY;
                    }
                    var newTile = ScriptableObject.CreateInstance<Tile>();
                    Vector3Int tilePos = new Vector3Int(tileX, tileY, 0);

                    newTile.gameObject = Globals.prefab_8F;
                    tileMap.SetTile(tilePos, newTile);
                    var tileData = new TileInfo
                    {
                        LocalPlace = tilePos,
                        WorldLocation = tileMap.CellToWorld(tilePos),
                        Rotation = RotationStrings.Base,
                        Flipped = false,
                        TileBase = newTile,
                        TilemapMember = tileMap,
                        ResourceType = WallTypes.PlaceHolder,
                        FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Up, FloorFullFacing.Down, FloorFullFacing.Left, FloorFullFacing.Right },
                        FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft, FloorCornerFacing.UpRight, FloorCornerFacing.DownLeft, FloorCornerFacing.DownRight },
                        AnimatorName = "8F",
                        BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = "8F" }

                    };
                    GameData.AddGameTile(tilePos, tileData);
                }
            }
            CreateWallsForRoom(roomWidth, roomHeight, maxX, maxY, minX, minY);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    private void CreateWallsForRoom(int roomWidth, int roomHeight, int maxX, int maxY, int minX, int minY)
    {
        for (int y = minY; y <= maxY; y++)
        {
            Vector3Int findPos = new Vector3Int(maxX + 1, y, 0);
            Vector3Int tilePos = new Vector3Int(maxX, y, 0);
            if (y == minY)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.CounterClockwise,
                    Flipped = true,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Left },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else if (y == maxY)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.CounterClockwise,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Left },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownLeft },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_4W;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.CounterClockwise,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] {  FloorFullFacing.Left },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft, FloorCornerFacing.DownLeft },
                    AnimatorName = Globals.prefab_4W.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_4W.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
        }
        for (int y = minY; y <= maxY; y++)
        {
            Vector3Int findPos = new Vector3Int(minX - 1, y, 0);
            Vector3Int tilePos = new Vector3Int(minX, y, 0);
            if (y == minY)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.Clockwise,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Right },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else if (y == maxY)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.Clockwise,
                    Flipped = true,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Right },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownRight },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_4W;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.Clockwise,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Right },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpRight, FloorCornerFacing.DownRight },
                    AnimatorName = Globals.prefab_4W.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_4W.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
        }

        for (int x = minX; x <= maxX; x++)
        {
            Vector3Int findPos = new Vector3Int(x, maxY + 1, 0);
            Vector3Int tilePos = new Vector3Int(x, maxY, 0);
            if (x == minX)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.Base,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Down },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownLeft },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else if (x == maxX)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.Base,
                    Flipped = true,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Down },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownRight },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_4W;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.Base,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Down },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.DownLeft, FloorCornerFacing.DownRight },
                    AnimatorName = Globals.prefab_4W.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_4W.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
        }
        for (int x = minX; x <= maxX; x++)
        {
            Vector3Int findPos = new Vector3Int(x, minY - 1, 0);
            Vector3Int tilePos = new Vector3Int(x, minY, 0);
            if (x == minX)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.UpsideDown,
                    Flipped = true,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Up },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else if (x == maxX)
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_3IC;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.UpsideDown,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Up },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpRight },
                    AnimatorName = Globals.prefab_3IC.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_3IC.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
            else
            {
                var newTile = ScriptableObject.CreateInstance<Tile>();
                Vector3Int newPos = Vector3Int.RoundToInt(findPos);
                newTile.gameObject = Globals.prefab_4W;
                tileMap.SetTile(newPos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = newPos,
                    WorldLocation = tileMap.CellToWorld(newPos),
                    Rotation = RotationStrings.UpsideDown,
                    Flipped = false,
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = WallTypes.PlaceHolder,
                    FloorFullFacings = new FloorFullFacing[] { FloorFullFacing.Up },
                    FloorCornerFacings = new FloorCornerFacing[] { FloorCornerFacing.UpLeft, FloorCornerFacing.UpRight },
                    AnimatorName = Globals.prefab_4W.name,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = Globals.prefab_4W.name }

                };
                GameData.AddGameTile(newPos, tileData);
            }
        }
    }
}
