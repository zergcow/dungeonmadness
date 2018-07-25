using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
                var floorTile = ScriptableObject.CreateInstance<Tile>();
                floorTile.gameObject = Globals.prefab_8F[Random.Range(0, Globals.prefab_8F.Length)];
                floorTile.name = "floor";
                tileMap.SetTile(new Vector3Int(tileX, tileY, 0), floorTile);
            }
        }
        CreateWallsForRoom(roomWidth, roomHeight, maxX, maxY, minX, minY);
    }

    private void CreateWallsForRoom(int roomWidth, int roomHeight, int maxX, int maxY, int minX, int minY)
    {

        for (int y = minY; y <= maxY; y++)
        {
            var eastTile = ScriptableObject.CreateInstance<Tile>();
            GameObject prefab = Globals.prefab_4W[Random.Range(0, Globals.prefab_4W.Length)];
            //var sprite = prefab.GetComponent<SpriteRenderer>();
            //sprite.transform.localRotation = Quaternion.Euler(0, 90, 0);
            //sprite.flipX = true;
            eastTile.gameObject = prefab;
            eastTile.name = "east4W";
            tileMap.SetTile(new Vector3Int(maxX, y, 0), eastTile);
            //eastTile.transform.rotation = Quaternion.Euler(0, 90, 0);
            //tilemap = GetComponent<Tilemap>();
            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 0f), Vector3.forward * -90); 
            tileMap.SetTransformMatrix(new Vector3Int(maxX, y, 0), matrix);
        }
        for (int y = minY; y <= maxY; y++)
        {
            var westTile = ScriptableObject.CreateInstance<Tile>();
            
            GameObject prefab = Globals.prefab_4W[Random.Range(0, Globals.prefab_4W.Length)];
            //var sprite = prefab.GetComponent<SpriteRenderer>();
            //sprite.transform.localRotation = Quaternion.Euler(0, 90, 0);
            //sprite.flipX = true;
            westTile.gameObject = prefab;
            westTile.name = "west4W";
            tileMap.SetTile(new Vector3Int(minX, y, 0), westTile);
        }
        /*
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
