using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallController : MonoBehaviour {

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
            var tileMap = gameObject.GetComponentInParent<Tilemap>();
            var floorTile = ScriptableObject.CreateInstance<Tile>();
            floorTile.gameObject = Globals.Floors[Random.Range(0, Globals.Floors.Length)];
            tileMap.SetTile(tilePos, floorTile);

            var westTileCur = tileMap.GetTile(new Vector3Int(tilePosX - 1, tilePosY, 0));
            if (westTileCur == null)
            {

            }
            else if (westTileCur.name != "floor")
            {

            }
            var eastTileCur = tileMap.GetTile(new Vector3Int(tilePosX + 1, tilePosY, 0));
            if (eastTileCur == null)
            {

                var eastTile = ScriptableObject.CreateInstance<Tile>();
                eastTile.gameObject = Globals.EWalls[Random.Range(0, Globals.EWalls.Length)];
                tileMap.SetTile(new Vector3Int(tilePosX + 1, tilePosY, 0), eastTile);
            }
            else if (eastTileCur.name != "floor")
            {
                
            }
            var southTileCur = tileMap.GetTile(new Vector3Int(tilePosX, tilePosY - 1, 0));

            var northTileCur = tileMap.GetTile(new Vector3Int(tilePosX, tilePosY + 1, 0));

        }

    }
}
