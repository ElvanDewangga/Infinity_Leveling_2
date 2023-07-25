using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
using System;
public class Skill_Pengaturan_Animasi : MonoBehaviour {
    #region Play_Animasi
    public int Skill_Power;
    [Header ("Pengaturan Umum :")]
    public List <Skill_Class_Ability> L_Skill_Class_Ability;
    
    [Header ("Khusus Skill PLAYER saja yang input : ''Cleve'' / ''Sword_Universal_1''")]
    [SerializeField]
    string Animation_Parameter_Name = "";
    [SerializeField]
    bool b_Lock_Parent;
    // Sp_Normal_Slash :
    [HideInInspector]
    public Player_2d Target_Player_2d;
    [HideInInspector]
    public Enemy_2d Target_Enemy_2d;
    [HideInInspector]
    public string Serangan_From = ""; // "Player" / "Enemy"
    public C_Home_Status _C_Home_Status;
    Skill_Data_Kumpulan _Skill_Data_Kumpulan;
    [SerializeField]
    public string Code_Skill_Hit = "Global_Hit";

    #region Fallback
    // Fallback :
    [Header ("Pengaturan Fallback :")]
    public bool b_Pengaturan_Fallback = false;
    public float Fallback_Power, Max_Fallback_Power = 0.0f;

    #endregion
    // Skill_Data_Editor :
    // Code_Mine : Mine, Not_Mine. Not_Mine = animasi only.
    public string Code_Mine;
    public void On_Play_Animasi (Player_2d Target_Player_2d_V, Skill_Data_Kumpulan Sdk_V, string Code_Mine_V) {
        Code_Mine = Code_Mine_V;
        _Skill_Data_Kumpulan = Sdk_V;
        
       

        
        if (Code_Mine == "Mine") { // Untuk Player_2d + "Skill_" sesuai nama di animator.
            foreach (Skill_Class_Ability s in L_Skill_Class_Ability) {
                s.Title_Skill =  _Skill_Data_Kumpulan.Skill_Name;
            }

            Code_Skill_Name = _Skill_Data_Kumpulan.Skill_Name;
            Serangan_From = "Player";
            Target_Player_2d = Target_Player_2d_V;
            // L_Self_Ability
            L_Self_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability s in L_Skill_Class_Ability) {
                if (s._Skill_Target == Skill_Target.Self) {
                    L_Self_Ability.Add (s);
                }
            }

            L_Allies_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability s in L_Skill_Class_Ability) {
                if (s._Skill_Target == Skill_Target.Allies || s._Skill_Target == Skill_Target.Allies_Except_Self) {
                    L_Allies_Ability.Add (s);
                }
            }

