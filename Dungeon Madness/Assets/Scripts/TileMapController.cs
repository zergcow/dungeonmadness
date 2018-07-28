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
            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_4W);
        }
        for (int y = minY; y <= maxY; y++)
        {
            Vector3Int findPos = new Vector3Int(minX - 1, y, 0);
            Vector3Int tilePos = new Vector3Int(minX, y, 0);
            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_4W);
        }
        
        for (int x = minX; x <= maxX; x++)
        {
            Vector3Int findPos = new Vector3Int(x, maxY + 1, 0);
            Vector3Int tilePos = new Vector3Int(x, maxY, 0);
            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_4W);
        }
        for (int x = minX; x <= maxX; x++)
        {
            Vector3Int findPos = new Vector3Int(x, minY - 1, 0);
            Vector3Int tilePos = new Vector3Int(x, minY, 0);
            Globals.SetNewWall(tileMap, tilePos, findPos, Globals.prefab_4W);
        }
        /*
        var neTile = ScriptableObject.CreateInstance<Tile>();
        neTile.gameObject = Globals.NECorner[Random.Range(0, Globals.NECorner.Length)];
        neTile.name = "northEastWall";
        tileMap.SetTile(new Vector3Int(maxX, maxY, 0), neTile);
        var nwTile = ScriptableObject.CreateInstance<Tile>();
        nwTile.gameObject = Globals.NWCorner[Random.Range(0, Globals.NWCorner.Length)];
        nwTile.name = "northWestWall";
        tileMap.SetTile(new Vector3Int(minX, maxY, 0), nwTile);
        var seTile = ScriptableObject.CreateInstance<Tile>();
        seTile.gameObject = Globals.SECorner[Random.Range(0, Globals.SECorner.Length)];
        seTile.name = "southEastWall";
        tileMap.SetTile(new Vector3Int(maxX, minY, 0), seTile);
        var swTile = ScriptableObject.CreateInstance<Tile>();
        swTile.gameObject = Globals.SWCorner[Random.Range(0, Globals.SWCorner.Length)];
        swTile.name = "southWestWall";
        tileMap.SetTile(new Vector3Int(minX, minY, 0), swTile);
        */
    }
}
