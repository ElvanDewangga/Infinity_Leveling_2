using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Starsky;
public class Enemy_2d_Online : MonoBehaviourPunCallbacks,IPunObservable {
    #region Enemy_2d
    // GMP_Map_Settings :
    public int Enemy_Id;
    public string Enemy_Code_Jenis;
    public void MC_Send_Id_Enemy (int Id, string Code_Jenis_V) {
        Enemy_Id = Id; Enemy_Code_Jenis = Code_Jenis_V;
        _PhotonView.RPC ("Rpc_Send_Id_Enemy", RpcTarget.All, Enemy_Id, Enemy_Code_Jenis);
    }

    [PunRPC]
    public void Rpc_Send_Id_Enemy (int Id, string Code_Jenis_V) {
        Enemy_Id = Id; Enemy_Code_Jenis = Code_Jenis_V;
        _Enemy_2d.On_Got_C_Byte_Enemy_Id (Enemy_Id, Enemy_Code_Jenis);
    }
    #endregion
    #region Ability
        #region Damage
        public int Cur_Damage;
        int Def_Damage;
        bool b_Critical;
        
        // Sp_Normal_Slash :
        public void On_Damage (Skill_Pengaturan_Animasi Sp, int Damage, GameObject From_Target) {
            if (Sp.b_Pengaturan_Fallback) {
            _Enemy_2d.On_Fallback (From_Target.transform.position, Sp.Max_Fallback_Power ,Sp.Fallback_Power, 0.0f ); 
            }  
            // Defense :
                Def_Damage = Damage - (_Enemy_2d._C_Home_Status.Defense * Random.Range (150,300) /100);
                Cur_Damage = Def_Damage * -1;
                if (Cur_Damage > 0) {
                    Cur_Damage = 0;
                }
            // Incoming_Damage_Percent :
            Cur_Damage += Cur_Damage * _Enemy_2d.Incoming_Damage_Percent /100;
            if (_Enemy_2d.Immunity_Point >0) {
                Cur_Damage = 0;
            }
            
            // Critical :
            b_Critical = false;
                int R_Critical = Random.Range (0,1000);
                int Damage_Critical_Rate = Sp._C_Home_Status.Critical_Rate;

                if (R_Critical < Damage_Critical_Rate) {
                    b_Critical = true;
                    Cur_Damage = Cur_Damage + (Cur_Damage * Sp._C_Home_Status.Critical_Damage/100) ;  
                }


            _Enemy_2d._C_Home_Status.Hp += Cur_Damage;
            if (_Enemy_2d._C_Home_Status.Hp > _Enemy_2d.Max_Hp) {_Enemy_2d._C_Home_Status.Hp = _Enemy_2d.Max_Hp;}
            _PhotonView.RPC ("Rpc_Send_Damage_Player", RpcTarget.All, _Enemy_2d._C_Home_Status.Hp, Sp.Code_Skill_Hit, Cur_Damage, b_Critical);
            
        }

        [PunRPC]
        public void Rpc_Send_Damage_Player (int Cur_Hp_V, string Code_Skill_Hit, int Damage, bool Critical_V) {
           // Cur_Hp = Cur_Hp_V;
            // if (Damage != 0) {
                _Enemy_2d.On_Change_Cur_Hp (_PhotonView.IsMine, Cur_Hp_V, Code_Skill_Hit);

                GameObject Ins = GameObject.Instantiate (Tower_Infinity_Manager.Ins.Hit_Bubble_Samp);
                Ins.transform.SetParent (Tower_Infinity_Manager.Ins.All_Tower_Infinity_Go.transform);
                Ins.transform.position = this.transform.position + new Vector3 (0, 0.4f, 0);
                Ins.GetComponent <Hit_Bubble> ().On_Hit_Bubble (Critical_V, Damage);
            //   Damage = 0;

        // }
        }
        #endregion
        #region Heal_Direct
        int Cur_Heal_Direct;
        // Sp_Normal_Slash :
        public void On_Heal_Direct (int Heal_V) {
            if(_PhotonView.IsMine) {
                Cur_Heal_Direct = Heal_V;

                _Enemy_2d._C_Home_Status.Hp += Cur_Heal_Direct;
                if (_Enemy_2d._C_Home_Status.Hp > _Enemy_2d._C_Home_Status.Hp) {_Enemy_2d._C_Home_Status.Hp = _Enemy_2d._C_Home_Status.Hp;}
                _PhotonView.RPC ("Rpc_Refresh_Health", RpcTarget.All, _Enemy_2d._C_Home_Status.Hp);
            }
        }

