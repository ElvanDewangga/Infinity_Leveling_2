using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Area : MonoBehaviour {
    GameObject Player_Target;
    // Online_Tower_Infinity_Room :
    public void On_Input_Player_Target (GameObject x) {
        Player_Target = x;
    }

    void OnTriggerEnter (Collider Col) {
        if (Col.gameObject.tag == "Player") {
            if (Col.gameObject == Player_Target) {
                Col.gameObject.GetComponent <Online_Player_2d>().On_Spawn_Area ();
            }
        }
    }
}
