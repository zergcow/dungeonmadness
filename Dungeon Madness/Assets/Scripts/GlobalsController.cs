using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsController : MonoBehaviour {

    public GameObject[] floors;
    public GameObject[] eastWalls;
    public GameObject[] westWalls;
    public GameObject[] northWalls;
    public GameObject[] southWalls;
    public GameObject[] northEastCorner;
    public GameObject[] northwestCorner;
    public GameObject[] southEastCorner;
    public GameObject[] southWestCorner;

    void Awake()
    {
        Globals.Floors = floors;
        Globals.EWalls = eastWalls;
        Globals.WWalls = westWalls;
        Globals.NWalls = northWalls;
        Globals.SWalls = southWalls;
        Globals.NECorner = northEastCorner;
        Globals.NWCorner = northwestCorner;
        Globals.SECorner = southEastCorner;
        Globals.SWCorner = southWestCorner;
    }
}
