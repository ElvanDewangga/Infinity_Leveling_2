using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Towards : MonoBehaviour {
    [SerializeField]
    bool b_Hit_Once = false;
    [SerializeField]
    int Max_Hit = 1;
    int Cur_Hit ;

    [SerializeField]
    Transform Towards;
    [SerializeField]
    float Spd;

    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 

    void Start () {
        Cur_Hit = Max_Hit;
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
    }
    void FixedUpdate () {
        transform.position = Vector3.MoveTowards (transform.position, Towards.position, Spd * Time.fixedDeltaTime);
    }

    void OnTriggerEnter (Collider Col) {
         _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        if (!_Skill_Pengaturan_Animasi.L_Collider_Enter_GO.Contains (Col.gameObject)) {
            if (_Skill_Pengaturan_Animasi.Serangan_From == "Player") {
                if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
                    if (Col.gameObject.tag == "Enemy") {
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
    }

}
