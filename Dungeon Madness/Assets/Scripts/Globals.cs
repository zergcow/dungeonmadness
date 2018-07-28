using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

static class Globals {

    public static GameObject prefab_0T;
    public static GameObject prefab_2CIC;
    public static GameObject prefab_2FIC;
    public static GameObject prefab_3IC;
    public static GameObject prefab_4ACIC;
    public static GameObject prefab_4CIC;
    public static GameObject prefab_4W;
    public static GameObject prefab_4WD;
    public static GameObject prefab_5OC;
    public static GameObject prefab_6CIC;
    public static GameObject prefab_6COC;
    public static GameObject prefab_6FOC;
    public static GameObject prefab_8F;
    public static GameObject prefab_8IC;
    public static GameObject prefab_8ICS;
    public static GameObject prefab_8S;

    public static void SetNewWall(Tilemap tileMap, Vector3Int tilePos, Vector3Int findPos, GameObject newTileObject, bool needsflipped = false)
    {
        var newTile = ScriptableObject.CreateInstance<Tile>();
        Vector3Int newPos = Vector3Int.RoundToInt(findPos);

        newTile.gameObject = newTileObject;
        tileMap.SetTile(newPos, newTile);
        RotationStrings rotStr = (RotationStrings)DetermineTileDirection(tilePos.x, tilePos.y, findPos.x, findPos.y);
        var tileData = new TileInfo
        {
            LocalPlace = newPos,
            WorldLocation = tileMap.CellToWorld(newPos),
            Rotation = rotStr,
            Flipped = needsflipped,
            TileBase = newTile,
            TilemapMember = tileMap,
            ResourceType = WallTypes.PlaceHolder,
            AnimatorName = newTileObject.name,
            BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = newTileObject.name }

        };
        GameData.AddGameTile(newPos, tileData);
    }


    public static int DetermineTileDirection(int fromX, int fromY, int x, int y)
    {
        RotationStrings ret = RotationStrings.Base;

        //Do Something to determine tile direction
        // X + 1 = EAST
        // Y + 1 = NORTH
        // X - 1 = WEST
        // Y - 1 = SOUTH

        int diffX = fromX - x;
        int diffY = fromY - y;

        if (diffX == 1)
        {
            ret = RotationStrings.Clockwise;
        }
        else if (diffX == -1)
        {
            ret = RotationStrings.CounterClockwise;
        }
        if (diffY == 1)
        {
            ret = RotationStrings.UpsideDown;
        }
        else if (diffY == -1)
        {
            ret = RotationStrings.Base;
        }
        return (int)ret;
    }
}
