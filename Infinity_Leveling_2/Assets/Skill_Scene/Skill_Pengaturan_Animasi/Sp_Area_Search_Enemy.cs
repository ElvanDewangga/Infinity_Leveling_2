using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Sp_Area_Search_Enemy : MonoBehaviour {
     [SerializeField]
    float Delay_Respawn_Time = 0.0f;
    public Skill_Target _Skill_Target;
    #region Random_Target
    
    [SerializeField]
    string Target_Object_Cd = "";
    [SerializeField]
    bool b_Random_Target = false;
    [Header("Max 100 Percent")]
    [SerializeField]
    int Random_Target_Accuracy = 0;
    [SerializeField]
    int Random_Max_Target = 0;
    int Random_Cur_Target = 0;
    #endregion
   Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 
   List <GameObject> L_GameObject_Target = new List <GameObject>();

   void Start () {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        On_Ins_Sample ();
   }

    void OnTriggerEnter (Collider Col) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
            if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                if (_Skill_Target == Skill_Target.Allies) {
                    if (Col.gameObject.tag == "Player") {
                        if (!L_GameObject_Target.Contains (Col.gameObject)) {
                            L_GameObject_Target.Add (Col.gameObject);
                        }
                    }
                } else if (_Skill_Target == Skill_Target.Enemies) {
                    if (Col.gameObject.tag == "Enemy") {
                        if (!L_GameObject_Target.Contains (Col.gameObject)) {
                            L_GameObject_Target.Add (Col.gameObject);
                        }
                    }
                } else if (_Skill_Target == Skill_Target.Self) {
                    if (Col.gameObject.tag == "Player") {
                        if (_Skill_Pengaturan_Animasi.Target_Player_2d.gameObject == Col.gameObject) {
                            if (!L_GameObject_Target.Contains (_Skill_Pengaturan_Animasi.gameObject)) {
                                L_GameObject_Target.Add (Col.gameObject);
                            }
                        }
                    }
                } else if (_Skill_Target == Skill_Target.Allies_Except_Self) {
                    if (Col.gameObject.tag == "Player") {
                        if (_Skill_Pengaturan_Animasi.Target_Player_2d.gameObject != Col.gameObject) {
                            if (!L_GameObject_Target.Contains (_Skill_Pengaturan_Animasi.gameObject)) {
                                L_GameObject_Target.Add (Col.gameObject);
                            }
                        }
                    }
                }
            }
            
        } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            if (_Skill_Target == Skill_Target.Allies) {
                    if (Col.gameObject.tag == "Enemy") {
                        if (!L_GameObject_Target.Contains (Col.gameObject)) {
                            L_GameObject_Target.Add (Col.gameObject);
                        }
                    }
            } else if (_Skill_Target == Skill_Target.Enemies) {
                    if (Col.gameObject.tag == "Player") {
                        if (!L_GameObject_Target.Contains (Col.gameObject)) {
                            L_GameObject_Target.Add (Col.gameObject);
                        }
                    }
            } else if (_Skill_Target == Skill_Target.Self) {
                    if (Col.gameObject.tag == "Enemy") {
                        if (_Skill_Pengaturan_Animasi.Target_Enemy_2d.gameObject == Col.gameObject) {
                            if (!L_GameObject_Target.Contains (Col.gameObject)) {
                                L_GameObject_Target.Add (Col.gameObject);
                            }
                        }
                    }
            } else if (_Skill_Target == Skill_Target.Allies_Except_Self) {
                    if (Col.gameObject.tag == "Enemy") {
                        if (_Skill_Pengaturan_Animasi.Target_Enemy_2d.gameObject != Col.gameObject) {
                            if (!L_GameObject_Target.Contains (Col.gameObject)) {
                                L_GameObject_Target.Add (Col.gameObject);
                            }
                        }
                    }
            }
            
        }
        
    }

    void OnTriggerExit (Collider Col) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
            if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                /*
                if (Col.gameObject.tag == "Enemy") {
                    Debug.Log ("Remove");
                    if (L_GameObject_Target.Contains (Col.gameObject)) {
                        L_GameObject_Target.Remove (Col.gameObject);
                    }
                }
                */
            }
        } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            /*
            if (Col.gameObject.tag == "Player") {
                if (L_GameObject_Target.Contains (Col.gameObject)) {
                    L_GameObject_Target.Remove (Col.gameObject);
                }
            }
            */
        }
    }
    
    void On_Ins_Sample () {
        if (b_Random_Target) {
            StartCoroutine (N_Random_Target_On_Ins_Sample ());
        }
    }

    bool Result_Target = false;
    IEnumerator N_Random_Target_On_Ins_Sample () {
        yield return new WaitForSeconds (Delay_Respawn_Time);
        foreach (GameObject x in L_GameObject_Target) {
            if (Random_Cur_Target < Random_Max_Target) {
                Result_Target = false;
                int Result = Random.Range (0,100);
                if (Result < Random_Target_Accuracy) {
                    Result_Target = true;
                } else {
                    Result_Target =false;
                }

                try {
                    if (Result_Target) {
                        Random_Cur_Target ++;
                        if (x.tag == "Player") {
                            _Skill_Pengaturan_Animasi._Sp_Spawn_Ins.On_Spawn_GameObject (x.GetComponent<Player_2d>(),0);
                        //  x.GetComponent <Online_Player_2d> ().On_Damage (_Skill_Pengaturan_Animasi,_Skill_Pengaturan_Animasi._C_Home_Status.Attack * Random.Range (70,100)/10 * _Skill_Pengaturan_Animasi.Skill_Power/100);
                        } else if (x.tag == "Enemy") {
                            _Skill_Pengaturan_Animasi._Sp_Spawn_Ins.On_Spawn_GameObject (x.GetComponent<Enemy_2d>(),0);
                        //  x.GetComponent <Enemy_2d_Online> ().On_Damage (_Skill_Pengaturan_Animasi,_Skill_Pengaturan_Animasi._C_Home_Status.Attack * Random.Range (70,100)/10 * _Skill_Pengaturan_Animasi.Skill_Power/100);
                        }
                    }
                } catch (MissingReferenceException) {
                    
                }
            }
        }
    }
}
