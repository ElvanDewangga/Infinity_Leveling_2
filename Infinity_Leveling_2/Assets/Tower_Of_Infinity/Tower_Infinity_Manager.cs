using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Starsky;
using Cinemachine;
public class Tower_Infinity_Manager : MonoBehaviour {
    public GameObject All_Tower_Infinity_Go;
    public GameObject Tower_Infinity_System_Go;
    public static Tower_Infinity_Manager Ins;
    public Transform A_Tower_Infinity_Clone;
   // Tower_Infinity_Choose :
   public GameObject Player_2d_Sample;
   void Awake () {
        Ins = this;
       // Player_2d_Sample = GameObject.Find ("Player_2d_Sample"); 
   }
     #region Tower_Infinity_Canvas
     [SerializeField]
     Canvas _Tower_Infinity_Canvas;
     
     public void On_Tower_Infinity_Canvas () {
          _Tower_Infinity_Canvas.gameObject.SetActive (true);
     }

     public void Off_Tower_Infinity_Canvas () {
          _Tower_Infinity_Canvas.gameObject.SetActive (false);
     }

    // TMP_Text Ready_But_Tx; 
     bool b_Ready = false; 
     public Button Start_Hunt_Button;
     [SerializeField]
     Button Ready_Button;
     [SerializeField]
     Sprite Ready_Sp, Ready_Cancel_Sp;
     
     public void On_Cli_Ready () {
          if (!b_Ready) {
               b_Ready = true;
               Ready_Button.image.sprite = Ready_Cancel_Sp;
               Online_Tower_Infinity_Room.Ins.Lc_On_Ready ();
               
          } else {
               b_Ready = false;
               Ready_Button.image.sprite = Ready_Sp;
               Online_Tower_Infinity_Room.Ins.Lc_Off_Ready ();
          }
     }

     void On_Refresh_Tab () {
          On_Right_Tab_Refresh ();
     }
          #region Right_Tab
          
          [SerializeField]
          Transform Room_Layout_Parent;
          [SerializeField]
          GameObject Room_Players_Button_Sample;
          // Online_Tower_Infinity_Room :
          public List <GameObject>  L_Room_Players_Button = new List <GameObject> ();
          // Online_Tower_Infinity_Room :
          public int Total_Button;
          [SerializeField]
          TMP_Text Number_Of_Players_Tx;
          public void On_Number_Of_Players_Tx (int V) {
               Number_Of_Players_Tx.text = "("+ V+"/6)";
          }

          void On_Right_Tab_Refresh () {
               
          }

          // Online_Tower_Infinity_Room :
          public void On_Input_Player (bool MC_V, string Nickname_V, GameObject Player_GO) {
               Total_Button ++;
               GameObject Crt = GameObject.Instantiate (Room_Players_Button_Sample);
               Crt.transform.SetParent (Room_Layout_Parent);
               Crt.GetComponent <RectTransform> ().localScale = new Vector3 (1,1,1);
               Crt.GetComponent <Room_Players_Button> ().On_Input_Player (MC_V, Nickname_V, Player_GO);
               Crt.SetActive (true);
               L_Room_Players_Button.Add (Crt);
          // On_Refresh_Tab ();
          }

          // Online_Tower_Infinity_Room : (On_Change_MC) :
          public void On_Change_Player (int Target, bool MC_V, string Nickname_V, GameObject Player_GO) {
               L_Room_Players_Button[Target].GetComponent <Room_Players_Button> ().On_Input_Player (MC_V, Nickname_V, Player_GO);
          }
          
          public void On_Remove_Player (int Code) {
               Total_Button --;
               GameObject Target = L_Room_Players_Button[Code];
               L_Room_Players_Button.Remove (Target);
               Destroy (Target);

          }

          // Online_Tower_Infinity_Room :
          public void On_Input_Ready (GameObject Player_V, bool Ready) {
               foreach (GameObject x in L_Room_Players_Button) {
                    Room_Players_Button Rp = x.GetComponent <Room_Players_Button> ();
                    if (Rp._Player_GO == Player_V) {
                         Rp.On_Input_Ready (Ready);
                         break;
                    }
               }  
          }
          
