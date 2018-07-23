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

        var floorTile = new Tile();
        floorTile.gameObject = floors[0];

        tileMap.SetTile(new Vector3Int(0, 0, 0), floorTile);
        tileMap.SetTile(new Vector3Int(1, 0, 0), floorTile);
        tileMap.SetTile(new Vector3Int(0, 1, 0), floorTile);
    }
}
