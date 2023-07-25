using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Starsky;
public class Character_Selection : MonoBehaviour {
    [SerializeField]
    Check_Box [] A_Check_Box_Gender;
    [SerializeField]
    Check_Box [] A_Check_Box_Accesories;

    [SerializeField]
    TMP_InputField Nickname_IF;

    [SerializeField]
    Canvas Character_Selection_Canvas; 
    
    [SerializeField]
    Transform Gender_Data_Trans, Hair_Type_Data_Trans, Face_Data_Trans, Hair_Colour_Data_Trans, Skin_Tone_Data_Trans, Body_Costume_Trans, Weapon_Trans, Ring_Trans, Earring_Trans, Offhand_Trans, Cape_Trans;

    [HideInInspector]
    public List <Gender_Data> L_Gender_Data;
    [HideInInspector]
    public List <Hair_Type_Data> L_Hair_Type_Data;
    [HideInInspector]
    public List <Face_Data> L_Face_Data;
    [HideInInspector]
    public List <Hair_Colour_Data> L_Hair_Colour_Data;
    [HideInInspector]
    public List <Skin_Tone_Data> L_Skin_Tone_Data;
    public Pemisah_Gender_Script PG_Body_Costume;
    [HideInInspector]
    public List <Body_Costume_Data> L_Body_Costume_Data;
    [HideInInspector]
    public List <Weapon_Data> L_Weapon_Data;
    [HideInInspector]
    public List <Ring_Data> L_Ring_Data;
    [HideInInspector]
    public List <Earring_Data> L_Earring_Data;
    [HideInInspector]
    public List <Offhand_Data> L_Offhand_Data;
    [HideInInspector]
    public List <Cape_Data> L_Cape_Data;
    void FixedUpdate () {
        if (b_On_Drag_Color_Bar) {
            CS_Hair_Value_Colour = (int)(Hue_Slider.value *1000);
            CS_Hair_Value_Dark = (int)(Dark_Slider.value * 1000);
            Target_Player_2d.Cur_Hair_Type_Front_GO.GetComponent <SpriteRenderer> ().color = Color.HSVToRGB(Hue_Slider.value, 0.7f, Dark_Slider.value);
            if (Target_Player_2d.Cur_Hair_Type_Back_GO) {
                Target_Player_2d.Cur_Hair_Type_Back_GO.GetComponent <SpriteRenderer> ().color = Color.HSVToRGB(Hue_Slider.value, 0.7f, Dark_Slider.value);
            }
        }
    }
    void On_Character_Load_Data () {
        L_Gender_Data = new List <Gender_Data> ();
        foreach (Transform x in Gender_Data_Trans) {
            L_Gender_Data.Add (x.GetComponent <Gender_Data>());
        }

        L_Hair_Type_Data = new List <Hair_Type_Data> ();
        foreach (Transform x in Hair_Type_Data_Trans) {
            L_Hair_Type_Data.Add (x.GetComponent <Hair_Type_Data>());
        }

        L_Face_Data = new List <Face_Data> ();
        foreach (Transform x in Face_Data_Trans) {
            L_Face_Data.Add (x.GetComponent <Face_Data>());
        }

        L_Hair_Colour_Data = new List <Hair_Colour_Data> ();
        foreach (Transform x in Hair_Colour_Data_Trans) {
            L_Hair_Colour_Data.Add (x.GetComponent <Hair_Colour_Data>());
        }

        L_Skin_Tone_Data = new List <Skin_Tone_Data> ();
        foreach (Transform x in Skin_Tone_Data_Trans) {
            L_Skin_Tone_Data.Add (x.GetComponent <Skin_Tone_Data>());
        }

        L_Body_Costume_Data = new List <Body_Costume_Data> ();
        foreach (Transform x in Body_Costume_Trans) {
            L_Body_Costume_Data.Add (x.GetComponent <Body_Costume_Data>());
        }

         L_Weapon_Data = new List <Weapon_Data> ();
        foreach (Transform x in Weapon_Trans) {
            L_Weapon_Data.Add (x.GetComponent <Weapon_Data>());
        }

         L_Ring_Data = new List <Ring_Data> ();
        foreach (Transform x in Ring_Trans) {
            L_Ring_Data.Add (x.GetComponent <Ring_Data>());
        }

         L_Earring_Data = new List <Earring_Data> ();
        foreach (Transform x in Earring_Trans) {
            L_Earring_Data.Add (x.GetComponent <Earring_Data>());
        }

         L_Offhand_Data = new List <Offhand_Data> ();
        foreach (Transform x in Offhand_Trans) {
            L_Offhand_Data.Add (x.GetComponent <Offhand_Data>());
        }

        L_Cape_Data = new List <Cape_Data> ();
        foreach (Transform x in Cape_Trans) {
            L_Cape_Data.Add (x.GetComponent <Cape_Data>());
        }
    }
    // Home_Canvas :
    public void On_Character_Selection () {
        On_Change_Panel_Type_1_Skill_Tab_2 ("Character_Selection");
        Home_System.Ins._Character_Selection.On_Chg_Target_Player_2d (Dont_Destroy_On_Load.Ins._Player_2d);
        On_Character_Load_Data ();
        if (Dont_Destroy_On_Load.Ins._Data_Online._Player_Status.Gender == "") {
            Character_Selection_Canvas.gameObject.SetActive (true);
            On_Load_Character_Selection ();
        } else {
            Home_System.Ins._Home_Canvas.Character_Selection_To_Home (true);
        }
    }

