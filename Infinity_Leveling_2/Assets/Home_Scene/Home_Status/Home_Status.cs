using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Starsky;
public class Home_Status : MonoBehaviour {
   // Hall_Of_Masters :
   public Canvas Home_Status_Canvas;
   [SerializeField]
    Check_Box_Type_2 [] A_Cb_Menu;

    [SerializeField]
    TMP_Text Home_Status_Title;

    Player_2d _Player_2d;
    
    // Check_Box_Type_2 :
    public void Cli_Home_Status () {
        Home_System.Ins._Home_Canvas.On_Clone_Bg_Header_Up (0);
        A_Cb_Menu[0].Cli_Box ();
    }
   public void Cli_On_Home_Status () {
        On_Menu_Choose ("Status");
        Home_Status_Canvas.gameObject.SetActive (true);
        
   }

   public void Cli_Off_Home_Status () {
        Home_System.Ins._Home_Canvas.Off_Clone_Bg_Header_Up ();
        Home_Status_Canvas.gameObject.SetActive (false);
   }

   string Menu_Choose = ""; // "Status"
   void On_Menu_Choose (string V) {
        foreach (Check_Box_Type_2 a in A_Cb_Menu) {
            if (a.Code_Item != V) { 
                a.Auto_Off_Box ();
            }
        }
        Off_All_Home_Status ();
        Menu_Choose = V;
        Home_Status_Title.text = Menu_Choose;
        if (Menu_Choose == "Status") {
            On_Bg_Status ();
        } else if (Menu_Choose == "Equipment") {
            On_HS_Equipment ();
        } else if (Menu_Choose == "Inventory") {
            On_HS_Inventory ();
        }
   }

   void Off_All_Home_Status () {
        Off_Bg_Status ();
        Off_HS_Equipment ();
        Off_HS_Inventory ();
   }
   #region Home_Status
    [SerializeField]
    Image HS_Status;
    [SerializeField]
    Clone_Bg_Status _Clone_Bg_Status;

    [SerializeField]
    TMP_Text Level_Tx;
    [SerializeField]
    TMP_Text Exp_Tx;
    [SerializeField]
    Slider Exp_Slider;

    [SerializeField]
    Set_Image_1 [] A_Set_Image_1;
    C_Home_Status _C_Home_Status;
    C_Equipment_Status _C_Equipment_Status;
    void On_Bg_Status () {
        HS_Status.gameObject.SetActive (true);
        _C_Home_Status = Dont_Destroy_On_Load.Ins._Data_Online._C_Home_Status;
        _C_Equipment_Status = Dont_Destroy_On_Load.Ins._Data_Online.Total_C_Equipment_Status;
        Exp_Slider.maxValue = Home_System.Ins._Home_Canvas.Target_Exp;
        Exp_Slider.value = _C_Home_Status.Cur_Exp;
        Level_Tx.text = "Level " + _C_Home_Status.Level.ToString ();
        Exp_Tx.text = _C_Home_Status.Cur_Exp.ToString () + " / " + Home_System.Ins._Home_Canvas.Target_Exp.ToString ();
        A_Set_Image_1[0].On_Write_Text ("HP", (_C_Home_Status.Hp +_C_Equipment_Status.Hp) .ToString ());
        A_Set_Image_1[1].On_Write_Text ("MP", (_C_Home_Status.Mp+_C_Equipment_Status.Mp).ToString ());
        A_Set_Image_1[2].On_Write_Text ("ATK", (_C_Home_Status.Attack+_C_Equipment_Status.Attack).ToString ());
        A_Set_Image_1[3].On_Write_Text ("DEF", (_C_Home_Status.Defense+_C_Equipment_Status.Defense).ToString ());
        A_Set_Image_1[4].On_Write_Text ("CRIT Rate", (_C_Home_Status.Critical_Rate+_C_Equipment_Status.Critical_Rate).ToString () + " %");
        A_Set_Image_1[5].On_Write_Text ("CRIT DMG", (_C_Home_Status.Critical_Damage+_C_Equipment_Status.Critical_Damage).ToString ()+ " %");
        A_Set_Image_1[6].On_Write_Text ("Block Chance", (_C_Home_Status.Block_Chance+_C_Equipment_Status.Block_Chance).ToString ()+ " %");
        A_Set_Image_1[7].On_Write_Text ("Penetration", (_C_Home_Status.Penetration+_C_Equipment_Status.Penetration).ToString ());
        A_Set_Image_1[8].On_Write_Text ("Vitality", (_C_Home_Status.Vitality+_C_Equipment_Status.Vitality).ToString ());
        A_Set_Image_1[9].On_Write_Text ("Mind", (_C_Home_Status.Mind+_C_Equipment_Status.Mind).ToString ());
        A_Set_Image_1[10].On_Write_Text ("Strength", (_C_Home_Status.Strength+_C_Equipment_Status.Strength).ToString ());
        A_Set_Image_1[11].On_Write_Text ("Agility", (_C_Home_Status.Agility+_C_Equipment_Status.Agility).ToString ());
    }   

