using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
using Photon.Pun;
using Photon.Realtime;
public class GMP_Map_Settings : MonoBehaviourPunCallbacks {
    [Header ("Jika b_On_Testing_Boss TRUE = mini boss dan boss akan ke floor 1")]
    [SerializeField]
    bool b_On_Testing_Boss = false;
    [SerializeField]
    string GMP_Map_Name = "Grass";
    [SerializeField]
    int Max_Random_Boss_Skill = 4;
    int Cur_Random_Boss_Skill = 0;
    public List <string> L_Random_Boss_Skill;
    List <string> L_Random_Cur_Boss_Skill = new List <string>();

    [SerializeField]
    int Max_Random_Mini_Boss_Skill = 2;
    int Cur_Random_Mini_Boss_Skill = 0;
    public List <string> L_Random_Mini_Boss_Skill;
    List <string> L_Random_Cur_Mini_Boss_Skill = new List <string>();
    
    #region Field
    

    public List <C_Byte_Field> L_MC_C_Byte_Field = new List <C_Byte_Field> ();
    public List <C_Byte_Enemy> L_MC_C_Byte_Enemy = new List <C_Byte_Enemy> ();
    public List <C_Byte_Enemy> L_MC_C_Byte_Mini_Boss = new List <C_Byte_Enemy> ();
    public List <C_Byte_Enemy> L_MC_C_Byte_Boss_Enemy = new List <C_Byte_Enemy> ();
    public List <string> L_MC_C_Random_Boss_Skill = new List <string> ();
    public List <string> L_MC_C_Random_Mini_Boss_Skill = new List <string> ();

    public List <C_Byte_Field> L_Cur_C_Byte_Field = new List <C_Byte_Field> ();
    // Online_Tower_Infinity_Room :
    public void On_Add_L_Cur_C_Byte_Field (C_Byte_Field Inp) {L_Cur_C_Byte_Field.Add (Inp);}

    public List <C_Byte_Enemy> L_Cur_C_Byte_Enemy= new List <C_Byte_Enemy> ();
    // Online_Tower_Infinity_Room :
    public void On_Add_L_Cur_C_Byte_Enemy (C_Byte_Enemy Inp) {L_Cur_C_Byte_Enemy.Add (Inp);}

    public List <C_Byte_Enemy> L_Cur_C_Byte_Mini_Boss= new List <C_Byte_Enemy> ();
    // Online_Tower_Infinity_Room :
    public void On_Add_L_Cur_C_Byte_Mini_Boss (C_Byte_Enemy Inp) {L_Cur_C_Byte_Mini_Boss.Add (Inp);}

    public List <C_Byte_Enemy> L_Cur_C_Byte_Boss_Enemy= new List <C_Byte_Enemy> ();
    // Online_Tower_Infinity_Room :
    public void On_Add_L_Cur_C_Byte_Boss_Enemy (C_Byte_Enemy Inp) {L_Cur_C_Byte_Boss_Enemy.Add (Inp);}

    public List <string> L_Cur_C_Random_Boss_Skill= new List <string> ();
    // Online_Tower_Infinity_Room :
    public void On_Add_L_Cur_C_Random_Boss_Skill (string Inp) {L_Cur_C_Random_Boss_Skill.Add (Inp);}

    public List <string> L_Cur_C_Random_Mini_Boss_Skill= new List <string> ();
    // Online_Tower_Infinity_Room :
    public void On_Add_L_Cur_C_Random_Mini_Boss_Skill (string Inp) {L_Cur_C_Random_Mini_Boss_Skill.Add (Inp); Debug.Log ("Write");}
    
