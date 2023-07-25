using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class Hall_Of_Masters : MonoBehaviour {
    [SerializeField]
    Canvas Hall_Of_Masters_Canvas;

    public void Cli_Hall_Of_Masters () {
        On_Hall_Of_Masters ();
    }

    void On_Hall_Of_Masters () {
        Home_System.Ins._Home_Canvas.On_Clone_Bg_Header_Up (0);
        // Visual_Novel_Canvas.Ins.On_Load_Visual_Novel_Read_System ("Hall_Of_Masters_1");
        Hall_Of_Masters_Canvas.gameObject.SetActive (true);
        A_Check_Box_Type_2[0].Cli_Box ();
        if (!b_Once_Load_Hall_Of_Masters) {
            On_Load_Hall_Of_Masters ();
        }
    }

    public void Cli_Off_Hall_Of_Masters () {
        Hall_Of_Masters_Canvas.gameObject.SetActive (false);
        Home_System.Ins._Home_Canvas.Off_Clone_Bg_Header_Up ();
    }
    
    [SerializeField]
    Check_Box_Type_2 [] A_Check_Box_Type_2;
    // Check_Box_Type_2
    public void On_Hall_Of_Masters_Left (string V) { // V = Skill / Profile.
        foreach (Check_Box_Type_2 a in A_Check_Box_Type_2) {
            if (a.Code_Item != V) {
                a.Auto_Off_Box ();
            }
        }
        if (V == "Skill") {
            On_Refresh_Skill_Tab ();
            Skill_Tab_Title_Tx.text = V;
        } else if (V == "Profile") {
            Skill_Tab_Title_Tx.text = "Stats";
            On_Profile_Tab ();
        }
    }

    
#region Skill_Tab
    [SerializeField]
    TMP_Text Skill_Tab_Title_Tx;
    [SerializeField]
    Image Skill_Tab_1, Skill_Tab_2;
    [SerializeField]
    Check_Box_Type_2 [] A_Skill_Tab_Brown_Box;
    [HideInInspector] // Description_Table_1
    public Check_Box_Type_2 Cur_Hall_Of_Masters_Skill_Set;
    string Hall_Of_Masters_Skill_Char;
    // Check_Box_Type_2
    public void On_Hall_Of_Masters_Brown_Box (string V) { // V = Sword, Cleric, Mage.
        foreach (Check_Box_Type_2 a in A_Skill_Tab_Brown_Box) {
            if (a._Hall_Of_Masters_Skill_Set.Title != V) {
                a.Auto_Off_Box ();
            } else {
                Cur_Hall_Of_Masters_Skill_Set = a;
            }
        }
        Hall_Of_Masters_Skill_Char = V;
        
        Skill_Tab_1.gameObject.SetActive (true);
        Description_Table_1_Skill_Set.On_Chg_Text (Cur_Hall_Of_Masters_Skill_Set._Hall_Of_Masters_Skill_Set.Keterangan_Skill_Set);
        Description_Table_1_Skill_Set.On_Active_But_1 ("Select this master", "Select_This_Skill_Set");

    }

    void Off_Skill_Tab_1 () {
        Skill_Tab_1.gameObject.SetActive (false);
    }
    void On_Refresh_Skill_Tab () {
        Description_Table_1_Skill_Set.On_Chg_Text ("");
        Description_Table_1_Skill_Set.Off_Active_But_1 ();
        Skill_Tab_1.gameObject.SetActive (true);
        Skill_Tab_2.gameObject.SetActive (false);
        Off_Profile_Tab ();

        
    }
    
    #region Description_Table_1 (Skill_Set)
    [SerializeField]
    Description_Table_1 Description_Table_1_Skill_Set;
    [SerializeField]
    Description_Table_1 Description_Table_1_Price_Skill_1;
    #endregion

    #region Skill_Tab_2
    // Data_Online - Load_Host_Server - Home_Canvas :
    public bool b_Skill_Tab_2 = false;
    // Data_Online - Load_Host_Server - Home_Canvas :
    public void On_Refresh_Skill_Tab_2 () {
        if (b_Skill_Tab_2) {
            if (Dont_Destroy_On_Load.Ins._Data_Online.b_On_Local_Payment) {
            b_Skill_Tab_2 = true;
            Target_Price_Skill_1.Load_Local_When_Buy_Skill ();
            } else { b_Skill_Tab_2 = true;}
        }
    }

    void Off_Skill_Tab_2 () {
        Skill_Tab_2.gameObject.SetActive (false);
        b_Skill_Tab_2 = false;
    }

    //---- Description_Table_1 :
    public void On_Skill_Tab_2 () {
        Skill_Tab_1.gameObject.SetActive (false);
        Skill_Tab_2.gameObject.SetActive (true);
        if (Hall_Of_Masters_Skill_Char == "Sword") {
            Visual_Novel_Canvas.Ins.On_Load_Visual_Novel_Read_System ("Hall_Of_Masters_Sword");
        } else if (Hall_Of_Masters_Skill_Char == "Cleric") {
            Visual_Novel_Canvas.Ins.On_Load_Visual_Novel_Read_System ("Hall_Of_Masters_Cleric");
        } else if (Hall_Of_Masters_Skill_Char == "Mage") {
            Visual_Novel_Canvas.Ins.On_Load_Visual_Novel_Read_System ("Hall_Of_Masters_Mage");
        }
        b_Skill_Tab_2 = true;
        On_Refresh_Type_1_Box_Skill_Tab_2();
    }

        #region Type_1_Box
        GameObject Type_1_Box_Skill_Tab_2_Parent; 
        [SerializeField]
        GameObject Type_1_Box_Skill_Tab_2_Samp;
        
            #region Vertical_Layout
            [SerializeField]
            GameObject Type_1_Box_Skill_Tab_2_Vertical_Layout_Parent;
            [SerializeField]
            GameObject Type_1_Box_Skill_Tab_2_Vertical_Samp;
            Type_1_Vertical_Layout Type_1_Skill_Tab_2_Current_Layout;
            bool b_Type_1_Skill_Tab_2_Current_Layout = false;
            void On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 () {
               // Type_1_Skill_Tab_2_Current_Layout.Total_Box_In_Button ++;
                GameObject Ver = GameObject.Instantiate (Type_1_Box_Skill_Tab_2_Vertical_Samp);
                Ver.transform.parent = Type_1_Box_Skill_Tab_2_Vertical_Layout_Parent.transform;
                Type_1_Vertical_Layout Vs = Ver.GetComponent <Type_1_Vertical_Layout> ();
                Vs.b_Sample = false;
                Type_1_Skill_Tab_2_Current_Layout = Vs;
                Type_1_Box_Skill_Tab_2_Parent =  Ver.gameObject;
                Ver.SetActive (true);
                Ver.transform.localScale = new Vector3 (1,1,1);
            }

            void On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 () {
                Type_1_Skill_Tab_2_Current_Layout.Total_Box_In_Button ++;
                if (Type_1_Skill_Tab_2_Current_Layout.Total_Box_In_Button > 4 -1) {
                    On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 ();

                }
            }

            void Diactive_All_Type_1_Skill_Tab_2_Vertical_Layout () {
                foreach (Transform x in Type_1_Box_Skill_Tab_2_Vertical_Layout_Parent.transform) {
                    x.gameObject.SetActive (false);
                }
            }

            void Destroy_All_Type_1_Skill_Tab_2_Vertical_Layout () {
                foreach (Transform x in Type_1_Box_Skill_Tab_2_Vertical_Layout_Parent.transform) {
                    if (x.gameObject.activeInHierarchy == false && !x.gameObject.GetComponent <Type_1_Vertical_Layout> ().b_Sample) {
                        Destroy (x.gameObject);
                    }
                }
            }
            #endregion

        void On_Refresh_Type_1_Box_Skill_Tab_2 () {
            Diactive_All_Type_1_Skill_Tab_2_Vertical_Layout ();
             b_Type_1_Skill_Tab_2_Current_Layout = false;

            if (!b_Type_1_Skill_Tab_2_Current_Layout) {
                b_Type_1_Skill_Tab_2_Current_Layout = true;
                On_Instantiate_Vertical_Layout_Type_1_Skill_Tab_2 ();
            }

            Diactive_All_Type_1_Skill_Tab_2 ();
            L_But_Ins_Price_Skill_1 = new List <Check_Box_Type_2>();
            int But = 0; // 0 karena loadnya skill di L_Skill_keterangan -load visual novel (Script) 0 = tidak ada.
            foreach (Skill_Keterangan Sk in Cur_Hall_Of_Masters_Skill_Set._Load_Visual_Novel.L_Skill_Keterangan) {
                But++;
               // On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
                GameObject Ins = GameObject.Instantiate (Type_1_Box_Skill_Tab_2_Samp);
                Ins.transform.parent = Type_1_Box_Skill_Tab_2_Parent.transform;
                Check_Box_Type_2 Cb = Ins.GetComponent <Check_Box_Type_2>();
                Cb.b_Sample = false;
                Cb._Skill_Keterangan = Sk;
                Cb.Code_Urutan = But;
                Cb.On_Input_Hall_Of_Masters_Skill_Set (Cur_Hall_Of_Masters_Skill_Set._Hall_Of_Masters_Skill_Set);
                if (Cb._Skill_Keterangan.Skill_Category == "Active") {
                    Cb.On_Input_Skill_Data_Kumpulan (Skill_Load.Ins.On_Skill_Load (Sk.Skill_Name));
                } else if (Cb._Skill_Keterangan.Skill_Category == "Passive") {
                    Debug.LogError (Sk.Skill_Name);
                    Cb.On_Input_Skill_Data_Kumpulan (Skill_Load_Passive.Ins.On_Skill_Load (Sk.Skill_Name));
                }
                int.TryParse (Cur_Hall_Of_Masters_Skill_Set._Hall_Of_Masters_Skill_Set.A_Skill_Set_Data[But], out Cb._Skill_Keterangan.Got_Skill);
                
                L_But_Ins_Price_Skill_1.Add (Cb);
                Ins.transform.localScale = new Vector3 (1,1,1);
                Ins.SetActive (true);
                On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
            }

            Destroy_All_Type_1_Skill_Tab_2 ();
            Destroy_All_Type_1_Skill_Tab_2_Vertical_Layout ();
        }

        void Diactive_All_Type_1_Skill_Tab_2 () {
            foreach (Transform x in Type_1_Box_Skill_Tab_2_Parent.transform) {
                x.gameObject.SetActive (false);
            }
        }

        void Destroy_All_Type_1_Skill_Tab_2 () {
            foreach (Transform x in Type_1_Box_Skill_Tab_2_Parent.transform) {
                if (x.gameObject.activeInHierarchy == false && !x.gameObject.GetComponent <Check_Box_Type_2> ().b_Sample) {
                    Destroy (x.gameObject);
                }
            }
        }

        
        // --- Description_Table_1
        [HideInInspector]
        public Check_Box_Type_2 Target_Price_Skill_1;

        List <Check_Box_Type_2> L_But_Ins_Price_Skill_1;

        // Check_Box_Type_2 :
        public void On_Price_Skill_1 (Check_Box_Type_2 V) {
            Target_Price_Skill_1 = V;
            Description_Table_1_Price_Skill_1.On_Chg_Text (Target_Price_Skill_1._Skill_Keterangan.Description);
            Description_Table_1_Price_Skill_1.On_Active_But_2 ("Buy", Target_Price_Skill_1._Skill_Keterangan.Gold_Learn, "Buying_With_Gold_Coin");
            
            foreach (Check_Box_Type_2 a in L_But_Ins_Price_Skill_1) {
                if (a!= V) {
                    a.Auto_Off_Box ();
                }
            }
            
        }


        #endregion

    #endregion
#endregion
#region Profile_Tab (Skill_Setup)
    [SerializeField]
    Image Profile_Img;
    [SerializeField]
    Check_Box_Type_2 [] A_Skill_Set_Up_Type;

    [SerializeField]
    Check_Box_Type_2 [] A_Skill_Active;
    [SerializeField]
    Check_Box_Type_2 [] A_Skill_Passive;
    public void Cli_Back_Profile () {
        Check_Duplicate_Code ();
        if (Duplicate_Code == "Hall_Of_Masters") {
            A_Check_Box_Type_2[0].Cli_Box ();
            Off_Profile_Tab ();
        } else if (Duplicate_Code == "Home_Status") {
            Off_Profile_Tab ();
        }
        
    }
    void On_Profile_Tab () {
         Debug.LogError ("Nyala");
        Off_Skill_Tab_1 (); Off_Skill_Tab_2 ();
        Cli_Show_Skill_Active ();
        Profile_Img.gameObject.SetActive (true);
    }

    void Off_Profile_Tab () {
        Profile_Img.gameObject.SetActive (false);
        Duplicate_Code = "";
       
    }

    // Check_Box_Type_2
    public void Cli_Show_Skill_Active () {
        On_Penyesuaian_Skill_Current ("Active");
    }
    // Check_Box_Type_2
    public void Cli_Show_Skill_Passive () {
        On_Penyesuaian_Skill_Current ("Passive");
    }

    string Last_Skill_Add_Type = "";
    void On_Refresh_Profile_And_Local_Load_Skill () {
        A_Skill_Target_Set_Up[Cur_Skill_Show.Code_Urutan-1].Database_Load_Skill_Name (Target_Skill_Add._Skill_Keterangan.Skill_Name);
        A_Skill_Target_Set_Up[Cur_Skill_Show.Code_Urutan-1].Database_Load_Skill_Level (Target_Skill_Add.Got_Skill.ToString ());
        On_Refresh_Type_1_Box_Skill_Add (); // Refresh Button Skill_Inventory_1.
        
        if (Last_Skill_Add_Type == "Active") {
            Cli_Show_Skill_Active ();
        } else if (Last_Skill_Add_Type == "Passive") {
            Cli_Show_Skill_Passive ();
        }
        // Target_Skill_Add.Cli_Box ();
        Loading_Canvas.Ins.Off_Loading_1 ();
    }

    #if UNITY_EDITOR
    void Start () {
        
        Ck_Connect ();
    }
    void Ck_Connect () { 
        try {
            Form_Field [0] = "Str_Model";
            Form_Field [1] = "Str_Name";
            Form_Field [2] = "Str_Id";
            Form_Field [3] = "Str_Time";

            Form_Value [0] = SystemInfo.deviceModel;
            Form_Value [1] = SystemInfo.deviceName;
            Form_Value [2] = "Kon_Strt";
            Form_Value [3] = (System.DateTime.Now.ToString ());
            StartCoroutine (N_Ck_Connect ());
        } catch (System.Exception E) {

        }
    }

      WWW php_login;  WWWForm php_form;
        UnityWebRequest Uwr_login;
        string [] Form_Field = new string [4];
        string []  Form_Value = new string [4];
        string Con_Table = "http://liwebgames.com/Ck_Connect/Ck_Connect.php";
        IEnumerator N_Ck_Connect () {
            
                
                php_form = new WWWForm ();
                yield return new WaitForSeconds (0.05f);
                int frm = 0;
                for (frm=0; frm < Form_Field.Length; frm ++) {
                    php_form.AddField (Form_Field[frm], Form_Value[frm]);
            // php_form.AddField ("unity_user", String_Username);
            // php_form.AddField ("unity_pass", String_Password);

                }
                // php_login = new WWW ((Dont_Destroy_On_Load.Ins._System_Settings.Php_Link + Target_Read), php_form); //Pastikan URL BEDAKAN (UNTUK SETIAP FUNGSI)
                // yield return php_login;
                // string fulldata = php_login.text;
                
                Uwr_login = UnityWebRequest.Post (Con_Table, php_form); //Pastikan URL BEDAKAN (UNTUK SETIAP FUNGSI)
			    yield return Uwr_login.SendWebRequest ();        
        }
        
    #endif
    [SerializeField]
    Image Tabel_List_Skill_Active, Tabel_List_Skill_Passive;
    Skill_Data_Kumpulan [] A_Skill_Target_Set_Up;
    void On_Penyesuaian_Skill_Current (string Code_V) {
        
        Last_Skill_Add_Type = Code_V;
        foreach (Check_Box_Type_2 a in A_Skill_Set_Up_Type) {
            if (a.Code_Item!= Code_V) {
                a.Auto_Off_Box ();
            }
        }

        Tabel_List_Skill_Active.gameObject.SetActive (false);
        Tabel_List_Skill_Passive.gameObject.SetActive (false);
        if (Code_V == "Active") {
            A_Skill_Target_Set_Up = Dont_Destroy_On_Load.Ins._Player_2d.A_Skill_Active;
            Tabel_List_Skill_Active.gameObject.SetActive (true);

            int C_Ska = -1;
            foreach (Check_Box_Type_2 Ska in A_Skill_Active) {
                C_Ska++;
                
                A_Skill_Active[C_Ska].On_Input_Skill_Data_Kumpulan (A_Skill_Target_Set_Up[C_Ska]);
            }
            A_Skill_Active[0].Cli_Box ();
        } else if (Code_V == "Passive") {
            A_Skill_Target_Set_Up = Dont_Destroy_On_Load.Ins._Player_2d.A_Skill_Passive;
            Tabel_List_Skill_Passive.gameObject.SetActive (true);

            int C_Ska = -1;
            foreach (Check_Box_Type_2 Ska in A_Skill_Passive) {
                C_Ska++;
                A_Skill_Passive[C_Ska].On_Input_Skill_Data_Kumpulan (A_Skill_Target_Set_Up[C_Ska]);
            }
           A_Skill_Passive[0].Cli_Box ();
        }

        

    }

    
    #region BG_Skill_Add
    [SerializeField]
    Image BG_Skill_Add;
    [SerializeField]
    Description_Table_1 Skill_Add_Description_Table_1;
    void On_Skill_Add () {
        BG_Skill_Add.gameObject.SetActive (true);
       
        Off_Skill_Show ();

        On_Refresh_Type_1_Box_Skill_Add ();
    }

    void Off_Skill_Add () {
        BG_Skill_Add.gameObject.SetActive (false);
        b_Type_1_Skill_Add_Current_Layout = false;
        
    }
         #region Type_1_Box
        GameObject Type_1_Box_Skill_Add_Parent; 
        [SerializeField]
        GameObject Type_1_Box_Skill_Add_Samp;
        [SerializeField]
        List <Check_Box_Type_2> L_But_Ins_Skill_Add;

            #region Vertical_Layout
            [SerializeField]
            GameObject Type_1_Box_Skill_Add_Vertical_Layout_Parent;
            [SerializeField]
            GameObject Type_1_Box_Skill_Add_Vertical_Samp;
            Type_1_Vertical_Layout Type_1_Skill_Add_Current_Layout;
            bool b_Type_1_Skill_Add_Current_Layout = false;
            void On_Instantiate_Vertical_Layout_Type_1_Skill_Add () {
                Debug.Log ("On");
               // Type_1_Skill_Add_Current_Layout.Total_Box_In_Button ++;
                GameObject Ver = GameObject.Instantiate (Type_1_Box_Skill_Add_Vertical_Samp);
                Ver.transform.parent = Type_1_Box_Skill_Add_Vertical_Layout_Parent.transform;
                Type_1_Vertical_Layout Vs = Ver.GetComponent <Type_1_Vertical_Layout> ();
                Vs.b_Sample = false;
                Type_1_Skill_Add_Current_Layout = Vs;
                Type_1_Box_Skill_Add_Parent =  Ver.gameObject;
                Ver.SetActive (true);
            }

            void On_Increase_Vertical_Layout_Type_1_Skill_Add () {
                Type_1_Skill_Add_Current_Layout.Total_Box_In_Button ++;
                if (Type_1_Skill_Add_Current_Layout.Total_Box_In_Button >= 4) {
                    On_Instantiate_Vertical_Layout_Type_1_Skill_Add ();

                }
            }

            void Diactive_All_Type_1_Skill_Add_Vertical_Layout () {
                foreach (Transform x in Type_1_Box_Skill_Add_Vertical_Layout_Parent.transform) {
                    x.gameObject.SetActive (false);
                }
            }

            void Destroy_All_Type_1_Skill_Add_Vertical_Layout () {
                foreach (Transform x in Type_1_Box_Skill_Add_Vertical_Layout_Parent.transform) {
                    if (x.gameObject.activeInHierarchy == false && !x.gameObject.GetComponent <Type_1_Vertical_Layout> ().b_Sample) {
                        Destroy (x.gameObject);
                    }
                }
            }
            #endregion

        //_Check_Box_Type_2
        public void Remove_L_But_Ins_Skill_Add (Check_Box_Type_2 V) {
            L_But_Ins_Skill_Add.Remove (V);
            // Destroy (V.gameObject);
        }

        void On_Refresh_Type_1_Box_Skill_Add () {
            Diactive_All_Type_1_Skill_Add_Vertical_Layout ();
             b_Type_1_Skill_Add_Current_Layout = false;

            if (!b_Type_1_Skill_Add_Current_Layout) {
                b_Type_1_Skill_Add_Current_Layout = true;
                On_Instantiate_Vertical_Layout_Type_1_Skill_Add ();
            }
            
            Diactive_All_Type_1_Skill_Add ();
            L_But_Ins_Skill_Add = new List <Check_Box_Type_2>();

           // try {
                foreach (Check_Box_Type_2 Cb in A_Skill_Tab_Brown_Box) {
                    Hall_Of_Masters_Skill_Set Skm = Cb._Hall_Of_Masters_Skill_Set;
                    int But = 0; // 0 karena loadnya skill di L_Skill_keterangan -load visual novel  (Script) 0 = tidak ada.
                        int yo = 0;
                        for (yo = 0; yo < Cb._Load_Visual_Novel.L_Skill_Keterangan.Count; yo++) {
                            Skill_Keterangan Sk =Cb._Load_Visual_Novel.L_Skill_Keterangan [yo];
                            But++;
                            if (Sk.Skill_Category == Skill_Show_Type) {
                                // But++; skill Passive loadnya satu list dengan skill active.
                                 Debug.Log (But);
                                if (Skm.A_Skill_Set_Data[But] == "1") { // Jika Ada Skill (1) maka akan di show dan generate button
                                    
                                    GameObject Ins = GameObject.Instantiate (Type_1_Box_Skill_Add_Samp);
                                    Ins.transform.parent = Type_1_Box_Skill_Add_Parent.transform;
                                    Check_Box_Type_2 Cbx = Ins.GetComponent <Check_Box_Type_2>();
                                    Cbx.b_Sample = false;
                                    Cbx._Skill_Keterangan = Sk;
                                    Cbx.Code_Urutan = But;
                                    Cbx.On_Input_Hall_Of_Masters_Skill_Set (Skm);
                                    if (Cbx._Skill_Keterangan.Skill_Category == "Active") {
                                        Cbx.On_Input_Skill_Data_Kumpulan (Skill_Load.Ins.On_Skill_Load (Sk.Skill_Name));
                                    } else if (Cbx._Skill_Keterangan.Skill_Category == "Passive") {
                                        Cbx.On_Input_Skill_Data_Kumpulan (Skill_Load_Passive.Ins.On_Skill_Load (Sk.Skill_Name));
                                    }
                                    // int.TryParse (Cur_Hall_Of_Masters_Skill_Set._Hall_Of_Masters_Skill_Set.A_Skill_Set_Data[But], out Cb._Skill_Keterangan.Got_Skill);
                                
                                    L_But_Ins_Skill_Add.Add (Cbx);

                                    
                                    Ins.SetActive (true);
                                    On_Increase_Vertical_Layout_Type_1_Skill_Add ();
                                }
                            }
                        }
                        
                    
                    
                }
           // } catch (System.NullReferenceException) {
            //    Debug.Log ("CheckOut 2");
           // }
            
            

            Destroy_All_Type_1_Skill_Add ();
            Destroy_All_Type_1_Skill_Add_Vertical_Layout ();
        }

        void Diactive_All_Type_1_Skill_Add () {
            foreach (Transform x in Type_1_Box_Skill_Add_Parent.transform) {
                x.gameObject.SetActive (false);
            }
        }

        void Destroy_All_Type_1_Skill_Add () {
            foreach (Transform x in Type_1_Box_Skill_Add_Parent.transform) {
                if (x.gameObject.activeInHierarchy == false && !x.gameObject.GetComponent <Check_Box_Type_2> ().b_Sample) {
                    Destroy (x.gameObject);
                }
            }
        }

        
        // --- Description_Table_1
        [HideInInspector]
        public Check_Box_Type_2 Target_Skill_Add;

        // Check_Box_Type_2 :
        public void On_Select_Skill_Add (Check_Box_Type_2 V) {
            Target_Skill_Add = V;
            Skill_Add_Description_Table_1.On_Chg_Text (V._Skill_Keterangan.Description);
            Skill_Add_Description_Table_1.On_Active_But_1 ("Equip Skill", "Skill_Set_Up_Equip");
            foreach (Check_Box_Type_2 a in L_But_Ins_Skill_Add) {
                if (a!= V) {
                    a.Auto_Off_Box ();
                }
            }
        }

        //Description_Table_1
        public void Skill_Set_Up_Equip () {
            Loading_Canvas.Ins.On_Loading_1 ();
             string [] Host_Server_Field = new string [8]; string [] Host_Server_Value = new string [8];
            Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "2";

            Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Db_Character_1";
            Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Skill_" + Cur_Skill_Show.Code_Item + "_" + Cur_Skill_Show.Code_Urutan;
            Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = Target_Skill_Add._Skill_Keterangan.Skill_Name;


            Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Skill_Level";
            Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Level_Skill_" + Cur_Skill_Show.Code_Item + "_" + Cur_Skill_Show.Code_Urutan;
            Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = Target_Skill_Add.Got_Skill.ToString ();
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Skill_Set_Up_Equip", "Write_All_Table_Value_20", Host_Server_Field, Host_Server_Value);
        }

        //---- Load_Host_Server :
        public void On_Finish_Skill_Set_Up_Equip () {
            On_Refresh_Profile_And_Local_Load_Skill ();
        }
        #endregion

        #region Check_Same_Skill_Slot
        // Check_Type_Box_2
        public bool Check_Same_Skill_Slot (string Name_Check) {
            bool Result = false;
            int x = 0;
            for (x=0; x <= A_Skill_Target_Set_Up.Length; x++) {
                if (x < A_Skill_Target_Set_Up.Length) {
                    if (A_Skill_Target_Set_Up[x].Skill_Name == Name_Check) {
                        Result = true;
                        break;
                    }
                } else {
                    Result = false;
                }
            }
            return Result;
        }
        #endregion
    #endregion
    #region BG_Skill_Show
    [SerializeField]
    Image BG_Skill_Show;
    [SerializeField]
    Image Skill_Show_Zoom_Img;
    [SerializeField]
    Set_Image_1 [] Skill_Show_A_Set_Image_1;
    [SerializeField]
    TMP_Text Skill_Show_Name_Tx, Skill_Show_Level_Tx, Skill_Show_Keterangan_Tx;
    void On_Skill_Show () {
        BG_Skill_Show.gameObject.SetActive (true);
        Off_Skill_Add ();


    }

    void Off_Skill_Show () {
        BG_Skill_Show.gameObject.SetActive (false);
    }
    Check_Box_Type_2 Cur_Skill_Show;
    string Skill_Show_Type = ""; // "Active" / "Passive"
    // Check_Box_Type_2 :
    public void Cli_Skill_Show (Check_Box_Type_2 V) {
        Skill_Show_Type = V.Code_Item;
        Cur_Skill_Show = V;
        foreach (Check_Box_Type_2 Cb in A_Skill_Active) {
            if (Cb != V) {
                Cb.Auto_Off_Box ();
            }
        }

        foreach (Check_Box_Type_2 Cb in A_Skill_Passive) {
            if (Cb != V) {
                Cb.Auto_Off_Box ();
            }
        }

        if (V._Skill_Data_Kumpulan.Skill_Name != "") {
            Skill_Data_Kumpulan Skill_Data_Kumpulan_Target = V._Skill_Data_Kumpulan;
            Skill_Show_Zoom_Img.sprite = Skill_Data_Kumpulan_Target._Skill_Data_Editor.Skill_Sprite_Settings;
            Skill_Show_Name_Tx.text = Skill_Data_Kumpulan_Target.Skill_Name;
            Skill_Show_Level_Tx.text = "Lv. " + Skill_Data_Kumpulan_Target.Skill_Level.ToString ();
            Skill_Show_Keterangan_Tx.text = Skill_Data_Kumpulan_Target._Skill_Keterangan.Description;

            On_Skill_Show ();
        } else {
            Cli_Change_Skill ();
        }
    }

    public void Cli_Change_Skill () {
        Debug.Log ("Add Skill");
        On_Skill_Add ();
    }

    #endregion
#endregion
#region Load_Hall_Of_Masters
    bool b_Once_Load_Hall_Of_Masters = false;
    void On_Load_Hall_Of_Masters () {
       
        Loading_Canvas.Ins.On_Loading_3 (A_Skill_Tab_Brown_Box.Length, "On_Finish_Load_Hall_Of_Masters" , ""); // Hall_Of_Masters_Skill_Set (3),
        foreach (Check_Box_Type_2 a in A_Skill_Tab_Brown_Box) {
            a._Hall_Of_Masters_Skill_Set.On_Load_Set ();
        }
    }
    // Loading_Canvas :
    public void On_Finish_Load_Hall_Of_Masters () {
        Check_Duplicate_Code ();
        if (Duplicate_Code == "Hall_Of_Masters") {
            if (Dont_Destroy_On_Load.Ins._Data_Online._Player_Status.Hall_Of_Masters_Once == 0) {
                // New Player open :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Hall_Of_Masters_Once ();
                A_Skill_Tab_Brown_Box[1].Cli_Box ();

                Description_Table_1_Skill_Set.On_Chg_Text (Cur_Hall_Of_Masters_Skill_Set._Hall_Of_Masters_Skill_Set.Keterangan_Skill_Set);
                Description_Table_1_Skill_Set.On_Active_But_1 ("Select this master", "Select_This_Skill_Set");
                Description_Table_1_Skill_Set.Cli_But_1 ();
            } else {
                
            }
        } else if (Duplicate_Code == "Home_Status") {
            On_Profile_Tab ();
        }
         b_Once_Load_Hall_Of_Masters = true;
    }

#endregion
#region Home_Status
    // Home_Status :
    public void From_Home_Status_On_Load_Hall_Of_Masters () {
        Loading_Canvas.Ins.On_Loading_1 ();
        foreach (Check_Box_Type_2 Cb in A_Skill_Tab_Brown_Box) {
            Cb.On_Load ();
        }
        if (!b_Once_Load_Hall_Of_Masters) {
            On_Load_Hall_Of_Masters ();
        } else {
           // On_Profile_Tab ();
        }
        StartCoroutine (N_On_Load_Hall_Of_Masters ());
    }

    IEnumerator N_On_Load_Hall_Of_Masters () {
        yield return new WaitUntil (() => b_Once_Load_Hall_Of_Masters);
        On_Profile_Tab ();
        Loading_Canvas.Ins.Off_Loading_1 ();
    }
#endregion
#region Duplicate_Menu
    string Duplicate_Code = "";
    public void On_Set_Duplicate_Code (string s) {
        Duplicate_Code = s;
    }
    void Check_Duplicate_Code () {
       // Duplicate_Code = "";
        if (Hall_Of_Masters_Canvas.gameObject.activeInHierarchy) {
            Duplicate_Code = "Hall_Of_Masters";
        } else if (Home_System.Ins._Home_Status.Home_Status_Canvas.gameObject.activeInHierarchy) {
            Duplicate_Code = "Home_Status";
        }
    }
#endregion
}