          // Button & Mini_Menu_1 :
          public void Cli_Back_Home () {
               Online_Tower_Infinity_Room.Ins.Cli_Back_Home ();
          }

          public void Cli_Start_Hunt () {
               Online_Tower_Infinity_Room.Ins.On_Start_Hunt ();
               On_Refresh_GMP_Item_Button ();
          }
          #endregion
     #endregion
     #region Cinemachine
     // Online_Tower_Infinity_Room :
     [SerializeField]
     CinemachineVirtualCamera Vcam;
     public void On_Change_Follow_Cinemachine (Transform x) {
          // vcam.LookAt = bla;
          Vcam.Follow = x;
          _Camera_Sementara.On_Change_Target_Follow (x);
     }
     // Online_Tower_Infinity_Room
     public Camera_Sementara _Camera_Sementara;
     #endregion
     #region Music_Script
          // Online_Tower_Infinity_Room :
          public void On_Start_Music () {
               Sound_System.Ins._Music.On_Clear_Playlist ();
               Sound_System.Ins._Music.On_Add_Playlist ("Infinity_Tower_1");
               Sound_System.Ins._Music.On_Add_Playlist ("Infinity_Tower_2");
               Sound_System.Ins._Music.On_Add_Playlist ("Infinity_Tower_3");
               Sound_System.Ins._Music.On_Next_Playlist ();
          }
     #endregion
     #region GMP
     // Online_Tower_Infinity_Room :
     
     public void On_Finish_Loading_Generate () {
          Off_Tower_Infinity_Canvas ();
          Dont_Destroy_On_Load.Ins._Player_2d.On_Transfer_Skill_To_Tower_Infinity_Manager ();
          Loading_Canvas.Ins.Off_Loading_2 ();
          DualJoystickPlayerController.Ins.On_Dual_Joy_Stick ();
          GMP_Canvas.gameObject.SetActive (true);
          GMP_Area_Generate.Ins.On_GMP_Masuk_Field ();
     }
     
          #region GMP_Canvas
          [SerializeField]
          Canvas GMP_Canvas;
          
               #region BG_GMP_Floor
               [SerializeField]
               TMP_Text GMP_Floor_Tx;
               // GMP_Area_Generate :
               public void On_Refresh_Floor_Tx (string s) {
                    GMP_Floor_Tx.text = s;
               }
               #endregion

               #region BG_GMP_Status
               [SerializeField]
               Slider GMP_Hp_Slider;
               [SerializeField]
               TMP_Text GMP_Hp_Text;
               [SerializeField]
               Slider GMP_Mp_Slider;
               [SerializeField]
               TMP_Text GMP_Mp_Text;
               [SerializeField]
               TMP_Text GMP_Nickname_Text;

               // Online_Player_Status :
               public void On_Refresh_Hp (int Cur, int Max) {
                    GMP_Hp_Slider.maxValue = Max;
                    GMP_Hp_Slider.value = Cur; 
                    GMP_Hp_Text.text = "HP " + Cur.ToString () + "/" + Max.ToString ();
               }
               // Online_Player_Status :
               public void On_Refresh_Mp (int Cur, int Max) {
                    GMP_Mp_Slider.maxValue = Max;
                    GMP_Mp_Slider.value = Cur;
                    GMP_Mp_Text.text = "MP " + Cur.ToString () + "/" + Max.ToString ();
               }

               public void On_Refresh_Nickname (string V) {
                    GMP_Nickname_Text.text = V;
               }

                #region Flip_Reversal_Raw
                    [SerializeField]
                    RawImage Raw_Player_Img;
                    // Player_2d :
                    public void On_Reversal_Raw_Player_Img () {
                         Raw_Player_Img.gameObject.transform.localScale = new Vector3 (-1,1,1);
                    }