    void Add_L_C_Byte_Field (List <C_Byte_Field> List_V, C_Byte_Field Cur_Field) {
        C_Byte_Field New = new C_Byte_Field ();
        New.Name_Texture = Cur_Field.Name_Texture;
        New.Cd_Texture = Cur_Field.Cd_Texture;
        New.Pos_X = Cur_Field.Pos_X; New.Pos_Y = Cur_Field.Pos_Y; New.Pos_Z = Cur_Field.Pos_Z;
        New.Scale_X = Cur_Field.Scale_X; New.Scale_Y = Cur_Field.Scale_Y; New.Scale_Z = Cur_Field.Scale_Z;
        
        New.Name_Floor = GMP_Map_Name + " " + "F" + (L_MC_C_Byte_Field.Count +1).ToString ();
        int Total_Spawn_Area = GMP_Area_Generate.Ins.On_Search_Square_Field (New.Name_Texture, New.Cd_Texture).GetComponent <GMP_Square_Field> ().Count_Total_Spawn_Area (); 
        New.Total_Spawn_Area = Total_Spawn_Area;
        List_V.Add (New);
    }
    int y_mini_boss, y_boss_enemy;
    void Add_L_C_Enemy (List <C_Byte_Enemy> List_V, C_Byte_Enemy Cur_Target, string Code_V) { // Code_V = "Normal_Enemy", "Mini_Boss", "Boss"
        C_Byte_Enemy New = new C_Byte_Enemy ();
        New.Code_Name = Cur_Target.Code_Name;
        New.Nickname = Cur_Target.Nickname;
        New.Min_Power_Up = Cur_Target.Min_Power_Up;
        New.Max_Power_Up = Cur_Target.Max_Power_Up;
        New.Level = Cur_Target.Level;
        New.Cur_Exp = Cur_Target.Cur_Exp;
        New.Rank = Cur_Target.Rank;
        New.Hp = Cur_Target.Hp;
        New.Mp = Cur_Target.Mp;
        New.Attack = Cur_Target.Attack;
        New.Defense = Cur_Target.Defense;
        New.Critical_Rate = Cur_Target.Critical_Rate;
        New.Critical_Damage = Cur_Target.Critical_Damage;
        New.Block_Chance = Cur_Target.Block_Chance;
        New.Penetration = Cur_Target.Penetration;
        New.Vitality = Cur_Target.Vitality;
        New.Mind = Cur_Target.Mind;
        New.Strength = Cur_Target.Strength;
        New.Agility = Cur_Target.Agility;

        New.Element_Room = Cur_Target.Element_Room;
        // Balancing System :
        On_Search_Balancing (New);
        // Give 1 Normal Enemy to all Room :
        if (Code_V == "Normal_Enemy") {
            New.Element_Room = Cur_Element_Room_For_Enemy;
            /*
            Cur_Enemy_Room_Minimum_1 ++;
            if (Cur_Enemy_Room_Minimum_1 < L_MC_C_Byte_Field.Count) {
                New.Element_Room = Cur_Enemy_Room_Minimum_1;
            } else {
                //setelah semua room terisi minimal 1 normal enemy maka :
                New.Element_Room = Random.Range (0,L_MC_C_Byte_Field.Count);
            }
            */
        } else if (Code_V == "Mini_Boss") { 
            foreach (string v in L_Random_Mini_Boss_Skill) {
                L_Random_Cur_Mini_Boss_Skill.Add (v);
            }

            // Cur_Random_Mini_Boss_Skill = Max_Random_Mini_Boss_Skill;
            int xi = 0;
            for (xi = 0; xi <Max_Random_Mini_Boss_Skill; xi++) {
                y_mini_boss = 0;
                //foreach (string x in L_Random_Cur_Mini_Boss_Skill) {
                    y_mini_boss = Random.Range (0, L_Random_Cur_Mini_Boss_Skill.Count);
                    L_MC_C_Random_Mini_Boss_Skill.Add (L_Random_Cur_Mini_Boss_Skill[y_mini_boss]);
                  //  break;
                //}
                 L_Random_Cur_Mini_Boss_Skill.RemoveAt (y_mini_boss);
            } 
            

            // Room 2-7.
            if (!b_On_Testing_Boss) {
                New.Element_Room = Random.Range (1,L_MC_C_Byte_Field.Count-1); // Random.Range Max tidak masuk dalam hitungan random.
            } else {
                New.Element_Room = 0;
            }

        } else if (Code_V == "Boss_Enemy") {
            foreach (string v in L_Random_Boss_Skill) {
                L_Random_Cur_Boss_Skill.Add (v);
            }

            // Cur_Random_Boss_Skill = Max_Random_Boss_Skill;
            int xi = 0;
            for (xi = 0; xi <Max_Random_Boss_Skill; xi++) {
                y_boss_enemy = 0;
                // foreach (string x in L_Random_Cur_Boss_Skill) {
                    y_boss_enemy = Random.Range (0, L_Random_Cur_Boss_Skill.Count);
                    L_MC_C_Random_Boss_Skill.Add (L_Random_Cur_Boss_Skill[y_boss_enemy]);
                  //  break;
                //}
                 L_Random_Cur_Boss_Skill.RemoveAt (y_boss_enemy);
            } 

            // Room Terakhir
            if (!b_On_Testing_Boss) {
                New.Element_Room = (L_MC_C_Byte_Field.Count-1);
            } else {
                New.Element_Room = 0;
            }
            
        }

        New.Element_Spawn = Random.Range (0,L_MC_C_Byte_Field[New.Element_Room].Total_Spawn_Area);
        
        List_V.Add (New);
    }
        #region Field_Settings
        public int Total_Room_In_Map = 8;
        public int Total_Enemy_Room = 18;
        public int Total_Mini_Boss_Map = 1;
        public int Total_Boss_Enemy_Map = 1;
        // Online_Tower_Infinity_Room :
        public void MC_Create_Field () {
            On_MC_Create_Byte_Data_Room_In_Map ();
            On_MC_Create_Byte_Data_Enemy_In_Map ();
            On_MC_Create_Byte_Data_Mini_Boss_In_Map ();
            On_MC_Create_Byte_Data_Boss_Enemy_In_Map ();
            Online_Tower_Infinity_Room.Ins.On_MC_Finish_Generate_Byte_Data ();
        }
        int Loading_Field_Process = 0;
        int Loading_Field_Process_Max = 3;
        void On_Refresh_Field_Process () {
            Loading_Field_Process = 0;
            Loading_Field_Process_Max =3;
        }

