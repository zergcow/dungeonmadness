using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    class TileInfo
    {
        public Vector3Int LocalPlace { get; set; }

        public Vector3 WorldLocation { get; set; }

        public TileBase TileBase { get; set; }

        public Tilemap TilemapMember { get; set; }

        public BaseObjectData BaseObjectData { get; set; }

        public Vector3 Rotation { get; set; }

        public ResourceTypes ResourceType { get; set; }
    }
}