        [PunRPC]
        public void Rpc_Refresh_Health (int Cur_Hp_V) {
            _Enemy_2d.On_Change_Cur_Hp (_PhotonView.IsMine, Cur_Hp_V, "");
        }
        #endregion
         #region Change_Status
        int Cur_Change_Status;
        // Sp_Normal_Slash / Onnline_Player_Status:
       // public void On_Heal_Mp (Skill_Pengaturan_Animasi Sp, int Heal_V) {
        // Value Status boleh min jika ada penurunan.
         public void On_Change_Status (string Code_Status, int Value_Status) { //Code_Status : Seperti DI C_Hom_Status "Mp", "Attack", dll.
            /* NOTE UNTUK MENCEGAH KEPANGGIL 1x TIAP PLAYER :
                JADI HANYA TIME ISMINE YANG BISA MENGHILANGKAN EFEK (PLAYER / ENEMY_2D)
            */
            if(_PhotonView.IsMine) {
                if (Code_Status == "Mp") {Cur_Change_Status = _Enemy_2d._C_Home_Status.Mp;}
                else if (Code_Status == "Attack") {Cur_Change_Status = _Enemy_2d._C_Home_Status.Attack;}
                else if (Code_Status == "Incoming_Damage_Percent") {Cur_Change_Status = _Enemy_2d.Incoming_Damage_Percent;}
                else if (Code_Status == "Defense") {Cur_Change_Status = _Enemy_2d._C_Home_Status.Defense;}
                else if (Code_Status == "Stun") {Cur_Change_Status = _Enemy_2d.Stun_Point;}
                else if (Code_Status == "Critical_Rate") {Cur_Change_Status = _Enemy_2d._C_Home_Status.Critical_Rate;}
                else if (Code_Status == "Critical_Damage") {Cur_Change_Status = _Enemy_2d._C_Home_Status.Critical_Damage;}
                else if (Code_Status == "Immunity") {Cur_Change_Status = _Enemy_2d.Immunity_Point;}

                Cur_Change_Status += Value_Status;
                if (Code_Status == "Mp") {
                    if (Cur_Change_Status > _Enemy_2d.Max_Mp) {Cur_Change_Status = _Enemy_2d.Max_Mp;}
                } else {

                }
                _PhotonView.RPC ("Rpc_Refresh_Status", RpcTarget.All, Code_Status, Cur_Change_Status);
            } else {
                Debug.LogError ("Status dont apply because not mine.");
            }
        }

        [PunRPC]
        public void Rpc_Refresh_Status (string Code_Status, int Value_Status) {
            _Enemy_2d.On_Change_Status (Code_Status, Value_Status);
        }
        #endregion
        #region Skill_Class_Ability
        List <Skill_Class_Ability> L_Skill_Class_Ability = new List <Skill_Class_Ability>();
        [SerializeField]
        List <Skill_Class_Ability> L_Transfer_Skill_Class_Ability;
        // Skill_Pengaturan_Animasi :
        public void On_Give_Skill_Class_Ability (Skill_Pengaturan_Animasi s, List <Skill_Class_Ability> L_Skill_Class_Ability_V) {
            L_Skill_Class_Ability = new List <Skill_Class_Ability>();
            L_Skill_Class_Ability = L_Skill_Class_Ability_V;
            int Id = -1;
            foreach (Skill_Class_Ability suan in L_Skill_Class_Ability) {
                Id ++;
                 // Rpc_Add_Skill_Class_Ability (s.Id, s.Title_Skill, s.Conv_Skill_Target_To_String(s._Skill_Target));
                _PhotonView.RPC ("Rpc_Add_Skill_Class_Ability", RpcTarget.All, 0, Id, suan.Title_Skill, suan.Conv_Skill_Target_To_String(suan._Skill_Target));
                
            }
        }

