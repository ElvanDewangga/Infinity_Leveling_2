using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
using TMPro;
using UnityEngine.UI;
public class Enemy_2d : MonoBehaviour {
   public GameObject Asset_2d_Titik_Tengah;
   public Transform Gender_Fix_Transform_Anim;
   Gender_Fix_Transform_Anim _Gender_Fix_Transform_Anim;
   public Transform Posisi_Depan, Posisi_Belakang;
   public Transform Asset_Body;
   public Transform Transform_Posisi_Depan_Tanah_1; 
   [HideInInspector]
   public GameObject Cur_Body_GO;


    void Update () {
        // Fixed_Pos_Y
        Fixed_Pos_Y = Selisih_Y_Z - (transform.position.z/Selisih_Y_Z);
        transform.position = new Vector3 (transform.position.x, Fixed_Pos_Y, transform.position.z);
        // END
    }
    
#region Load_Refresh_Asset
    [SerializeField]
    Player_Status _Player_Status;
    // --- Data_Online / Online_Player_Status (Online) :
    public void On_Input_Player_Status (Player_Status Ps) {
        _Player_Status = Ps;
    }
    // -- Home_Canvas (Offline) / Online_Player_Status (Online) :
    public void On_Load_Refresh_Asset () {
       //  Home_System.Ins._Character_Selection.On_Chg_Target_Player_2d (this);
        foreach (Gender_Data x in Home_System.Ins._Character_Selection.L_Gender_Data) {
            if (x.Code_Character_Selection == _Player_Status.Gender) {
                x.On_Set_To_Player_2d ();
            }
        }

    }
#endregion
#region Load_Skill_Character
    int Jumlah_Max_Skill = 5;
    //[SerializeField]
    // Hall_Of_Masters :
    public Skill_Data_Kumpulan [] A_Skill_Active;
    //[SerializeField]
    public Skill_Data_Kumpulan [] A_Skill_Passive;
    
#endregion
#region Char_World_Canvas
[SerializeField]
TMP_Text Char_World_Nickname_Tx;
[SerializeField]
Slider Char_World_Hp_Slider;
// Enemy_2d_Online :
[HideInInspector]
public int Max_Hp, Max_Mp;
void On_Refresh_Char_World_Data_Awal (string Nickname_V) {
    Char_World_Nickname_Tx.text = Nickname_V; Char_World_Hp_Slider.maxValue = _C_Home_Status.Hp;
    Char_World_Hp_Slider.value = _C_Home_Status.Hp;
    Max_Hp = _C_Home_Status.Hp; Max_Mp = _C_Home_Status.Mp;
}

void On_Refresh_Char_World_Data_Cur_Hp () {
    Char_World_Hp_Slider.value = _C_Home_Status.Hp;
}

