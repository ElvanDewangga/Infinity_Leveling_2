using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Starsky;
public class Online_Player_2d : MonoBehaviourPunCallbacks,IPunObservable {
   #region Ability
        #region Damage
        public int Cur_Damage;
        int Def_Damage;
        // Sp_Normal_Slash :
        bool b_Critical;
        public void On_Damage (Skill_Pengaturan_Animasi Sp, int Damage) {
            if(_PhotonView.IsMine) {
                // Defense :
                Def_Damage = Damage - (_Online_Player_Status.GMP_C_Home_Status.Defense * Random.Range (150,300) /100);
                Cur_Damage = Def_Damage * -1;
                if (Cur_Damage > 0) {
                    Cur_Damage = 0;
                }
                // Incoming_Damage_Percent :
                Cur_Damage += Cur_Damage * _Online_Player_Status.Incoming_Damage_Percent /100;

                // Critical :
                b_Critical = false;
                int R_Critical = Random.Range (0,1000);
                int Damage_Critical_Rate = Sp._C_Home_Status.Critical_Rate;

                if (R_Critical < Damage_Critical_Rate) {
                    b_Critical = true;
                    Cur_Damage = Cur_Damage + (Cur_Damage * Sp._C_Home_Status.Critical_Damage/100) ;  
                }

                if (_Online_Player_Status.Immunity_Point >0) {
                    Cur_Damage = 0;
                }
                
                _Online_Player_Status.GMP_C_Home_Status.Hp += Cur_Damage;
                if (_Online_Player_Status.GMP_C_Home_Status.Hp > _Online_Player_Status._C_Home_Status.Hp) {_Online_Player_Status.GMP_C_Home_Status.Hp = _Online_Player_Status._C_Home_Status.Hp;}
                _PhotonView.RPC ("Rpc_Send_Damage_Player", RpcTarget.All, _Online_Player_Status.GMP_C_Home_Status.Hp, Sp.Code_Skill_Hit, Cur_Damage, b_Critical);
            }
        }
        

        [PunRPC]
        public void Rpc_Send_Damage_Player (int Cur_Hp_V, string Code_Skill_Hit, int Damage, bool Critical_V) {
            // if (Damage != 0) {
                if (_PhotonView.IsMine) {
                    _Online_Player_Status.On_Mine_Change_Cur_Hp (Cur_Hp_V,Code_Skill_Hit);
                } else if (!_PhotonView.IsMine) {
                    _Online_Player_Status.On_Not_Mine_Change_Cur_Hp (Cur_Hp_V,Code_Skill_Hit);
                }

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
        // Sp_Normal_Slash / Onnline_Player_Status:
       // public void On_Heal_Direct (Skill_Pengaturan_Animasi Sp, int Heal_V) {
         public void On_Heal_Direct (int Heal_V) {
            if(_PhotonView.IsMine) {
                Cur_Heal_Direct = Heal_V;

                _Online_Player_Status.GMP_C_Home_Status.Hp += Cur_Heal_Direct;
                if (_Online_Player_Status.GMP_C_Home_Status.Hp > _Online_Player_Status._C_Home_Status.Hp) {_Online_Player_Status.GMP_C_Home_Status.Hp = _Online_Player_Status._C_Home_Status.Hp;}
                _PhotonView.RPC ("Rpc_Refresh_Health", RpcTarget.All, _Online_Player_Status.GMP_C_Home_Status.Hp);
            }
        }

        [PunRPC]
        public void Rpc_Refresh_Health (int Cur_Hp_V) {
            // if (Damage != 0) {
                if (_PhotonView.IsMine) {
                    _Online_Player_Status.On_Mine_Change_Cur_Hp (Cur_Hp_V, "");
                } else if (!_PhotonView.IsMine) {
                    _Online_Player_Status.On_Not_Mine_Change_Cur_Hp (Cur_Hp_V, "");
                }
            //   Damage = 0;
        // }
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
                Debug.LogError ("Effect " + Code_Status);
                if (Code_Status == "Mp") {Cur_Change_Status = _Online_Player_Status.GMP_C_Home_Status.Mp;}
                else if (Code_Status == "Attack") {Cur_Change_Status = _Online_Player_Status.GMP_C_Home_Status.Attack;}
                else if (Code_Status == "Incoming_Damage_Percent") {Cur_Change_Status = _Online_Player_Status.Incoming_Damage_Percent;}
                else if (Code_Status == "Defense") {Cur_Change_Status = _Online_Player_Status.GMP_C_Home_Status.Defense;}
                else if (Code_Status == "Stun") {Cur_Change_Status = _Online_Player_Status.Stun_Point;}
                else if (Code_Status == "Critical_Rate") {Cur_Change_Status = _Online_Player_Status.GMP_C_Home_Status.Critical_Rate;}
                else if (Code_Status == "Critical_Damage") {Cur_Change_Status = _Online_Player_Status.GMP_C_Home_Status.Critical_Damage;}
                else if (Code_Status == "Immunity") {Cur_Change_Status = _Online_Player_Status.Immunity_Point;}

                Cur_Change_Status += Value_Status;
                if (Code_Status == "Mp") {
                    if (Cur_Change_Status > _Online_Player_Status._C_Home_Status.Mp) {Cur_Change_Status = _Online_Player_Status._C_Home_Status.Mp;}
                } else {

                }
                _PhotonView.RPC ("Rpc_Refresh_Status", RpcTarget.All, Code_Status, Cur_Change_Status);
            } else {
                Debug.LogError ("Status dont apply because not mine.");
            }
        }

