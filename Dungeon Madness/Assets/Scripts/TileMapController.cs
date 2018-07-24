using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour {

    public GameObject[] floors;
    public GameObject[] rightWalls;
    public GameObject[] leftWalls;
    public GameObject[] topWalls;
    public GameObject[] bottomWalls;
    public GameObject[] neCorner;
    public GameObject[] nwCorner;
    public GameObject[] seCorner;
    public GameObject[] swCorner;
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
                floorTile.gameObject = floors[Random.Range(0, floors.Length)];
                tileMap.SetTile(new Vector3Int(tileX, tileY, 0), floorTile);
            }
        }
        CreateWallsForRoom(roomWidth, roomHeight, maxX, maxY, minX, minY);
    }

    private void CreateWallsForRoom(int roomWidth, int roomHeight, int maxX, int maxY, int minX, int minY)
    {

        for (int y = minY; y <= maxY; y++)
        {
            var rightTile = ScriptableObject.CreateInstance<Tile>();
            rightTile.gameObject = rightWalls[Random.Range(0, rightWalls.Length)];
            tileMap.SetTile(new Vector3Int(maxX, y, 0), rightTile);
        }
        for (int y = minY; y <= maxY; y++)
        {
            var leftTile = ScriptableObject.CreateInstance<Tile>();
            leftTile.gameObject = leftWalls[Random.Range(0, leftWalls.Length)];
            tileMap.SetTile(new Vector3Int(minX, y, 0), leftTile);
        }
        for (int x = minX; x <= maxX; x++)
        {
            var topTile = ScriptableObject.CreateInstance<Tile>();
            topTile.gameObject = topWalls[Random.Range(0, topWalls.Length)];
            tileMap.SetTile(new Vector3Int(x, maxY, 0), topTile);
        }
        for (int x = minX; x <= maxX; x++)
        {
            var botTile = ScriptableObject.CreateInstance<Tile>();
            botTile.gameObject = bottomWalls[Random.Range(0, bottomWalls.Length)];
            tileMap.SetTile(new Vector3Int(x, minY, 0), botTile);
        }

        var neTile = ScriptableObject.CreateInstance<Tile>();
        neTile.gameObject = neCorner[Random.Range(0, neCorner.Length)];
        tileMap.SetTile(new Vector3Int(maxX, maxY, 0), neTile);
        var nwTile = ScriptableObject.CreateInstance<Tile>();
        nwTile.gameObject = nwCorner[Random.Range(0, nwCorner.Length)];
        tileMap.SetTile(new Vector3Int(minX, maxY, 0), nwTile);
        var seTile = ScriptableObject.CreateInstance<Tile>();
        seTile.gameObject = seCorner[Random.Range(0, seCorner.Length)];
        tileMap.SetTile(new Vector3Int(maxX, minY, 0), seTile);
        var swTile = ScriptableObject.CreateInstance<Tile>();
        swTile.gameObject = swCorner[Random.Range(0, swCorner.Length)];
        tileMap.SetTile(new Vector3Int(minX, minY, 0), swTile);

    }
}
