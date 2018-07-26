using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Scripts;

public class WallController : MonoBehaviour {

    private Tilemap tileMap;
    public Sprite dmgSprite;
    public int hp = 5;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        tileMap = gameObject.GetComponentInParent<Tilemap>();
        if (GameData.GameTiles.ContainsKey(transform.localPosition))
        {
            TileInfo curTile = GameData.GameTiles[transform.localPosition];
            

            Animator tileAni = gameObject.GetComponent<Animator>();
            tileAni.StartPlayback();
            tileAni.PlayInFixedTime(curTile.AnimatorName, 0, (float)curTile.ResourceType / (float)10);
            gameObject.transform.Rotate(GameData.RotationTypes[curTile.Rotation]);
        }
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

        }

    }

    private string CheckTileInDirection(int tilePosX, int tilePosY, int offsetX, int offsetY)
    {
        //prevent infinite loop
        if (offsetX > 1)
            return "";
        if (offsetY > 1)
            return "";
        if (offsetX < -1)
            return "";
        if (offsetY < -1)
            return "";

        return "";
    }


}