    void Off_Bg_Status () {
        HS_Status.gameObject.SetActive (false);
    }
   #endregion
   #region Home_Equipment
   [SerializeField]
   Image HS_Equipment;
   void On_HS_Equipment () {
        HS_Equipment.gameObject.SetActive (true);

        Home_System.Ins._Character_Selection.On_Destroy_Cloning_Button ();
        Home_System.Ins._Character_Selection.On_Change_Panel_Type_1_Skill_Tab_2 ("Equipment");

        // Load_Inventory :
        int y = 1;
        for (y=1; y < (Max_Slot+1); y++) {
            if (Code_Equipment_Filler == "All") {
                Home_System.Ins._Character_Selection.On_Create_Button (A_Inventory_Name[y], A_Inventory_Type[y], A_Inventory_Value[y]);
            } else {
                if (Code_Equipment_Filler == A_Inventory_Type[y]) {
                    Home_System.Ins._Character_Selection.On_Create_Button (A_Inventory_Name[y], A_Inventory_Type[y], A_Inventory_Value[y]);
                } else {
                    Home_System.Ins._Character_Selection.On_Inc_Code_Urutan_Button ();
                }
            }
        }
        // END
        // Give Equip Logo
        Home_System.Ins._Character_Selection.On_Give_Equip_Logo_All ();
        // END
   }

   void Off_HS_Equipment () {
        HS_Equipment.gameObject.SetActive (false);
   }

    // Check_Box_Type_2 :
   public void Cli_On_HS_Equipment () {
     On_Menu_Choose ("Equipment");
   }

    #region HS_Equipment_Remove
    // Check_Box_Type_3 :
    Check_Box_Type_3 HS_Equipment_Cb_3;
    public void On_HS_Equipment_Input_Cb_3 (Check_Box_Type_3 Cb) {
        Home_System.Ins._Character_Selection.Off_Cb_Home_Status_Slot_Cape_3 ();
        HS_Equipment_Cb_3 = Cb;
        HS_Equipment_Cb_3.Auto_On_Box ();
        
        HS_Equipment_Equip_But.gameObject.SetActive (false);
        if (HS_Equipment_Cb_3._Check_Box_Type_2) {
            HS_Equipment_Remove_But.gameObject.SetActive (true);
        } else {
            HS_Equipment_Remove_But.gameObject.SetActive (false);
        }

        if (HS_Equipment_Cb_2) { HS_Equipment_Cb_2.Auto_Off_Box ();}
    }

    


