using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsController : MonoBehaviour {

    public GameObject[] prefab_0T;
    public GameObject[] prefab_2CIC;
    public GameObject[] prefab_2FIC;
    public GameObject[] prefab_3IC;
    public GameObject[] prefab_4ACIC;
    public GameObject[] prefab_4CIC;
    public GameObject[] prefab_4W;
    public GameObject[] prefab_4WD;
    public GameObject[] prefab_5OC;
    public GameObject[] prefab_6CIC;
    public GameObject[] prefab_6COC;
    public GameObject[] prefab_6FOC;
    public GameObject[] prefab_8F;
    public GameObject[] prefab_8IC;
    public GameObject[] prefab_8ICS;
    public GameObject[] prefab_8S;
    void Awake()
    {
        Globals.prefab_0T = this.prefab_0T;
        Globals.prefab_2CIC = this.prefab_2CIC;
        Globals.prefab_2FIC = this.prefab_2FIC;
        Globals.prefab_3IC = this.prefab_3IC;
        Globals.prefab_4ACIC = this.prefab_4ACIC;
        Globals.prefab_4CIC = this.prefab_4CIC;
        Globals.prefab_4W = this.prefab_4W;
        Globals.prefab_4WD = this.prefab_4WD;
        Globals.prefab_5OC = this.prefab_5OC;
        Globals.prefab_6CIC = this.prefab_6CIC;
        Globals.prefab_6COC = this.prefab_6COC;
        Globals.prefab_6FOC = this.prefab_6FOC;
        Globals.prefab_8F = this.prefab_8F;
        Globals.prefab_8IC = this.prefab_8IC;
        Globals.prefab_8ICS = this.prefab_8ICS;
        Globals.prefab_8S = this.prefab_8S;
    }
}