        [PunRPC]
        public void Rpc_Add_Skill_Class_Ability (int Your_Players_V, int Id, string Title_V, string Skill_Target_V) {
            if (Id == 0) { L_Transfer_Skill_Class_Ability = new List <Skill_Class_Ability> ();}
            // if (Your_Players != Your_Players_V) {L_Skill_Class_Ability = new List <Skill_Class_Ability>();}
             if (!_PhotonView.IsMine) {L_Skill_Class_Ability = new List <Skill_Class_Ability>();}

            Skill_Class_Ability Sc = new Skill_Class_Ability ();
            Sc.Your_Players_Id = Your_Players_V;
            Sc.Id = Id;
            Sc.Title_Skill = Title_V;
            Sc._Skill_Target = Sc.Conv_String_To_Skill_Target(Skill_Target_V);
            L_Transfer_Skill_Class_Ability.Add (Sc);
            /*
            foreach (Class_Ability cz in s.L_Class_Ability) {
                    
            }
            */
            if (_PhotonView.IsMine) {
                if (L_Skill_Class_Ability.Count > 0) {
                    int z= 0;
                    for (z=0; z <= L_Skill_Class_Ability[Id].L_Class_Ability.Count; z++ ) {
                        if (z < L_Skill_Class_Ability[Id].L_Class_Ability.Count) {
                            Skill_Class_Ability suan = L_Skill_Class_Ability[Id];
                            Class_Ability cz = L_Skill_Class_Ability[Id].L_Class_Ability[z];
                            _PhotonView.RPC ("Rpc_L_Transfer_Skill_Class_Ability_Add_Class_Ability", RpcTarget.All, false, Id, suan.Conv_Ability_Type_To_String(cz._Ability_Type), cz.Value_Int_1);

                        } else {
                            _PhotonView.RPC ("Rpc_L_Transfer_Skill_Class_Ability_Add_Class_Ability", RpcTarget.All, true, Id,"", 0);
                        }
                    }
                }
            }
            /*
            foreach (Class_Ability cz in L_Skill_Class_Ability[Id].L_Class_Ability) {
                  //  Rpc_L_Transfer_Skill_Class_Ability_Add_Class_Ability (Id, s.Conv_Ability_Effect_To_String(Cz._Ability_Type), Cz.Value_Int_1);
            }
            */
        }
        
        [PunRPC]
        public void Rpc_L_Transfer_Skill_Class_Ability_Add_Class_Ability (bool Finish_Transfer, int Id, string s, int value_int_1) {
            
            if (Finish_Transfer) {
                    _Enemy_2d.Add_Skill_Class_Ability (L_Transfer_Skill_Class_Ability[Id]);
            } else {
                Class_Ability Cs = new Class_Ability ();
                Cs._Ability_Type = L_Transfer_Skill_Class_Ability[Id].Conv_String_To_Ability_Type(s);
                Cs.Value_Int_1 = value_int_1;
                L_Transfer_Skill_Class_Ability[Id].L_Class_Ability.Add (Cs);
            }
        }

        #endregion
   #endregion
   #region Rpc_Others
        #region Cur_Flip
       //  public string Cur_Flip;
        // Enemy_2d :
        public void On_Mine_Lc_Cur_Flip (string Flip) {
            if (_PhotonView.IsMine) { // supaya not mine tdk kepanggil.
                _PhotonView.RPC ("Rpc_Send_Cur_Flip", RpcTarget.All, Flip);
            }
        }

        [PunRPC]
        public void Rpc_Send_Cur_Flip (string Flip) {
           // Cur_Hp = Cur_Hp_V;
            // if (Damage != 0) {
            if (!_PhotonView.IsMine) {
                _Enemy_2d.On_Flip (Flip);
            }
            //   Damage = 0;
        // }
        }
        #endregion

        #region Character_Animation
       //  public string Cur_Flip;
        // Enemy_2d :
        public void On_Mine_Character_Animation (string Animation) {
            if (_PhotonView.IsMine) { // supaya not mine tdk kepanggil.
                _PhotonView.RPC ("Rpc_Send_Character_Animation", RpcTarget.All, Animation);
            }
        }

