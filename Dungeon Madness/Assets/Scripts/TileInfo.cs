using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

    class TileInfo
    {
        public Vector3Int LocalPlace { get; set; }

        public Vector3 WorldLocation { get; set; }

        public TileBase TileBase { get; set; }

        public Tilemap TilemapMember { get; set; }

        public String AnimatorName { get; set; }

        public BaseObjectData BaseObjectData { get; set; }

        public RotationStrings Rotation { get; set; }

        public bool Flipped { get; set; }

        public WallTypes ResourceType { get; set; }
    }