    // Load_Host_Server :
    public void Off_Character_Selection () {
        Loading_Canvas.Ins.Off_Loading_1 ();
        Character_Selection_Canvas.gameObject.SetActive (false);
        Home_System.Ins._Home_Canvas.Character_Selection_To_Home (false);
        On_Correct_Nickname_2 ();
        Home_System.Ins._Home_Canvas.On_Visual_Novel_Hellper_Awal ();
    }

#region Load_Character_Selection
    void On_Load_Character_Selection () {
        

        A_Check_Box_Gender[0].Cli_Box ();
        A_Check_Box_Accesories[0].Cli_Box ();
        L_Gender_Data[0].On_Set_To_Player_2d (); CS_Gender = L_Gender_Data[0].Code_Terpilih;
        L_Hair_Type_Data[4].On_Set_To_Player_2d (); CS_Hair_Type = L_Hair_Type_Data[4].Code_Terpilih;
        L_Face_Data[0].On_Set_To_Player_2d (); CS_Face = L_Face_Data[0].Code_Terpilih;
        L_Hair_Colour_Data[0].On_Set_To_Player_2d (); CS_Hair_Colour = L_Hair_Colour_Data[0].Code_Terpilih;
        L_Skin_Tone_Data[0].On_Set_To_Player_2d (); CS_Skin_Tone = L_Skin_Tone_Data[0].Code_Terpilih;
        PG_Body_Costume.Conv_Body_Costume("Free_Costume", "Male").On_Set_To_Player_2d ("Body_Costume"); CS_Body_Costume = "Free_Costume";
        PG_Body_Costume.Conv_Body_Costume("Free_Costume", "Male").On_Set_To_Player_2d ("Boot"); CS_Boot = "Free_Costume";
      //  L_Body_Costume_Data[1].On_Set_To_Player_2d ("Body_Costume"); CS_Body_Costume = L_Body_Costume_Data[1].Code_Terpilih;
      //  L_Body_Costume_Data[1].On_Set_To_Player_2d ("Boot"); CS_Boot = L_Body_Costume_Data[1].Code_Terpilih;
    }
#endregion
#region Refresh_Gender & Refresh_Accesories
    // --- Refresh_Gender :
    public void On_Refresh_Gender (string V) {
        foreach (Check_Box x in A_Check_Box_Gender) {
            if (x.Code_Box != V) {x.Auto_Off_Box ();}
        }
      //  Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Body ();
        
        foreach (Gender_Data x in L_Gender_Data) {
            if (x.Code_Terpilih == V) { // x.Code_Character_Selection
                x.On_Set_To_Player_2d ();
            }
        }
        CS_Gender = V;
        Target_Type_Gender = Target_Player_2d.Cur_Gender_GO.GetComponent <Gender_Data>().Gender_Type;
        On_Refresh_Accesories (Cur_Code_Refresh_Accesories);
        // Refresh_Ulang :
        // L_Gender_Data[0].On_Set_To_Player_2d (); CS_Gender = L_Gender_Data[0].Code_Terpilih;
        if (Target_Type_Gender == "Female") { 
            L_Hair_Type_Data[0].On_Set_To_Player_2d (); CS_Hair_Type = L_Hair_Type_Data[0].Code_Terpilih;
            L_Face_Data[0].On_Set_To_Player_2d (); CS_Face = L_Face_Data[0].Code_Terpilih;
            L_Hair_Colour_Data[0].On_Set_To_Player_2d (); CS_Hair_Colour = L_Hair_Colour_Data[0].Code_Terpilih;
            L_Skin_Tone_Data[0].On_Set_To_Player_2d (); CS_Skin_Tone = L_Skin_Tone_Data[0].Code_Terpilih;
          //  L_Body_Costume_Data[0].On_Set_To_Player_2d ("Body_Costume"); CS_Body_Costume = L_Body_Costume_Data[0].Code_Terpilih;
          //  L_Body_Costume_Data[0].On_Set_To_Player_2d ("Boot"); CS_Boot = L_Body_Costume_Data[0].Code_Terpilih;
          PG_Body_Costume.Conv_Body_Costume("Free_Costume", "Female").On_Set_To_Player_2d ("Body_Costume"); CS_Body_Costume = "Free_Costume";
          PG_Body_Costume.Conv_Body_Costume("Free_Costume", "Female").On_Set_To_Player_2d ("Boot"); CS_Boot = "Free_Costume";
        } else if (Target_Type_Gender == "Male") {
            L_Hair_Type_Data[4].On_Set_To_Player_2d (); CS_Hair_Type = L_Hair_Type_Data[4].Code_Terpilih;
            L_Face_Data[0].On_Set_To_Player_2d (); CS_Face = L_Face_Data[0].Code_Terpilih;
            L_Hair_Colour_Data[0].On_Set_To_Player_2d (); CS_Hair_Colour = L_Hair_Colour_Data[0].Code_Terpilih;
            L_Skin_Tone_Data[0].On_Set_To_Player_2d (); CS_Skin_Tone = L_Skin_Tone_Data[0].Code_Terpilih;
         //   L_Body_Costume_Data[1].On_Set_To_Player_2d ("Body_Costume"); CS_Body_Costume = L_Body_Costume_Data[1].Code_Terpilih;
         //   L_Body_Costume_Data[1].On_Set_To_Player_2d ("Boot"); CS_Boot = L_Body_Costume_Data[1].Code_Terpilih;
            PG_Body_Costume.Conv_Body_Costume("Free_Costume", "Male").On_Set_To_Player_2d ("Body_Costume"); CS_Body_Costume = "Free_Costume";
            PG_Body_Costume.Conv_Body_Costume("Free_Costume", "Male").On_Set_To_Player_2d ("Boot"); CS_Boot = "Free_Costume";
        }

      //  Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Body ();
        
    }
    [HideInInspector]
    public string Target_Type_Gender = ""; // "Male" / "Female" / "All"
    string Cur_Code_Refresh_Accesories;
    // --- Check_Box:
    public void On_Refresh_Accesories (string V) {
        
        Cur_Code_Refresh_Accesories = V;

        Diactive_All_Type_1_Box_Selection_Panel_Column ();
        Diactive_All_Type_2_Box_Selection_Panel_Column ();

        Destroy_All_Type_1_Box_Selection_Panel_Column ();
        Destroy_All_Type_2_Box_Selection_Panel_Column ();

        Diactive_All_Box_Selection_Panel_Column ();

        b_Type_1_Skill_Tab_2_Current_Layout = false;

        if (!b_Type_1_Skill_Tab_2_Current_Layout) {
            b_Type_1_Skill_Tab_2_Current_Layout = true;
            On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 ();
        }


        foreach (Check_Box x in A_Check_Box_Accesories) {
            if (x.Code_Box != V) {x.Auto_Off_Box ();}
        }
        
        Target_Type_Gender = Target_Player_2d.Cur_Gender_GO.GetComponent <Gender_Data>().Gender_Type;

        if (V == "Character_Selection_Hair_Type") {
            Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
            foreach (Hair_Type_Data x in L_Hair_Type_Data) {
                if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                    
                    x.On_Create_Button_To_Character_Selection ();
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                }
                
            }
            // Hair_Colour :
            Bg_Color_Bar.gameObject.SetActive (true);
            // Type_2_Box_Selection_Panel_Parent.gameObject.SetActive (true);
            /*
            foreach (Hair_Colour_Data x in L_Hair_Colour_Data) {
                
                x.On_Create_Button_To_Character_Selection ();
                On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
            }
            */

        }