    #region Incoming_Damage_Percent
        public int Incoming_Damage_Percent;
        void On_Change_Incoming_Damage_Percent () {
           // Incoming_Damage_Percent = v;
        }
    #endregion
    #region Stun
        public int Stun_Point; // 0 = tidak stun. 1 = stun.
        void On_Change_Stun_Point () {
            if (Stun_Point == 0) {
                    On_b_Can_Move ();
                    On_b_Can_Skill ();
            } else {
                if (!b_On_b_Can_Move_With_Time) {
                    Off_b_Can_Move ();
                    Off_b_Can_Skill ();
                }
            }
        }
    #endregion
    #region Immunity
        public int Immunity_Point = 0; // 0 = tidak stun. 1 = stun.
        void On_Change_Immunity_Point () {
            
        }
    #endregion
#endregion
#region Ability
// Enemy_2d_Online :
/*
public void On_Change_Cur_Hp (int Got_Damage) { // Dmaage : Mines && Heal : Plus
    _C_Home_Status.Hp += Got_Damage;
    if (_C_Home_Status.Hp > Max_Hp) {_C_Home_Status.Hp = Max_Hp;}
    if (_C_Home_Status.Hp <= 0) {Debug.Log ("Dead");}
    On_Refresh_Char_World_Data_Cur_Hp ();
}
*/
// Enemy_2d_Online
public void On_Change_Cur_Hp (bool IsMine, int Cur_Hp_V, string Code_Skill_Hit) { // Dmaage : Mines && Heal : Plus
    b_IsMine = IsMine;
    if (!b_Dead) {
        _C_Home_Status.Hp = Cur_Hp_V;
        // if (_C_Home_Status.Hp > Max_Hp) {_C_Home_Status.Hp = Max_Hp;}
        // if (_C_Home_Status.Hp <= 0) {Debug.Log ("Dead");}
        if (_C_Home_Status.Hp <= 0) {
            b_Dead = true;
            On_Dead ();
        }
            On_Refresh_Char_World_Data_Cur_Hp ();
            On_Hit_Particle (Code_Skill_Hit);
    }
}

    
    #region Dead
    bool b_IsMine = false;
    bool b_Dead = false;
    void On_Dead () { // Destroy harus semua Rpc client.all karena InstantiateSceneObject
       Tower_Infinity_Manager.Ins.On_Got_Exp (_C_Byte_Enemy.Cur_Exp);
       Online_Tower_Infinity_Room.Ins.MC_Lc_Decrease_Total_Enemy ();
       Destroy (this.gameObject);
    }
    #endregion
    #region Change_Status
        // Enemy_2d_Online :
        public void On_Change_Status (string Code_Status, int Value_Status) { // Dmaage : Mines && Heal : Plus
            if (Code_Status == "Mp" ) {
                _C_Home_Status.Mp = Value_Status;
            }else if (Code_Status == "Incoming_Damage_Percent") {
                Incoming_Damage_Percent = Value_Status;
                On_Change_Incoming_Damage_Percent ();
            }  else if (Code_Status == "Attack") {
                _C_Home_Status.Attack = Value_Status;
            } else if (Code_Status == "Defense") {
                _C_Home_Status.Defense = Value_Status;
            } else if (Code_Status == "Stun") {
                Stun_Point = Value_Status;
                On_Change_Stun_Point ();
            }  else if (Code_Status == "Critical_Rate") {
                _C_Home_Status.Critical_Rate = Value_Status;
            }  else if (Code_Status == "Critical_Damage") {
                _C_Home_Status.Critical_Damage = Value_Status;
            } else if (Code_Status == "Immunity") {
                Immunity_Point = Value_Status;
                On_Change_Immunity_Point ();
            }

        }
        /*
        // Online_Player_2d :
        public void On_Not_Mine_Change_Status (string Code_Status, int Value_Status) { // Dmaage : Mines && Heal : Plus
            if (Code_Status == "Mp" ) {
                _C_Home_Status.Mp = Value_Status;
            } else if (Code_Status == "Attack") {
                _C_Home_Status.Attack = Value_Status;
            }
           
        }
        */
        #endregion
#endregion
#region Skill_Class_Ability
            [SerializeField]
            public List <Skill_Class_Ability> L_Skill_Class_Ability;
           
            public void Add_Skill_Class_Ability (Skill_Class_Ability s) {
                L_Skill_Class_Ability.Add (s);
                On_Class_Ability (s);
            }

            void Remove_Skill_Class_Ability (Skill_Class_Ability s) {
                L_Skill_Class_Ability.Remove (s);
            }

