using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Sage_Shrine : MonoBehaviour {
    public static Sage_Shrine Ins;

    void Awake () {
        Ins = this;
    }
    
    [SerializeField]
    Canvas Sage_Shrine_Canvas;
    
    public string Code_Menu = "";
    // Button :
    public void On_Sage () {
        Ref_Menu ("Exchange_Exp");
        Home_System.Ins._Home_Canvas.On_Clone_Bg_Header_Up (0);
        Sage_Shrine_Canvas.gameObject.SetActive (true);
    } 
    // Back_Home :
    public void Off_Sage () {
        Off_Exchange_Exp ();
        Sage_Shrine_Canvas.gameObject.SetActive (false);
        Home_System.Ins._Home_Canvas.Off_Clone_Bg_Header_Up ();
    }
    
    void Ref_Menu (string V) {
        Code_Menu = V;
        if (Code_Menu == "Exchange_Exp") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith");
            On_Exchange_Exp ();
        }
        
    }

    public void Back_Menu() {
        if (Code_Menu == "Exchange_Exp") {
            Off_Exchange_Exp ();
            Off_Sage ();
        }
    }

    #region Exchange_Exp
        // Cur_Exp = C_Home_Status.
        [System.Serializable]
        public class C_Select_1 { 
            public string Submit_Code = ""; //"100_Hp"
            public string Str_Required = "";
            public int Cd_Int_Required = 0;
            public Sprite Cd_Sprite;
        }
        [SerializeField]
        C_Select_1 [] A_C_Select_1;
        [SerializeField]
        TMP_Text Cur_Exp;
        // this / Data_Online
        public void On_Ref_Cur_Exp () {
            Cur_Exp.text =  Dont_Destroy_On_Load.Ins._Data_Online._C_Home_Status.Cur_Exp.ToString ();
        }
        void On_Exchange_Exp () {
            On_Ref_Cur_Exp ();
            Dont_Destroy_On_Load.Ins._Select_1_Parent.On_Active_Select_Event ("Select_1", "Sage_Exchange_Exp"); 
            foreach (C_Select_1 x in A_C_Select_1) {
                Dont_Destroy_On_Load.Ins._Select_1_Parent.On_Add_Select_Button (x.Submit_Code, x.Str_Required, x.Cd_Int_Required, x.Cd_Sprite);
            }

            Dont_Destroy_On_Load.Ins._Select_1_Parent.L_Select_1_Button[0].On_Select ();
        }

        void Off_Exchange_Exp () {
            Dont_Destroy_On_Load.Ins._Select_1_Parent.Off_Active_Select_Event ();
        }

        Select_1_Button Cur_Select_1_Button;
        string [] Host_Server_Field = new string [8]; string [] Host_Server_Value = new string [8];
        public void On_Confirm_Exchange () {
            Cur_Select_1_Button = Dont_Destroy_On_Load.Ins._Select_1_Parent.Cur_Select_1_Button; 
            if (Cur_Select_1_Button.Cd_Str_Required == "Cur_Exp") {
                if ( Dont_Destroy_On_Load.Ins._Data_Online._C_Home_Status.Cur_Exp >=  Cur_Select_1_Button.Cd_Int_Required) {
                    Host_Server_Field = new string [8]; Host_Server_Value = new string [8];
                    Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
                    Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "2";
                    // Cur_Exp :
                    Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Db_Character_1_Home_Status";
                    Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Cur_Exp";
                    Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = (Cur_Select_1_Button.Cd_Int_Required * -1).ToString ();
                    // Eff :
                    if (Cur_Select_1_Button.Cd_Submit_Code == "100_HP") {
                        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
                        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Hp";
                        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "100";
                    }
                    if (Cur_Select_1_Button.Cd_Submit_Code == "100_MP") {
                        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
                        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Mp";
                        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "100";
                    }
                    if (Cur_Select_1_Button.Cd_Submit_Code == "Vitality_1x") {
                        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
                        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Vitality";
                        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1";
                    }
                    if (Cur_Select_1_Button.Cd_Submit_Code == "Mind_1x") {
                        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
                        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Mind";
                        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1";
                    }
                    if (Cur_Select_1_Button.Cd_Submit_Code == "Strength_1x") {
                        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
                        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Strength";
                        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1";
                    }
                    if (Cur_Select_1_Button.Cd_Submit_Code == "Agility_1x") {
                        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
                        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Agility";
                        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1";
                    }

                    Dont_Destroy_On_Load.Ins._Data_Online.Got_Items (Host_Server_Field, Host_Server_Value);  
                } else {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You dont have enough exp.", "Confirm", "");
                }
            }
        }

    #endregion
}