        void On_Increase_Field_Process () {
            Loading_Field_Process ++;
            if (Loading_Field_Process >= Loading_Field_Process_Max) {
                On_Refresh_Field_Process ();
                Online_Tower_Infinity_Room.Ins.On_Finish_Ld_Process_Byte_Data ();
            }
        }

        void On_Finish_Loading_First () {
            Online_Tower_Infinity_Room.Ins.Increase_Loading_Room_Rpc ("On_MC_Finish_Generate_Byte_Data_2");
        }

            #region Total_Room_In_Map
                #region Create_Byte_Data (MC)
                int Cur_Room_In_Map = 0;
                public void On_MC_Create_Byte_Data_Room_In_Map () {
                    L_Database_Once_C_Byte_Field = new List <C_Byte_Field>();
                    foreach (C_Byte_Field s in L_Database_C_Byte_Field) {
                        L_Database_Once_C_Byte_Field.Add (s);
                    }
                    Cur_Room_In_Map = Total_Room_In_Map;
                    int x = Cur_Room_In_Map;
                    for (x = Cur_Room_In_Map; x > 0; x--) {
                        C_Byte_Field Target = L_Database_Once_C_Byte_Field[Random.Range (0, L_Database_Once_C_Byte_Field.Count)];
                        Add_L_C_Byte_Field (L_MC_C_Byte_Field, Target);
                        L_Database_Once_C_Byte_Field.Remove (Target);
                    }
                }
                #endregion
                #region Process_Byte_Data
                // Online_Tower_Infinity_Room :
                public void On_Process_Room_In_Map () {
                    int x = 0;
                    for (x = 0; x < L_Cur_C_Byte_Field.Count; x++) {
                        
                        GameObject Ins_Room_Enemy_Parent = GameObject.Instantiate (GMP_Area_Generate.Ins.Room_Enemy_Parent_Sample);
                        Ins_Room_Enemy_Parent.transform.SetParent (GMP_Area_Generate.Ins.A_Ins_Room_Enemy_Parent);
                        
                        GameObject Ins_Square_Field = GameObject.Instantiate (GMP_Area_Generate.Ins.On_Search_Square_Field (L_Cur_C_Byte_Field[x].Name_Texture, L_Cur_C_Byte_Field[x].Cd_Texture));
                        Ins_Square_Field.transform.SetParent (GMP_Area_Generate.Ins.A_Ins_Square_Field);
                        Ins_Square_Field.transform.localPosition = new Vector3 (L_Cur_C_Byte_Field[x].Pos_X, L_Cur_C_Byte_Field[x].Pos_Y, L_Cur_C_Byte_Field[x].Pos_Z);
                        Ins_Square_Field.transform.localScale = new Vector3 (L_Cur_C_Byte_Field[x].Scale_X, L_Cur_C_Byte_Field[x].Scale_Y, L_Cur_C_Byte_Field[x].Scale_Z);
                        
                        Ins_Square_Field.GetComponent <GMP_Square_Field> ().On_Input_Data_To_GMP_Square_Field (L_Cur_C_Byte_Field[x].Name_Floor, x);
                        
                        
                    }
                    On_Finish_Loading_First ();
                }
                #endregion
            #endregion
            #region Total_Enemy_Room
                #region Create_Byte_Data (MC)
                int Cur_Element_Room_For_Enemy = 0;
                int Cur_Enemy_Room_Minimum_1 = -1;
                public void On_MC_Create_Byte_Data_Enemy_In_Map() {
                    Cur_Enemy_Room_Minimum_1 = -1;
                    
                    int y = 0;
                    for (y =0; y < Total_Room_In_Map; y++) {
                        Cur_Element_Room_For_Enemy = y;
                        int x = Total_Enemy_Room;
                        for (x = Total_Enemy_Room; x > 0; x--) {
                            C_Byte_Enemy Target = L_Database_C_Byte_Enemy[Random.Range (0, L_Database_C_Byte_Enemy.Count)];
                            Add_L_C_Enemy (L_MC_C_Byte_Enemy, Target, "Normal_Enemy");
                        }
                    }
                }
                #endregion
                #region Process_Byte_Data
                // Online_Tower_Infinity_Room :
                public void On_Process_Enemy_In_Map () {
                    int x = 0;
                    for (x = 0; x < L_Cur_C_Byte_Enemy.Count; x++) {
                        
                       if (PhotonNetwork.IsMasterClient) {
                            
                            C_Home_Status New_Home_Status = new C_Home_Status ();
                            GameObject Ins = PhotonNetwork.InstantiateSceneObject (GMP_Area_Generate.Ins.Enemy_Sample.name, new Vector3 (0,0,0), Quaternion.Euler (0,0,0));
                            // Dont_Destroy_On_Load.Ins._System_Settings.Conv_C_Byte_Enemy_To_C_Home_Status (L_Cur_C_Byte_Enemy[x],New_Home_Status);
                            // Debug.LogError ("Enemy Hp = " + New_Home_Status.Hp);
                            Ins.GetComponent <Enemy_2d_Online> ().MC_Send_Id_Enemy (x, "Normal_Enemy");
                            Ins.transform.SetParent (GMP_Area_Generate.Ins.A_Ins_Room_Enemy_Parent.GetChild(L_Cur_C_Byte_Enemy[x].Element_Room));
                            // Spawn :
                            GMP_Square_Field Target_Ins_Square_Field = GMP_Area_Generate.Ins.A_Ins_Square_Field.GetChild(L_Cur_C_Byte_Enemy[x].Element_Room).GetComponent <GMP_Square_Field>();
                            Ins.transform.position = Target_Ins_Square_Field.A_Spawn_Area.GetChild (L_Cur_C_Byte_Enemy[x].Element_Spawn).transform.position;
                            
                        }
                        
                    }
                    On_Increase_Field_Process ();
                }
                #endregion
            #endregion
            #region Total_Mini_Boss
                #region Create_Byte_Data (MC)
                int Cur_Mini_Boss_In_Map = 0;
                public void On_MC_Create_Byte_Data_Mini_Boss_In_Map() {
                    Cur_Mini_Boss_In_Map = Total_Mini_Boss_Map;
                    int x = Cur_Mini_Boss_In_Map;
                    for (x = Cur_Mini_Boss_In_Map; x > 0; x--) {
                        C_Byte_Enemy Target = L_Database_C_Byte_Mini_Boss[Random.Range (0, L_Database_C_Byte_Mini_Boss.Count)];
                        Add_L_C_Enemy (L_MC_C_Byte_Mini_Boss, Target, "Mini_Boss");
                    }
                }
                #endregion
                #region Process_Byte_Data
                // Online_Tower_Infinity_Room :
                public void On_Process_Mini_Boss_In_Map () {
                    int x = 0;
                    for (x = 0; x < L_Cur_C_Byte_Mini_Boss.Count; x++) {
                        
                       if (PhotonNetwork.IsMasterClient) {
                            
                            C_Home_Status New_Home_Status = new C_Home_Status ();
                            GameObject Ins = PhotonNetwork.InstantiateSceneObject (GMP_Area_Generate.Ins.Enemy_Sample.name, new Vector3 (0,0,0), Quaternion.Euler (0,0,0));
 
                            Ins.GetComponent <Enemy_2d_Online> ().MC_Send_Id_Enemy (x, "Mini_Boss");
                            
                            Ins.transform.SetParent (GMP_Area_Generate.Ins.A_Ins_Room_Enemy_Parent.GetChild(L_Cur_C_Byte_Mini_Boss[x].Element_Room));
                            // Spawn :
                            GMP_Square_Field Target_Ins_Square_Field = GMP_Area_Generate.Ins.A_Ins_Square_Field.GetChild(L_Cur_C_Byte_Mini_Boss[x].Element_Room).GetComponent <GMP_Square_Field>();
                            Ins.transform.position = Target_Ins_Square_Field.A_Spawn_Area.GetChild (L_Cur_C_Byte_Mini_Boss[x].Element_Spawn).transform.position;
                            
                        }
                        
                    }
                    On_Increase_Field_Process ();
                }
                #endregion
            #endregion
             #region Boss_Enemy
                #region Create_Byte_Data (MC)
                int Cur_Boss_Enemy_In_Map = 0;
                public void On_MC_Create_Byte_Data_Boss_Enemy_In_Map() {
                    Cur_Boss_Enemy_In_Map = Total_Boss_Enemy_Map;
                    int x = Cur_Boss_Enemy_In_Map;
                    for (x = Cur_Boss_Enemy_In_Map; x > 0; x--) {
                        C_Byte_Enemy Target = L_Database_C_Byte_Boss_Enemy[Random.Range (0, L_Database_C_Byte_Boss_Enemy.Count)];
                        Add_L_C_Enemy (L_MC_C_Byte_Boss_Enemy, Target, "Boss_Enemy");
                    }
                }
                #endregion
                #region Process_Byte_Data
                // Online_Tower_Infinity_Room :
                public void On_Process_Boss_Enemy_In_Map () {
                    int x = 0;
                    for (x = 0; x < L_Cur_C_Byte_Boss_Enemy.Count; x++) {
                        
                       if (PhotonNetwork.IsMasterClient) {
                            
                            C_Home_Status New_Home_Status = new C_Home_Status ();
                            GameObject Ins = PhotonNetwork.InstantiateSceneObject (GMP_Area_Generate.Ins.Enemy_Sample.name, new Vector3 (0,0,0), Quaternion.Euler (0,0,0));
 
                            Ins.GetComponent <Enemy_2d_Online> ().MC_Send_Id_Enemy (x, "Boss_Enemy"); // Enemy_2d_Online, Ctrl+F Enemy_2d.
                            Ins.transform.SetParent (GMP_Area_Generate.Ins.A_Ins_Room_Enemy_Parent.GetChild(L_Cur_C_Byte_Boss_Enemy[x].Element_Room));
                            // Spawn :
                            GMP_Square_Field Target_Ins_Square_Field = GMP_Area_Generate.Ins.A_Ins_Square_Field.GetChild(L_Cur_C_Byte_Boss_Enemy[x].Element_Room).GetComponent <GMP_Square_Field>();
                            Ins.transform.position = Target_Ins_Square_Field.A_Spawn_Area.GetChild (L_Cur_C_Byte_Boss_Enemy[x].Element_Spawn).transform.position;
                        }
                        
                    }
                    On_Increase_Field_Process ();
                }
                #endregion
            #endregion
        #endregion
    #endregion
    #region Database_C_Byte_Field
    public List <C_Byte_Field> L_Database_C_Byte_Field = new List <C_Byte_Field> ();
    List <C_Byte_Field> L_Database_Once_C_Byte_Field = new List <C_Byte_Field>();
    #endregion
    #region Database_C_Byte_Enemy
    [Header ("Akan dibuat versi offline :")]
    public List <C_Byte_Enemy> L_Database_C_Byte_Enemy = new List <C_Byte_Enemy> ();
    public List <C_Byte_Enemy> L_Database_C_Byte_Mini_Boss  = new List <C_Byte_Enemy> ();
    public List <C_Byte_Enemy> L_Database_C_Byte_Boss_Enemy = new List <C_Byte_Enemy> ();
    #endregion
    #region Portal
    public GameObject [] L_Portal_GO = new GameObject[0];