        if (V == "Character_Selection_Face") {
            Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
            foreach (Face_Data x in L_Face_Data) {
                if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                    
                    x.On_Create_Button_To_Character_Selection ();
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                }
            }
        }
   
        if (V == "Character_Selection_Skin_Tone") {
          
            Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
            foreach (Skin_Tone_Data x in L_Skin_Tone_Data) {
                
                x.On_Create_Button_To_Character_Selection ();
                On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
            }
        } 
        if (V == "Character_Selection_Body_Costume") {
            Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
            foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                    
                    x.On_Create_Button_To_Character_Selection ("Body_Costume");
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                }
            }
            
        }
        
    }
#endregion
#region Box_Selection_Panel_Column
    [SerializeField]
    Transform Type_1_Box_Selection_Panel_Parent;
    [SerializeField]
    Transform Type_2_Box_Selection_Panel_Parent;
    [SerializeField]
    Image Bg_Color_Bar; 
    [SerializeField]
    bool b_On_Drag_Color_Bar = false;
    [SerializeField]
    Slider Hue_Slider;
    [SerializeField]
    Slider Dark_Slider;
    public void On_Begin_Color_Bar () {
        b_On_Drag_Color_Bar = true;
    }

    public void On_End_Color_Bar () {
        b_On_Drag_Color_Bar = false;
    }
    // Hair_Type_Data :
    public Transform Type_1_Box_Selection_Panel_Column; // Height Column 159 * Jumlah Kolom.
    public Transform Type_2_Box_Selection_Panel_Column; // Height Column 86 * Jumlah Kolom.

    // Hair_Type_Data :
    public GameObject Type_1_Character_Select_Check_Box_Sample;
    public GameObject Type_2_Character_Select_Check_Box_Sample;
    void Diactive_All_Box_Selection_Panel_Column () {
        Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (false);
        Type_2_Box_Selection_Panel_Parent.gameObject.SetActive (false);
        Bg_Color_Bar.gameObject.SetActive (false);
    }

    public void Diactive_All_Type_1_Box_Selection_Panel_Column () {
        foreach  (Transform x in Type_1_Box_Selection_Panel_Column) {
            x.gameObject.SetActive (false);
        }
        Diactive_All_Type_1_Skill_Tab_2_Vertical_Layout ();
    }

    public void Destroy_All_Type_1_Box_Selection_Panel_Column () {
        foreach  (Transform x in Type_1_Box_Selection_Panel_Column) {
            if (x.gameObject.activeInHierarchy == false && x.GetComponent <Check_Box_Type_2>().b_Sample == false) {
                Destroy (x.gameObject);
            }
        }
        Destroy_All_Type_1_Skill_Tab_2_Vertical_Layout ();
    }
    #region Vertical_Layout (Type_1)
            [SerializeField]
            GameObject Type_1_Box_Skill_Tab_2_Vertical_Layout_Parent;
            [SerializeField]
            GameObject Type_1_Box_Skill_Tab_2_Vertical_Samp;
            Type_1_Vertical_Layout Type_1_Skill_Tab_2_Current_Layout;
            bool b_Type_1_Skill_Tab_2_Current_Layout = false;
            void On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 () {
               // Type_1_Skill_Tab_2_Current_Layout.Total_Box_In_Button ++;
                //GameObject Ver = GameObject.Instantiate (Type_1_Box_Skill_Tab_2_Vertical_Samp); 
                GameObject Ver = GameObject.Instantiate (Target_Panel_Column_Samp);
                // Ver.transform.parent = Type_1_Box_Skill_Tab_2_Vertical_Layout_Parent.transform;
                Ver.transform.parent = Target_Parent_Column;
                Type_1_Vertical_Layout Vs = Ver.GetComponent <Type_1_Vertical_Layout> ();
                Vs.b_Sample = false;
                Type_1_Skill_Tab_2_Current_Layout = Vs;
                Type_1_Box_Selection_Panel_Column =  Ver.gameObject.transform;
                Ver.SetActive (true);
                Ver.transform.localScale = new Vector3 (1,1,1);
            }
            int Max_Box_In_Row = 3;
            //Pasang sebelum Ins dan sebelum SetParent : Hair_Type_Data (DIGANTI JADI THIS DISINI)
            public void On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 () {
                Type_1_Skill_Tab_2_Current_Layout.Total_Box_In_Button ++;
                if (Type_1_Skill_Tab_2_Current_Layout.Total_Box_In_Button >= Max_Box_In_Row) {
                    On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 ();

                }
            }

            void Diactive_All_Type_1_Skill_Tab_2_Vertical_Layout () {
                foreach (Transform x in Target_Parent_Column) {
                    x.gameObject.SetActive (false);
                }
            }

            void Destroy_All_Type_1_Skill_Tab_2_Vertical_Layout () {
                foreach (Transform x in Target_Parent_Column) {
                    if (x.gameObject.activeInHierarchy == false && !x.gameObject.GetComponent <Type_1_Vertical_Layout> ().b_Sample) {
                        Destroy (x.gameObject);
                    }
                }
            }
            #endregion

    public void Diactive_All_Type_2_Box_Selection_Panel_Column () {
        foreach  (Transform x in Type_2_Box_Selection_Panel_Column) {
            x.gameObject.SetActive (false);
        }
    }

    public void Destroy_All_Type_2_Box_Selection_Panel_Column () {
        foreach  (Transform x in Type_2_Box_Selection_Panel_Column) {
            if (x.gameObject.activeInHierarchy == false && x.GetComponent <Check_Box_Type_2>().b_Sample == false) {
                Destroy (x.gameObject);
            }
        }
    }
    