            void On_Class_Ability (Skill_Class_Ability yang) {
                C_Home_Status Pemberi_C_Home_Status = Online_Tower_Infinity_Room.Ins.A_Clone_Player_2d[yang.Your_Players_Id].GetComponent <Online_Player_Status>().GMP_C_Home_Status;
                On_Refresh_L_Int_Value ();
                foreach (Class_Ability ying in yang.L_Class_Ability) {
                    
                    if (ying._Ability_Type == Ability_Type.Stun_Seconds) {

                    }
                    if (ying._Ability_Type == Ability_Type.Damage_Power) {

                    }
                    if (ying._Ability_Type == Ability_Type.Heal_Power) {
                        
                    }
                    if (ying._Ability_Type == Ability_Type.Damage_Direct) {

                    }
                    if (ying._Ability_Type == Ability_Type.Heal_Direct) { // TOP
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value (ying.Value_Int_1);
                    }
            
            
                    if (ying._Ability_Type == Ability_Type.Decrease_Atk_Point) {
                    
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Atk_Point) {

                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Mp) {
                        
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Atk_Percent) {
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Attack * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Atk_Percent) {
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Attack * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Def_Percent) {
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Defense * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Def_Percent) {
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Defense * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Hp_Percent) { // SIDE
                        Add_L_Int_Value ( _C_Home_Status.Hp * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Hp_Percent) {
                        if (yang._Skill_Target == Skill_Target.Self) { // TOP
                        Top_Ability_Type = ying._Ability_Type;
                            Add_L_Int_Value ( Max_Hp * ying.Value_Int_1 /100 );
                        }

                    }

                    if (ying._Ability_Type == Ability_Type.Increase_Mp_Percent) { // TOP
                    Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Mp * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Mp_Percent) {
                        if (yang._Skill_Target == Skill_Target.Self) { // TOP
                        Top_Ability_Type = ying._Ability_Type;
                            Add_L_Int_Value ( Max_Mp * ying.Value_Int_1 /100 );
                        }
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Damage_By_Cur_Hp_Percent) { // Side
                        Add_L_Int_Value ( Pemberi_C_Home_Status.Hp * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Damage_By_Cur_Mp_Percent) { // Side
                        Add_L_Int_Value (Pemberi_C_Home_Status.Mp * ying.Value_Int_1 /100);
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Damage_By_Attack_Percent) { // Side
                        Add_L_Int_Value (Pemberi_C_Home_Status.Attack * ying.Value_Int_1 /100);
                    }
                    // Cek apakah ada Seconds :
                    if (ying._Ability_Type == Ability_Type.Cd_Seconds) { // Side
                        yang.Cur_Cd_Seconds = ying.Value_Int_1;
                        On_Add_Time_L_Skill_Class_Ability(yang);
                    } else {
                        Remove_Skill_Class_Ability (yang);
                    }

                    if (ying._Ability_Type == Ability_Type.Increase_Coming_Damage_Percent) { // TOP
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value (  ying.Value_Int_1);
                    }

                    if (ying._Ability_Type == Ability_Type.stun) {
                         Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value (1);
                    }
                    
                    if (ying._Ability_Type == Ability_Type.Increase_Critical_Rate_Percent) {
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Critical_Rate * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Increase_Critical_Damage_Percent) {
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Critical_Damage * ying.Value_Int_1 /100 );
                    }

                    if (ying._Ability_Type == Ability_Type.Immunity) {
                         Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value (1);
                    }

                    if (ying._Ability_Type == Ability_Type.Decrease_Cur_Hp_Percent) {
                        if (yang._Skill_Target == Skill_Target.Self) { // TOP
                            Top_Ability_Type = ying._Ability_Type;
                            Add_L_Int_Value ( _C_Home_Status.Hp * ying.Value_Int_1 /100 );
                        }
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Cur_Mp_Percent) {
                        if (yang._Skill_Target == Skill_Target.Self) { // TOP
                            Top_Ability_Type = ying._Ability_Type;
                            Add_L_Int_Value ( _C_Home_Status.Mp * ying.Value_Int_1 /100 );
                        }
                    }
                
                }
                On_Start_Give_Top_Ability_Type ();
            }
            #region Ability_Value_Setting
            List <int> L_Int_Value;
            int Total_Int_Value;
            Ability_Type Top_Ability_Type;
            void On_Refresh_L_Int_Value () {
                Total_Int_Value = 0;
                Top_Ability_Type = Ability_Type.Stun_Seconds; // Stun_Seconds karena tidak bisa null (ANGGAP AJA DEFAULT KARENA TDK BISA DIPAKAI)
                L_Int_Value = new List <int> ();
            }
            
            void Add_L_Int_Value (int v) {
                L_Int_Value.Add (v);
            }

            void On_Start_Give_Top_Ability_Type () {
                foreach (int x in L_Int_Value) {Total_Int_Value += x;}
                if (Top_Ability_Type == Ability_Type.Heal_Direct) { // TOP
                    _Enemy_2d_Online.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Hp_Percent) { // TOP
                    _Enemy_2d_Online.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Mp_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Mp", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Mp_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Mp", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Atk_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Attack", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Atk_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Attack", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Def_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Defense", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Coming_Damage_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Incoming_Damage_Percent", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.stun) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Stun", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Critical_Rate_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Critical_Rate", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Critical_Damage_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Critical_Damage", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Immunity) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Immunity", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Cur_Hp_Percent) { // TOP
                    _Enemy_2d_Online.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Cur_Mp_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Mp", Total_Int_Value);
                }
            }
            #endregion


