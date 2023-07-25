using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Online_Player_Status : MonoBehaviour {
    [SerializeField]
    Player_Status _Player_Status = new Player_Status ();

    [HideInInspector]
    public C_Home_Status _C_Home_Status = new C_Home_Status ();
   // [HideInInspector] // Pengaturan_Animasi / Online_Player_2d:
    public C_Home_Status GMP_C_Home_Status = new C_Home_Status ();

    Player_2d _Player_2d;
    int Your_Players;

    Online_Player_2d _Online_Player_2d;
    
    // Online_Player_2d : Mine
    #region Mine
        public void On_All_Load_Player_Status (int Your_Players_V) {
            Your_Players = Your_Players_V;
            On_Load_Local_Player_Status ();
        }

        #region Player_Status
        void On_Load_Local_Player_Status () {
            Dont_Destroy_On_Load.Ins._Data_Online.Send_Player_Status (this);
        }

        // ---- Data_Online :
        C_Home_Status _C_Home_Status_Before_Change;
        public void On_Got_Local_Player_Status (Player_Status x, C_Home_Status c) {
            // Sementara _C_Home_Status tidak perlu di send rpc karena tidak dipakai statusnya :
            _Player_Status = x; _C_Home_Status = new C_Home_Status (); _C_Home_Status_Before_Change = c; 
            On_C_Equipment_Status ();
            On_Send_Rpc_Player_Status ();
            On_GMP_C_Home_Status (_C_Home_Status);
        }
        
            #region C_Equipment_Status
                C_Equipment_Status _C_Equipment_Status;
                void On_C_Equipment_Status () {
                    _C_Equipment_Status = Dont_Destroy_On_Load.Ins._Data_Online.Total_C_Equipment_Status;
                    Debug.LogError (_C_Home_Status_Before_Change.Defense + " " +_C_Equipment_Status.Defense);
                    _C_Home_Status.Hp = _C_Home_Status_Before_Change.Hp +_C_Equipment_Status.Hp;
                    _C_Home_Status.Mp = _C_Home_Status_Before_Change.Mp +_C_Equipment_Status.Mp;
                    _C_Home_Status.Attack = _C_Home_Status_Before_Change.Attack +_C_Equipment_Status.Attack;
                    _C_Home_Status.Defense = _C_Home_Status_Before_Change.Defense +_C_Equipment_Status.Defense;
                    _C_Home_Status.Critical_Rate = _C_Home_Status_Before_Change.Critical_Rate +_C_Equipment_Status.Critical_Rate;
                    _C_Home_Status.Critical_Damage = _C_Home_Status_Before_Change.Critical_Damage +_C_Equipment_Status.Critical_Damage;
                    _C_Home_Status.Block_Chance = _C_Home_Status_Before_Change.Block_Chance +_C_Equipment_Status.Block_Chance;
                    _C_Home_Status.Penetration = _C_Home_Status_Before_Change.Penetration +_C_Equipment_Status.Penetration;
                    _C_Home_Status.Vitality = _C_Home_Status_Before_Change.Vitality +_C_Equipment_Status.Vitality;
                    _C_Home_Status.Mind = _C_Home_Status_Before_Change.Mind +_C_Equipment_Status.Mind;
                    _C_Home_Status.Strength = _C_Home_Status_Before_Change.Strength +_C_Equipment_Status.Strength;
                    _C_Home_Status.Agility = _C_Home_Status_Before_Change.Agility +_C_Equipment_Status.Agility;
                }
            #endregion
        void On_Send_Rpc_Player_Status () {
            Online_Tower_Infinity_Room.Ins.Lc_Load_Player_Status (Your_Players, _Player_Status);
        }
        
        #endregion
        #region GMP_C_Home_Status
        // Sementara _C_Home_Status tidak perlu di send rpc karena tidak dipakai statusnya : (NOW DIPAKAI)
        void On_GMP_C_Home_Status (C_Home_Status C) {
            C_Home_Status New = new C_Home_Status ();
            New.Level = C.Level;
            New.Cur_Exp = C.Cur_Exp;
            New.Rank = C.Rank;
            New.Hp = C.Hp;
            New.Mp = C.Mp;
            New.Attack = C.Attack;
            New.Defense = C.Defense;
            New.Critical_Rate = C.Critical_Rate;
            New.Critical_Damage = C.Critical_Damage;
            New.Block_Chance = C.Block_Chance;
            New.Penetration = C.Penetration;
            New.Vitality = C.Vitality;
            New.Mind = C.Mind;
            New.Strength = C.Strength;
            New.Agility = C.Agility;

            GMP_C_Home_Status = New;
            On_Refresh_All ();
        }
        
        void On_Refresh_All () {
            
            Tower_Infinity_Manager.Ins.On_Refresh_Hp (GMP_C_Home_Status.Hp,_C_Home_Status.Hp);
            Tower_Infinity_Manager.Ins.On_Refresh_Mp (GMP_C_Home_Status.Mp,_C_Home_Status.Mp);
            Tower_Infinity_Manager.Ins.On_Refresh_Nickname (_Player_Status.Nickname);
            On_Alive ();
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
                    _Player_2d.On_b_Can_Move ();
                    _Player_2d.On_b_Can_Skill ();
            } else {
                if (!_Player_2d.b_On_b_Can_Move_With_Time) {
                    _Player_2d.Off_b_Can_Move ();
                    _Player_2d.Off_b_Can_Skill ();
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
    #endregion
    #region Ability
        // Player_2d :
        public void On_Mine_Change_Cur_Hp (int Cur_Hp, string Code_Skill_Hit) { // Dmaage : Mines && Heal : Plus
            GMP_C_Home_Status.Hp = Cur_Hp;
            Tower_Infinity_Manager.Ins.On_Refresh_Hp (GMP_C_Home_Status.Hp,_C_Home_Status.Hp);
            if (GMP_C_Home_Status.Hp <= 0) {On_Mine_Dead ();} else {_Player_2d._Player_AI_Utama._Player_AI_Use_Item.On_Check_Use_Hp_Potion ();}
            if (Code_Skill_Hit != "") {
                On_Hit_Particle ();
            }
            Tower_Infinity_Manager.Ins.On_Refresh_Syarat_Skill_Active ();
        }
        // Player_2d :
        public void On_Not_Mine_Change_Cur_Hp (int Cur_Hp, string Code_Skill_Hit) { // Dmaage : Mines && Heal : Plus
            GMP_C_Home_Status.Hp = Cur_Hp;
           // if (GMP_C_Home_Status.Hp <= 0) {Debug.Log ("Dead");}
           if (Code_Skill_Hit != "") {
                On_Hit_Particle ();
           }
        }

        #region Change_Status
        // Online_Player_2d :
        public void On_Mine_Change_Status (string Code_Status, int Value_Status) { // Dmaage : Mines && Heal : Plus
            if (Code_Status == "Mp" ) {
                GMP_C_Home_Status.Mp = Value_Status;
                Tower_Infinity_Manager.Ins.On_Refresh_Mp (GMP_C_Home_Status.Mp,_C_Home_Status.Mp);
                _Player_2d._Player_AI_Utama._Player_AI_Use_Item.On_Check_Use_Mp_Potion ();
            }else if (Code_Status == "Incoming_Damage_Percent") {
                Incoming_Damage_Percent = Value_Status;
            } else if (Code_Status == "Attack") {
                GMP_C_Home_Status.Attack = Value_Status;
            } else if (Code_Status == "Defense") {
                GMP_C_Home_Status.Defense = Value_Status;
            } else if (Code_Status == "Stun") {
                Stun_Point = Value_Status;
            }  else if (Code_Status == "Critical_Rate") {
                GMP_C_Home_Status.Critical_Rate = Value_Status;
            }  else if (Code_Status == "Critical_Damage") {
                GMP_C_Home_Status.Critical_Damage = Value_Status;
            } else if (Code_Status == "Immunity") {
                Immunity_Point = Value_Status;
                On_Change_Immunity_Point ();
            }
            Tower_Infinity_Manager.Ins.On_Refresh_Syarat_Skill_Active ();

        }
        // Online_Player_2d :
        public void On_Not_Mine_Change_Status (string Code_Status, int Value_Status) { // Dmaage : Mines && Heal : Plus
            if (Code_Status == "Mp" ) {
                GMP_C_Home_Status.Mp = Value_Status;
            }else if (Code_Status == "Incoming_Damage_Percent") {
                Incoming_Damage_Percent = Value_Status;
            }  else if (Code_Status == "Attack") {
                GMP_C_Home_Status.Attack = Value_Status;
            } else if (Code_Status == "Defense") {
                GMP_C_Home_Status.Defense = Value_Status;
            } else if (Code_Status == "Stun") {
                Stun_Point = Value_Status;
            }  else if (Code_Status == "Critical_Rate") {
                GMP_C_Home_Status.Critical_Rate = Value_Status;
            }  else if (Code_Status == "Critical_Damage") {
                GMP_C_Home_Status.Critical_Damage = Value_Status;
            } else if (Code_Status == "Immunity") {
                Immunity_Point = Value_Status;
                On_Change_Immunity_Point ();
            }
           
        }
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
                            Add_L_Int_Value ( _C_Home_Status.Hp * ying.Value_Int_1 /100 );
                        }

                    }

                    if (ying._Ability_Type == Ability_Type.Increase_Mp_Percent) { // TOP
                        Top_Ability_Type = ying._Ability_Type;
                        Add_L_Int_Value ( _C_Home_Status.Mp * ying.Value_Int_1 /100 );
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Mp_Percent) {
                        if (yang._Skill_Target == Skill_Target.Self) { // TOP
                            Top_Ability_Type = ying._Ability_Type;
                            Add_L_Int_Value ( _C_Home_Status.Mp * ying.Value_Int_1 /100 );
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

                    if (ying._Ability_Type == Ability_Type.Increase_Coming_Damage_Percent) {
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
                            Add_L_Int_Value ( GMP_C_Home_Status.Hp * ying.Value_Int_1 /100 );
                        }
                    }
                    if (ying._Ability_Type == Ability_Type.Decrease_Cur_Mp_Percent) {
                        if (yang._Skill_Target == Skill_Target.Self) { // TOP
                            Top_Ability_Type = ying._Ability_Type;
                            Add_L_Int_Value ( GMP_C_Home_Status.Mp * ying.Value_Int_1 /100 );
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
                    _Online_Player_2d.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Hp_Percent) { // TOP
                    _Online_Player_2d.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Mp_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Mp", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Mp_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Mp", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Atk_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Attack", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Atk_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Attack", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Def_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Defense", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Def_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Defense", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Coming_Damage_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Incoming_Damage_Percent", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.stun) { // TOP
                    _Online_Player_2d.On_Change_Status ("Stun", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Critical_Rate_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Critical_Rate", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Increase_Critical_Damage_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Critical_Damage", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Immunity) { // TOP
                    _Online_Player_2d.On_Change_Status ("Immunity", Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Cur_Hp_Percent) { // TOP
                    _Online_Player_2d.On_Heal_Direct (Total_Int_Value);
                }
                if (Top_Ability_Type == Ability_Type.Decrease_Cur_Mp_Percent) { // TOP
                    _Online_Player_2d.On_Change_Status ("Mp", Total_Int_Value);
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
                    _Online_Player_2d.On_Change_Status ("Stun", Time_Total_Int_Value);
                }
                if (Time_Top_Ability_Type == Ability_Type.Immunity) { // TOP
                    _Online_Player_2d.On_Change_Status ("Immunity", Time_Total_Int_Value);
                }
            }
            #endregion
        
    #endregion
    #region Hit_Particle
        Transform _Skill_Hit;
        void On_Hit_Particle () {
            _Skill_Hit = Home_System.Ins.Skill_Hit;
            foreach (Transform x in _Skill_Hit.transform) {
                Skill_Hit Sk = x.GetComponent <Skill_Hit>();
                Sk.On_Instantiate_Particle (this.gameObject.transform);
            }
        }
    #endregion
    #region Dead
    bool b_Dead = false;

    void On_Mine_Dead () {
        if (!b_Dead) {
            Debug.Log ("Dead"); 
            b_Dead = true;
            Online_Tower_Infinity_Room.Ins.On_Lc_Player_Dead ();
            _Online_Player_2d.On_Mine_Dead ();
            this.gameObject.SetActive (false);
        }
    }
    // Online_Player_2d :
    public void On_Not_Mine_Dead () {
        
        if (!b_Dead) {
            Debug.Log ("Dead"); 
            b_Dead = true;
            this.gameObject.SetActive (false);
        }
    }

    void On_Alive () {
        b_Dead = false;
    }
    #endregion
    #region Not_Mine
        bool b_On_Refresh_Player_Status = false; // Blm di load player status. jika ada perubahan maka bisa di false kembali.
        void On_Change_Asset () { // jika player menggganti rambut di room (INI BLM DIPAKAI FUNGSINYA)
            b_On_Refresh_Player_Status = false; 
        }
        // Online_Tower_Infinity_Room :
        public void On_Got_Local_Player_Status (int Id, string Guest_Id, string Nickname, string Token_Google, int Accept_Privacy_Policy, string Gender, string Hair_Type, string Face, string Hair_Colour, string Skin_Tone, string Body_Costume, string Helmet, string Weapon, string Ring, string Earring, string Offhand, string Glove, string Boot, string Cape, int Hair_Value_Colour, int Hair_Value_Dark) {
            if (!b_On_Refresh_Player_Status) { // untuk clone yang blm LOAD. boleh melakukan load.
                b_On_Refresh_Player_Status = true;
                _Player_Status.Id = Id;
                _Player_Status.Guest_Id = Guest_Id;
                _Player_Status.Nickname = Nickname;
                _Player_Status.Token_Google = Token_Google;
                _Player_Status.Accept_Privacy_Policy = Accept_Privacy_Policy;
                _Player_Status.Gender = Gender;
                _Player_Status.Hair_Type = Hair_Type;
                _Player_Status.Face = Face;
                _Player_Status.Hair_Colour = Hair_Colour;
                _Player_Status.Skin_Tone = Skin_Tone;
                _Player_Status.Body_Costume = Body_Costume;
                _Player_Status.Helmet = Helmet;
                _Player_Status.Weapon = Weapon;
                _Player_Status.Ring = Ring;
                _Player_Status.Earring = Earring;
                _Player_Status.Offhand = Offhand;
                _Player_Status.Glove = Glove;
                _Player_Status.Boot = Boot;
                _Player_Status.Cape = Cape;
                _Player_Status.Hair_Value_Colour = Hair_Value_Colour;
                _Player_Status.Hair_Value_Dark =Hair_Value_Dark;

                _Player_2d = GetComponent<Player_2d>();
                _Online_Player_2d = this.GetComponent <Online_Player_2d> ();
                _Player_2d.On_Input_Player_Status (_Player_Status);
                _Player_2d.On_Load_Refresh_Asset ("Online_Clone");
            }
        }
    #endregion
}
