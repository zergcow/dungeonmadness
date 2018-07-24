using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallController : MonoBehaviour {

    private Tilemap tileMap;
    public Sprite dmgSprite;
    public int hp = 5;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
		
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
            var tilePosX = Mathf.RoundToInt(gameObject.transform.position.x);
            var tilePosY = Mathf.RoundToInt(gameObject.transform.position.y);
            var tilePos = new Vector3Int(tilePosX, tilePosY, 0);
            tileMap = gameObject.GetComponentInParent<Tilemap>();
            var floorTile = ScriptableObject.CreateInstance<Tile>();
            floorTile.gameObject = Globals.Floors[Random.Range(0, Globals.Floors.Length)];
            tileMap.SetTile(tilePos, floorTile);

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    CheckTileInDirection(tilePosX, tilePosY, x, y);
                }
            }
        }

    }

    private void CheckTileInDirection(int tilePosX, int tilePosY, int offsetX, int offsetY)
    {
        //prevent infinite loop
        if (offsetX > 1)
            return;
        if (offsetY > 1)
            return;
        if (offsetX < -1)
            return;
        if (offsetY < -1)
            return;

        var dirTileCur = tileMap.GetTile(new Vector3Int(tilePosX + offsetX, tilePosY + offsetY, 0));
        if (dirTileCur == null)
        {
            string newName = "";
            GameObject[] dirWalls = Globals.GetDirectionName(offsetX, offsetY, out newName);

            var newTile = ScriptableObject.CreateInstance<Tile>();
            newTile.gameObject = dirWalls[Random.Range(0, dirWalls.Length)];
            newTile.name = newName;
            tileMap.SetTile(new Vector3Int(tilePosX + offsetX, tilePosY + offsetY, 0), newTile);
        }
    }


}
