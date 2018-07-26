using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Scripts;

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

                newTile.gameObject = Globals.prefab_8F[Random.Range(0, Globals.prefab_8F.Length)];
                tileMap.SetTile(tilePos, newTile);
                var tileData = new TileInfo
                {
                    LocalPlace = tilePos,
                    WorldLocation = tileMap.CellToWorld(tilePos),
                    Rotation = new Vector3(0, 0, 0),
                    TileBase = newTile,
                    TilemapMember = tileMap,
                    ResourceType = ResourceTypes.Basic,
                    BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = "Floor" }
                    
                };
                if (GameData.GameTiles == null)
                {
                    GameData.GameTiles = new Dictionary<Vector3, TileInfo>();
                }
                if (GameData.GameTiles.ContainsKey(tilePos))
                {
                    GameData.GameTiles[tilePos] = tileData;
                }
                else
                {
                    GameData.GameTiles.Add(tilePos, tileData);
                }
            }
        }
        CreateWallsForRoom(roomWidth, roomHeight, maxX, maxY, minX, minY);
    }

    private void CreateWallsForRoom(int roomWidth, int roomHeight, int maxX, int maxY, int minX, int minY)
    {

        for (int y = minY; y <= maxY; y++)
        {
            var newTile = ScriptableObject.CreateInstance<Tile>();
            
            GameObject prefab = Globals.prefab_4W[Random.Range(0, Globals.prefab_4W.Length)];
            newTile.gameObject = prefab;
            Vector3Int tilePos = new Vector3Int(maxX, y, 0);
            tileMap.SetTile(tilePos, newTile);
            var tileData = new TileInfo
            {
                LocalPlace = tilePos,
                WorldLocation = tileMap.CellToWorld(tilePos),
                Rotation = new Vector3(0, 0, -45),
                TileBase = newTile,
                TilemapMember = tileMap,
                ResourceType = ResourceTypes.Iron,
                BaseObjectData = new BaseObjectData { Essence = new EssenceTypes[] { 0 }, EssenceAmount = 0, Name = "4W" }

            };
            if (GameData.GameTiles.ContainsKey(tilePos))
            {
                GameData.GameTiles[tilePos] = tileData;
            }
            else
            {
                GameData.GameTiles.Add(tilePos, tileData);
            }
        }
        /*
        for (int y = minY; y <= maxY; y++)
        {
            var westTile = ScriptableObject.CreateInstance<Tile>();
            westTile.gameObject = Globals.WWalls[Random.Range(0, Globals.WWalls.Length)];
            westTile.name = "westWall";
            tileMap.SetTile(new Vector3Int(minX, y, 0), westTile);
        }
        for (int x = minX; x <= maxX; x++)
        {
            var northTile = ScriptableObject.CreateInstance<Tile>();
            northTile.gameObject = Globals.NWalls[Random.Range(0, Globals.NWalls.Length)];
            northTile.name = "northWall";
            tileMap.SetTile(new Vector3Int(x, maxY, 0), northTile);
        }
        for (int x = minX; x <= maxX; x++)
        {
            var southTile = ScriptableObject.CreateInstance<Tile>();
            southTile.gameObject = Globals.SWalls[Random.Range(0, Globals.SWalls.Length)];
            southTile.name = "southWall";
            tileMap.SetTile(new Vector3Int(x, minY, 0), southTile);
        }

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