        [PunRPC]
        public void Rpc_Send_Character_Animation (string Animation) {
           // Cur_Hp = Cur_Hp_V;
            // if (Damage != 0) {
            if (!_PhotonView.IsMine) {
                _Enemy_2d.On_Character_Animation (Animation);
            }
            //   Damage = 0;
        // }
        }
        #endregion
        #region Skill_Animation
        public Skill_Data_Kumpulan Slash_Skill_Data_Kumpulan_Not_Mine_Animasi_Only;
        Skill_Pengaturan_Animasi Cur_Slash_Skill_Pengaturan_Animasi;
        // Skill_Pengaturan_Animasi ("Not_Mine") :
        public void On_Inp_Cur_Slash_Skill_Pengaturan_Animasi (Skill_Pengaturan_Animasi s) {
            Cur_Slash_Skill_Pengaturan_Animasi = s;
        }
        // Skill_Pengaturan_Animasi :
        public void On_Mine_Lc_Skill_Animation (string Name_Skill) {
            if (_PhotonView.IsMine) {
                _PhotonView.RPC ("Rpc_Send_Skill_Animation", RpcTarget.All, Name_Skill);
            }
        }

        [PunRPC]
        public void Rpc_Send_Skill_Animation (string Name_Skill) {
            Slash_Skill_Data_Kumpulan_Not_Mine_Animasi_Only.Database_Load_Skill_Name (Name_Skill);
            Slash_Skill_Data_Kumpulan_Not_Mine_Animasi_Only._Skill_Data_Editor.On_Play_Skill_Animation_Only (_Enemy_2d, null);
        }

        // Skill_Pengaturan_Animasi :
        public void On_Mine_Destroy_Skill_Pengaturan_Animasi () {
            if (_PhotonView.IsMine) {
                _PhotonView.RPC ("Rpc_On_Mine_Destroy_Skill_Pengaturan_Animasi", RpcTarget.All);
            }
        }

            #region Skill_Data_Hit
            public Skill_Data_Kumpulan Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only;
            // Sp_Normal_Effect:
            public void Hit_On_Mine_Lc_Skill_Animation (string Name_Skill) {
                //if (_PhotonView.IsMine) {
                    _PhotonView.RPC ("Hit_Rpc_Send_Skill_Animation", RpcTarget.Others, Name_Skill);
               // }
            }

            [PunRPC]
            public void Hit_Rpc_Send_Skill_Animation (string Name_Skill) {
               // if (!_PhotonView.IsMine) { // Menghindari double
                Debug.LogError ("Taiga 0.3");
                    Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only.Database_Load_Skill_Name (Name_Skill);
                    Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only._Skill_Data_Editor.Rpc_Sp_Normal_Effect_Animation (_Enemy_2d, Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only);
               // }
            }

            #endregion
        #endregion
   #endregion
    
    Enemy_2d _Enemy_2d;
    [HideInInspector] // Enemy_AI_Catch, dll :
    public PhotonView _PhotonView;
    void Awake () {
        _Enemy_2d = this.GetComponent <Enemy_2d> ();
        _PhotonView = this.GetComponent <PhotonView>();
    
    }

    void Start () {
        if (_PhotonView.IsMine) {
            Online_Tower_Infinity_Room.Ins.MC_Lc_Increase_Total_Enemy ();
        }
    }
    Vector3 Target_Pos;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting)
        {
            stream.SendNext (Target_Pos);
           // stream.SendNext (Target_Rot);
          //  stream.SendNext (Target_Scl);
           // stream.SendNext (Damage);
        }
        else
        {   
            Target_Pos = (Vector3)stream.ReceiveNext();
          //  Target_Rot = (Quaternion)stream.ReceiveNext();
          //  Target_Scl =   (Vector3)stream.ReceiveNext();
          //  Damage = (int)stream.ReceiveNext ();
        }
        
    }

    void FixedUpdate () {
        if (_PhotonView.IsMine) {
            /*
            if (b_GMP_Spawn) {
                if (Vector3.Distance (this.transform.position, Target_Spawn.position ) < 5.0f) {
                    // Follower_Bidak_Player.transform.position =  AI_Nav_Target.position;
                   
                    b_GMP_Spawn = false;
                    GMP_Area_Generate.Ins.Lc_Loading_Confirmation_Spawn ("Lc_All_Finish_Spawn");
                }
            }
            Fixed_Pos_Y = Selisih_Y_Z - (transform.position.z/Selisih_Y_Z);
            transform.position = new Vector3 (transform.position.x, Fixed_Pos_Y, transform.position.z);
            */
            Target_Pos = this.transform.position;
        } else {
            Vector3.Slerp (this.transform.position, Target_Pos, 1.0f * Time.fixedDeltaTime);
        }
    }   
}