#endregion
#region Change_Equip
    public void On_Change_Equip (string Type_V, string Name_V) {
        
        if (Type_V == "Hair_Type_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Hair_Type_Front ();
           Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Hair_Type_Back ();

            foreach (Hair_Type_Data x in L_Hair_Type_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Hair_Type = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Hair_Type_Front ();
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Hair_Type_Back ();
        }
        if (Type_V == "Face_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Face ();
           

            foreach (Face_Data x in L_Face_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Face = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Face ();
        }
        if (Type_V == "Hair_Colour_Data") {
           
            foreach (Hair_Colour_Data x in L_Hair_Colour_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Hair_Colour = Name_V;
        }
        if (Type_V == "Skin_Tone_Data") {
           
            foreach (Skin_Tone_Data x in L_Skin_Tone_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Skin_Tone = Name_V;
        }
        if (Type_V == "Body_Costume_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Body_Costume();
           
            foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                if (Name_V == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Body_Costume");
                }
            }
            CS_Body_Costume = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Body_Costume ();
        }
        if (Type_V == "Helmet_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Body_Costume();
           
            foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                if (Name_V == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Helmet");
                }
            }
            CS_Helmet = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Body_Costume ();
        }
        if (Type_V == "Weapon_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Weapon();
           

            foreach (Weapon_Data x in L_Weapon_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Weapon = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Weapon ();
        }
        if (Type_V == "Ring_Data") {
           //Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Weapon();
           

            foreach (Ring_Data x in L_Ring_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Ring = Name_V;
          //  Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Weapon ();
        }
        if (Type_V == "Earring_Data") {
           //Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Weapon();
           

            foreach (Earring_Data x in L_Earring_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Earring = Name_V;
          //  Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Weapon ();
        }
        if (Type_V == "Offhand_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Offhand();
           

            foreach (Offhand_Data x in L_Offhand_Data) {
                if (Name_V == x.Code_Terpilih ) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Offhand = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Offhand ();
        }
        if (Type_V == "Glove_Data") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Body_Costume();
           
            foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                if (Name_V == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Glove");
                }
            }
            CS_Glove = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Body_Costume ();
        }
        if (Type_V == "Boot") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Body_Costume();
           
            foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                if (Name_V == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Boot");
                }
            }
            CS_Boot = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Body_Costume ();
        }
        if (Type_V == "Cape") {
            Dont_Destroy_On_Load.Ins._Player_2d.Diactive_All_Asset_Cape();
           
            foreach (Cape_Data x in L_Cape_Data) {
                if (Name_V == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
            }
            CS_Cape = Name_V;
            Dont_Destroy_On_Load.Ins._Player_2d.Destroy_All_Diactive_Asset_Cape ();
        }
    }
#endregion
#region Confirm_Character_Selection
    string CS_Nickname = "";
    string CS_Gender = "";
    string CS_Hair_Type = "";
    string CS_Face = "";
    string CS_Hair_Colour = "";
    string CS_Skin_Tone = "";
    string CS_Body_Costume = "";
    string CS_Helmet = "";
    string CS_Weapon = "";
    string CS_Ring = "";
    string CS_Earring = "";
    string CS_Offhand = "";
    string CS_Glove = "";
    string CS_Boot = "";
    string CS_Cape = "";
    int CS_Hair_Value_Colour = 0;
    int CS_Hair_Value_Dark = 0;
    public void On_Confirm_Character_Selection () {
        string Nickname_V = Nickname_IF.text;
        if (Nickname_V.Length <6) {
            Short_Nickname ();
        } else if (Nickname_V.Length > 12) {
            Long_Nickname ();
        } else {
            Correct_Nickname ();
        }
    }

    void Short_Nickname () {
        Notification_Canvas.Ins.On_Notification_1 ("Notification", "Your nickname is short. Please enter your nickname around 6 - 12 letters.", "Okay", "");
    }

    void Long_Nickname () {
        Notification_Canvas.Ins.On_Notification_1 ("Notification", "Your nickname is long. Please enter your nickname around 6 - 12 letters.", "Okay", "");
    }

    void Correct_Nickname () {
        CS_Nickname = Nickname_IF.text;
        Loading_Canvas.Ins.On_Loading_1 ();
        // Save_Inventory :
        Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
       // Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Hair_Type, "Hair_Type", "1");
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Body_Costume, "Body_Costume", "1");
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Boot, "Boot", "1");
        Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
        // END
        Character_Selection_Canvas.gameObject.SetActive (false);
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Player_Status (CS_Nickname,CS_Gender,CS_Hair_Type,CS_Face,CS_Hair_Colour,CS_Skin_Tone,CS_Body_Costume, CS_Helmet, CS_Weapon, CS_Ring, CS_Earring, CS_Offhand, CS_Glove, CS_Boot, CS_Cape);   
    }

    void On_Correct_Nickname_2 () {
        Loading_Canvas.Ins.On_Loading_1 ();
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Hair_Colour (CS_Hair_Value_Colour, CS_Hair_Value_Dark);
    }
    // Load_Host_Server :
    public void On_Correct_Nickname_3 () {
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Player_Status_Equipment_Slot (0,0,0,0,1,0,0,0,0,2,0);
    }

#endregion
#region Online_Player_Status
// Face_Data,dll.
public Player_2d Target_Player_2d;
// This & Home_Canvas (Offline) / Online_Player_Status (Online) - Player_2d :
public void On_Chg_Target_Player_2d (Player_2d x) {
    Target_Player_2d = x;
}
#endregion
#region Settings_Type_1_Skill_Tab_2
    public string Code_Active_Equipment ;
    GameObject Target_Panel_Column_Samp;
    [HideInInspector]
    public Transform Target_Parent_Column;

    [SerializeField]
    GameObject Character_Selection_Type_1_Character_Select_Check_Box_Sample;
    [SerializeField]
    GameObject Character_Selection_Panel_Column_Samp;
    [SerializeField]
    Transform Character_Selection_Target_Parent_Column;
    [SerializeField]
    int Character_Selection_Max_Box_In_Row = 3;

    [SerializeField]
    GameObject Inventory_Type_1_Character_Select_Check_Box_Sample;
    [SerializeField]
    GameObject Inventory_Panel_Column_Samp;
    [SerializeField]
    Transform Inventory_Target_Parent_Column;
    [SerializeField]
    int Inventory_Max_Box_In_Row = 8;

    [SerializeField]
    GameObject Equipment_Type_1_Character_Select_Check_Box_Sample;
    [SerializeField]
    GameObject Equipment_Panel_Column_Samp;
    [SerializeField]
    Transform Equipment_Target_Parent_Column;
    [SerializeField]
    int Equipment_Max_Box_In_Row = 3;

    // This / Home_Status :
    public void On_Change_Panel_Type_1_Skill_Tab_2 (string V) {
        Code_Active_Equipment = V;
        if (V == "Character_Selection") {
            Type_1_Character_Select_Check_Box_Sample = Character_Selection_Type_1_Character_Select_Check_Box_Sample;
            Target_Panel_Column_Samp = Character_Selection_Panel_Column_Samp;
            Target_Parent_Column = Character_Selection_Target_Parent_Column;
            Max_Box_In_Row = Character_Selection_Max_Box_In_Row;
        } else if (V == "Inventory") {
            
            Type_1_Character_Select_Check_Box_Sample = Inventory_Type_1_Character_Select_Check_Box_Sample;
            Target_Panel_Column_Samp = Inventory_Panel_Column_Samp;
            Target_Parent_Column = Inventory_Target_Parent_Column;
            Max_Box_In_Row = Inventory_Max_Box_In_Row;
        } else if (V == "Equipment") {
            
            Type_1_Character_Select_Check_Box_Sample = Equipment_Type_1_Character_Select_Check_Box_Sample;
            Target_Panel_Column_Samp = Equipment_Panel_Column_Samp;
            Target_Parent_Column = Equipment_Target_Parent_Column;
            Max_Box_In_Row = Equipment_Max_Box_In_Row;
        }
    }

    #region Home_Status
    // Home_Status :
    int Code_Urutan_Button = 0;
    [SerializeField]
    Sprite Inventory_Black;
    
    Check_Box_Type_2 Cb_Home_Status_Slot_Hair_Type;
    Check_Box_Type_2 Cb_Home_Status_Slot_Helmet;
    Check_Box_Type_2 Cb_Home_Status_Slot_Weapon;
    Check_Box_Type_2 Cb_Home_Status_Slot_Ring;
    Check_Box_Type_2 Cb_Home_Status_Slot_Body_Costume;
    Check_Box_Type_2 Cb_Home_Status_Slot_Face;
    Check_Box_Type_2 Cb_Home_Status_Slot_Earring;
    Check_Box_Type_2 Cb_Home_Status_Slot_Offhand;
    Check_Box_Type_2 Cb_Home_Status_Slot_Glove;
    Check_Box_Type_2 Cb_Home_Status_Slot_Boot;
    Check_Box_Type_2 Cb_Home_Status_Slot_Cape;

    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Hair_Type_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Helmet_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Weapon_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Ring_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Body_Costume_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Face_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Earring_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Offhand_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Glove_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Boot_3;
    [SerializeField]
    Check_Box_Type_3 Cb_Home_Status_Slot_Cape_3;
    
    // Home_Status :
    public void Off_Cb_Home_Status_Slot_Cape_3 () {
        Cb_Home_Status_Slot_Hair_Type_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Helmet_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Weapon_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Ring_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Body_Costume_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Face_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Earring_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Offhand_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Glove_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Boot_3.Auto_Off_Box ();
        Cb_Home_Status_Slot_Cape_3.Auto_Off_Box ();
    }

    Player_Status _Player_Status;
    // this - Player_2d :
    public void On_Input_Player_Status (Player_Status x) {
        _Player_Status = x;
    }
    // Check_Box_Type_2 
    public void On_Create_Urutan_Button (Check_Box_Type_2 Result_Ins) {
        Code_Urutan_Button ++;
        Result_Ins.Code_Urutan = Code_Urutan_Button;
        
    }
    // Home_Status / this (Equipment - Item) : :
    public void On_Inc_Code_Urutan_Button () {
        Code_Urutan_Button++;
    }
        #region On_Give_Equip_Logo
        // Home_Status :
        public void On_Give_Equip_Logo_All () {
            Dont_Destroy_On_Load.Ins._Player_2d.On_Send_Player_Status_To_Character_Selection ();
            On_Give_Equip_Logo ("Slot_Hair_Type");
            On_Give_Equip_Logo ("Slot_Helmet");
            On_Give_Equip_Logo ("Slot_Weapon");
            On_Give_Equip_Logo ("Slot_Ring");
            On_Give_Equip_Logo ("Slot_Body_Costume");
            On_Give_Equip_Logo ("Slot_Face");
            On_Give_Equip_Logo ("Slot_Earring");
            On_Give_Equip_Logo ("Slot_Offhand");
            On_Give_Equip_Logo ("Slot_Glove");
            On_Give_Equip_Logo ("Slot_Boot");
            On_Give_Equip_Logo ("Slot_Cape");
        }
        
        void On_Give_Equip_Logo (string v) {
            // Slot_Hair_Type :
            if (v == "Slot_Hair_Type") {
                if (Cb_Home_Status_Slot_Hair_Type) {Cb_Home_Status_Slot_Hair_Type.Off_Equip_Img ();}
                if (_Player_Status.Slot_Hair_Type != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Hair_Type) {
                                Cb_Home_Status_Slot_Hair_Type = xs;
                                Cb_Home_Status_Slot_Hair_Type_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Hair_Type.On_Equip_Img ();
                }
            }
            // Slot_Helmet : 
            if (v == "Slot_Helmet") {
                
                if (Cb_Home_Status_Slot_Helmet) {Cb_Home_Status_Slot_Helmet.Off_Equip_Img ();}
                if (_Player_Status.Slot_Helmet != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Helmet) {
                                Cb_Home_Status_Slot_Helmet = xs;
                                Cb_Home_Status_Slot_Helmet_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Helmet.On_Equip_Img ();
                }
            }

            // Slot_Weapon : 
            if (v == "Slot_Weapon") {
                
                if (Cb_Home_Status_Slot_Weapon) {Cb_Home_Status_Slot_Weapon.Off_Equip_Img ();}
                if (_Player_Status.Slot_Weapon != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Weapon) {
                                Cb_Home_Status_Slot_Weapon = xs;
                                Cb_Home_Status_Slot_Weapon_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Weapon.On_Equip_Img ();
                }
            }

            // Slot_Ring : 
            if (v == "Slot_Ring") {
                
                if (Cb_Home_Status_Slot_Ring) {Cb_Home_Status_Slot_Ring.Off_Equip_Img ();}
                if (_Player_Status.Slot_Ring != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Ring) {
                                Cb_Home_Status_Slot_Ring = xs;
                                Cb_Home_Status_Slot_Ring_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Ring.On_Equip_Img ();
                }
            }

            // Slot_Body_Costume : 
            if (v == "Slot_Body_Costume") {
                
                if (Cb_Home_Status_Slot_Body_Costume) {Cb_Home_Status_Slot_Body_Costume.Off_Equip_Img ();}
                if (_Player_Status.Slot_Body_Costume != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Body_Costume) {
                                Cb_Home_Status_Slot_Body_Costume = xs;
                                Cb_Home_Status_Slot_Body_Costume_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Body_Costume.On_Equip_Img ();
                }
            }

            // Slot_Face : 
            if (v == "Slot_Face") {
                
                if (Cb_Home_Status_Slot_Face) {Cb_Home_Status_Slot_Face.Off_Equip_Img ();}
                if (_Player_Status.Slot_Face != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Face) {
                                Cb_Home_Status_Slot_Face = xs;
                                Cb_Home_Status_Slot_Face_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Face.On_Equip_Img ();
                }
            }

            // Slot_Earring : 
            if (v == "Slot_Earring") {
                
                if (Cb_Home_Status_Slot_Earring) {Cb_Home_Status_Slot_Earring.Off_Equip_Img ();}
                if (_Player_Status.Slot_Earring != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Earring) {
                                Cb_Home_Status_Slot_Earring = xs;
                                Cb_Home_Status_Slot_Earring_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Earring.On_Equip_Img ();
                }
            }

            // Slot_Offhand : 
            if (v == "Slot_Offhand") {
                
                if (Cb_Home_Status_Slot_Offhand) {Cb_Home_Status_Slot_Offhand.Off_Equip_Img ();}
                if (_Player_Status.Slot_Offhand != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Offhand) {
                                Cb_Home_Status_Slot_Offhand = xs;
                                Cb_Home_Status_Slot_Offhand_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Offhand.On_Equip_Img ();
                }
            }

            // Slot_Glove : 
            if (v == "Slot_Glove") {
                
                if (Cb_Home_Status_Slot_Glove) {Cb_Home_Status_Slot_Glove.Off_Equip_Img ();}
                if (_Player_Status.Slot_Glove != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Glove) {
                                Cb_Home_Status_Slot_Glove = xs;
                                Cb_Home_Status_Slot_Glove_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Glove.On_Equip_Img ();
                }
            }

            

            // Slot_Boot : 
            if (v == "Slot_Boot") {
                
                if (Cb_Home_Status_Slot_Boot) {Cb_Home_Status_Slot_Boot.Off_Equip_Img ();}
                if (_Player_Status.Slot_Boot != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Boot) {
                                Cb_Home_Status_Slot_Boot = xs;
                                Cb_Home_Status_Slot_Boot_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Boot.On_Equip_Img ();
                }
            }

            // Slot_Cape : 
            if (v == "Slot_Cape") {
                
                if (Cb_Home_Status_Slot_Cape) {Cb_Home_Status_Slot_Cape.Off_Equip_Img ();}
                if (_Player_Status.Slot_Cape != 0) {
                    foreach (Transform x1 in Target_Parent_Column.transform)  {
                        foreach (Transform x2 in x1.transform) {
                            Check_Box_Type_2 xs = x2.GetComponent <Check_Box_Type_2> ();
                            if (xs.Code_Urutan ==  _Player_Status.Slot_Cape) {
                                Cb_Home_Status_Slot_Cape = xs;
                                Cb_Home_Status_Slot_Cape_3.On_Input_Data_Check_Box_Type_2 (xs);
                                break;
                            }
                            
                        }
                    }
                    Cb_Home_Status_Slot_Cape.On_Equip_Img ();
                }
            }
            
        }
        #endregion

    public void On_Destroy_Cloning_Button () {
        Target_Type_Gender = Target_Player_2d.Cur_Gender_GO.GetComponent <Gender_Data>().Gender_Type;
        Diactive_All_Type_1_Box_Selection_Panel_Column ();
        Diactive_All_Type_2_Box_Selection_Panel_Column ();

        Destroy_All_Type_1_Box_Selection_Panel_Column ();
        Destroy_All_Type_2_Box_Selection_Panel_Column ();

        Diactive_All_Box_Selection_Panel_Column ();
        b_Type_1_Skill_Tab_2_Current_Layout = false;
        Code_Urutan_Button = 0;
    }

    // Home_Status :
    public void On_Create_Button (string Name, string Type, string Value) {
        
        // Code_Urutan_Button ++;
        if (!b_Type_1_Skill_Tab_2_Current_Layout) {
            b_Type_1_Skill_Tab_2_Current_Layout = true;
            On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 ();
        }
        if (Name != "") {
            if (Type == "Hair_Type") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Hair_Type_Data x in L_Hair_Type_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                            
                            x.On_Create_Button_To_Character_Selection ();
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                //   }
                    
                }
                /*
                // Hair_Colour :
                Type_2_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Hair_Colour_Data x in L_Hair_Colour_Data) {
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                    x.On_Create_Button_To_Character_Selection ();
                }
                */
            }

            if (Type == "Face") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Face_Data x in L_Face_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Character_Selection ();
                        On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                //  }
                }
            }
            /*
            if (V == "Skin_Tone") {
            
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Skin_Tone_Data x in L_Skin_Tone_Data) {
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                    x.On_Create_Button_To_Character_Selection ();
                }
            } 
            */
            if (Type == "Body_Costume") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Character_Selection ("Body_Costume");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log (Target_Type_Gender);
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Character_Selection ("Body_Costume");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log ("2" + Target_Type_Gender);
                            break;
                        }
                    }
                }
            }

            if (Type == "Helmet") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Character_Selection ("Helmet");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log (Target_Type_Gender);
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Character_Selection ("Helmet");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log ("2" + Target_Type_Gender);
                            break;
                        }
                    }
                }
            }

            if (Type == "Weapon") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Weapon_Data x in L_Weapon_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Character_Selection ();
                        On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                //  }
                }
            }
            if (Type == "Ring") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Ring_Data x in L_Ring_Data) {
                // if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Character_Selection ();
                        On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                // }
                }
            }

            if (Type == "Earring") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Earring_Data x in L_Earring_Data) {
                    // if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Character_Selection ();
                        On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                // }
                }
            }
            
            if (Type == "Offhand") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Offhand_Data x in L_Offhand_Data) {
                //    if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Character_Selection ();
                        On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                //    }
                }
            }

            if (Type == "Glove") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Character_Selection ("Glove");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log (Target_Type_Gender);
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Character_Selection ("Glove");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log ("2" + Target_Type_Gender);
                            break;
                        }
                    }
                }
            }

            if (Type == "Boot") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Body_Costume_Data x in L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih && Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Character_Selection ("Boot");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log (Target_Type_Gender);
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Character_Selection ("Boot");
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                            Debug.Log ("2" + Target_Type_Gender);
                            break;
                        }
                    }
                }
            }

            if (Type == "Cape") {
                Type_1_Box_Selection_Panel_Parent.gameObject.SetActive (true);
                foreach (Cape_Data x in L_Cape_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Character_Selection ();
                        On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        }
                //  }
                }
            }

            
                if (Type == "Item") {
                        if (Code_Active_Equipment == "Inventory") {
                            // Create Item Block :
                            GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
                            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
                            sc.Code_Box = "";
                            sc.b_Sample = false;
                            // sc._Hair_Type_Data = this;
                            sc._Item_Data_Script = Item_Scene_Script.Ins.On_Search_Item_Data_Script (Name);
                            sc.Code_Item = Type;
                            sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
                            sc.On_Input_Data (sc._Item_Data_Script.Item_Sprite_Box, Name, Value);
                            Sam.SetActive (true);
                            On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                        } else {
                             On_Inc_Code_Urutan_Button ();
                        }
                }
            
        } else {
            
                if (Type == "Item") {
                    /*
                    // Create Item Block :
                    GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
                    Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
                    sc.Code_Box = "";
                    sc.b_Sample = false;
                    // sc._Hair_Type_Data = this;
                    sc._Item_Data_Script = Item_Scene_Script.Ins.On_Search_Item_Data_Script (Name);
                    sc.Code_Item = Type;
                    sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
                    sc.On_Input_Data (sc._Item_Data_Script.Item_Sprite_Box, "");
                    Sam.SetActive (true);
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                    */
                } else {
                    if (Code_Active_Equipment == "Inventory") {
                    // Create Empty Block :
                    GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
                    Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
                    sc.Code_Box = "";
                    sc.b_Sample = false;
                    // sc._Hair_Type_Data = this;
                    // sc.Code_Item = Code_Terpilih;
                    sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
                    sc.On_Input_Data (Inventory_Black, "");
                    Sam.SetActive (true);
                    On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                    } else {
                        On_Inc_Code_Urutan_Button ();
                    }
                }
            
        }

    }
    #endregion
    #region Got_Item_1_Parent
        public void On_Refresh_Gender () {
            On_Chg_Target_Player_2d (Dont_Destroy_On_Load.Ins._Player_2d);
            Target_Type_Gender = Target_Player_2d.Cur_Gender_GO.GetComponent <Gender_Data>().Gender_Type;
        }
    #endregion
    #region Specific_Item_Button
    // Submit_1_Parent / Got_Item_1_Parent :
    public void On_Specific_Item_Button (GameObject But_Go, Transform Parent_Go, string Name, string Type, string Value) {
        On_Refresh_Gender ();
        if (Type == "Hair_Type") {
                foreach (Hair_Type_Data x in Home_System.Ins._Character_Selection.L_Hair_Type_Data) {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        }
                    
                }
        }

            if (Type == "Face") {
                foreach (Face_Data x in Home_System.Ins._Character_Selection.L_Face_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        }
                //  }
                }
            }
            /*
            if (V == "Skin_Tone") {
            
                
                foreach (Skin_Tone_Data x in L_Skin_Tone_Data) {
                    
                    x.On_Create_Button_To_Character_Selection ();
                }
            } 
            */
            if (Type == "Body_Costume") {
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih && Home_System.Ins._Character_Selection.Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Specific_Parent ("Body_Costume", But_Go, Parent_Go);
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Specific_Parent ("Body_Costume", But_Go, Parent_Go);
                            break;
                        }
                    }
                }
            }

            if (Type == "Helmet") {
                
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih &&Home_System.Ins._Character_Selection.Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Specific_Parent ("Helmet", But_Go, Parent_Go);
                            
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Specific_Parent ("Helmet", But_Go, Parent_Go);
                            
                            break;
                        }
                    }
                }
            }

            if (Type == "Weapon") {
                
                foreach (Weapon_Data x in Home_System.Ins._Character_Selection.L_Weapon_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        
                        }
                //  }
                }
            }
            if (Type == "Ring") {
                
                foreach (Ring_Data x in Home_System.Ins._Character_Selection.L_Ring_Data) {
                // if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        
                        }
                // }
                }
            }

            if (Type == "Earring") {
                
                foreach (Earring_Data x in Home_System.Ins._Character_Selection.L_Earring_Data) {
                    // if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        
                        }
                // }
                }
            }
            
            if (Type == "Offhand") {
                
                foreach (Offhand_Data x in Home_System.Ins._Character_Selection.L_Offhand_Data) {
                //    if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        
                        }
                //    }
                }
            }

            if (Type == "Glove") {
                
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih &&Home_System.Ins._Character_Selection.Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Specific_Parent ("Glove", But_Go, Parent_Go);
                            
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Specific_Parent ("Glove", But_Go, Parent_Go);
                            
                            Debug.Log ("2" +Home_System.Ins._Character_Selection.Target_Type_Gender);
                            break;
                        }
                    }
                }
            }

            if (Type == "Boot") {
                
                foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih &&Home_System.Ins._Character_Selection.Target_Type_Gender == x.Gender_Type) {
                            x.On_Create_Button_To_Specific_Parent ("Boot", But_Go, Parent_Go);
                            
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            x.On_Create_Button_To_Specific_Parent ("Boot", But_Go, Parent_Go);
                            
                            Debug.Log ("2" +Home_System.Ins._Character_Selection.Target_Type_Gender);
                            break;
                        }
                    }
                }
            }

            if (Type == "Cape") {
                
                foreach (Cape_Data x in Home_System.Ins._Character_Selection.L_Cape_Data) {
                //  if (Target_Type_Gender == x.Gender_Type || x.Gender_Type == "All") {
                        if (Name == x.Code_Terpilih) {
                        x.On_Create_Button_To_Specific_Parent (But_Go, Parent_Go);
                        
                        }
                //  }
                }
            }

        if (Type == "Item") {
            GameObject Ins = GameObject.Instantiate (But_Go);
            Check_Box_Type_2 sc = Ins.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "";
            sc.b_Sample = false;
            sc._Item_Data_Script = Item_Scene_Script.Ins.On_Search_Item_Data_Script (Name);
            sc.Code_Item = Type;
            Ins.transform.parent = Parent_Go;
            Ins.transform.localScale = new Vector3 (1,1,1);
            sc.On_Input_Data (sc._Item_Data_Script.Item_Sprite_Box, Name, Value);
            Ins.SetActive (true);
        }
    }
    #endregion
    #region Get_Subtype_Weapon
    // Home_Status :
    Weapon_Data Result_Subtype_Weapon;
    public Weapon_Data On_Get_Subtype_Weapon (string Name_Item) {
        Result_Subtype_Weapon = new Weapon_Data ();
        foreach (Weapon_Data x in Home_System.Ins._Character_Selection.L_Weapon_Data) {
            if (x.Code_Terpilih == Name_Item) {
                Result_Subtype_Weapon = x;
                break;
            }
        }
        return Result_Subtype_Weapon;
    }
    #endregion
    #region Get_Subtype_Offhand
    // Home_Status :
    Offhand_Data Result_Subtype_Offhand;
    public Offhand_Data On_Get_Subtype_Offhand (string Name_Item) {
        Result_Subtype_Offhand = new Offhand_Data ();
        foreach (Offhand_Data x in Home_System.Ins._Character_Selection.L_Offhand_Data) {
            if (x.Code_Terpilih == Name_Item) {
                Result_Subtype_Offhand = x;
                break;
            }
        }
        return Result_Subtype_Offhand;
    }
    #endregion
#endregion
}
