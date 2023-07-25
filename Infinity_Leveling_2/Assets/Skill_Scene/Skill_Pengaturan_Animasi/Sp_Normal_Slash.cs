using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Normal_Slash : MonoBehaviour {
    [SerializeField]
    bool b_Hit_Once = false;
    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 
    void OnTriggerEnter (Collider Col) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
            if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                if (Col.gameObject.tag == "Enemy") {
                    Debug.Log ("Damage");
                    // Col.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (_Skill_Pengaturan_Animasi,_Skill_Pengaturan_Animasi.Result_Damage ());
                    _Skill_Pengaturan_Animasi.On_Damage (Col.gameObject.tag, Col.gameObject, this.gameObject);
                    if(b_Hit_Once) {
                        Destroy (this.gameObject);
                    }

                }
            }
        } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            if (Col.gameObject.tag == "Player") {
                Debug.Log ("Damage");
                // Col.gameObject.GetComponent <Online_Player_2d> ().On_Damage (_Skill_Pengaturan_Animasi,_Skill_Pengaturan_Animasi.Result_Damage ());
                _Skill_Pengaturan_Animasi.On_Damage (Col.gameObject.tag, Col.gameObject, this.gameObject);
                if(b_Hit_Once) {
                    Destroy (this.gameObject);
                }
            }
        }
    }
}