                    public void On_Back_Raw_Player_Img () {
                         Raw_Player_Img.gameObject.transform.localScale = new Vector3 (1,1,1);
                    }
                #endregion
               #endregion
               #region BG_GMP_Skill_Active
               [SerializeField]
               GameObject GMP_Skill_Active_But_Sample;
               [SerializeField]
               GameObject BG_GMP_Skill_Active;
               [SerializeField]
               Skill_Data_Kumpulan [] A_GMP_Skill_Active;
               List <GMP_Skill_Button> L_GMP_Skill_Button = new List <GMP_Skill_Button> ();
               // this - Player_2d :
               public void On_Refresh_Skill_Active (Skill_Data_Kumpulan [] Sk) {
                    A_GMP_Skill_Active = Sk;
                   StartCoroutine (N_On_Refresh_Skill_Active ());
               }

               IEnumerator N_On_Refresh_Skill_Active () {
                    yield return new WaitUntil (() => GMP_Canvas.gameObject.activeInHierarchy);
                     foreach (Skill_Data_Kumpulan Sdk in A_GMP_Skill_Active) {
                         if (Sdk.Skill_Name != "") {
                              
                              GameObject Ins_Skill_But = GameObject.Instantiate (GMP_Skill_Active_But_Sample);
                              Ins_Skill_But.transform.SetParent (BG_GMP_Skill_Active.transform);
                              Ins_Skill_But.SetActive (true);
                              Ins_Skill_But.GetComponent <GMP_Skill_Button> ().On_Input_Data (Sdk, Online_Tower_Infinity_Room.Ins.Mine_Player_2d);
                              Ins_Skill_But.transform.localScale = new Vector3 (1,1,1);
                              L_GMP_Skill_Button.Add (Ins_Skill_But.GetComponent <GMP_Skill_Button> ()); 
                         }
                    }
                    On_Refresh_Syarat_Skill_Active ();
               }

               // this & GMP_Skill_Button, Sp_Slash_Continue :
               public void On_Refresh_Syarat_Skill_Active () {
                    foreach (GMP_Skill_Button Gmp_Button in L_GMP_Skill_Button) {
                         Gmp_Button.Check_b_Memenuhi_Syarat ();
                    }
               }
               #endregion
               #region BG_GMP_Skill_Passive
               [SerializeField]
               GameObject GMP_Skill_Passive_But_Sample;
               [SerializeField]
               GameObject BG_GMP_Skill_Passive;
               Skill_Data_Kumpulan [] A_GMP_Skill_Passive;
               // this - Player_2d :
               public void On_Refresh_Skill_Passive (Skill_Data_Kumpulan [] Sk) {
                    A_GMP_Skill_Passive = Sk;
               }
               #endregion
               #region GMP_Settings
              [SerializeField]
              Image Bg_GMP_Settings;

               public void On_GMP_Settings () {
                   // Notification_Canvas.Ins.On_Notification_2 ("Notification", "Are you sure you want quit ?", "Cancel", "Confirm", "", "Quit_Tower_Infinity");
                    Bg_GMP_Settings.gameObject.SetActive (true);
               }

               public void Off_GMP_Settings () {
                   // Notification_Canvas.Ins.On_Notification_2 ("Notification", "Are you sure you want quit ?", "Cancel", "Confirm", "", "Quit_Tower_Infinity");
                    Bg_GMP_Settings.gameObject.SetActive (false);
               }

               // Notification_Canvas :
               public void On_Quit () {
                    Bg_GMP_Settings.gameObject.SetActive (false);
                    Save_Give_Exp_To_Player ();
                    Cli_Back_Home ();
               } 

                    #region Auto_Skill
                    [SerializeField]
                    TMP_Text Auto_Skill_Tx;
                    int Cur_Auto_Skill = 0; // 0 = Off, 1 = On.
                    int Max_Auto_Skill = 1;

                    [SerializeField]
                    string Auto_Skill_Cur_Code = "";
                    
                    public void On_Left_Auto_Skill () {
                         Cur_Auto_Skill --;
                         On_Refresh_Auto_Skill ();
                    }

                    public void On_Right_Auto_Skill () {
                         Cur_Auto_Skill ++;
                         On_Refresh_Auto_Skill ();
                    }

