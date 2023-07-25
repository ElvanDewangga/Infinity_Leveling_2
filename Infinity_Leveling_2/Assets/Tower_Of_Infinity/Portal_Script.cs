using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Script : MonoBehaviour {
    
    void OnTriggerEnter (Collider Col) {
        if (Col.gameObject.tag == "Player") {
            Online_Player_2d Op = Col.gameObject.GetComponent <Online_Player_2d>();
            if (Op._PhotonView == true) {
                Online_Tower_Infinity_Room.Ins.On_Rpc_GMP_Masuk_Field ();
            }
        }
    }
}