            #region Time_L_Skill_Class_Ability
             List <Skill_Class_Ability> Time_L_Skill_Class_Ability = new List <Skill_Class_Ability> ();
             List <Skill_Class_Ability> CUR_Time_L_Skill_Class_Ability = new List <Skill_Class_Ability> ();
             public void On_Add_Time_L_Skill_Class_Ability (Skill_Class_Ability s) {
                
                Time_L_Skill_Class_Ability.Add (s);
                
                if (Time_L_Skill_Class_Ability.Count == 1) {
                    C_N_Time_L_Skill_Class_Ability = StartCoroutine (N_Time_L_Skill_Class_Ability ());
                }
             }

             void On_Remove_Time_L_Skill_Class_Ability (Skill_Class_Ability s) {
                C_Home_Status Pemberi_C_Home_Status = Online_Tower_Infinity_Room.Ins.A_Clone_Player_2d[s.Your_Players_Id].GetComponent <Online_Player_Status>().GMP_C_Home_Status;
                Time_On_Refresh_L_Int_Value ();

                foreach (Class_Ability Ca in s.L_Class_Ability) {
                    if (Ca._Ability_Type == Ability_Type.stun) {
                         Time_Top_Ability_Type = Ca._Ability_Type;
                        Time_Add_L_Int_Value (-1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Immunity) {
                         Time_Top_Ability_Type = Ca._Ability_Type;
                        Time_Add_L_Int_Value (-1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Increase_Atk_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Attack * Ca.Value_Int_1 /100 * -1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Decrease_Atk_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Attack * Ca.Value_Int_1 /100 * -1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Increase_Def_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Defense * Ca.Value_Int_1 /100 * -1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Decrease_Def_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Defense * Ca.Value_Int_1 /100 * -1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Increase_Coming_Damage_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( Incoming_Damage_Percent * Ca.Value_Int_1 /100 * -1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Increase_Critical_Damage_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Critical_Damage * Ca.Value_Int_1 /100 * -1);
                    }
                    if (Ca._Ability_Type == Ability_Type.Increase_Critical_Rate_Percent) {
                        Top_Ability_Type = Ca._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Critical_Rate * Ca.Value_Int_1 /100 * -1);
                    }
                }
                Time_On_Start_Give_Top_Ability_Type ();
                Time_L_Skill_Class_Ability.Remove (s);
                Remove_Skill_Class_Ability (s);
             }

            Coroutine C_N_Time_L_Skill_Class_Ability;
            IEnumerator N_Time_L_Skill_Class_Ability () {
                CUR_Time_L_Skill_Class_Ability = new List <Skill_Class_Ability>();
                foreach (Skill_Class_Ability s in Time_L_Skill_Class_Ability) { // supaya tidak index of range karena .remove
                    CUR_Time_L_Skill_Class_Ability.Add (s);
                }

                yield return new WaitForSeconds (1);
                foreach (Skill_Class_Ability s in CUR_Time_L_Skill_Class_Ability) {
                    s.Cur_Cd_Seconds --;
                    if (s.Cur_Cd_Seconds <= 0) {
                        On_Remove_Time_L_Skill_Class_Ability (s);
                    }
                }

                if (Time_L_Skill_Class_Ability.Count >0) {
                    C_N_Time_L_Skill_Class_Ability = StartCoroutine (N_Time_L_Skill_Class_Ability ());
                } else {
                    StopCoroutine (C_N_Time_L_Skill_Class_Ability);
                }
            }
            #endregion

            #region Time_Ability_Value_Setting
            List <int> Time_L_Int_Value;
            int Time_Total_Int_Value;
            Ability_Type Time_Top_Ability_Type;
            void Time_On_Refresh_L_Int_Value () {
                Time_Total_Int_Value = 0;
                Time_Top_Ability_Type = Ability_Type.Stun_Seconds; // Stun_Seconds karena tidak bisa null (ANGGAP AJA DEFAULT KARENA TDK BISA DIPAKAI)
                Time_L_Int_Value = new List <int> ();
            }
            
            void Time_Add_L_Int_Value (int v) {
                Time_L_Int_Value.Add (v);
            }

            void Time_On_Start_Give_Top_Ability_Type () {
                foreach (int x in Time_L_Int_Value) {Time_Total_Int_Value += x;}
                /*
                if (Top_Ability_Type == Ability_Type.Heal_Direct) { // TOP
                    _Enemy_2d_Online.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Hp_Percent) { // TOP
                    _Enemy_2d_Online.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Mp_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Mp", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Def_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Defense", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Coming_Damage_Percent) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Incoming_Damage_Percent", Total_Int_Value);
                }
                */
                if (Time_Top_Ability_Type == Ability_Type.stun) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Stun", Time_Total_Int_Value);
                }
                if (Time_Top_Ability_Type == Ability_Type.Immunity) { // TOP
                    _Enemy_2d_Online.On_Change_Status ("Immunity", Time_Total_Int_Value);
                }
            }
            #endregion
        
