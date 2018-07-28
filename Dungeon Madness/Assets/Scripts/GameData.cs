using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    enum EssenceTypes
    {
        None = 0,
        Earth = 1,
        Fire = 2,
        Water = 3,
        Air = 4,
        Light = 5,
        Dark = 6
    }
    enum WallTypes
    {
        PlaceHolder = 0,
        Copper = 1,
        Iron = 2,
        Wood = 3,
        Stone = 4,
        Marble = 5,
        Slate = 6,
        Goblin = 7,
        Spider = 8,
        Slime = 9,
        Acid = 10,
        Lava = 11,
        Cave = 12,
        Cliff = 13
    }
    enum RotationStrings
    {
        Base = 0,
        CounterClockwise =1,
        UpsideDown = 2,
        Clockwise = 3
        
    }
    static class GameData
    {
        public static Dictionary<RotationStrings, Vector3> RotationTypes = new Dictionary<RotationStrings, Vector3> {
            { RotationStrings.Base, new Vector3(0, 0, 0) },
            { RotationStrings.CounterClockwise, new Vector3(0, 0, -90) },
            { RotationStrings.UpsideDown, new Vector3(0, 0, 180) },
            { RotationStrings.Clockwise, new Vector3(0, 0, 90) }
        };
        public static Dictionary<Vector3Int, TileInfo> GameTiles;

        public static void AddGameTile(Vector3Int vector3, TileInfo tileInfo)
        {
            if (GameTiles == null)
            {
                GameTiles = new Dictionary<Vector3Int, TileInfo>();
            }
            if (GameTiles.ContainsKey(vector3))
            {
                GameTiles[vector3] = tileInfo;
            }
            else
            {
                GameTiles.Add(vector3, tileInfo);
            }
        }
    }

