using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Range_Forward : MonoBehaviour {
    [SerializeField]
    bool b_Hit_Once = false;
    [SerializeField]
    int Max_Hit = 3;
    int Cur_Hit ;
    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 
    void Start () {
        Cur_Hit = Max_Hit;
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        if (b_Use_Skill_Movement) {
            On_Skill_Movement ();
        }
    }
    void FixedUpdate () {
        if (b_Active_Skill_Movement) {
            if (Code_Mov =="Left") {
                this.gameObject.transform.position -= new Vector3 (Speed_Movement/10,0,0);
            } else if (Code_Mov =="Right") {
                this.gameObject.transform.position += new Vector3 (Speed_Movement/10,0,0);
            }
            /*
            if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
                if (Code_Mov =="Left") {
                    this.gameObject.transform.position -= new Vector3 (Speed_Movement/10,0,0);
                } else if (Code_Mov =="Right") {
                    this.gameObject.transform.position += new Vector3 (Speed_Movement/10,0,0);
                }
            }
            else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
                if (Code_Mov =="Left") {
                    this.gameObject.transform.position -= new Vector3 (Speed_Movement/10,0,0);
                } else if (Code_Mov =="Right") {
                    this.gameObject.transform.position += new Vector3 (Speed_Movement/10,0,0);
                }
            }
            */
        }

        if (b_Movement_Updown) {
            this.gameObject.transform.position += new Vector3 (0,0,Speed_Updown/100);
        }
    }

    void OnTriggerEnter (Collider Col) {
         _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
            if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                if (Col.gameObject.tag == "Enemy") {
                    _Skill_Pengaturan_Animasi.On_Damage (Col.gameObject.tag, Col.gameObject, this.gameObject);
                    if(b_Hit_Once) {
                        if (Cur_Hit > 0) {
                            Cur_Hit--;
                        } else {
                            _Skill_Pengaturan_Animasi.On_Destroy_All_Sp_Non_Towards ();
                            Destroy (this.gameObject);
                        }
                        
                    }
                }
            }
        } else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            
            if (Col.gameObject.tag == "Player") {
                _Skill_Pengaturan_Animasi.On_Damage (Col.gameObject.tag, Col.gameObject, this.gameObject);
                if(b_Hit_Once) {
                    if (Cur_Hit > 0) {
                        Cur_Hit--;
                    } else {
                        Destroy (this.gameObject);
                    }
                }
            }
        }
    }

    #region Skill_Movement
    [SerializeField]
    bool b_Use_Skill_Movement = false;
    [SerializeField]
    float Speed_Movement = 5.0f;
    [SerializeField]
    bool b_Active_Skill_Movement = false;
    string Code_Mov = "Left";
    void On_Skill_Movement () {
        if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
           Code_Mov = _Skill_Pengaturan_Animasi.Target_Player_2d.Cur_Flip;
        }
        else if (_Skill_Pengaturan_Animasi.Serangan_From == "Enemy") {
            Code_Mov = _Skill_Pengaturan_Animasi.Target_Enemy_2d.Cur_Flip;
        }
        b_Active_Skill_Movement = true;
        // melepas transform parent supaya tidak bergerak saat ditembak :
        _Skill_Pengaturan_Animasi.gameObject.transform.parent = null;
    }

    [SerializeField]
    bool b_Movement_Updown = false;
    [SerializeField]
    float Speed_Updown = 0.0f;
    #endregion
}
