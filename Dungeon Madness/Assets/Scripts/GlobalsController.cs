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
    public GameObject[] northWestCorner;
    public GameObject[] southEastCorner;
    public GameObject[] southWestCorner;
    public GameObject[] northEastInverse;
    public GameObject[] northWestInverse;
    public GameObject[] southEastInverse;
    public GameObject[] southWestInverse;
    void Awake()
    {
        Globals.Floors = floors;
        Globals.EWalls = eastWalls;
        Globals.WWalls = westWalls;
        Globals.NWalls = northWalls;
        Globals.SWalls = southWalls;
        Globals.NECorner = northEastCorner;
        Globals.NWCorner = northWestCorner;
        Globals.SECorner = southEastCorner;
        Globals.SWCorner = southWestCorner;
        Globals.NEInverse = northEastInverse;
        Globals.NWInverse = northWestInverse;
        Globals.SEInverse = southEastInverse;
        Globals.SWInverse = southWestInverse;
    }
}