        [PunRPC]
        public void Rpc_Refresh_Status (string Code_Status, int Value_Status) {
            // if (Damage != 0) {
                if (_PhotonView.IsMine) {
                    _Online_Player_Status.On_Mine_Change_Status (Code_Status, Value_Status);
                } else if (!_PhotonView.IsMine) {
                    _Online_Player_Status.On_Not_Mine_Change_Status (Code_Status, Value_Status);
                }
            //   Damage = 0;
        // }
        }
        #endregion
        #region Skill_Class_Ability
        List <Skill_Class_Ability> L_Skill_Class_Ability = new List <Skill_Class_Ability> ();
        [SerializeField]
        List <Skill_Class_Ability> L_Transfer_Skill_Class_Ability;
        // Skill_Pengaturan_Animasi :
        public void On_Give_Skill_Class_Ability (Skill_Pengaturan_Animasi s, List <Skill_Class_Ability> L_Skill_Class_Ability_V) {
            Debug.Log ("1");
            L_Skill_Class_Ability = new List <Skill_Class_Ability>();
            L_Skill_Class_Ability = L_Skill_Class_Ability_V;
            int Id = -1;
            foreach (Skill_Class_Ability suan in L_Skill_Class_Ability) {
                Id ++;
                 // Rpc_Add_Skill_Class_Ability (s.Id, s.Title_Skill, s.Conv_Skill_Target_To_String(s._Skill_Target));
                _PhotonView.RPC ("Rpc_Add_Skill_Class_Ability", RpcTarget.All, Your_Players, Id, suan.Title_Skill, suan.Conv_Skill_Target_To_String(suan._Skill_Target));
                
            }
        }

