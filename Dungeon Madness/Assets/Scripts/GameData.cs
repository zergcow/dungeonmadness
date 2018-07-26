using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
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
    static class GameData
    {
        public static Dictionary<Vector3, TileInfo> GameTiles;

    }
}
