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
            var tilePos = new Vector3Int(Mathf.RoundToInt(gameObject.transform.position.x), Mathf.RoundToInt(gameObject.transform.position.y), 0);
            var tileMap = gameObject.GetComponentInParent<Tilemap>();
            var floorTile = ScriptableObject.CreateInstance<Tile>();
            floorTile.gameObject = Globals.Floors[Random.Range(0, Globals.Floors.Length)];
            tileMap.SetTile(tilePos, floorTile);

        }
            
    }
}