    #endregion
    #region C_Enemy_Status_Balancing
    public C_Enemy_Status_Balancing [] A_C_Enemy_Status_Balancing;
    C_Enemy_Status_Balancing Cur_C_Enemy_Status_Balancing;
    void On_Search_Balancing (C_Byte_Enemy sb) {
        foreach (C_Enemy_Status_Balancing s in A_C_Enemy_Status_Balancing) {
            if (s.Type_Status_Balancing == sb.Type_Status_Balancing) {
                Cur_C_Enemy_Status_Balancing = s;
                On_C_Byte_Enemy_Combination_C_Enemy_Status_Balancing (sb ,Cur_C_Enemy_Status_Balancing);
                break;
            }
        }

    }

    void On_C_Byte_Enemy_Combination_C_Enemy_Status_Balancing (C_Byte_Enemy sb, C_Enemy_Status_Balancing Balancing) {
        Online_Player_Status Ps = Online_Tower_Infinity_Room.Ins.Player_Strongers_Hp.GetComponent <Online_Player_Status>();
        sb.Hp = Balancing.Hp_Times * Ps.GMP_C_Home_Status.Hp * 2 * (20* Online_Tower_Infinity_Room.Ins.A_Clone_Player_2d.Length / 100);
    }
    #endregion
    
}