            L_Enemies_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability s in L_Skill_Class_Ability) {
                if (s._Skill_Target == Skill_Target.Enemies) {
                    L_Enemies_Ability.Add (s);
                }
            }
            
            if(!_Sp_Slash_Continue) {
                On_Ability_Self ();
            }
            
            
            Lock_Move_And_Skill_Setting ();
            Target_Player_2d.On_b_Can_Move_With_Time ("Idle", Time_Countdown_Animation);
            _C_Home_Status = Target_Player_2d.gameObject.GetComponent <Online_Player_Status> ().GMP_C_Home_Status;
            Target_Player_2d.On_Character_Animation (Animation_Parameter_Name);
            Target_Player_2d.gameObject.GetComponent <Online_Player_2d>().On_Mine_Lc_Skill_Animation (_Skill_Data_Kumpulan.Skill_Name);
            On_Spawn_Area (); On_Flip ();
            
            this.gameObject.SetActive (true);
            StartCoroutine (N_On_Countdown_Animation ());
            StartCoroutine (N_On_Destroy ());
        } else if (Code_Mine == "Not_Mine") {
            
            // Hanya Sp_Slash_Continue yang membutuhkan ini supaya bisa perintah destroy saat player asli melepas tombol.
            Serangan_From = "Player";
            Target_Player_2d = Target_Player_2d_V;
            if (_Sp_Slash_Continue) {Target_Player_2d.gameObject.GetComponent <Online_Player_2d>().On_Inp_Cur_Slash_Skill_Pengaturan_Animasi(this);}
            On_Spawn_Area (); On_Flip ();
            this.gameObject.SetActive (true);
            if (b_Sp_Normal_Effect) {
             //   _Sp_Spawn_Ins.On_Spawn_GameObject (this.gameObject,0);
            }
            StartCoroutine (N_On_Destroy ());
        }
    }

    public void On_Play_Animasi (Enemy_2d Enemy_2d_V, Skill_Data_Kumpulan Sdk_V, string Code_Mine_V) {
        Code_Mine = Code_Mine_V;
        _Skill_Data_Kumpulan = Sdk_V;
        foreach (Skill_Class_Ability s in L_Skill_Class_Ability) {
            s.Title_Skill =  _Skill_Data_Kumpulan.Skill_Name;
        }
        if (Code_Mine == "Mine") {
            Code_Skill_Name = _Skill_Data_Kumpulan.Skill_Name;
            Serangan_From = "Enemy";
            Target_Enemy_2d = Enemy_2d_V;
                // L_Self_Ability
            L_Self_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability s in L_Self_Ability) {
                if (s._Skill_Target == Skill_Target.Self) {
                    L_Self_Ability.Add (s);
                }
            }

            L_Allies_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability s in L_Allies_Ability) {
                if (s._Skill_Target == Skill_Target.Allies || s._Skill_Target == Skill_Target.Allies_Except_Self) {
                    L_Allies_Ability.Add (s);
                }
            }

            L_Enemies_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability s in L_Enemies_Ability) {
                if (s._Skill_Target == Skill_Target.Enemies) {
                    L_Enemies_Ability.Add (s);
                }
            }
            if(!_Sp_Slash_Continue) {
            On_Ability_Self ();
            }
            
            
            Lock_Move_And_Skill_Setting ();
            Target_Enemy_2d.On_b_Can_Move_With_Time ("Idle", Time_Countdown_Animation);
            Target_Enemy_2d.On_Character_Animation ("Idle");
            Target_Enemy_2d.On_Character_Animation ("Skill_Active_" + Sdk_V.Urutan_Skill.ToString ());
            _C_Home_Status = Target_Enemy_2d.gameObject.GetComponent <Enemy_2d> ()._C_Home_Status;
            Target_Enemy_2d.gameObject.GetComponent <Enemy_2d_Online>().On_Mine_Lc_Skill_Animation (_Skill_Data_Kumpulan.Skill_Name);
            On_Spawn_Area (); On_Flip ();
            this.gameObject.SetActive (true);
            Debug.Log (_Skill_Data_Kumpulan.Skill_Name);
            Target_Enemy_2d._Enemy_AI_Control.On_Use_Skill ();
            StartCoroutine (N_On_Countdown_Animation ());
            StartCoroutine (N_On_Destroy ());
        } else if (Code_Mine == "Not_Mine") {
            // Hanya Sp_Slash_Continue yang membutuhkan ini supaya bisa perintah destroy saat player asli melepas tombol.
            
            Serangan_From = "Enemy";
            Target_Enemy_2d = Enemy_2d_V;
            if (_Sp_Slash_Continue) { Target_Enemy_2d.gameObject.GetComponent <Enemy_2d_Online>().On_Inp_Cur_Slash_Skill_Pengaturan_Animasi(this);}

           On_Spawn_Area (); On_Flip ();
            this.gameObject.SetActive (true);
            
            StartCoroutine (N_On_Destroy ());
        }
    }

    
    #endregion
    #region Spawn_Area
    [SerializeField]
    string Code_Spawn = "";
    /* Code_Spawn :
    1. "Transform_Posisi_Depan" = Player_2d - Posisi_Depan
    2. "Transform_Posisi_Belakang" = Player_2d - Posisi_Belakang
    3. "Player_2d_Posisi_Titik_Tengah" = Player_2d - Asset_2d_Titik_Tengah

    */
    void On_Spawn_Area () {
        
        if (Serangan_From == "Player") {
            if (Code_Spawn == "Transform_Posisi_Depan") {
                if (b_Lock_Parent) {this.gameObject.transform.SetParent (Target_Player_2d.Posisi_Depan);}
                this.gameObject.transform.position = Target_Player_2d.Posisi_Depan.position + new Vector3 (0, 0.4f, 0);
            }
            else if (Code_Spawn == "Transform_Posisi_Depan_Tanah_1") {
                if (b_Lock_Parent) {this.gameObject.transform.SetParent (Target_Player_2d.Transform_Posisi_Depan_Tanah_1);}
                this.gameObject.transform.position = Target_Player_2d.Transform_Posisi_Depan_Tanah_1.position + new Vector3 (0, 0.4f, 0);
            }
             else if (Code_Spawn == "Transform_Posisi_Belakang") {
                if (b_Lock_Parent) {this.gameObject.transform.SetParent (Target_Player_2d.Posisi_Belakang);}
                this.gameObject.transform.position = Target_Player_2d.Posisi_Belakang.position + new Vector3 (0, 0.4f, 0);
            } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
                if (b_Lock_Parent) {this.gameObject.transform.SetParent (Target_Player_2d.transform);}
                this.gameObject.transform.position = Target_Player_2d.Asset_2d_Titik_Tengah.transform.position + new Vector3 (0, 0.4f, 0);
            }
        } else if (Serangan_From == "Enemy") {
            if (Code_Spawn == "Transform_Posisi_Depan") {
                this.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Depan);
                this.gameObject.transform.localPosition = Target_Enemy_2d.Posisi_Depan.localPosition + new Vector3 (0, 0.4f, 0);
            }
            else if (Code_Spawn == "Transform_Posisi_Depan_Tanah_1") {
                if (b_Lock_Parent) {this.gameObject.transform.SetParent (Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1);}
                this.gameObject.transform.position = Target_Enemy_2d.Transform_Posisi_Depan_Tanah_1.position + new Vector3 (0, 0.4f, 0);
            }
             else if (Code_Spawn == "Transform_Posisi_Belakang") {
                 this.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Belakang);
                this.gameObject.transform.localPosition = Target_Enemy_2d.Posisi_Belakang.localPosition + new Vector3 (0, 0.4f, 0);
            } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
                 this.gameObject.transform.SetParent (Target_Enemy_2d.Asset_2d_Titik_Tengah.transform);
                this.gameObject.transform.localPosition = Target_Enemy_2d.Asset_2d_Titik_Tengah.transform.localPosition + new Vector3 (0, 0.4f, 0);
            }
        }
    }
    #endregion
    #region Flip
    
    void On_Flip () {
        if (Serangan_From == "Player") {
            if (Target_Player_2d.Cur_Flip =="Left") {
                this.gameObject.transform.localScale = new Vector3 (-1,1,1);
            } else if (Target_Player_2d.Cur_Flip =="Right") {
                this.gameObject.transform.localScale = new Vector3 (1,1,1);
            }

        } else if (Serangan_From == "Enemy") {
            if (Target_Enemy_2d.Cur_Flip =="Left") {
                this.gameObject.transform.localScale = new Vector3 (-1,1,1);
            } else if (Target_Enemy_2d.Cur_Flip =="Right") {
                this.gameObject.transform.localScale = new Vector3 (-1,1,1);
            }
        }
    }
    #endregion
    #region Destroy
    // GMP_Skill_Button - Skill_Data_Editor :
    public void On_Direct_Destroy () {
        try {
            if (Code_Mine == "Mine") {
                if (Serangan_From == "Player") {
                    Target_Player_2d.On_b_Can_Move_With_Time ("Idle", 0.0f);
                    Target_Player_2d.gameObject.GetComponent <Online_Player_2d> ().On_Mine_Destroy_Skill_Pengaturan_Animasi ();
                }
                else if (Serangan_From == "Enemy") {
                    Target_Enemy_2d.On_b_Can_Move_With_Time ("Idle", 0.0f);
                    Target_Enemy_2d.gameObject.GetComponent <Enemy_2d_Online> ().On_Mine_Destroy_Skill_Pengaturan_Animasi ();
                }
            }
            
            Destroy (this.gameObject);
        } catch (MissingReferenceException e) {

        }
            
       
    }
    [SerializeField]
    float Time_Destroy = 1.0f;
    IEnumerator N_On_Destroy () {
        // yield return new WaitForSeconds (Time_Countdown_Animation);
        yield return new WaitForSeconds (Time_Destroy);
        
        Destroy (this.gameObject);
    }
    #endregion
    #region Countdown_Animation 
    void Lock_Move_And_Skill_Setting () {
        if (Serangan_From == "Player") {
            Target_Player_2d.Off_b_Can_Skill ();
            if (_Sp_Slash_Continue) {
                Target_Player_2d.On_b_Can_Move ();
            } else {
                Target_Player_2d.Off_b_Can_Move ();
            }
        }
        else if (Serangan_From == "Enemy") {
            Target_Enemy_2d.Off_b_Can_Skill ();
            if (_Sp_Slash_Continue) {
                Target_Enemy_2d.On_b_Can_Move ();
            } else {
                Target_Enemy_2d.Off_b_Can_Move ();
            }
        }
    }
    [SerializeField]
    float Time_Countdown_Animation = 0.5f;
    IEnumerator N_On_Countdown_Animation () {
        yield return new WaitForSeconds (Time_Countdown_Animation);
        if (Serangan_From == "Player") {
      
        }
        else if (Serangan_From == "Enemy") {
          
            try {
                Target_Enemy_2d._Enemy_AI_Control.Off_Use_Skill ();
                Target_Enemy_2d._Enemy_AI_Control.On_Change_Enemy_AI_Movement ("Enemy_AI_Idle");
            } catch (MissingReferenceException e) {
                
            }
        }
    }
    #endregion
    [HideInInspector]
    // Sp_S
    public string Code_Skill_Name = "";
    #region A_Particle_Samp
    // Sp_Spawn_Ins
    public GameObject [] A_Particle_Samp;
    #endregion
    #region Sp_Normal_Slash
    [SerializeField]
    Sp_Normal_Slash _Sp_Normal_Slash;
    #endregion
    #region Sp_Range_Forward
    [SerializeField]
    Sp_Range_Forward _Sp_Range_Forward;
    #endregion
    #region Sp_Slash_Continue
    [SerializeField]
    Sp_Slash_Continue _Sp_Slash_Continue;
    #endregion
    #region Sp_Spawn_Ins
    // Sp_Area_Search_Enemy :
    public Sp_Spawn_Ins _Sp_Spawn_Ins;
    #endregion
    #region Sp_Area_Search_Enemy
    [SerializeField]
    Sp_Area_Search_Enemy _Sp_Area_Search_Enemy;
    #endregion
    #region Sp_Normal_Effect
    // Skill_Data_Editor :
    public bool b_Sp_Normal_Effect = false;
    public void Rpc_Sp_Normal_Effect_Animation (Player_2d P2_V, Skill_Data_Kumpulan Sdk_V, string Code_Mine_V) {
      // On_Spawn_Area (); On_Flip ();
      Code_Mine = Code_Mine_V;
        this.gameObject.SetActive (true);
        Serangan_From  = "Player";
            if (b_Sp_Normal_Effect) {
                _Sp_Spawn_Ins.On_Spawn_GameObject (P2_V.gameObject,0);
            }
            StartCoroutine (N_On_Destroy ());
    }
    // Skill_Data_Editor :
    public void Rpc_Sp_Normal_Effect_Animation (Enemy_2d Enemy_2d_V, Skill_Data_Kumpulan Sdk_V, string Code_Mine_V) {
       // On_Spawn_Area (); On_Flip ();
       Code_Mine = Code_Mine_V;
        this.gameObject.SetActive (true);
         Serangan_From  = "Enemy";
            if (b_Sp_Normal_Effect) {
                _Sp_Spawn_Ins.On_Spawn_GameObject (Enemy_2d_V.gameObject,0);
            }
            StartCoroutine (N_On_Destroy ());
    }
    #endregion
    #region Sp_Non_Towards
    [SerializeField]
    Sp_Non_Towards [] A_Sp_Non_Towards;
    // Sp_Range_Forward :
    public void On_Destroy_All_Sp_Non_Towards () {
        foreach (Sp_Non_Towards s in A_Sp_Non_Towards) {
            Destroy (s.gameObject);
        }
    }
    #endregion
    #region Skill_Class_Ability
        List <Skill_Class_Ability> L_Allies_Ability = new List <Skill_Class_Ability>(); 
        List <Skill_Class_Ability> L_Enemies_Ability = new List <Skill_Class_Ability>();
        List <Skill_Class_Ability> L_Self_Ability = new List <Skill_Class_Ability>();
        #region On_Self
        // Self : (This)
        void On_Ability_Self () {
            if (Serangan_From == "Player") {
                    if (L_Self_Ability.Count >0) {
                        Target_Player_2d.gameObject.GetComponent <Online_Player_2d> ().On_Give_Skill_Class_Ability (this, L_Self_Ability);
                    }
           } else if (Serangan_From == "Enemy") {
                    if (L_Self_Ability.Count >0) {
                        Target_Enemy_2d.gameObject.GetComponent <Enemy_2d_Online> ().On_Give_Skill_Class_Ability (this, L_Self_Ability);
                    }
           }
        }
        // Sp_Slash_Continue :

        public void On_Continue_Ability_Self () {
            On_Ability_Self ();
        }
        // GMP_Skill_Button / Sp_Slash_Continue :
        bool Result_Ability_Self = false;
        bool Keep_Check_Ability_Self = false;
        C_Home_Status _Self_GMP_C_Home_Status;
        C_Home_Status _Self_C_Home_Status;
        public bool On_Check_Ability_Self (GameObject s, string Sv) {
            if (Sv == "Player") {
                _Self_C_Home_Status = s.GetComponent <Online_Player_Status> ()._C_Home_Status;
                _Self_GMP_C_Home_Status = s.GetComponent <Online_Player_Status> ().GMP_C_Home_Status;
            } else if (Sv == "Enemy") {
                _Self_GMP_C_Home_Status = s.GetComponent <Enemy_2d> ()._C_Home_Status;
               // _Self_GMP_C_Home_Status = s.GetComponent <Enemy_2d> ()._C_Home_Status; ENEMY TIDAK MEMILIKI GMP_C_HOME_STATUS.
            }
            // L_Self_Ability
            Result_Ability_Self = false;
            Keep_Check_Ability_Self = true;
            L_Self_Ability = new List <Skill_Class_Ability>();
            foreach (Skill_Class_Ability tu in L_Skill_Class_Ability) {
                if (tu._Skill_Target == Skill_Target.Self) {
                    L_Self_Ability.Add (tu);
                }
            }

            int x = 0;
            for (x=0; x <L_Self_Ability.Count; x++) {
                if (Keep_Check_Ability_Self) {
                    int y = 0;
                    for (y=0; y <= L_Self_Ability[x].L_Class_Ability.Count; y++) {
                        if (Keep_Check_Ability_Self) {
                            if (y < L_Self_Ability[x].L_Class_Ability.Count) {
                                if (L_Self_Ability[x].L_Class_Ability[y]._Ability_Type == Ability_Type.Decrease_Hp_Percent) {
                                    if (_Self_GMP_C_Home_Status.Hp > ( (_Self_C_Home_Status.Hp * L_Self_Ability[x].L_Class_Ability[y].Value_Int_1/100) *-1)) { // * -1 karena mines harus diubah ke positif.

                                    } else {
                                        Keep_Check_Ability_Self = false;
                                        Result_Ability_Self = false;
                                        return Result_Ability_Self;
                                    }
                                   
                                    
                                } else if (L_Self_Ability[x].L_Class_Ability[y]._Ability_Type == Ability_Type.Decrease_Mp_Percent) {
                                    if (_Self_GMP_C_Home_Status.Mp >= ( (_Self_C_Home_Status.Mp * L_Self_Ability[x].L_Class_Ability[y].Value_Int_1/100) *-1)) {

                                    } else {
                                        Keep_Check_Ability_Self = false;
                                        Result_Ability_Self = false;
                                        return Result_Ability_Self;
                                    }
                                   
                                    
                                }
                            } else {
                                if (x == (L_Self_Ability.Count-1)) {
                                Result_Ability_Self = true;
                                return Result_Ability_Self;
                                }
                            }
                        } else {
                            Keep_Check_Ability_Self = false;
                            break;
                        }
                    }
                } else {
                    break;
                }
                
            }

            Result_Ability_Self = false;
            return Result_Ability_Self;
        }
        #endregion
        #region On_Allies
        public void On_Ability_Allies (string Enemy_From, GameObject s) {
           if (Enemy_From == "Player") {
                if (s) {
                    if (L_Allies_Ability.Count >0) {
                        s.gameObject.GetComponent <Online_Player_2d> ().On_Give_Skill_Class_Ability (this, L_Allies_Ability);
                    }
                }
           } else if (Enemy_From == "Enemy") {
                if (s) {
                    if (L_Allies_Ability.Count >0) {
                        s.gameObject.GetComponent <Enemy_2d_Online> ().On_Give_Skill_Class_Ability (this, L_Allies_Ability);
                    }
                }
           }
        }

        #endregion
        #region On_Enemies
        int Rs_Damage = 0;
        public void On_Ability_Enemies (string Enemy_From, GameObject s) {
           if (Enemy_From == "Player") {
                if (s) {
                    if (L_Enemies_Ability.Count >0) {
                        s.gameObject.GetComponent <Online_Player_2d> ().On_Give_Skill_Class_Ability (this, L_Enemies_Ability);
                    }
                }
           } else if (Enemy_From == "Enemy") {
                if (s) {
                    if (L_Enemies_Ability.Count >0) {
                        s.gameObject.GetComponent <Enemy_2d_Online> ().On_Give_Skill_Class_Ability (this, L_Enemies_Ability);
                    }
                }
           }
        }
        [HideInInspector]
        public List <GameObject> L_Collider_Enter_GO = new List <GameObject> ();

        public void On_Damage (string Enemy_From, GameObject s, GameObject From_Target) {
            if (!L_Collider_Enter_GO.Contains (s)) {
                L_Collider_Enter_GO.Add (s);
                if (Serangan_From == "Player") {
                    if (Enemy_From == "Player") {
                        s.gameObject.GetComponent <Online_Player_2d> ().On_Damage (this,this.Result_Damage ());
                        On_Ability_Allies (Enemy_From, s);
                    } else if (Enemy_From == "Enemy") {
                        Debug.LogError ("Skill Enemy Damage");
                        s.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (this,this.Result_Damage (), From_Target);
                        On_Ability_Enemies (Enemy_From, s);
                    }
                } else if (Serangan_From == "Enemy") {
                    if (Enemy_From == "Player") {
                        s.gameObject.GetComponent <Online_Player_2d> ().On_Damage (this,this.Result_Damage ());
                        On_Ability_Enemies (Enemy_From, s);
                    } else if (Enemy_From == "Enemy") {
                        s.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (this,this.Result_Damage (), From_Target);
                        On_Ability_Allies (Enemy_From, s);
                    }
                }
            }

        }

        // Sp_Slash_Continue :
        public void On_Continue_Damage (string Enemy_From, GameObject s, GameObject From_Target) {
            // if (!L_Collider_Enter_GO.Contains (s)) {
             //   L_Collider_Enter_GO.Add (s);
                if (Serangan_From == "Player") {
                    if (Enemy_From == "Player") {
                        s.gameObject.GetComponent <Online_Player_2d> ().On_Damage (this,this.Result_Damage ());
                        On_Ability_Allies (Enemy_From, s);
                    } else if (Enemy_From == "Enemy") {
                        Debug.LogError ("Skill Enemy Damage");
                        s.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (this,this.Result_Damage (), From_Target);
                        On_Ability_Enemies (Enemy_From, s);
                    }
                } else if (Serangan_From == "Enemy") {
                    if (Enemy_From == "Player") {
                        s.gameObject.GetComponent <Online_Player_2d> ().On_Damage (this,this.Result_Damage ());
                        On_Ability_Enemies (Enemy_From, s);
                    } else if (Enemy_From == "Enemy") {
                        s.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (this,this.Result_Damage (), From_Target);
                        On_Ability_Allies (Enemy_From, s);
                    }
                }
           // }

        }

        public int Result_Damage () {
            //  Col.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (_Skill_Pengaturan_Animasi,_Skill_Pengaturan_Animasi._C_Home_Status.Attack * Random.Range (70,100)/10 * _Skill_Pengaturan_Animasi.Skill_Power/100);
            Rs_Damage = 0;
            Rs_Damage = Skill_Power / 100 * _C_Home_Status.Attack;
            foreach (Skill_Class_Ability x in L_Skill_Class_Ability) {
                if (x._Skill_Target == Skill_Target.Enemies) {
                    foreach (Class_Ability u in x.L_Class_Ability) {
                        if (u._Ability_Type == Ability_Type.Increase_Damage_By_Cur_Hp_Percent) {
                            Rs_Damage +=   _C_Home_Status.Hp * u.Value_Int_1 /100;
                        }

                        if (u._Ability_Type == Ability_Type.Increase_Damage_By_Cur_Mp_Percent) {
                            Rs_Damage +=   _C_Home_Status.Hp * u.Value_Int_1 /100;
                        }

                        if (u._Ability_Type == Ability_Type.Increase_Damage_By_Attack_Percent) {
                            Rs_Damage +=   _C_Home_Status.Hp * u.Value_Int_1 /100;
                        }
                    }
                }
            }
            return Rs_Damage;
        }
        #endregion
        
    #endregion
}
