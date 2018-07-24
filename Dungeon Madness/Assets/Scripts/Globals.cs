using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Globals {

    public static GameObject[] Floors;
    public static GameObject[] EWalls;
    public static GameObject[] WWalls;
    public static GameObject[] NWalls;
    public static GameObject[] SWalls;
    public static GameObject[] NECorner;
    public static GameObject[] NWCorner;
    public static GameObject[] SECorner;
    public static GameObject[] SWCorner;
    public static GameObject[] NEInverse;
    public static GameObject[] NWInverse;
    public static GameObject[] SEInverse;
    public static GameObject[] SWInverse;
    public static GameObject[] GetDirectionName(int offsetX, int offsetY, out string tileName)
    {
        tileName = "";
        if (offsetX == -1)
        {
            if (offsetY == 0)
            {
                tileName = "westWall";
                return WWalls;
            }
            else if (offsetY == 1)
            {
                tileName = "northWestWall";
                return NWCorner;
            }
            else if (offsetX == -1)
            {
                tileName = "southWestWall";
                return SWCorner;
            }
        }
        else if (offsetX == 1)
        {
            if (offsetY == 0)
            {
                tileName = "eastWall";
                return EWalls;
            }
            else if (offsetY == 1)
            {
                tileName = "northEastWall";
                return NECorner;
            }
            else if (offsetY == -1)
            {
                tileName = "southEastWall";
                return SECorner;
            }
        }
        else if (offsetX == 0)
        {
            if (offsetY == 0)
            {
                tileName = "floor";
                return Floors;
            }
            else if (offsetY == 1)
            {
                tileName = "northWall";
                return NWalls;
            }
            else if (offsetY == -1)
            {
                tileName = "southWall";
                return SWalls;
            }
        }

        return null;
    }
}
