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

	// Use this for initialization
	void Start () {
        var tileMap = GetComponent<Tilemap>();

        int roomHeight = 6;
        int roomWidth = 8;
        int offsetX = -3;
        int offsetY = -3;
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
        var rightTile = ScriptableObject.CreateInstance<Tile>();
        rightTile.gameObject = rightWalls[Random.Range(0, rightWalls.Length)];

        
    }
}