                    void On_Refresh_Auto_Skill () {
                         if (Cur_Auto_Skill < 0) {
                              Cur_Auto_Skill = Max_Auto_Skill;
                         }
                         if (Cur_Auto_Skill > Max_Auto_Skill) {
                              Cur_Auto_Skill = 0;
                         }

                         if (Cur_Auto_Skill == 0) {
                              Auto_Skill_Tx.text = "Auto Skill: OFF";
                              Auto_Skill_Cur_Code = "Auto_Skill_Off";
                              foreach (GMP_Skill_Button x in L_GMP_Skill_Button) {
                                   x.Off_Auto_Skill ();
                              }
                              Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Skill.On_Turn_AI_Skill (false);
                         }
                         if (Cur_Auto_Skill == 1) {
                              Auto_Skill_Tx.text = "Auto Skill: ON";
                              Auto_Skill_Cur_Code = "Auto_Skill_On";
                              foreach (GMP_Skill_Button x in L_GMP_Skill_Button) {
                                   x.On_Auto_Skill ();
                              }
                              Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Skill.On_Turn_AI_Skill (true);
                         }
                    }
                    #endregion
                    #region Auto_Hp_Potion
                    void On_Refresh_GMP_Item_Button () {
                         Auto_Hp_Potion_Button.On_Input_Data (Online_Tower_Infinity_Room.Ins.Mine_Player_2d);
                         Auto_Mp_Potion_Button.On_Input_Data (Online_Tower_Infinity_Room.Ins.Mine_Player_2d);
                    }
                    [SerializeField] // Player_AI_Use_Item
                    public GMP_Item_Button Auto_Hp_Potion_Button;
                    [SerializeField]
                    TMP_Text Auto_Hp_Potion_Tx;
                    int Cur_Auto_Hp_Potion = 0; // 0 = Off, 1 = On.
                    int Max_Auto_Hp_Potion = 8;

                    [SerializeField]
                    string Auto_Hp_Potion_Cur_Code = "";
                    
                    public void On_Left_Auto_Hp_Potion () {
                         Cur_Auto_Hp_Potion --;
                         On_Refresh_Auto_Hp_Potion ();
                    }

                    public void On_Right_Auto_Hp_Potion () {
                         Cur_Auto_Hp_Potion ++;
                         On_Refresh_Auto_Hp_Potion ();
                    }

                    public void On_Disable_Auto_Hp_Potion () {
                         Cur_Auto_Hp_Potion = 0;
                         On_Refresh_Auto_Hp_Potion ();
                    }

                    void On_Refresh_Auto_Hp_Potion () {
                         if (Cur_Auto_Hp_Potion < 0) {
                              Cur_Auto_Hp_Potion = Max_Auto_Hp_Potion;
                         }
                         if (Cur_Auto_Hp_Potion > Max_Auto_Hp_Potion) {
                              Cur_Auto_Hp_Potion = 0;
                         }

                         if (Cur_Auto_Hp_Potion == 0) {
                              Auto_Hp_Potion_Tx.text = "HP - Auto Use Potion: OFF";
                              Auto_Hp_Potion_Cur_Code = "Auto_Hp_Potion_Off";
                              Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Use_Item.On_Auto_Hp_Potion (Cur_Auto_Hp_Potion * 10);
                              // Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Skill.On_Turn_AI_Skill (false);
                              Auto_Hp_Potion_Button.Off_Auto ();
                         }
                         if (Cur_Auto_Hp_Potion >= 1 && Cur_Auto_Hp_Potion <= 8) {
                              Auto_Hp_Potion_Tx.text = "HP - Auto Use Potion: " + (Cur_Auto_Hp_Potion * 10).ToString () + "%";
                              Auto_Hp_Potion_Cur_Code = "Auto_Hp_Potion_" + (Cur_Auto_Hp_Potion * 10).ToString ()+ "%";
                              Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Use_Item.On_Auto_Hp_Potion (Cur_Auto_Hp_Potion * 10);
                              Auto_Hp_Potion_Button.On_Auto ();
                         }
                    }
                    #endregion
                    #region Auto_Mp_Potion
                    [SerializeField] // Player_AI_Use_Item
                    public GMP_Item_Button Auto_Mp_Potion_Button;
                    [SerializeField]
                    TMP_Text Auto_Mp_Potion_Tx;
                    int Cur_Auto_Mp_Potion = 0; // 0 = Off, 1 = On.
                    int Max_Auto_Mp_Potion = 8;

