using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Syarat_AI_Collider_Check : MonoBehaviour {
    // AI sudah pasti "Enemy"
    Skill_Syarat_Keseluruhan_AI _Skill_Syarat_Keseluruhan_AI;
    List <GameObject> L_GameObject_In_Collider = new List <GameObject>();
    void OnTriggerEnter (Collider Col) {
        
        if (Col.gameObject.tag == "Player") {
            if (!L_GameObject_In_Collider.Contains (Col.gameObject)) {
                L_GameObject_In_Collider.Add (Col.gameObject);
                On_Ai_Sub_Syarat ();
            }
            
        }
        
    }

    void OnTriggerExit (Collider Col) {
        if (Col.gameObject.tag == "Player") {
            if (L_GameObject_In_Collider.Contains (Col.gameObject)) {
                L_GameObject_In_Collider.Remove (Col.gameObject);
                On_Ai_Sub_Syarat ();
            }
        }
        
    }

    #region AI_Sub_Syarat
    // --- Skill_Syarat_Keseluruhan_AI
    public bool b_Sub_Syarat = false;
    void On_Ai_Sub_Syarat () {
        _Skill_Syarat_Keseluruhan_AI = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Syarat_Keseluruhan_AI> ();
        // jika ada 1 Player maka syarat terpenuhi (Sementara) :
        if (L_GameObject_In_Collider.Count >0) {
            b_Sub_Syarat = true;
        } else {
            b_Sub_Syarat = false;
        }
        _Skill_Syarat_Keseluruhan_AI.On_Skill_Syarat_AI_Collider_Check ();
    }
    #endregion
}
