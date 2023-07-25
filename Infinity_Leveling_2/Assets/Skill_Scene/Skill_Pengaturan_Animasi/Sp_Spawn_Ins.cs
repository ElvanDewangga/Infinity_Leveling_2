using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Spawn_Ins : MonoBehaviour {

    string Serangan_From = "";
    
    #region Spawn_Area
    [SerializeField]
    bool b_Lock_Parent = false;
    [SerializeField]
    string Code_Spawn = "";
    /* Code_Spawn :
    1. "Transform_Posisi_Depan" = Player_2d - Posisi_Depan
    2. "Transform_Posisi_Belakang" = Player_2d - Posisi_Belakang
    3. "Player_2d_Posisi_Titik_Tengah" = Player_2d - Asset_2d_Titik_Tengah

    */
    Player_2d Target_Player_2d;
    Enemy_2d Target_Enemy_2d;
    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 
    int Ins_Target = 0;
    void Start () {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
    }
    // Sp_Area_Search_Enemy
    public void On_Spawn_GameObject (Player_2d Op, int Ins_V) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        Ins_Target = Ins_V;
        Serangan_From = "Player";
        Target_Player_2d = Op;
         On_Spawn_Area ();
    }

    public void On_Spawn_GameObject (Enemy_2d Op, int Ins_V) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        Ins_Target = Ins_V;
        Serangan_From = "Enemy";
        Target_Enemy_2d = Op;
        On_Spawn_Area ();
    }

    // Skill_Pengaturan_Animasi (Animasi Only) :
    public void On_Spawn_GameObject (GameObject Op, int Ins_V) {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        _Skill_Pengaturan_Animasi.gameObject.transform.position = new Vector3 (0,0,0);
        // _Skill_Pengaturan_Animasi.gameObject.transform.position = new Vector3 (0,0,0);
        Ins_Target = Ins_V;
        if (Op.tag == "Player") {
            Serangan_From = "Player";
            Target_Player_2d = Op.GetComponent <Player_2d> ();
        } else if (Op.tag == "Enemy") {
            Serangan_From = "Enemy";
            Target_Enemy_2d = Op.GetComponent <Enemy_2d> ();
        }
        
        On_Spawn_Area ();
    }

    GameObject Ins;
    void On_Spawn_Area () {
        Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.A_Particle_Samp[Ins_Target]);
       // Ins.gameObject.transform.SetParent (_Skill_Pengaturan_Animasi.gameObject.transform);
        if (Serangan_From == "Player") {
            if (Code_Spawn == "Transform_Posisi_Depan") {
               // if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Player_2d.Posisi_Depan);}
               Ins.gameObject.transform.SetParent (Target_Player_2d.Posisi_Depan);
                Ins.gameObject.transform.localPosition = Target_Player_2d.Posisi_Depan.localPosition + new Vector3 (0, 0.4f, 0);
            }
            else if (Code_Spawn == "Transform_Posisi_Depan_Tanah_1") {
                Ins.gameObject.transform.SetParent (Target_Player_2d.Transform_Posisi_Depan_Tanah_1);
               // if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Player_2d.Transform_Posisi_Depan_Tanah_1);}
                Ins.gameObject.transform.localPosition = Target_Player_2d.Transform_Posisi_Depan_Tanah_1.localPosition + new Vector3 (0, 0.4f, 0);
            }
             else if (Code_Spawn == "Transform_Posisi_Belakang") {
                Ins.gameObject.transform.SetParent (Target_Player_2d.Posisi_Belakang);
              //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Player_2d.Posisi_Belakang);}
                Ins.gameObject.transform.localPosition = Target_Player_2d.Posisi_Belakang.localPosition + new Vector3 (0, 0.4f, 0);
            } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
                Ins.gameObject.transform.SetParent (Target_Player_2d.Asset_2d_Titik_Tengah.transform);
               // if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Player_2d.transform);}
                Ins.gameObject.transform.localPosition = Target_Player_2d.Asset_2d_Titik_Tengah.transform.localPosition + new Vector3 (0, 0.4f, 0);
            }
        } else if (Serangan_From == "Enemy") {
            if (Code_Spawn == "Transform_Posisi_Depan") {
              //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Depan);}
              Ins.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Depan);
                Ins.gameObject.transform.localPosition = Target_Enemy_2d.Posisi_Depan.localPosition + new Vector3 (0, 0.4f, 0);
            }
            else if (Code_Spawn == "Transform_Posisi_Depan_Tanah_1") {
              //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1);}
              Ins.gameObject.transform.SetParent (Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1);
                Ins.gameObject.transform.localPosition = Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1.localPosition + new Vector3 (0, 0.4f, 0);
            }
             else if (Code_Spawn == "Transform_Posisi_Belakang") {
              //   if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Belakang);}
              Ins.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Belakang);
                Ins.gameObject.transform.localPosition = Target_Enemy_2d.Posisi_Belakang.localPosition + new Vector3 (0, 0.4f, 0);
            } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
               //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Asset_2d_Titik_Tengah.transform);}
               Ins.gameObject.transform.SetParent (Target_Enemy_2d.Asset_2d_Titik_Tengah.transform);
                Ins.gameObject.transform.localPosition = Target_Enemy_2d.Asset_2d_Titik_Tengah.transform.localPosition + new Vector3 (0, 0.4f, 0);
            }
        }
        Ins.gameObject.transform.SetParent (_Skill_Pengaturan_Animasi.gameObject.transform);
        if (b_Lock_Parent) {
            On_Lock_Parent ();
        }
        Ins.gameObject.SetActive (true);
        Ins.gameObject.name = "Particle_From_Sp_Spawn_Ins";
            if (_Skill_Pengaturan_Animasi.b_Sp_Normal_Effect) {
                if (Serangan_From == "Player") {
                    Ins.GetComponent <Sp_Normal_Effect> ().On_Input_Action (_Skill_Pengaturan_Animasi, Target_Player_2d.gameObject, Serangan_From);
                } else if (Serangan_From == "Enemy") {
                    Ins.GetComponent <Sp_Normal_Effect> ().On_Input_Action (_Skill_Pengaturan_Animasi, Target_Enemy_2d.gameObject, Serangan_From);
                }
            }
        
    }
        #region Lock_Parent
            void On_Lock_Parent () {
                if (Serangan_From == "Player") {
                    if (Code_Spawn == "Transform_Posisi_Depan") {
                        _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Player_2d.Posisi_Depan);
                    }
                    else if (Code_Spawn == "Transform_Posisi_Depan_Tanah_1") {
                        _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Player_2d.Transform_Posisi_Depan_Tanah_1);
                    }
                    else if (Code_Spawn == "Transform_Posisi_Belakang") {
                        _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Player_2d.Posisi_Belakang);
                    } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
                        _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Player_2d.Asset_2d_Titik_Tengah.transform);
                    }
                } else if (Serangan_From == "Enemy") {
                    if (Code_Spawn == "Transform_Posisi_Depan") {
                    //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Depan);}
                    _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Depan);
                    }
                    else if (Code_Spawn == "Transform_Posisi_Depan_Tanah_1") {
                    //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1);}
                    _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1);
                    }
                    else if (Code_Spawn == "Transform_Posisi_Belakang") {
                    //   if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Belakang);}
                    _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Belakang);
                    } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
                    //  if (b_Lock_Parent) {Ins.gameObject.transform.SetParent (Target_Enemy_2d.Asset_2d_Titik_Tengah.transform);}
                    _Skill_Pengaturan_Animasi.gameObject.transform.SetParent (Target_Enemy_2d.Asset_2d_Titik_Tengah.transform);
                    }
                }
            }
        #endregion
    #endregion
}
