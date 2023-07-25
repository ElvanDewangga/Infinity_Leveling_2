using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Start_Catch : MonoBehaviour {
    // Enemy_AI_Control :
    public bool b_Can_AI_Catch = false;
    
    void OnTriggerEnter (Collider Col) {
        if (Col.gameObject.tag == "Player") {
            b_Can_AI_Catch = true;
        }
    }
}
