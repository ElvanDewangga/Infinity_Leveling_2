using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Check_Box_Type_2 : MonoBehaviour {
    public string Subcode_Box = ""; // Home_Status - Inventory, Submit_1.
    public string Code_Box = ""; // Hair_Type_Data , Face_Data, dll.
    public string Code_Item = "";
    // Hall_Of_Masters :
    public int Code_Urutan = 0;
    public bool b_Sample = true;
    [HideInInspector]
    public Hair_Type_Data _Hair_Type_Data;
    [HideInInspector]
    public Face_Data _Face_Data;
    [HideInInspector]
    public Hair_Colour_Data _Hair_Colour_Data;
    [HideInInspector]
    public Skin_Tone_Data _Skin_Tone_Data;
    [HideInInspector]
    public Body_Costume_Data _Body_Costume_Data;
    [HideInInspector]
    public Body_Costume_Data _Helmet_Data;
    [HideInInspector]
    public Weapon_Data _Weapon_Data;
    [HideInInspector]
    public Ring_Data _Ring_Data;
    [HideInInspector]
    public Earring_Data _Earring_Data;
    [HideInInspector]
    public Offhand_Data _Offhand_Data;
    [HideInInspector]
    public Body_Costume_Data _Glove_Data;
    [HideInInspector]
    public Body_Costume_Data _Boot_Data;
    [HideInInspector]
    public Cape_Data _Cape_Data;

    [HideInInspector]
    public Item_Data_Script _Item_Data_Script;

    [SerializeField]
    Button Box_Button;

    [SerializeField] // Check_Box_Type_3 :
    public Image Logo_Img;

    [HideInInspector]
    bool b_Check = false;
    bool b_Can_Click = true;

    [SerializeField]
    // Skill_Set_Up [0] = Skill_Name, [1] = Level.
    // Blacksmith_Script
    public TMP_Text [] A_Text; // [0] = Title.
    
    [SerializeField]
    Image Img_Select;
    [SerializeField]
    Sprite On_Selected, Off_Selected;
    [Header ("Hall_Of_Master_Left / Skill_Set_Up_Type / Submit_1  :")]
    public Image Selected_Img;

    [Header ("Hall_Of_Masters_Brown_Box :")]
    // Hall_Of_Masters :
    public Hall_Of_Masters_Skill_Set _Hall_Of_Masters_Skill_Set; // Price_Skill_1 / Skill_Inventory_1
    public Load_Visual_Novel _Load_Visual_Novel;


    [Header ("Price_Skill_1 / Skill_Inventory_1 :")]
    // [HideInInspector]
    public Skill_Keterangan _Skill_Keterangan;
    // [HideInInspector]
    public int Got_Skill;
    Color Grayout_Color = new Color (0.20f,0.21f,0.28f,1);
    Color Normal_Color = new Color (1,1,1,1);
    [Header ("Skill_Set_Up")]
    // Hall_Of_Masters :
    [HideInInspector]
    public Skill_Data_Kumpulan _Skill_Data_Kumpulan;
    [SerializeField]
    Image Bg_Have_Skill;
    [SerializeField]
    Image Bg_Not_Have_Skill;
    
    [Header ("Subcode : HS_Inventory / HS_Equipment / Got_Parent / Submit_1")]
    [SerializeField] // Home_Status :
    public Image BG_Equip_Img;
    // Home_Status:
    public void On_Equip_Img () {
        if (Subcode_Box == "HS_Inventory" || Subcode_Box == "HS_Equipment" || Subcode_Box == "Submit_1") {
            BG_Equip_Img.gameObject.SetActive (true);
        }
    }

    public void Off_Equip_Img () {
        if (Subcode_Box == "HS_Inventory" || Subcode_Box == "HS_Equipment" || Subcode_Box == "Submit_1") {
            BG_Equip_Img.gameObject.SetActive (false);
        }
    }

    void Awake () {
        Box_Button.onClick.AddListener (Cli_Box);
        if (Code_Box == "Hall_Of_Masters_Brown_Box") {
            A_Text[0].text = _Hall_Of_Masters_Skill_Set.Title;
            _Load_Visual_Novel = this.gameObject.GetComponent <Load_Visual_Novel>();
            this.gameObject.GetComponent <Load_Visual_Novel>().Load_Data ();
        } else if (Code_Box == "Price_Skill_1") {
            A_Text[0].text = _Skill_Keterangan.Skill_Name;
            A_Text[1].text = _Skill_Keterangan.Gold_Learn.ToString ();

        }
    }
    
    public void Cli_Box () {
        if (b_Can_Click) {
            if (!b_Check) {
                
            }
            b_Check = true;  
                On_Box ();
        }
    }

    // Character_Selection :
    public void Auto_Off_Box () {
        /*
        if (b_Check) {
            b_Check = false;
            Off_Box ();
        }
        */
        Off_Box ();
    }

    void On_Box () {
        if (Code_Box == "Hair_Type_Data" || Code_Box == "Face_Data" || Code_Box == "Hair_Colour_Data" || Code_Box == "Skin_Tone_Data" || Code_Box == "Body_Costume_Data" || Code_Box == "Helmet_Data" || Code_Box == "Weapon_Data" || Code_Box == "Ring_Data" || Code_Box == "Earring_Data" || Code_Box == "Offhand_Data" || Code_Box == "Glove_Data" || Code_Box == "Boot_Data" || Code_Box == "Cape_Data") {
            if (Subcode_Box == "") {
                Home_System.Ins._Character_Selection.On_Change_Equip (Code_Box, Code_Item);
            } else if (Subcode_Box == "HS_Equipment") {
                Selected_Img.gameObject.SetActive (true);
                Home_System.Ins._Home_Status.On_HS_Equipmet_Input_Cb_2 (this);
            }
        } else if (Code_Box == "Hall_Of_Masters_Left") {
            Selected_Img.gameObject.SetActive (true);
            Home_System.Ins._Hall_Of_Masters.On_Hall_Of_Masters_Left (Code_Item);
        } else if (Code_Box == "Hall_Of_Masters_Brown_Box") {
            Home_System.Ins._Hall_Of_Masters.On_Hall_Of_Masters_Brown_Box (_Hall_Of_Masters_Skill_Set.Title);
            Img_Select.sprite = On_Selected;
        } else if (Code_Box == "Price_Skill_1") {
            Home_System.Ins._Hall_Of_Masters.On_Price_Skill_1 (this);
            Img_Select.sprite = On_Selected;
        } else if (Code_Box == "Skill_Set_Up_Type") {
            Selected_Img.gameObject.SetActive (true);
            if (Code_Item == "Active") {Home_System.Ins._Hall_Of_Masters.Cli_Show_Skill_Active ();} 
            else if (Code_Item == "Passive") {Home_System.Ins._Hall_Of_Masters.Cli_Show_Skill_Passive ();}
        } else if (Code_Box == "Skill_Set_Up") {
            Img_Select.gameObject.SetActive (true);
            Home_System.Ins._Hall_Of_Masters.Cli_Skill_Show (this);
        } else if (Code_Box == "Skill_Inventory_1") {
            Home_System.Ins._Hall_Of_Masters.On_Select_Skill_Add (this);
            Img_Select.sprite = On_Selected;
        } else if (Code_Box == "Status_Left") {
            Selected_Img.gameObject.SetActive (true);
            if (Code_Item == "Profile") {
                Home_System.Ins._Home_Status.Open_Clone_Skill_Set_Up ();
            } else if (Code_Item == "Equipment") {
                Home_System.Ins._Home_Status.Cli_On_HS_Equipment ();
            } else if (Code_Item == "Status") {
                 Home_System.Ins._Home_Status.Cli_On_Home_Status ();
            } else if (Code_Item == "Inventory") {
                 Home_System.Ins._Home_Status.Cli_On_HS_Inventory ();
            }
        } else if (Code_Box == "Setting_Configuration_Left") {
            Selected_Img.gameObject.SetActive (true);
            Setting_Configuration.Ins.Cli_Setting_Configuration_Left (this);
        }

        if (Subcode_Box == "HS_Inventory") {
            if (Code_Item == "Item") {
                if (_Item_Data_Script.b_Inventory_Click) {
                    Item_Scene_Script.Ins.On_Click_Inventory (_Item_Data_Script);
                }
            } else if (Code_Box == "Hair_Type_Data" || Code_Box == "Face_Data" || Code_Box == "Hair_Colour_Data" || Code_Box == "Skin_Tone_Data" || Code_Box == "Body_Costume_Data" || Code_Box == "Helmet_Data" || Code_Box == "Weapon_Data" || Code_Box == "Ring_Data" || Code_Box == "Earring_Data" || Code_Box == "Offhand_Data" || Code_Box == "Glove_Data" || Code_Box == "Boot_Data" || Code_Box == "Cape_Data") {
                Home_System.Ins._Home_Status.On_Input_Cur_Select_Inventory (this);
                b_Can_Click = true;
            }
        } else if (Subcode_Box == "Submit_1") {
            Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Choose_Items (this);
            Selected_Img.gameObject.SetActive (true);
        }
    }
    
    void Off_Box () {
        if (Code_Box == "Hair_Type_Data" || Code_Box == "Face_Data" || Code_Box == "Hair_Colour_Data" || Code_Box == "Skin_Tone_Data" || Code_Box == "Body_Costume_Data" || Code_Box == "Helmet_Data" || Code_Box == "Weapon_Data" || Code_Box == "Ring_Data" || Code_Box == "Earring_Data" || Code_Box == "Offhand_Data" || Code_Box == "Glove_Data" || Code_Box == "Boot_Data" || Code_Box == "Cape_Data") {
            if (Subcode_Box == "") {

            }  else if (Subcode_Box == "HS_Equipment") {
                Selected_Img.gameObject.SetActive (false);
            } else if (Subcode_Box == "Submit_1") {
             Selected_Img.gameObject.SetActive (false);
            } 
        } else if (Code_Box == "Hall_Of_Masters_Left") {
            Selected_Img.gameObject.SetActive (false);
        } else if (Code_Box == "Hall_Of_Masters_Brown_Box") {
            Img_Select.sprite = Off_Selected;
        } else if (Code_Box == "Price_Skill_1") {
            Img_Select.sprite = Off_Selected;
        } else if (Code_Box == "Skill_Set_Up_Type") {
            Selected_Img.gameObject.SetActive (false);
        } else if (Code_Box == "Skill_Set_Up") {
            Img_Select.gameObject.SetActive (false);
        } else if (Code_Box == "Skill_Inventory_1") {
             Img_Select.sprite = Off_Selected;
        } else if (Code_Box =="Status_Left" || Code_Box == "Setting_Configuration_Left") {
            Selected_Img.gameObject.SetActive (false);
        } 
    }
#region Input_Data
    // Submit_1_Parent:
    [HideInInspector]
    public Sprite Sp_283;
    [HideInInspector]
    public string Item_Name;

    public void On_Input_Data (Sprite Sp_283_x_283_V) {
        Logo_Img.sprite = Sp_283_x_283_V;
        if (A_Text.Length >0) {
            A_Text[0].text = Code_Item;
        }
        if (Subcode_Box == "HS_Equipment") {
            Home_System.Ins._Character_Selection.On_Create_Urutan_Button (this);
            A_Text[1].gameObject.SetActive (false);
            BG_Equip_Img.gameObject.SetActive (false);
        }
    }
    public void On_Input_Data (Sprite Sp_283_x_283_V, string Name_V) { // Body_Costume_Data.
        Logo_Img.sprite = Sp_283_x_283_V;  Sp_283 = Sp_283_x_283_V; Item_Name = Name_V;
        if (A_Text.Length >0) {
            A_Text[0].text = Name_V;
        }
        if (Subcode_Box == "HS_Inventory" || Subcode_Box == "Submit_1") {
            if (Subcode_Box == "Submit_1") {Dont_Destroy_On_Load.Ins._Submit_1_Parent.Add_Check_Box_Type_2 (this);}
            if (Subcode_Box == "HS_Inventory" ) {Home_System.Ins._Character_Selection.On_Create_Urutan_Button (this);}
            if (Code_Item == "Item") {
                if (A_Text.Length >1) {
                    A_Text[1].text = "x " + 0;
                }
            } else {
                A_Text[1].gameObject.SetActive (false);
            }
            BG_Equip_Img.gameObject.SetActive (false);
        }
       if (Subcode_Box == "HS_Equipment") {
            Home_System.Ins._Character_Selection.On_Create_Urutan_Button (this);
            A_Text[1].gameObject.SetActive (false);
            BG_Equip_Img.gameObject.SetActive (false);
        } 
        if (Subcode_Box == "Got_Parent") {
            // Home_System.Ins._Character_Selection.On_Create_Urutan_Button (this);
            if (Code_Item == "Item") {
                if (A_Text.Length >1) {
                    A_Text[1].text = "x " + 0;
                }
            } else {
                A_Text[1].gameObject.SetActive (false);
            }
           //  BG_Equip_Img.gameObject.SetActive (false);
        }
    }

    // Character_Selection / Got_Item_1_Parent :
    public void On_Input_Data (Sprite Sp_283_x_283_V, string Name_V, string Value) {
        Logo_Img.sprite = Sp_283_x_283_V;  Sp_283 = Sp_283_x_283_V; Item_Name = Name_V;
       
        if (A_Text.Length >0) {
            A_Text[0].text = Name_V;
        }
        if (Subcode_Box == "HS_Inventory"|| Subcode_Box == "Submit_1") {
            if (Subcode_Box == "Submit_1") {Dont_Destroy_On_Load.Ins._Submit_1_Parent.Add_Check_Box_Type_2 (this);}
             if (Subcode_Box == "HS_Inventory" ) {Home_System.Ins._Character_Selection.On_Create_Urutan_Button (this);}
            if (Code_Item == "Item") {
                if (A_Text.Length >1) {
                    A_Text[1].text = "x " + Value;
                }
            } else {
                A_Text[1].gameObject.SetActive (false);
            }
            BG_Equip_Img.gameObject.SetActive (false);
        }
        if (Subcode_Box == "Got_Parent") {
             
            // Home_System.Ins._Character_Selection.On_Create_Urutan_Button (this);
            if (Code_Item == "Item") {
                if (A_Text.Length >1) {
                    A_Text[1].text = "x " + Value;
                }
            } else {
                A_Text[1].gameObject.SetActive (false);
            }
           // BG_Equip_Img.gameObject.SetActive (false);
        }
    }

    public void On_Input_Data (Color Color_V) {
        Logo_Img.color = Color_V;
    }

    // Hall_Of_Masters :
    public void On_Input_Skill_Data_Kumpulan (Skill_Data_Kumpulan V) {
        _Skill_Data_Kumpulan = V;
        if (Code_Box == "Skill_Set_Up") {
            A_Text[0].text = _Skill_Data_Kumpulan.Skill_Name;
            A_Text[1].text = "Lv. " + _Skill_Data_Kumpulan.Skill_Level.ToString ();
            if (_Skill_Data_Kumpulan.Skill_Name != "") {
                Bg_Have_Skill.gameObject.SetActive (true); 
                Bg_Not_Have_Skill.gameObject.SetActive (false);
                Logo_Img.sprite = _Skill_Data_Kumpulan._Skill_Data_Editor.Skill_Sprite_Settings;
            } else {
                Bg_Have_Skill.gameObject.SetActive (false);
                Bg_Not_Have_Skill.gameObject.SetActive (true);
            }
           // if (!_Skill_Data_Kumpulan) {
                
          //  }
        }
        if (Code_Box == "Price_Skill_1" || Code_Box == "Skill_Inventory_1") {
            _Skill_Data_Kumpulan = V;
            Logo_Img.sprite = _Skill_Data_Kumpulan._Skill_Data_Editor.Skill_Sprite_Settings;
        }

        
    }

    // Hall_Of_Masters :
    public void On_Input_Hall_Of_Masters_Skill_Set (Hall_Of_Masters_Skill_Set Hm) { // For : Price_Skill_1 / Skill_Inventory_1
        _Hall_Of_Masters_Skill_Set = Hm;
        if (Code_Box == "Skill_Inventory_1") {
            A_Text[0].text = _Skill_Keterangan.Skill_Name;
            int.TryParse  (_Hall_Of_Masters_Skill_Set.A_Skill_Set_Data[Code_Urutan], out Got_Skill);
            if (Got_Skill == 0) { // tidak ada skill
                Home_System.Ins._Hall_Of_Masters.Remove_L_But_Ins_Skill_Add (this);
                // Destroy (this.gameObject);
            } else { // ada skill
                if (!Home_System.Ins._Hall_Of_Masters.Check_Same_Skill_Slot (_Skill_Keterangan.Skill_Name)) {
                    Img_Select.color = Normal_Color;
                    Logo_Img.color = Normal_Color;
                    b_Can_Click = true;
                } else {
                    Img_Select.color = Grayout_Color;
                    Logo_Img.color = Grayout_Color;
                    b_Can_Click = false;
                }
            }
        } else if (Code_Box == "Price_Skill_1") {
            int.TryParse  (_Hall_Of_Masters_Skill_Set.A_Skill_Set_Data[Code_Urutan], out Got_Skill);
            if (Got_Skill > 0) {
                Img_Select.color = Grayout_Color;
                Logo_Img.color = Grayout_Color;
                b_Can_Click = false;
            } else {
                Img_Select.color = Normal_Color;
                Logo_Img.color = Normal_Color;
                b_Can_Click = true;
            }
        }
    }

    // Hall_Of_Masters
    public void Load_Local_When_Buy_Skill () { // For Price_Skill_1
        _Hall_Of_Masters_Skill_Set.A_Skill_Set_Data[Code_Urutan] = "1";
        int.TryParse  (_Hall_Of_Masters_Skill_Set.A_Skill_Set_Data[Code_Urutan], out Got_Skill);
        Img_Select.color = Grayout_Color; Logo_Img.color = Grayout_Color;
        b_Can_Click = false;
    }
#endregion
#region On_Load
//  Home_Status - Hall_Of_Masters :
    public void On_Load () {
        if (Code_Box == "Hall_Of_Masters_Brown_Box") {
            // Debug.Log ("Load_Data");
            _Load_Visual_Novel = this.gameObject.GetComponent <Load_Visual_Novel>();
            this.gameObject.GetComponent <Load_Visual_Novel>().Load_Data ();
        }
    }
#endregion
}