    #endregion
#region Hit_Particle
    Transform _Skill_Hit;
    void On_Hit_Particle (string Target_Name) {
        _Skill_Hit = Home_System.Ins.Skill_Hit;
        foreach (Transform x in _Skill_Hit.transform) {
            Skill_Hit Sk = x.GetComponent <Skill_Hit>();
            if (Sk.Code_Name == Target_Name) {
                Sk.On_Instantiate_Particle (this.gameObject.transform);
            }      
        }
    }
#endregion
#region C_Byte_Enemy
    int Code_Enemy_Id = 0;
    public string Code_Enemy_Jenis = "Normal_Enemy";
    [SerializeField]
    C_Byte_Enemy _C_Byte_Enemy = new C_Byte_Enemy ();
    #region Home_Status
    // Skill_Pengaturan_Animasi :
    [HideInInspector]
    public C_Home_Status _C_Home_Status = new C_Home_Status ();
    // GMP_Map_Settings - Enemy_2d_Online :
    public void On_Got_C_Byte_Enemy_Id (int Code_Enemy_Id_V, string Code_Enemy_Jenis_V) {
        Code_Enemy_Id = Code_Enemy_Id_V; Code_Enemy_Jenis = Code_Enemy_Jenis_V;
        if (Code_Enemy_Jenis == "Normal_Enemy") {
            _C_Byte_Enemy = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings.L_Cur_C_Byte_Enemy[Code_Enemy_Id_V];
            Dont_Destroy_On_Load.Ins._System_Settings.Conv_C_Byte_Enemy_To_C_Home_Status (_C_Byte_Enemy,_C_Home_Status);
            On_Refresh_Char_World_Data_Awal (_C_Byte_Enemy.Nickname);
            On_Enemy_Load_Scene_System ();
        } else if (Code_Enemy_Jenis == "Mini_Boss") {
            _C_Byte_Enemy = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings.L_Cur_C_Byte_Mini_Boss[Code_Enemy_Id_V];
            Dont_Destroy_On_Load.Ins._System_Settings.Conv_C_Byte_Enemy_To_C_Home_Status (_C_Byte_Enemy,_C_Home_Status);
            On_Refresh_Char_World_Data_Awal (_C_Byte_Enemy.Nickname);
            On_Enemy_Load_Scene_System ();
        } else if (Code_Enemy_Jenis == "Boss_Enemy") {
            _C_Byte_Enemy = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings.L_Cur_C_Byte_Boss_Enemy[Code_Enemy_Id_V];
            Dont_Destroy_On_Load.Ins._System_Settings.Conv_C_Byte_Enemy_To_C_Home_Status (_C_Byte_Enemy,_C_Home_Status);
            On_Refresh_Char_World_Data_Awal (_C_Byte_Enemy.Nickname);
            On_Enemy_Load_Scene_System ();
        }
        On_Not_Mine_Spawn_And_Parent_Room ();
       // On_Refresh_Char_World_Data_Awal (_C_Byte_Enemy.Nickname);
    }

    void On_Not_Mine_Spawn_And_Parent_Room () {
        this.gameObject.transform.SetParent (GMP_Area_Generate.Ins.A_Ins_Room_Enemy_Parent.GetChild(_C_Byte_Enemy.Element_Room));
        // Spawn :
        GMP_Square_Field Target_Ins_Square_Field = GMP_Area_Generate.Ins.A_Ins_Square_Field.GetChild(_C_Byte_Enemy.Element_Room).GetComponent <GMP_Square_Field>();
        this.gameObject.transform.position = Target_Ins_Square_Field.A_Spawn_Area.GetChild (_C_Byte_Enemy.Element_Spawn).transform.position;
                            
    }
    // GMP_Map_Settings :
    /*
    public void On_Enemy_Input_C_Home_Status (C_Home_Status s, C_Byte_Enemy c) {
        _C_Home_Status = s; _C_Byte_Enemy = c;
        On_Refresh_Char_World_Data_Awal (_C_Byte_Enemy.Nickname);
    }
    */
    
