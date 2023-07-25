using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Blacksmith_Script : MonoBehaviour {
    [SerializeField]
    Canvas Blacksmith_Cvs;
    [SerializeField]
    Image Blacksmith_Menu;
    [SerializeField]
    Image Blacksmith_Echance;
    [SerializeField]
    Image Blacksmith_Transfer_Status;
    [SerializeField]
    Image Blacksmith_Craft_Equipment, Blacksmith_Craft_Equipment_2;
    Home_Status _Home_Status;
    void Start () {
        _Home_Status = Home_System.Ins._Home_Status;
        _Submit_1_Parent = Dont_Destroy_On_Load.Ins._Submit_1_Parent;
    }
    public string Code_Menu_Blacksmith = "";
    // Button- BSIM :
    public void On_Blacksmith () {
        Ref_Blacksmith_Menu ("Menu");
        Home_System.Ins._Home_Canvas.On_Clone_Bg_Header_Up (0);
        Blacksmith_Cvs.gameObject.SetActive (true);
    } 
    // Back_Home :
    public void Off_Blacksmith () {
        Blacksmith_Cvs.gameObject.SetActive (false);
        Home_System.Ins._Home_Canvas.Off_Clone_Bg_Header_Up ();
        BSIM_Script.Ins.Off_Canvas ();
    }
    
    void Ref_Blacksmith_Menu (string V) {
        Code_Menu_Blacksmith = V;
        Blacksmith_Menu.gameObject.SetActive (false);
        Blacksmith_Echance.gameObject.SetActive (false);
        Blacksmith_Transfer_Status.gameObject.SetActive (false);
        Blacksmith_Craft_Equipment.gameObject.SetActive (false);
        Blacksmith_Craft_Equipment_2.gameObject.SetActive (false);
        if (Code_Menu_Blacksmith == "Menu") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith");
            On_Menu ();
        }
        if (Code_Menu_Blacksmith == "Echance_Weapon") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith - Echance Weapon");
            On_Echance_Weapon ();
        }
        if (Code_Menu_Blacksmith == "Echance_Armor") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith - Echance Armor");
            On_Echance_Armor ();
        }
        if (Code_Menu_Blacksmith == "Transfer_Status_Weapon") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith - Transfer Status Weapon");
            On_Transfer_Status_Weapon ();
        }
        if (Code_Menu_Blacksmith == "Transfer_Status_Armor") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith - Transfer Status Armor");
            On_Transfer_Status_Armor ();
        }
        if (Code_Menu_Blacksmith == "Craft_Equipment") {
            BSIM_Script.Ins.On_Change_BSIM_Title ("Blacksmith - Craft Equipment");
            On_Craft_Equipment ();
        }
        if (Code_Menu_Blacksmith == "Tier_Upgrade") {
            On_Tier_Upgrade ();
        }
        if (Code_Menu_Blacksmith == "Add_Rune_Socket") {
            On_Add_Rune_Socket ();
        }
    }

    public void Back_Blacksmith () {
        if (Code_Menu_Blacksmith == "Menu") {
            Off_Blacksmith ();
        }
        if (Code_Menu_Blacksmith == "Echance_Weapon") {
            Off_Echance_Weapon ();
            Ref_Blacksmith_Menu ("Menu");
        }
        if (Code_Menu_Blacksmith == "Echance_Armor") {
            Off_Echance_Armor ();
            Ref_Blacksmith_Menu ("Menu");
        }
        if (Code_Menu_Blacksmith == "Transfer_Status_Weapon") {
            Off_Transfer_Status_Weapon ();
            Ref_Blacksmith_Menu ("Menu");
        }
        if (Code_Menu_Blacksmith == "Transfer_Status_Armor") {
            Off_Transfer_Status_Armor ();
            Ref_Blacksmith_Menu ("Menu");
        }
        if (Code_Menu_Blacksmith == "Craft_Equipment") {
            Off_Craft_Equipment ();
            Ref_Blacksmith_Menu ("Menu");
        }
        if (Code_Menu_Blacksmith == "Tier_Upgrade") {
            Off_Craft_Equipment ();
            Ref_Blacksmith_Menu ("Menu");
        }
        if (Code_Menu_Blacksmith == "Add_Rune_Socket") {
            Off_Craft_Equipment ();
            Ref_Blacksmith_Menu ("Menu");
        }
    }
    #region Menu
    void On_Menu () {
        
        Blacksmith_Menu.gameObject.SetActive (true);
    }
    public void Cli_Change_Menu (string SU) {
        Ref_Blacksmith_Menu (SU);
    }
    
    #endregion
    #region Echance_Weapon
    [SerializeField]
    TMP_Text Echance_Title;
    [SerializeField]
    Button Echance_Button;
    [SerializeField]
    TMP_Text Echance_Cost_Tx;
    [SerializeField]
    int Echance_Cost = 888;
    
    public void On_Echance_Weapon () {
        
       Echance_Button.gameObject.SetActive (false);
        Echance_Title.text = "Echance Weapon";
        Echance_Cost_Tx.text = Echance_Cost.ToString ();

        Blacksmith_Echance.gameObject.SetActive (true);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Echance_Weapon");
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Weapon_Offhand", 1);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Name", "Weapon_Echant_Stone", 8);
    }

    void Off_Echance_Weapon () {
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.Off_Active_Submit_Event ();
    }

    void On_Check_Retry () {
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.Close_Set_Submit ();
    }
    // Submit_1_Parent :
    bool b_Check_Echance = false;
        public void On_Check_Submitted_Echance (bool v) {
            if (Dont_Destroy_On_Load.Ins._Data_Online._Player_Status.Gold_Coin >= Echance_Cost) {
                b_Check_Echance = v;
                if (v == true) {
                    Echance_Button.gameObject.SetActive (true);
                } else {
                    Echance_Button.gameObject.SetActive (false);
                }
            } else {
                b_Check_Echance = false;
            }
        }



        int Chance_Ech = 100;
        bool b_Echance_Success = false;
        string Str_Echance_Status;
        string [] Rows_Echance_Status;
        [SerializeField]
        string Str_Echance_Status_Save = "";
        int Cur_Level_Echance;
        int Max_Level_Echance = 8;
        Submit_1_Parent _Submit_1_Parent;
        void Result_Echance () {
            /*
            Str_Echance_Status = _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory];
            Rows_Echance_Status = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued( _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory]);
            int.TryParse (Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued_Search_Title (Rows_Echance_Status,"Level"),out Cur_Level_Echance);
            */

            if (Cur_Level_Echance <=3) {
                Chance_Ech = 100;
            } else {
                Chance_Ech = 8;
            }

            int Res = Random.Range (0,100);
            if (Res < Chance_Ech) {
                b_Echance_Success = true;
            } else {
                b_Echance_Success = false;
            }

            Dont_Destroy_On_Load.Ins._Data_Online.Got_Gold_Coin ((Echance_Cost).ToString ());

            if (b_Echance_Success) {
                Result_Text.text = "Success !";
                int u = 1;
                for (u =1; u < Rows_Echance_Status.Length; u++) {
                    if (Rows_Echance_Status[u] == "Level") {
                        Rows_Echance_Status[u+1] = (Cur_Level_Echance+1).ToString ();
                    }
                }
                Str_Echance_Status_Save = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued_To_String(Rows_Echance_Status);


                
                // Save_Inventory :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory, Str_Echance_Status_Save);
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[1].Cur_Slot_Inventory, "-8");
                Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("");
                // END 
                Sparkle_1.gameObject.SetActive (true); Sparkle_2.gameObject.SetActive (true);
            } else {
                Result_Text.text = "Failed...";

                // Save_Inventory :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[1].Cur_Slot_Inventory, "-8");
                Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("");
                // END 
                Sparkle_1.gameObject.SetActive (false); Sparkle_2.gameObject.SetActive (false);
            }
        }
        #region Anim
        [SerializeField]
        Image Bg_Echance_Action, Bg_Echance_Result, BG_Echance_Action_Universal;
        [SerializeField]
        Check_Box_Type_2 Items_Echance;
        [SerializeField]
        Button Echance_Result_Retry_But, Echance_Result_Back_But, Echance_Result_Retry_Black_But;
        [SerializeField]
        TMP_Text Result_Text;
        [SerializeField]
        GameObject Sparkle_1, Sparkle_2;
        public void Cli_Start_Echance () {
            Str_Echance_Status = _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory];
            Rows_Echance_Status = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued( _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory]);
            int.TryParse (Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued_Search_Title (Rows_Echance_Status,"Level"),out Cur_Level_Echance);
           
           
            if (Cur_Level_Echance <8) {
                Cli_Back_Result_Echance ();
                Result_Echance ();
                Bg_Echance_Result.gameObject.SetActive (false);
                Bg_Echance_Action.gameObject.SetActive (true);
                BG_Echance_Action_Universal.gameObject.SetActive (true);
                Items_Echance.Logo_Img.sprite = Dont_Destroy_On_Load.Ins._Submit_1_Parent.L_Submit_Button_1[0].Item_Img.sprite;
                Items_Echance.A_Text[0].text = Dont_Destroy_On_Load.Ins._Submit_1_Parent.L_Submit_Button_1[0].Item_Title.text;
                StartCoroutine (N_Cli_Start_Echance ());
            } else {
                Notification_Canvas.Ins.On_Notification_1 ("Notification", "This equipment reach maximum level.", "Confirm", "");
            }
        }

        IEnumerator N_Cli_Start_Echance () {
            yield return new WaitForSeconds (3);
            Bg_Echance_Action.gameObject.SetActive (false);
            StartCoroutine (N_Anim_Echance_Result());
        }

        IEnumerator N_Anim_Echance_Result () {
            Bg_Echance_Result.gameObject.SetActive (true);
            yield return new WaitForSeconds (1.5f);
            On_Check_Retry ();
            Echance_Result_Back_But.gameObject.SetActive (true);
            if (b_Check_Echance) {
                Echance_Result_Retry_Black_But.gameObject.SetActive (false);
                Echance_Result_Retry_But.gameObject.SetActive (true);
            } else {
                Echance_Result_Retry_Black_But.gameObject.SetActive (true);
                Echance_Result_Retry_But.gameObject.SetActive (false);
            }
        }


        public void Cli_Back_Result_Echance () {
            Bg_Echance_Result.gameObject.SetActive (false);
            Bg_Echance_Action.gameObject.SetActive (false);
            BG_Echance_Action_Universal.gameObject.SetActive (false);

            Echance_Result_Retry_But.gameObject.SetActive (false); 
            Echance_Result_Back_But.gameObject.SetActive (false);
            Echance_Result_Retry_Black_But.gameObject.SetActive (false);
        }
        
        #endregion

    #endregion
    #region Echance_Armor
    
    public void On_Echance_Armor () {
       Echance_Button.gameObject.SetActive (false);
        Echance_Title.text = "Echance Armor";
        Echance_Cost_Tx.text = Echance_Cost.ToString ();

        Blacksmith_Echance.gameObject.SetActive (true);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Echance_Weapon"); // same as weapon.
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Bodyparts", 1);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Name", "Armor_Echant_Stone", 8);
    }

    void Off_Echance_Armor () {
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.Off_Active_Submit_Event ();
    }


    #endregion
    #region Transfer_Status_Weapon
    [SerializeField]
    TMP_Text Transfer_Status_Title;
    [SerializeField]
    Button Transfer_Status_Button;
    [SerializeField]
    TMP_Text Transfer_Status_Cost_Tx;
    [SerializeField]
    int Transfer_Status_Cost = 888;
    
    public void On_Transfer_Status_Weapon () {
       Transfer_Status_Button.gameObject.SetActive (false);
        Transfer_Status_Title.text = "Transfer Status Weapon";
        Transfer_Status_Cost_Tx.text = Transfer_Status_Cost.ToString ();

        Blacksmith_Transfer_Status.gameObject.SetActive (true);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Transfer_Status_Weapon");
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Weapon_Offhand", 1);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Weapon_Offhand", 1);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Name", "Weapon_Echant_Stone", 8);
       //  Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Weapon_Offhand", 1);
    }

    void Off_Transfer_Status_Weapon () {
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.Off_Active_Submit_Event ();
    }

    // Submit_1_Parent :
    bool b_Check_Transfer_Status = false;
        public void On_Check_Submitted_Transfer_Status (bool v) {
            if (Dont_Destroy_On_Load.Ins._Data_Online._Player_Status.Gold_Coin >= Transfer_Status_Cost) {
                b_Check_Transfer_Status = v;
                if (v == true) {
                    Transfer_Status_Button.gameObject.SetActive (true);
                } else {
                    Transfer_Status_Button.gameObject.SetActive (false);
                }
            } else {
                b_Check_Transfer_Status = false;
            }
        }



        string Str_Transfer_Status_Status_From;
       // string [] Rows_Transfer_Status_Status_From;
       // string Str_Transfer_Status_Status_Save_From_Sementara = "";

        string Str_Transfer_Status_Status_To;
      //  string [] Rows_Transfer_Status_Status_To;
      //  string Str_Transfer_Status_Status_Save_To_Sementara = "";

        void Result_Transfer_Status () {
             Str_Transfer_Status_Status_From = _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[1].Cur_Slot_Inventory];
            Str_Transfer_Status_Status_To = _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory];
           // Rows_Transfer_Status_Status = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued( _Home_Status.A_Inventory_Value[_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory]);
          
            Dont_Destroy_On_Load.Ins._Data_Online.Got_Gold_Coin ((Transfer_Status_Cost).ToString ());

                Transfer_Status_Result_Text.text = "Transfer Success !";

                // Save_Inventory :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory, Str_Transfer_Status_Status_From);
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[1].Cur_Slot_Inventory, Str_Transfer_Status_Status_To);
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[2].Cur_Slot_Inventory, "-8");
                Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("");
                // END 
        }
        #region Anim
        [SerializeField]
        Image Bg_Transfer_Status_Action, Bg_Transfer_Status_Result, BG_Transfer_Status_Action_Universal;
        [SerializeField]
        Check_Box_Type_2 Items_Transfer_Status, Items_Transfer_Status_2;
        [SerializeField]
        Button Transfer_Status_Result_Back_But;
        [SerializeField]
        TMP_Text Transfer_Status_Result_Text;
        public void Cli_Start_Transfer_Status () {
            Cli_Back_Result_Transfer_Status ();
            Result_Transfer_Status ();
            Bg_Transfer_Status_Result.gameObject.SetActive (false);
            Bg_Transfer_Status_Action.gameObject.SetActive (true);
            BG_Transfer_Status_Action_Universal.gameObject.SetActive (true);
            Items_Transfer_Status.Logo_Img.sprite = Dont_Destroy_On_Load.Ins._Submit_1_Parent.L_Submit_Button_1[0].Item_Img.sprite;
            Items_Transfer_Status.A_Text[0].text = Dont_Destroy_On_Load.Ins._Submit_1_Parent.L_Submit_Button_1[0].Item_Title.text;
            Items_Transfer_Status_2.Logo_Img.sprite = Dont_Destroy_On_Load.Ins._Submit_1_Parent.L_Submit_Button_1[1].Item_Img.sprite;
            Items_Transfer_Status_2.A_Text[0].text = Dont_Destroy_On_Load.Ins._Submit_1_Parent.L_Submit_Button_1[1].Item_Title.text;
            StartCoroutine (N_Cli_Start_Transfer_Status ());
        }

        IEnumerator N_Cli_Start_Transfer_Status () {
            yield return new WaitForSeconds (3);
            Bg_Transfer_Status_Action.gameObject.SetActive (false);
            StartCoroutine (N_Anim_Transfer_Status_Result());
        }

        IEnumerator N_Anim_Transfer_Status_Result () {
            Bg_Transfer_Status_Result.gameObject.SetActive (true);
            yield return new WaitForSeconds (1.5f);
            On_Check_Retry ();
            Transfer_Status_Result_Back_But.gameObject.SetActive (true);
           
        }


        public void Cli_Back_Result_Transfer_Status () {
            
            Bg_Transfer_Status_Result.gameObject.SetActive (false);
            Bg_Transfer_Status_Action.gameObject.SetActive (false);
            BG_Transfer_Status_Action_Universal.gameObject.SetActive (false);

            Transfer_Status_Result_Back_But.gameObject.SetActive (false);
        }
        
        #endregion

    #endregion
    #region Transfer_Status_Armor
   
    
    public void On_Transfer_Status_Armor () {
       Transfer_Status_Button.gameObject.SetActive (false);
        Transfer_Status_Title.text = "Transfer Status Armor";
        Transfer_Status_Cost_Tx.text = Transfer_Status_Cost.ToString ();

        Blacksmith_Transfer_Status.gameObject.SetActive (true);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Transfer_Status_Armor");
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Bodyparts", 1);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Bodyparts", 1);
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Name", "Armor_Echant_Stone", 8);
        
       //  Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Type", "Weapon_Offhand", 1);
    }

    void Off_Transfer_Status_Armor () {
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.Off_Active_Submit_Event ();
    }    

    #endregion
    #region Craft_Equipment
    [SerializeField]
    TMP_Text Craft_Equipment_Title;
    [SerializeField]
    Button Craft_Equipment_Button;
    [SerializeField]
    TMP_Text Craft_Equipment_Cost_Tx;
    [SerializeField]
    int Craft_Equipment_Cost = 488;

    public void On_Craft_Equipment () {
        Cli_Change_Craft_Equipment_Filler("Weapon");
        Blacksmith_Craft_Equipment.gameObject.SetActive (true);
        Blacksmith_Craft_Equipment_2.gameObject.SetActive (true);
        Craft_Equipment_Cost_Tx.text = Craft_Equipment_Cost.ToString ();
        Craft_Equipment_Title.text = "Craft Equipment";
    }

    void Off_Craft_Equipment () {
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.Off_Active_Submit_Event ();
    }

    // Submit_1_Parent :
    public void On_Check_Submitted_Craft_Equipment (bool v) {
            if (Dont_Destroy_On_Load.Ins._Data_Online._Player_Status.Gold_Coin >= Craft_Equipment_Cost) {
                if (v == true) {
                    Craft_Equipment_Button.gameObject.SetActive (true);
                } else {
                    Craft_Equipment_Button.gameObject.SetActive (false);
                }
            } else {

            }
    }

    void On_Refresh_Craft_Equipment () {
         Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Craft_Equipment");
        if (Code_Craft_Equipment_Filler == "Body_Costume" || Code_Craft_Equipment_Filler == "Glove" || Code_Craft_Equipment_Filler == "Boot" || Code_Craft_Equipment_Filler == "Helmet") {
           // Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Craft_Equipment");
            Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Name", "Armor_Fragment", 8);
        }
        if (Code_Craft_Equipment_Filler == "Weapon" || Code_Craft_Equipment_Filler == "Offhand") {
           // Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Active_Submit_Event ("Submit_1", "Craft_Equipment");
            Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Submit_Button ("Name", "Weapon_Fragment", 8);
        }
         Dont_Destroy_On_Load.Ins._Submit_1_Parent.Close_Set_Submit ();
    }
        #region Reward
        [SerializeField]
         List <string> L_Craft_Weapon;
         [SerializeField]
         List <string> L_Craft_Offhand;
         [SerializeField]
         List <string> L_Craft_Body_Costume;
         [SerializeField]
         List <string> L_Craft_Helmet;
         [SerializeField]
         List <string> L_Craft_Glove;
         [SerializeField]
         List <string> L_Craft_Boot;
        
            string Result_Craft_Equipment_Name;
            string Result_Craft_Equipment_Type;
            string Result_Craft_Equipment_Value;


        public void Start_Craft () {
            Dont_Destroy_On_Load.Ins._Data_Online.Got_Gold_Coin ((Craft_Equipment_Cost).ToString ());
            if (Code_Craft_Equipment_Filler == "Weapon") {
                int Rand = Random.Range (0,L_Craft_Weapon.Count);
                Result_Craft_Equipment_Name = L_Craft_Weapon[Rand];
                foreach (Weapon_Data x in Home_System.Ins._Character_Selection.L_Weapon_Data) {
                        if (Result_Craft_Equipment_Name == x.Code_Terpilih) {
                            Result_Craft_Equipment_Type = Code_Craft_Equipment_Filler;
                            Result_Craft_Equipment_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                        }
                }
            } else if (Code_Craft_Equipment_Filler == "Offhand") {
                int Rand = Random.Range (0,L_Craft_Offhand.Count);
                Result_Craft_Equipment_Name = L_Craft_Offhand[Rand];
                foreach (Offhand_Data x in Home_System.Ins._Character_Selection.L_Offhand_Data) {
                        if (Result_Craft_Equipment_Name == x.Code_Terpilih) {
                            Result_Craft_Equipment_Type = Code_Craft_Equipment_Filler;
                            Result_Craft_Equipment_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                        }
                }
            } else if (Code_Craft_Equipment_Filler == "Body_Costume") {
                int Rand = Random.Range (0,L_Craft_Body_Costume.Count);
                Result_Craft_Equipment_Name = L_Craft_Body_Costume[Rand];
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                        if (Result_Craft_Equipment_Name == x.Code_Terpilih) {
                            Result_Craft_Equipment_Type = Code_Craft_Equipment_Filler;
                            Result_Craft_Equipment_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                        }
                }
            } else if (Code_Craft_Equipment_Filler == "Glove") {
                int Rand = Random.Range (0,L_Craft_Glove.Count);
                Result_Craft_Equipment_Name = L_Craft_Glove[Rand];
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                        if (Result_Craft_Equipment_Name == x.Code_Terpilih) {
                            Result_Craft_Equipment_Type = Code_Craft_Equipment_Filler;
                            Result_Craft_Equipment_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                        }
                }
            } else if (Code_Craft_Equipment_Filler == "Helmet") {
                int Rand = Random.Range (0,L_Craft_Helmet.Count);
                Result_Craft_Equipment_Name = L_Craft_Helmet[Rand];
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                        if (Result_Craft_Equipment_Name == x.Code_Terpilih) {
                            Result_Craft_Equipment_Type = Code_Craft_Equipment_Filler;
                            Result_Craft_Equipment_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                        }
                }
            } else if (Code_Craft_Equipment_Filler == "Boot") {
                int Rand = Random.Range (0,L_Craft_Boot.Count);
                Result_Craft_Equipment_Name = L_Craft_Boot[Rand];
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                        if (Result_Craft_Equipment_Name == x.Code_Terpilih) {
                            Result_Craft_Equipment_Type = Code_Craft_Equipment_Filler;
                            Result_Craft_Equipment_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                        }
                }
            }

            // Save_Inventory :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (Result_Craft_Equipment_Name, Result_Craft_Equipment_Type, Result_Craft_Equipment_Value);
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (_Submit_1_Parent.L_Submit_Button_1[0].Cur_Slot_Inventory, "-8");
                Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
            // END
             Dont_Destroy_On_Load.Ins._Submit_1_Parent.Close_Set_Submit ();
         }
        #endregion

        #region Filler_System
        string Code_Craft_Equipment_Filler = "Weapon"; // All, Body_Costume, Glove, Weapon, Boot, Hair_Type, Helmet, Ring, etc.
        [SerializeField]
        Image Bg_Craft_Equipment_Filler;
        [SerializeField]
        TMP_Text Title_Craft_Equipment_Filler_Tx;
        bool b_Craft_Equipment_Filler = false;
        public void Cli_Craft_Equipment_Filler () {
            if (!b_Craft_Equipment_Filler) {
                On_Show_Craft_Equipment_Filler ();
            } else {
                Off_Show_Craft_Equipment_Filler ();
                
            }
        }

        void On_Show_Craft_Equipment_Filler () {
            b_Craft_Equipment_Filler = true;
            Bg_Craft_Equipment_Filler.gameObject.SetActive (true);
        }

        void Off_Show_Craft_Equipment_Filler () {
            b_Craft_Equipment_Filler = false;
            Bg_Craft_Equipment_Filler.gameObject.SetActive (false);
        }

        public void Cli_Change_Craft_Equipment_Filler (string V) {
            Code_Craft_Equipment_Filler = V;
            Off_Show_Craft_Equipment_Filler ();
            Title_Craft_Equipment_Filler_Tx.text = Code_Craft_Equipment_Filler;
            On_Refresh_Craft_Equipment ();
        }
        #endregion

    #endregion
    #region Tier_Upgrade
    public void On_Tier_Upgrade () {
        Notification_Canvas.Ins.On_Notification_1 ("Notification", "Coming Soon", "Confirm", "");
        Ref_Blacksmith_Menu ("Menu");
    }
    #endregion
    #region Add_Rune_Socket
    public void On_Add_Rune_Socket () {
        Notification_Canvas.Ins.On_Notification_1 ("Notification", "Coming Soon", "Confirm", "");
        Ref_Blacksmith_Menu ("Menu");
    }
    #endregion
}
