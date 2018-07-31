using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

static class Globals {

    public static GameObject prefab_0T;
    public static GameObject prefab_2CIC;
    public static GameObject prefab_2FIC;
    public static GameObject prefab_3IC;
    public static GameObject prefab_4ACIC;
    public static GameObject prefab_4CIC;
    public static GameObject prefab_4W;
    public static GameObject prefab_4WD;
    public static GameObject prefab_5OC;
    public static GameObject prefab_6CIC;
    public static GameObject prefab_6COC;
    public static GameObject prefab_6FOC;
    public static GameObject prefab_8F;
    public static GameObject prefab_8IC;
    public static GameObject prefab_8ICS;
    public static GameObject prefab_8S;

    public static int DetermineTileDirection(int fromX, int fromY, int x, int y)
    {
        RotationStrings ret = RotationStrings.Base;

        //Do Something to determine tile direction
        // X + 1 = EAST
        // Y + 1 = NORTH
        // X - 1 = WEST
        // Y - 1 = SOUTH

        int diffX = fromX - x;
        int diffY = fromY - y;

        if (diffX == 1)
        {
            ret = RotationStrings.Clockwise;
        }
        else if (diffX == -1)
        {
            ret = RotationStrings.CounterClockwise;
        }
        if (diffY == 1)
        {
            ret = RotationStrings.UpsideDown;
        }
        else if (diffY == -1)
        {
            ret = RotationStrings.Base;
        }
        return (int)ret;
    }
}