    #endregion
    #region C_Skill
    C_Skill _C_Skill = new C_Skill ();
    #endregion
    #region Enemy_Load_Scene_System
    // Gender_Fix_Transform_Anim :
    [HideInInspector]
    public GameObject Enemy_Load_GO;
    // Skill_Pengaturan_Animasi / GMP_Out_Of_Zone :
    [HideInInspector]
    public Enemy_AI_Control _Enemy_AI_Control;
    void On_Enemy_Load_Scene_System () {
        GameObject Target_Load_GO = Enemy_Load_Scene_System.Ins.On_Search_Enemy (_C_Byte_Enemy.Code_Name);  
        Enemy_Load_GO = GameObject.Instantiate (Target_Load_GO);
        Enemy_Load_GO.transform.SetParent (Gender_Fix_Transform_Anim);
        Enemy_Load_GO.transform.localPosition = Enemy_Load_GO.GetComponent <Enemy_AI_Control>().V3_Load_Local_Position;
        Enemy_Load_GO.GetComponent <Enemy_AI_Control>().On_Input_Enemy_2d_GO (this.gameObject);
        Enemy_Load_GO.transform.localRotation = Quaternion.Euler (90,0,0);
        Enemy_Load_GO.SetActive (true);

        _Character_Animation = this.gameObject.GetComponent <Character_Animation>();
        _Enemy_AI_Control = Enemy_Load_GO.gameObject.GetComponent <Enemy_AI_Control>();
        _Character_Animation.On_Input_Character_GO (Enemy_Load_GO);
        
        On_Character_Animation ("Idle");
        if (Code_Enemy_Jenis == "Mini_Boss") {
            int x = -1;
            foreach (string s in GMP_Area_Generate.Ins.Cur_GMP_Map_Settings.L_Cur_C_Random_Mini_Boss_Skill) {
                Debug.Log ("Ap" + s);
                x++;
                Enemy_Load_GO.GetComponent <Enemy_Data_Tetap> ().A_Active_C_Enemy_Skill_Data[x].Skill_Name = s;
                Enemy_Load_GO.GetComponent <Enemy_Data_Tetap> ().A_Active_C_Enemy_Skill_Data[x].Skill_Level = 1;
            }
        } else if (Code_Enemy_Jenis == "Boss_Enemy") {
            int x = -1;
            foreach (string s in GMP_Area_Generate.Ins.Cur_GMP_Map_Settings.L_Cur_C_Random_Boss_Skill) {
                Debug.Log ("Ap2" + s);
                x++;
                Enemy_Load_GO.GetComponent <Enemy_Data_Tetap> ().A_Active_C_Enemy_Skill_Data[x].Skill_Name = s;
                Enemy_Load_GO.GetComponent <Enemy_Data_Tetap> ().A_Active_C_Enemy_Skill_Data[x].Skill_Level = 1;
            }
        }
        On_Enemy_Load_Skill ();
        
    }