                    [SerializeField]
                    string Auto_Mp_Potion_Cur_Code = "";
                    
                    public void On_Left_Auto_Mp_Potion () {
                         Cur_Auto_Mp_Potion --;
                         On_Refresh_Auto_Mp_Potion ();
                    }

                    public void On_Right_Auto_Mp_Potion () {
                         Cur_Auto_Mp_Potion ++;
                         On_Refresh_Auto_Mp_Potion ();
                    }

                    public void On_Disable_Auto_Mp_Potion () {
                         Cur_Auto_Mp_Potion = 0;
                         On_Refresh_Auto_Mp_Potion ();
                    }

                    void On_Refresh_Auto_Mp_Potion () {
                         if (Cur_Auto_Mp_Potion < 0) {
                              Cur_Auto_Mp_Potion = Max_Auto_Mp_Potion;
                         }
                         if (Cur_Auto_Mp_Potion > Max_Auto_Mp_Potion) {
                              Cur_Auto_Mp_Potion = 0;
                         }

                         if (Cur_Auto_Mp_Potion == 0) {
                              Auto_Mp_Potion_Tx.text = "Mp - Auto Use Potion: OFF";
                              Auto_Mp_Potion_Cur_Code = "Auto_Mp_Potion_Off";
                              Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Use_Item.On_Auto_Mp_Potion (Cur_Auto_Mp_Potion * 10);
                              // Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Skill.On_Turn_AI_Skill (false);
                              Auto_Mp_Potion_Button.Off_Auto ();
                         }
                         if (Cur_Auto_Mp_Potion >= 1 && Cur_Auto_Mp_Potion <= 8) {
                              Auto_Mp_Potion_Tx.text = "Mp - Auto Use Potion: " + (Cur_Auto_Mp_Potion * 10).ToString () + "%";
                              Auto_Mp_Potion_Cur_Code = "Auto_Mp_Potion_" + (Cur_Auto_Mp_Potion * 10).ToString ()+ "%";
                              Online_Tower_Infinity_Room.Ins.Mine_Player_2d._Player_AI_Utama._Player_AI_Use_Item.On_Auto_Mp_Potion (Cur_Auto_Mp_Potion * 10);
                              Auto_Mp_Potion_Button.On_Auto ();
                         }
                    }
                    #endregion
               #endregion
          #endregion

          #region GMP_Finish
          [SerializeField]
          Image GMP_Victory;
          [SerializeField]
          Image GMP_Defeat;
          // GMP_Area_Generate / Online_Tower_Infinity_Room :
          public void On_GMP_Finish (string V) {
               if (V == "Victory") {
                    On_Got_Exp (888);
                    GMP_Victory.gameObject.SetActive (true);
               } else if (V == "Defeat") {
                    GMP_Defeat.gameObject.SetActive (true);
               }
              // Save_Give_Exp_To_Player ();
          }

          public void On_Cli_Finish () {
               GMP_Victory.gameObject.SetActive (false);
               GMP_Defeat.gameObject.SetActive (false);
               Save_Give_Exp_To_Player ();
               Cli_Back_Home ();
          }

               #region Exp
                    [SerializeField]
                    int Total_Got_Exp = 0;
                    // ONline_Tower_Infinity_Room (Room) & Enemy_2d (Mini_Boss & Boss) :
                    public void On_Got_Exp (int V) {
                         Total_Got_Exp +=V;
                    }

                    void Save_Give_Exp_To_Player () {
                         Debug.Log ("Save_Exp");

                         string [] Host_Server_Field = new string [8]; string [] Host_Server_Value = new string [8];
                         Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
                         Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "2";
                         // Cur_Exp :
                         Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Db_Character_1_Home_Status";
                         Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Cur_Exp";
                         Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = Total_Got_Exp.ToString ();
                         // Loot :
                          Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Player_Status";
                         Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Gold_Coin";
                         Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1500";

                         Dont_Destroy_On_Load.Ins._Data_Online.Got_Items (Host_Server_Field, Host_Server_Value);  

                         Total_Got_Exp = 0;
                    }
               #endregion
          #endregion
          
          #region GMP_Umum
          public GameObject Hit_Bubble_Samp;
          #endregion
     #endregion
}
