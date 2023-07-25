using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sp_Slash_Continue : MonoBehaviour {
    [SerializeField]
    float Delay_Respawn_Damage = 0.0f;
   Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 
   List <GameObject> L_GameObject_Target = new List <GameObject>();
   void Start () {
    _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
    On_Give_Damage ();
   }
    void OnTriggerEnter (Collider Col) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
            if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                if (Col.gameObject.tag == "Enemy") {
                    if (!L_GameObject_Target.Contains (Col.gameObject)) {
                        L_GameObject_Target.Add (Col.gameObject);
                    }
                   // if (L_GameObject_Target.Count > 0) {
                     //   On_Give_Damage ();
                   // }
                }
            }
            
        } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            if (Col.gameObject.tag == "Player") {
                if (!L_GameObject_Target.Contains (Col.gameObject)) {
                    L_GameObject_Target.Add (Col.gameObject);
                }
               // if (L_GameObject_Target.Count > 0) {
                  // On_Give_Damage ();
               // }
            }

            
        }
        
    }

    void OnTriggerExit (Collider Col) {
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
            if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                if (Col.gameObject.tag == "Enemy") {
                    if (L_GameObject_Target.Contains (Col.gameObject)) {
                        L_GameObject_Target.Remove (Col.gameObject);
                    }
                 //   if (L_GameObject_Target.Count == 0) {
                 //       Off_Give_Damage ();
                  //  }
                }
            }
        } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            if (Col.gameObject.tag == "Player") {
                if (L_GameObject_Target.Contains (Col.gameObject)) {
                    L_GameObject_Target.Remove (Col.gameObject);
                }
              //  if (L_GameObject_Target.Count == 0) {
              //      Off_Give_Damage ();
              //  }
            }
            
        }
    }
    bool b_On_Give_Damage = false;
    Coroutine C_N_Give_Damage;
    void On_Give_Damage () {
        if (!b_On_Give_Damage) {
            b_On_Give_Damage = true;
            C_N_Give_Damage = StartCoroutine (N_Give_Damage ());
        }
    }

    void Off_Give_Damage () {
        if (b_On_Give_Damage) {
            StopCoroutine (C_N_Give_Damage);
            b_On_Give_Damage = false;
        }
    }
    GameObject Target_GO;
    IEnumerator N_Give_Damage () {
        if (!Target_GO) {
            if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
                Target_GO = _Skill_Pengaturan_Animasi.Target_Player_2d.gameObject;
            } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
                Target_GO = _Skill_Pengaturan_Animasi.Target_Enemy_2d.gameObject;
            }
        }
        yield return new WaitForSeconds (Delay_Respawn_Damage);
            // if (_Skill_Pengaturan_Animasi.On_Check_Ability_Self (Target_GO, _Skill_Pengaturan_Animasi.Serangan_From)) {
                _Skill_Pengaturan_Animasi.On_Continue_Ability_Self ();
                Debug.LogError ("Skill Dmaage");
                foreach (GameObject x in L_GameObject_Target) {
                    //try {
                        if (x) {
                            if (x.tag == "Player") {
                                
                                _Skill_Pengaturan_Animasi.On_Continue_Damage (x.gameObject.tag, x.gameObject, this.gameObject);
                            } else if (x.tag == "Enemy") {
                                _Skill_Pengaturan_Animasi.On_Continue_Damage (x.gameObject.tag, x.gameObject, this.gameObject);
                            }
                        }
                   // } catch (MissingReferenceException) {
                    //    Debug.LogError ("Skill Missing");
                   // }
                }
           // } else {
                // Turn off auto : Jika tidak memenuhi syarat (ANTARA PERLU ATAU TIDAK SOALNYA PAS DECREASE MP /HP AKAN ADA REFRESH JUGA ) INI DIBUAT UNTUK JIKA KONEKSI LAMBAT
             //   Tower_Infinity_Manager.Ins.On_Refresh_Syarat_Skill_Active ();
            //  }
        
        C_N_Give_Damage =StartCoroutine (N_Give_Damage ());
    }
}