    void On_Enemy_Load_Skill () {
        Enemy_Data_Tetap Dt = Enemy_Load_GO.GetComponent <Enemy_Data_Tetap> ();
        int Ak = -1;
        foreach (C_Enemy_Skill_Data x in Dt.A_Active_C_Enemy_Skill_Data) {
            Ak++;
            Debug.Log (x.Skill_Name);
            A_Skill_Active[Ak].Database_Load_Skill_Name_And_Skill_Level (Ak, x.Skill_Name, x.Skill_Level, this);
        }

        int Pv = -1;
        foreach (C_Enemy_Skill_Data x in Dt.A_Passive_C_Enemy_Skill_Data) {
            Pv++;
            A_Skill_Passive[Pv].Database_Load_Skill_Name_And_Skill_Level (Pv, x.Skill_Name, x.Skill_Level, this);
        }
    }
    #endregion
#endregion
#region Fixed_Pos_Y
    [SerializeField]
    float Fixed_Pos_Y = 0.0f; // z (200) = y (10) berarti selisih 20x lipat
    float Selisih_Y_Z = 20.0f;
#endregion
#region Flip
public string Cur_Flip = "Left"; // "Left" / "Right"
// Enemy_AI_Catch (Mine) / this - Enemy_2d_Online (NotMine) : 
public void On_Flip (string v) {
    Cur_Flip = v;
    if (Cur_Flip == "Left") {
        Asset_2d_Titik_Tengah.transform.localScale = new Vector3 (1,1,1);
        if (Tower_Infinity_Manager.Ins != null) {
            Tower_Infinity_Manager.Ins.On_Back_Raw_Player_Img ();
        }
         
    } else if (Cur_Flip == "Right") {
        Asset_2d_Titik_Tengah.transform.localScale = new Vector3 (-1,1,1);
        if (Tower_Infinity_Manager.Ins != null) {
            Tower_Infinity_Manager.Ins.On_Reversal_Raw_Player_Img ();
        }
    }
    this.gameObject.GetComponent <Enemy_2d_Online>().On_Mine_Lc_Cur_Flip (Cur_Flip);
}
#endregion
#region Character_Animation
// [HideInInspector]
Character_Animation _Character_Animation;
// Skill Active : IsMine
// This (Enemy) / Skill_Pengaturan_Animasi (Enemy)
// End Skill Active :
// Skill_Pengaturan_Animasi (Enemy).
// Idle :
// Enemy_AI_Control - Enemy_AI_Catch.
// Walk :
// Enemy_AI_Control - Enemy_AI_Catch.
// NotMine : this - Enemy_2d_Online :
Enemy_2d_Online _Enemy_2d_Online;
public void On_Character_Animation (string Code_V) { // Skill_Active_0, Idle, Skill_Active_1
    _Enemy_2d_Online = this.gameObject.GetComponent <Enemy_2d_Online>();
    if (_Enemy_2d_Online._PhotonView.IsMine) {
        _Character_Animation.On_Play_Animation (Code_V);
        _Enemy_2d_Online.On_Mine_Character_Animation (Code_V);
    } else {
        _Character_Animation.On_Play_Animation (Code_V);
    }

    if (!_Gender_Fix_Transform_Anim) {
            _Gender_Fix_Transform_Anim = Gender_Fix_Transform_Anim.gameObject.GetComponent <Gender_Fix_Transform_Anim>();
        }
     //    _Gender_Fix_Transform_Anim.On_Refresh_Gender_Fix_Transform ();
}
#endregion
#region b_Can_Move
// not use yet.
    [HideInInspector]
    public bool b_Can_Move = true;

    string Can_Move_Next_Animation = "";
    float Can_Move_Time = 0.0f;
    
    [HideInInspector] // Online_Player_2d (Stun) :
    public bool b_On_b_Can_Move_With_Time = false;
    // Skill_Pengaturan_Animasi
    public void On_b_Can_Move_With_Time (string Code_Animation_V, float Time) {
        Can_Move_Next_Animation = Code_Animation_V; Can_Move_Time = Time; b_On_b_Can_Move_With_Time = true;
        StartCoroutine (N_On_b_Can_Move_With_Time ());
    }

    IEnumerator N_On_b_Can_Move_With_Time () {
        yield return new WaitForSeconds (Can_Move_Time);
        _Character_Animation.On_Play_Animation (Can_Move_Next_Animation);
        if (Stun_Point == 0) {
            On_b_Can_Move ();
            On_b_Can_Skill ();
        }
        b_On_b_Can_Move_With_Time =false;
    }
    
    public void On_b_Can_Move () {
        b_Can_Move = true;
    }

    public void Off_b_Can_Move () {
        b_Can_Move = false;
    }
#endregion
#region b_Can_Skill
// not use yet.
    [HideInInspector]
    public bool b_Can_Skill = true;

    public void On_b_Can_Skill () {
        b_Can_Skill = true;
    }

    public void Off_b_Can_Skill () {
        b_Can_Skill = false;
    }
#endregion
#region Pendukung_Enemy
    public Pendukung_Enemy _Pendukung_Enemy;
    // Skill_Pengaturan_Animasi - Enemy_2d_Online :
    public void On_Fallback (Vector3 Str, float Max_Power_V, float Increase_Power_V, float Decrease_Power_V) {
        if (_Pendukung_Enemy) {
            if (_Pendukung_Enemy._Enemy_Fallback) { 
                
                _Pendukung_Enemy._Enemy_Fallback.On_Enemy_Fallback (Str, Max_Power_V, Increase_Power_V, Decrease_Power_V);
                
            }
        }
    }
#endregion
}