        [PunRPC]
        public void Rpc_Add_Skill_Class_Ability (int Your_Players_V, int Id, string Title_V, string Skill_Target_V) {
            if (Id == 0) { L_Transfer_Skill_Class_Ability = new List <Skill_Class_Ability> ();}
            if (Your_Players != Your_Players_V) {L_Skill_Class_Ability = new List <Skill_Class_Ability>();}
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
                    _Online_Player_Status.Add_Skill_Class_Ability (L_Transfer_Skill_Class_Ability[Id]);
            } else {
                Class_Ability Cs = new Class_Ability ();
                Cs._Ability_Type = L_Transfer_Skill_Class_Ability[Id].Conv_String_To_Ability_Type(s);
                Cs.Value_Int_1 = value_int_1;
                L_Transfer_Skill_Class_Ability[Id].L_Class_Ability.Add (Cs);
            }
        }

        #endregion
        #region Dead
        // Online_Player_Status :
        public void On_Mine_Dead () {
            if (_PhotonView.IsMine) { // supaya not mine tdk kepanggil.
                _PhotonView.RPC ("Rpc_Send_Dead", RpcTarget.All);
            }
        }

        [PunRPC]
        public void Rpc_Send_Dead () {
           // Cur_Hp = Cur_Hp_V;
            // if (Damage != 0) {
            if (!_PhotonView.IsMine) {
                _Online_Player_Status.On_Not_Mine_Dead ();
            }
            //   Damage = 0;
        // }
        }
        #endregion

   #endregion
   #region Rpc_Others
        #region Cur_Flip
       //  public string Cur_Flip;
        // Player_2d :
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
                _Player_2d.On_Flip (Flip);
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
                _Player_2d = GetComponent <Player_2d>();
                _Player_2d.On_Character_Animation (Animation);
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
            Debug.LogError ("Sapi Masuk") ;
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
            if (!_PhotonView.IsMine) { // Menghindari double
                Slash_Skill_Data_Kumpulan_Not_Mine_Animasi_Only.Database_Load_Skill_Name (Name_Skill);
                Slash_Skill_Data_Kumpulan_Not_Mine_Animasi_Only._Skill_Data_Editor.On_Play_Skill_Animation_Only (_Player_2d, null);
            }
        }

        // Skill_Pengaturan_Animasi :
        public void On_Mine_Destroy_Skill_Pengaturan_Animasi () {
            if (_PhotonView.IsMine) {
                _PhotonView.RPC ("Rpc_On_Mine_Destroy_Skill_Pengaturan_Animasi", RpcTarget.All);
            }
        }

        [PunRPC]
        public void Rpc_On_Mine_Destroy_Skill_Pengaturan_Animasi () {
            if (!_PhotonView.IsMine) { // Menghindari double
            Debug.LogError ("Sapi Hancurkan") ;
                Slash_Skill_Data_Kumpulan_Not_Mine_Animasi_Only._Skill_Data_Editor.On_Direct_Destroy_Animation_Only (Cur_Slash_Skill_Pengaturan_Animasi);
            }
        }

            #region Skill_Data_Hit
            public Skill_Data_Kumpulan Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only;
            // Sp_Normal_Effect:
            public void Hit_On_Mine_Lc_Skill_Animation (string Name_Skill) {
               // if (_PhotonView.IsMine) {
                    _PhotonView.RPC ("Hit_Rpc_Send_Skill_Animation", RpcTarget.Others, Name_Skill);
                // }
            }

            [PunRPC]
            public void Hit_Rpc_Send_Skill_Animation (string Name_Skill) {
                //if (!_PhotonView.IsMine) { // Menghindari double
                    Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only.Database_Load_Skill_Name (Name_Skill);
                    Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only._Skill_Data_Editor.Rpc_Sp_Normal_Effect_Animation (_Player_2d, Hit_Skill_Data_Kumpulan_Not_Mine_Animasi_Only);
                // }
            }

            #endregion
        #endregion
   #endregion
    [HideInInspector]
    public PhotonView _PhotonView;
    [SerializeField]
    int Your_Players = -1;
    Online_Player_Status _Online_Player_Status;
    Player_2d _Player_2d;
    Online_Tower_Infinity_Room _Online_Tower_Infinity_Room;
    
    // Online_Tower_Infinity_Room :
    [HideInInspector]
    public bool Is_Mine = false;
    void Start () {
        _PhotonView = GetComponent <PhotonView>();
        _Player_2d = GetComponent <Player_2d>();
        _Online_Player_Status = GetComponent <Online_Player_Status>();
        _Online_Tower_Infinity_Room = GameObject.Find ("Online_Tower_Infinity_Room").GetComponent <Online_Tower_Infinity_Room>();
        if (_PhotonView.IsMine) {
           Is_Mine = true;
           DualJoystickPlayerController.Ins.On_Input_Player_2d (this.gameObject);
          
        }
        // _Photon_Room = GameObject.Find ("Photon_Room").GetComponent <Photon_Room>();
         _Online_Tower_Infinity_Room.Add_L_Player_Clone (this.gameObject);
        if (!_PhotonView.IsMine) {
            // = GameObject.Find ("Room_Manager").GetComponent<Room_Manager>();
            if (PhotonNetwork.IsMasterClient) {
                _Online_Tower_Infinity_Room.Lc_MC_Kirim_All_Data_Karena_Player_Baru_Masuk (); 
                /*
                _Photon_Room._Photon_View.RPC 
                ("Rpc_Ld_All",RpcTarget.All, _Photon_Room.Room_Cur_Players,_Photon_Room.Room_Category,_Photon_Room.Room_Max_Players,_Photon_Room.Room_Code,
                _Photon_Room.Room_P1_Nickname, _Photon_Room.Room_P2_Nickname, _Photon_Room.Room_P3_Nickname, _Photon_Room.Room_P4_Nickname,
                _Photon_Room.Room_P1_Avatar, _Photon_Room.Room_P2_Avatar, _Photon_Room.Room_P3_Avatar, _Photon_Room.Room_P4_Avatar,
                _Photon_Room.Room_P1_Ready, _Photon_Room.Room_P2_Ready, _Photon_Room.Room_P3_Ready, _Photon_Room.Room_P4_Ready, _Photon_Room.Room_Tot_Ready);
                */
            } 
             transform.SetParent (Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone);
        } else {
            // _Room_Manager = GameObject.Find ("Room_Manager").GetComponent<Room_Manager>();
        }
        
         _Player_2d._Hiasan_Player.On_Char_Penanda (_PhotonView.IsMine);
       
    }
    
    public void On_Chg (int Your_Players_V) {
        Your_Players = Your_Players_V;
        // this.gameObject.transform.SetParent (Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone);
        
        Online_Tower_Infinity_Room.Ins.On_Set_A_Clone_Player_2d (Your_Players, this.gameObject);
        
    }

    // Online_Tower_Infinity_Room :
    public void On_Refresh_Sibling () {
        this.gameObject.transform.SetSiblingIndex (Your_Players);
    }
    // Online_Tower_Infinity_Room :
    
    public void On_Refresh_Player_Status () {
            _PhotonView = GetComponent <PhotonView>();
            _Online_Player_Status = GetComponent <Online_Player_Status>();
            if (_PhotonView.IsMine) {
                _Online_Player_Status.On_All_Load_Player_Status (Your_Players);
            }
        
    }

    Vector3 Target_Pos;
   // Quaternion Target_Rot;
   // Vector3 Target_Scl;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext (Target_Pos);
            stream.SendNext (Your_Players);
        }
        else
        {   
            Target_Pos = (Vector3)stream.ReceiveNext();
            Your_Players = (int)stream.ReceiveNext ();
        }
     
    }


    void OnDestroy () {
        if (!_PhotonView.IsMine && !_Online_Tower_Infinity_Room.Cannot_Destroy) {
            _Online_Tower_Infinity_Room.Remove_L_Player_Clone (this.gameObject);
            _Online_Tower_Infinity_Room.On_Dc (Your_Players);
            /*
                if (_Photon_Room.Room_Your_Players == 0) { // PhotonNetwork.IsMasterClient
                    
                    if (_Photon_Room != null) {
                        if (Your_Players != 0) { // Jika Your Players 0, maka player stack di full room
                            _Photon_Room.On_Dc (Your_Players);
                        }
                        
                    }
                } 
                else if (_Photon_Room.Sub_MC) {
                    
                    if (Your_Players == 0) {
                        if (Nickname != "") { // jika Nickname x sama, maka player stack di full room.
                            _Photon_Room.On_Dc (Your_Players);
                            
                      }
                    }
                
                }
                */
            
        }
    }

    void Update() {
        if (_PhotonView.IsMine) {
            if (b_GMP_Spawn) {
                /*
                if (Vector3.Distance (this.transform.position, Target_Spawn.position ) < 0.5f) {
                    // Follower_Bidak_Player.transform.position =  AI_Nav_Target.position;
                   Debug.Log ("Same Spawn");
                    b_GMP_Spawn = false;
                    GMP_Area_Generate.Ins.Lc_Loading_Confirmation_Spawn ("Lc_All_Finish_Spawn");
                } else {
                     Debug.Log ("Not Spawn");
                }
                */
            } else {
                Fixed_Pos_Y = Selisih_Y_Z - (transform.position.z/Selisih_Y_Z);
                transform.position = new Vector3 (transform.position.x, Fixed_Pos_Y, transform.position.z);
            }


        } else {
            Vector3.Slerp (this.transform.position, Target_Pos, 2.0f * Time.fixedDeltaTime);
        }
    }    

    #region GMP_Spawn
    [SerializeField]
    Transform Target_Spawn;
    // DualJoyPlayerController :
    public bool b_GMP_Spawn = false;
    public void On_Input_Target_Spawn (Transform s) {
        Target_Spawn = s;
        b_GMP_Spawn = true;
    }
    #endregion
    #region Fixed_Pos_Y
    [SerializeField]
    float Fixed_Pos_Y = 0.0f; // z (200) = y (10) berarti selisih 20x lipat
    float Selisih_Y_Z = 20.0f;
    #endregion
    #region Refresh_Camera_Culling_Mask
    void On_Refresh_Camera_Culling_Masuk () {
        _Player_2d = GetComponent <Player_2d>();
        int layer1 = LayerMask.NameToLayer("Player_" +Your_Players);

        this.gameObject.layer = layer1;
        foreach (Transform child in transform)
         {
                 child.gameObject.layer = layer1;
         }
        // Camera :
        _Player_2d.Raw_Camera.cullingMask = (1 << layer1);
    }
    
    #endregion
    #region Spawn_Area
    // Spawn_Area :
    public void On_Spawn_Area () {
        if (_PhotonView.IsMine) {
            if (b_GMP_Spawn) {
                b_GMP_Spawn = false;
                GMP_Area_Generate.Ins.Lc_Loading_Confirmation_Spawn ("Lc_All_Finish_Spawn");
                
            } 
        }
    }
    #endregion
    
}
