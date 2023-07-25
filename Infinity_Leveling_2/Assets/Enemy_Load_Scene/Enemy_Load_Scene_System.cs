using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Load_Scene_System : MonoBehaviour {
    public static Enemy_Load_Scene_System Ins;
    void Awake () {
        Ins = this;
    }
    GameObject Result_Search_Square_Field;
    // Enemy_2d:
    public GameObject On_Search_Enemy (string v) {
        foreach (Transform x in this.transform) {
            Enemy_AI_Control Pusat_Script = x.GetComponent <Enemy_AI_Control>();
            if (Pusat_Script.Code_Name == v) {
                Result_Search_Square_Field = x.gameObject;
                break;
            }
        }
        return Result_Search_Square_Field;
    }
}