    [SerializeField]
    Button HS_Equipment_Remove_But;
    public void Cli_HS_Equipment_Remove () {
        HS_Equipment_Equip_But.gameObject.SetActive (false);
        HS_Equipment_Remove_But.gameObject.SetActive (false);

        _Player_2d = Dont_Destroy_On_Load.Ins._Player_2d;
        Loading_Canvas.Ins.On_Loading_1 ();
        
        if (HS_Equipment_Cb_3.Code_Item == "Hair_Type") {_Player_2d._Player_Status.Slot_Hair_Type = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Helmet") {_Player_2d._Player_Status.Slot_Helmet = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Weapon") {_Player_2d._Player_Status.Slot_Weapon = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Ring") {_Player_2d._Player_Status.Slot_Ring = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Body_Costume") {_Player_2d._Player_Status.Slot_Body_Costume = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Face") {_Player_2d._Player_Status.Slot_Face = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Earring") {_Player_2d._Player_Status.Slot_Earring = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Offhand") {_Player_2d._Player_Status.Slot_Offhand = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Glove") {_Player_2d._Player_Status.Slot_Glove = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Boot") {_Player_2d._Player_Status.Slot_Boot = 0;}
        if (HS_Equipment_Cb_3.Code_Item == "Cape") {_Player_2d._Player_Status.Slot_Cape = 0;}
        if (_Player_2d) {
            HS_Equipment_Cb_3.Off_Input_Data_Check_Box_Type_2 ();
        }
        _Player_2d.On_Load_Refresh_Asset ("Local");
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Player_Status_Equipment_Slot ();
        
        On_HS_Equipment ();
        
    }
    
    #endregion
    #region HS_Equipment_Equip
        #region Passive_Equipment_Skill
        [SerializeField]
        List <string> L_Passive_Equipment_Skill; // "Equip_Mace_Items", etc.
        void On_Refresh_b_Passive_Equipment_Skill () {
            L_Passive_Equipment_Skill = new List <string> ();
        }

        // Player_2d :
        public void On_Add_b_Passive_Equipment_Skill (string v) {
                L_Passive_Equipment_Skill.Add (v);
        }
        #endregion
    [SerializeField]
    Button HS_Equipment_Equip_But;
    public void Cli_HS_Equipment_Equip () {
        _Player_2d = Dont_Destroy_On_Load.Ins._Player_2d;
        On_Refresh_b_Passive_Equipment_Skill ();
        _Player_2d.On_Check_Skill_Passive_Equipment ();

        if (HS_Equipment_Cb_2.Code_Box == "Weapon_Data") {
            Weapon_Data s = Home_System.Ins._Character_Selection.On_Get_Subtype_Weapon (A_Inventory_Name[HS_Equipment_Cb_2.Code_Urutan]);
            // Debug.LogError (s.Weapon_Type);
            if (s.Weapon_Type == "One_Handed_Sword") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_one_hand_sword_items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive one handed sword to equip this item.", "Confirm", "");
                    return;
                }
            }
            if (s.Weapon_Type == "Two_Handed_Sword") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_Two_Hand_Sword_Items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive two handed sword to equip this item.", "Confirm", "");
                    return;
                }
            }
            if (s.Weapon_Type == "Staff") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_staff_items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive staff to equip this item.", "Confirm", "");
                    return;
                }
            }
            if (s.Weapon_Type == "Wand") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_Wand_Items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive wand to equip this item.", "Confirm", "");
                    return;
                }
            }
            if (s.Weapon_Type == "Mace") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_Mace_Items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive mace to equip this item.", "Confirm", "");
                    return;
                }
            }
        } else if (HS_Equipment_Cb_2.Code_Box == "Offhand_Data") {
            Offhand_Data s = Home_System.Ins._Character_Selection.On_Get_Subtype_Offhand (A_Inventory_Name[HS_Equipment_Cb_2.Code_Urutan]);
            // Debug.LogError (s.Offhand_Type);
            if (s.Offhand_Type == "Orb") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_Orb_Items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive orb to equip this item.", "Confirm", "");
                    return;
                }
            }
            if (s.Offhand_Type == "Shield") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_Shield_Items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive shield to equip this item.", "Confirm", "");
                    return;
                }
            }
            if (s.Offhand_Type == "Book") {
                if (!L_Passive_Equipment_Skill.Contains ("Equip_Book_Items")) {
                    Notification_Canvas.Ins.On_Notification_1 ("Notification", "You must learn and add skill passive book to equip this item.", "Confirm", "");
                    return;
                }
            }
        }

        HS_Equipment_Equip_But.gameObject.SetActive (false);
        HS_Equipment_Remove_But.gameObject.SetActive (false);

        
        Loading_Canvas.Ins.On_Loading_1 ();
        if (HS_Equipment_Cb_2.Code_Box == "Hair_Type_Data") {_Player_2d._Player_Status.Slot_Hair_Type = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Helmet_Data") {_Player_2d._Player_Status.Slot_Helmet = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Weapon_Data") {_Player_2d._Player_Status.Slot_Weapon = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Ring_Data") {_Player_2d._Player_Status.Slot_Ring = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Body_Costume_Data") {_Player_2d._Player_Status.Slot_Body_Costume = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Face_Data") {_Player_2d._Player_Status.Slot_Face = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Earring_Data") {_Player_2d._Player_Status.Slot_Earring = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Offhand_Data") {_Player_2d._Player_Status.Slot_Offhand = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Glove_Data") {_Player_2d._Player_Status.Slot_Glove = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Boot_Data") {_Player_2d._Player_Status.Slot_Boot = HS_Equipment_Cb_2.Code_Urutan;}
        if (HS_Equipment_Cb_2.Code_Box == "Cape_Data") {_Player_2d._Player_Status.Slot_Cape = HS_Equipment_Cb_2.Code_Urutan;}
        if (_Player_2d) {
            HS_Equipment_Cb_2.On_Equip_Img ();
        }
        _Player_2d.On_Load_Refresh_Asset ("Local");
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Player_Status_Equipment_Slot ();
        On_HS_Equipment ();
    }
    Check_Box_Type_2 HS_Equipment_Cb_2;
    // Check_Box_Type_2 :
    public void On_HS_Equipmet_Input_Cb_2 (Check_Box_Type_2 Cb) {
        
        HS_Equipment_Cb_2 = Cb;
        HS_Equipment_Remove_But.gameObject.SetActive (false);
        
        foreach (Transform x1 in Home_System.Ins._Character_Selection.Target_Parent_Column.transform)  {
            foreach (Transform x2 in x1.transform) {
                Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                if (xs != Cb) {
                    xs.Auto_Off_Box ();
                }       
            }
        }
        
        if (HS_Equipment_Cb_2.BG_Equip_Img.gameObject.activeInHierarchy) {
            HS_Equipment_Equip_But.gameObject.SetActive (false);
        } else {
            HS_Equipment_Equip_But.gameObject.SetActive (true);
        }

        if (HS_Equipment_Cb_3) { HS_Equipment_Cb_3.Auto_Off_Box ();}
    }
    #endregion
    #region Filler_System
    string Code_Equipment_Filler = "All"; // All, Body_Costume, Glove, Weapon, Boot, Hair_Type, Helmet, Ring, etc.
    [SerializeField]
    Image Bg_Equipment_Filler;
    [SerializeField]
    TMP_Text Title_Equipment_Filler_Tx;
    bool b_Equipment_Filler = false;
    public void Cli_Equipment_Filler () {
        if (!b_Equipment_Filler) {
            On_Show_Equipment_Filler ();
        } else {
            Off_Show_Equipment_Filler ();
            
        }
    }

    void On_Show_Equipment_Filler () {
        b_Equipment_Filler = true;
        Bg_Equipment_Filler.gameObject.SetActive (true);
    }

    void Off_Show_Equipment_Filler () {
        b_Equipment_Filler = false;
         Bg_Equipment_Filler.gameObject.SetActive (false);
    }

    public void Cli_Change_Equipment_Filler (string V) {
        Code_Equipment_Filler = V;
        Off_Show_Equipment_Filler ();
        Title_Equipment_Filler_Tx.text = Code_Equipment_Filler;
        On_HS_Equipment ();
    }
    #endregion
   #endregion
   #region Home_Inventory 
   
   [SerializeField]
   Image HS_Inventory;
   void On_HS_Inventory () {
        HS_Inventory.gameObject.SetActive (true);

        Home_System.Ins._Character_Selection.On_Destroy_Cloning_Button ();
        Home_System.Ins._Character_Selection.On_Change_Panel_Type_1_Skill_Tab_2 ("Inventory");
       
        int y = 1;
        for (y=1; y < (Max_Slot+1); y++) {
            Home_System.Ins._Character_Selection.On_Create_Button (A_Inventory_Name[y], A_Inventory_Type[y], A_Inventory_Value[y]);
        }
        On_Refresh_Total_Cur_Slot ();
        // Give Equip Logo
        Home_System.Ins._Character_Selection.On_Give_Equip_Logo_All ();
        // END
        
       // Home_System.Ins._Character_Selection.On_Refresh_Accesories ("Character_Selection_Hair_Type");
   }

   void Off_HS_Inventory () {
    HS_Inventory.gameObject.SetActive (false);
   }

    // Check_Box_Type_2 & Load_Host_Server :
   public void Cli_On_HS_Inventory () {
        if (Home_Status_Canvas.gameObject.activeInHierarchy) {
            On_Menu_Choose ("Inventory");
        }
   }
    int Cur_Slot = 0;
    int Max_Slot = 88;
    [SerializeField]
    TMP_Text Inventory_Slot_Tx;
    // This & Data_Online :
   public void On_Refresh_Total_Cur_Slot () {
        Cur_Slot = 0;
        int y = 1;
        for (y=1; y < (Max_Slot+1); y++) {
            if (A_Inventory_Name[y] != "") {
                Cur_Slot++;
            }
        }
        Inventory_Slot_Tx.text = Cur_Slot.ToString () + "/" + Max_Slot.ToString ();
   }

    // GMP_Item_Button :
    int Result_Value;
   public int On_Inventory_Search_Multiple_Item (string Cd_Item) {
        
        int x;
        for (x = 1; x < A_Inventory_Name.Length; x++) {
            if (A_Inventory_Name[x] == Cd_Item) {
                int Valyed = 0;
                int.TryParse (A_Inventory_Value [x], out Valyed);
                Result_Value += Valyed;
            }   
        }
        

        return Result_Value;
   }

    // Submit_1_Parent :
    string Code_Submit_Parent;
    string Cd_Submit_Code;
    string Cd_Submit_For;
    public void On_Submit_1_Parent_Filler_Show_Inventory (string Cd_Submit_Code_V, string Cd_Submit_For_V) {
        Cd_Submit_Code = Cd_Submit_Code_V; Cd_Submit_For = Cd_Submit_For_V;
        Debug.LogError (Cd_Submit_Code + Cd_Submit_For);
        if (Cd_Submit_Code == "Type") {
            On_Inventory_Search_Type_Item (Cd_Submit_For);
        } else if (Cd_Submit_Code == "Name") {
            On_Inventory_Search_Name_Item (Cd_Submit_For);
        }
    }

    // Result_Slot :
   int Result_Slot;
   void On_Inventory_Search_Type_Item (string Cd_Item) {
        int x;

        for (x = 1; x < A_Inventory_Type.Length; x++) {
            if (Cd_Item == "Weapon_Offhand") {
                if (A_Inventory_Type[x] == "Weapon" || A_Inventory_Type[x] == "Offhand") {
                    Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Item_Submit_Button_1(x);
                }  
            } else if (Cd_Item == "Bodyparts") {
                if (A_Inventory_Type[x] == "Body_Costume" || A_Inventory_Type[x] == "Helmet" || A_Inventory_Type[x] == "Glove" || A_Inventory_Type[x] == "Boot") {
                    Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Item_Submit_Button_1(x);
                } 
            } else {
                if (A_Inventory_Type[x] == Cd_Item) {
                    Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Item_Submit_Button_1(x);
                }  
            } 
        }
   }

   void On_Inventory_Search_Name_Item (string Cd_Item) {
        int x;
        for (x = 1; x < A_Inventory_Name.Length; x++) {
            if (A_Inventory_Name[x] == Cd_Item) {
                Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Add_Item_Submit_Button_1(x);
            }   
        }
   }
    #region Click_Button_Di_Inventory
   // Click_Button_Di_Inventory :
   [HideInInspector]
    public Check_Box_Type_2 Cur_Select_Inventory;
    int Cur_Cli = 0;
    // Check_Box_Type_2 :
    public void On_Input_Cur_Select_Inventory (Check_Box_Type_2 x) {
        if (Cur_Select_Inventory) {
            if (Cur_Select_Inventory == x) {
                Cur_Cli ++;
            }
            if (Cur_Cli >=2) {
                Cur_Cli = 1;
                S_Sts ();
            }
        } else {
            Cur_Cli ++;
        }
        Cur_Select_Inventory = x;
    }
    [SerializeField]
    Image Sts_Img;
    [SerializeField]
    TMP_Text Sts_Tx;
    string [] A_Sts;

    void S_Sts () {
        Sts_Tx.text = "";
        Sts_Img.gameObject.SetActive (true);
        A_Sts = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Rows_Valued (A_Inventory_Value[Cur_Select_Inventory.Code_Urutan]);
        int y = 1;
        for (y=1; y < A_Sts.Length; y++) {
            Sts_Tx.text = Sts_Tx.text + A_Sts[y] +"/";
        }

    }

    public void Off_Shw_Sts () {
        Sts_Img.gameObject.SetActive (false);
    }

    public void On_Use_Cur_Select_Inventory () {
       // Save_Inventory :
        Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
       // Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Hair_Type, "Hair_Type", "1");
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory_Value_Changed (Cur_Select_Inventory.Code_Urutan, "-1");
        Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1_Use_Item");
        // END 
    }
    #endregion

    
   #endregion
   #region Skill_Set_Up
    public void Open_Clone_Skill_Set_Up () {
        Debug.LogError ("Call");
        Home_System.Ins._Hall_Of_Masters.On_Set_Duplicate_Code ("Home_Status");
        Home_System.Ins._Hall_Of_Masters.From_Home_Status_On_Load_Hall_Of_Masters ();
    }
   #endregion
   #region Load_Data
   // Home_Canvas :
    public void On_Load_Data_Inventory () {
        b_Load_Inventory_Name = false; b_Load_Inventory_Type = false; b_Load_Inventory_Value = false;
        On_Load_Inventory_Name ();
        On_Load_Inventory_Type ();
        On_Load_Inventory_Value ();
    }

    
        #region Inventory_Name
        // Player_2d (Local) :
        [HideInInspector]
        public bool b_Load_Inventory_Name = false;

        // Data_Online / Player_2d:
        [HideInInspector]
        public string [] A_Inventory_Name;
        void On_Load_Inventory_Name () {
            string [] Host_Server_Field = new string [2]; 
            string [] Host_Server_Value = new string [2]; 
            Host_Server_Field[0] = "table"; Host_Server_Value[0] = "Db_Inventory_Name"; 
            Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;

            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("On_Load_Inventory_Name", "Read_All_Table_2", Host_Server_Field, Host_Server_Value);
        }

        // Load_Host_Server :
        public void On_Got_Data_Inventory_Name (string [] Result) {
            A_Inventory_Name = new string [0];
            A_Inventory_Name = Result;
            Loading_Canvas.Ins.On_Increase_Loading_3 ();
            b_Load_Inventory_Name = true;
        }
        #endregion
        #region Inventory_Type
        // Player_2d (Local) :
        [HideInInspector]
        public bool b_Load_Inventory_Type = false;
        [HideInInspector]
        public string [] A_Inventory_Type;
        void On_Load_Inventory_Type () {
            string [] Host_Server_Field = new string [2]; 
            string [] Host_Server_Value = new string [2]; 
            Host_Server_Field[0] = "table"; Host_Server_Value[0] = "Db_Inventory_Type"; 
            Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("On_Load_Inventory_Type", "Read_All_Table_3", Host_Server_Field, Host_Server_Value);
        }

        // Load_Host_Server :
        public void On_Got_Data_Inventory_Type (string [] Result) {
            A_Inventory_Type = new string [0];
            A_Inventory_Type = Result;
            Loading_Canvas.Ins.On_Increase_Loading_3 ();
            b_Load_Inventory_Type = true;
        }
        #endregion
        #region Inventory_Value
        // Player_2d (Local) :
        [HideInInspector]
        public bool b_Load_Inventory_Value = false;
        [HideInInspector]
        public string [] A_Inventory_Value;
        void On_Load_Inventory_Value () {
            string [] Host_Server_Field = new string [2]; 
            string [] Host_Server_Value = new string [2]; 
            Host_Server_Field[0] = "table"; Host_Server_Value[0] = "Db_Inventory_Value"; 
            Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;

            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("On_Load_Inventory_Value", "Read_All_Table_4", Host_Server_Field, Host_Server_Value);
        }

        // Load_Host_Server :
        public void On_Got_Data_Inventory_Value (string [] Result) {
            A_Inventory_Value = new string [0];
            A_Inventory_Value = Result;
            /*
            A_Inventory_Value = new int [Result.Length];
            int v = -1;
            foreach (string x in Result) {
                v++;
                int.TryParse (Result[v], out A_Inventory_Value[v]);
            }
            // A_Inventory_Value = Result;
            Loading_Canvas.Ins.On_Increase_Loading_3 ();
            b_Load_Inventory_Value = true;
            */
            Loading_Canvas.Ins.On_Increase_Loading_3 ();
            b_Load_Inventory_Value = true;
        }
        #endregion
   #endregion
}
