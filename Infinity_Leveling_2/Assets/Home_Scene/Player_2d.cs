using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;

public class Player_2d : MonoBehaviour {
    [Header ("Local / Network")]
    [SerializeField]
    string Local_Cd = "Local";
    public bool Is_Mine = false;
    public string Your_Gender = ""; // Male, Female
    // Gender_Data :
    public GameObject Asset_2d_Titik_Tengah;
    public Transform Gender_Fix_Transform_Anim;
    Gender_Fix_Transform_Anim _Gender_Fix_Transform_Anim;
    public Transform Posisi_Depan, Posisi_Belakang;
    public Transform Transform_Posisi_Depan_Tanah_1;
    public Transform Asset_Gender_Trans;
    Gender_Data Cur_Gender_Data;
    // Gender_Data :
    public void On_Set_Asset_Gender (Transform x) {
        Cur_Gender_Data = x.GetComponent <Gender_Data> ();

        Polos_Body = Cur_Gender_Data.Polos_Body;
        Polos_R_Arm_Up = Cur_Gender_Data.Polos_R_Arm_Up;
        Polos_L_Arm_Up = Cur_Gender_Data.Polos_L_Arm_Up;
        Polos_R_Arm_Down = Cur_Gender_Data.Polos_R_Arm_Down;
        Polos_L_Arm_Down = Cur_Gender_Data.Polos_L_Arm_Down;
        Polos_R_Hand = Cur_Gender_Data.Polos_R_Hand;
        Polos_L_Hand = Cur_Gender_Data.Polos_L_Hand;

        Polos_R_Leg_Up = Cur_Gender_Data.Polos_R_Leg_Up;
        Polos_L_Leg_Up = Cur_Gender_Data.Polos_L_Leg_Up;
        Polos_R_Leg_Down = Cur_Gender_Data.Polos_R_Leg_Down;
        Polos_L_Leg_Down = Cur_Gender_Data.Polos_L_Leg_Down;
        Polos_R_Foot = Cur_Gender_Data.Polos_R_Foot;
        Polos_L_Foot = Cur_Gender_Data.Polos_L_Foot;

        Polos_Face = Cur_Gender_Data.Polos_Face;

        Asset_Helmet = Cur_Gender_Data.Asset_Helmet;
        Asset_Body_Costume = Cur_Gender_Data.Asset_Body_Costume;
        Asset_Body_Lower = Cur_Gender_Data.Asset_Body_Lower;
        Asset_Weapon = Cur_Gender_Data.Asset_Weapon;
        Asset_Offhand = Cur_Gender_Data.Asset_Offhand;
        Asset_Cape = Cur_Gender_Data.Asset_Cape;
        
        Asset_R_Arm_Up = Cur_Gender_Data.Asset_R_Arm_Up; Asset_L_Arm_Up = Cur_Gender_Data.Asset_L_Arm_Up;
        Asset_R_Arm_Down = Cur_Gender_Data.Asset_R_Arm_Down; Asset_L_Arm_Down = Cur_Gender_Data.Asset_L_Arm_Down;
        Asset_R_Hand = Cur_Gender_Data.Asset_R_Hand; Asset_L_Hand = Cur_Gender_Data.Asset_L_Hand;

        Asset_R_Leg_Up = Cur_Gender_Data.Asset_R_Leg_Up; Asset_L_Leg_Up = Cur_Gender_Data.Asset_L_Leg_Up;
        Asset_R_Leg_Down = Cur_Gender_Data.Asset_R_Leg_Down; Asset_L_Leg_Down = Cur_Gender_Data.Asset_L_Leg_Down;
        Asset_R_Foot = Cur_Gender_Data.Asset_R_Foot; Asset_L_Foot = Cur_Gender_Data.Asset_L_Foot;

        Asset_Face = Cur_Gender_Data.Asset_Face; Asset_Hair_Type_Front = Cur_Gender_Data.Asset_Hair_Type_Front; Asset_Hair_Type_Back = Cur_Gender_Data.Asset_Hair_Type_Back; 

        _Character_Animation = this.GetComponent <Character_Animation>();
        _Character_Animation.On_Input_Character_GO (x.gameObject, x.gameObject.GetComponent <Animator> ());
        
      //  On_Character_Animation ("Idle");
    }

    #region Polos_Asset
   
    public GameObject Polos_Body;
    public GameObject Polos_R_Arm_Up;
    public GameObject Polos_L_Arm_Up;
    public GameObject Polos_R_Arm_Down;
    public GameObject Polos_L_Arm_Down;
    public GameObject Polos_R_Hand;
    public GameObject Polos_L_Hand;
    
    public GameObject Polos_R_Leg_Up;
    public GameObject Polos_L_Leg_Up;
    public GameObject Polos_R_Leg_Down;
    public GameObject Polos_L_Leg_Down;
    public GameObject Polos_R_Foot;
    public GameObject Polos_L_Foot;

    public GameObject Polos_Face;

    // Body_Costume_Data :
    public void On_Active_Body_Costume_Code (string v) {
        if (v == "") {
            Polos_Body.gameObject.SetActive (true);
            Polos_R_Arm_Up.gameObject.SetActive (true);
            Polos_L_Arm_Up.gameObject.SetActive (true);
            Polos_R_Arm_Down.gameObject.SetActive (true);
            Polos_L_Arm_Down.gameObject.SetActive (true);
            Polos_R_Hand.gameObject.SetActive (true);
            Polos_L_Hand.gameObject.SetActive (true);

            Polos_R_Leg_Up.gameObject.SetActive (true);
            Polos_L_Leg_Up.gameObject.SetActive (true);
            Polos_R_Leg_Down.gameObject.SetActive (true);
            Polos_L_Leg_Down.gameObject.SetActive (true);
            Polos_R_Foot.gameObject.SetActive (true);
            Polos_L_Foot.gameObject.SetActive (true);

            Polos_Face.gameObject.SetActive (true);
        } else if (v == "Diactive_Polos_All_Leg_Up_Down") {
            Polos_Body.gameObject.SetActive (true);
            Polos_R_Arm_Up.gameObject.SetActive (true);
            Polos_L_Arm_Up.gameObject.SetActive (true);
            Polos_R_Arm_Down.gameObject.SetActive (true);
            Polos_L_Arm_Down.gameObject.SetActive (true);
            Polos_R_Hand.gameObject.SetActive (true);
            Polos_L_Hand.gameObject.SetActive (true);

            Polos_R_Leg_Up.gameObject.SetActive (false);
            Polos_L_Leg_Up.gameObject.SetActive (false);
            Polos_R_Leg_Down.gameObject.SetActive (false);
            Polos_L_Leg_Down.gameObject.SetActive (false);
            Polos_R_Foot.gameObject.SetActive (true);
            Polos_L_Foot.gameObject.SetActive (true);

            Polos_Face.gameObject.SetActive (true);
        }
    }

    #endregion
    [HideInInspector]
    public Transform Asset_Helmet;
    [HideInInspector]
    public Transform Asset_Body_Costume;
    [HideInInspector]
    public Transform Asset_Body_Lower;
    [HideInInspector]
    public Transform Asset_Weapon;
    [HideInInspector]
    public Transform Asset_Offhand;
    [HideInInspector]
    public Transform Asset_Cape;

    [HideInInspector]
    public Transform Asset_R_Arm_Up;
    [HideInInspector]
    public Transform Asset_L_Arm_Up;
    [HideInInspector]
    public Transform Asset_R_Arm_Down;
    [HideInInspector]
    public Transform Asset_L_Arm_Down;
    [HideInInspector]
    public Transform Asset_R_Hand;
    [HideInInspector]
    public Transform Asset_L_Hand;
    
    [HideInInspector]
    public Transform Asset_R_Leg_Up;
    [HideInInspector]
    public Transform Asset_L_Leg_Up;
    [HideInInspector]
    public Transform Asset_R_Leg_Down;
    [HideInInspector]
    public Transform Asset_L_Leg_Down;
    [HideInInspector]
    public Transform Asset_R_Foot;
    [HideInInspector]
    public Transform Asset_L_Foot;

    [HideInInspector]
    public Transform Asset_Face;
    [HideInInspector]
    public Transform Asset_Hair_Type_Front;
    [HideInInspector]
    public Transform Asset_Hair_Type_Back;
    
    // Gender_Data:
    [HideInInspector]
    public GameObject Cur_Gender_GO;
    // Body_Costume_Data :
    [HideInInspector]
    public GameObject Cur_Helmet_GO;
    [HideInInspector]
    public GameObject Cur_Body_Costume_GO;
    [HideInInspector]
    public GameObject Cur_Body_Lower_GO;
    [HideInInspector]
    public GameObject Cur_Weapon_GO;
    [HideInInspector]
    public GameObject Cur_Offhand_GO;
    [HideInInspector]
    public GameObject Cur_Cape_GO;
    [HideInInspector]
    public GameObject Cur_R_Arm_Up_GO;
    [HideInInspector]
    public GameObject Cur_L_Arm_Up_GO;
    [HideInInspector]
    public GameObject Cur_R_Arm_Down_GO;
    [HideInInspector]
    public GameObject Cur_L_Arm_Down_GO;
    [HideInInspector]
    public GameObject Cur_R_Hand_GO;
    [HideInInspector]
    public GameObject Cur_L_Hand_GO;

    [HideInInspector]
    public GameObject Cur_R_Leg_Up_GO;
    [HideInInspector]
    public GameObject Cur_L_Leg_Up_GO;
    [HideInInspector]
    public GameObject Cur_R_Leg_Down_GO;
    [HideInInspector]
    public GameObject Cur_L_Leg_Down_GO;
    [HideInInspector]
    public GameObject Cur_R_Foot_GO;
    [HideInInspector]
    public GameObject Cur_L_Foot_GO;

    [HideInInspector]
    public GameObject Cur_Face_GO;
    [HideInInspector]
    public GameObject Cur_Hair_Type_Front_GO;
    [HideInInspector]
    public GameObject Cur_Hair_Type_Back_GO;
    
    // Online_Player_2d :
    public Camera Raw_Camera;
    [SerializeField]
    Camera Player_Camera;
    void Awake (){
        _Online_Player_2d = this.GetComponent <Online_Player_2d>();
        if (this.gameObject.name == "Player_2d") {
            Is_Mine = true;
            if (Is_Mine) {
                Dont_Destroy_On_Load.Ins._Player_2d = this;
                
            }
        }
        
    }

    void FixedUpdate () {

        // Menghilangkan bug -0.25 scale setiap ada player yang quit. blm tahu penyebabnya.
        // Online_Tower_Infinity_Room merefresh sibling <Online_Player_2d>().On_Refresh_Player_Status ();
        /*
        if (Cur_Body_GO!= null) {
            if (Cur_Body_GO.transform.localScale.x < 0) {
                Cur_Body_GO.transform.localScale = new Vector3 (0.25f,0.25f,0.25f);
            }
        }
        if (Cur_Face_GO !=null) {
            if (Cur_Face_GO.transform.localScale.x < 0) {
                Cur_Face_GO.transform.localScale = new Vector3 (0.25f,0.25f,0.25f);
            }
        }
        if (Cur_Hair_Type_Front_GO != null) {
            if (Cur_Hair_Type_Front_GO.transform.localScale.x < 0) {
                Cur_Hair_Type_Front_GO.transform.localScale = new Vector3 (0.25f,0.25f,0.25f);
            }
        }
        */
    }
    [HideInInspector] // Player_AI_Use_Item :
    public Online_Player_Status _Online_Player_Status;
    void Start () {
        On_Check_Player_Clone ();
        _Online_Player_Status = this.GetComponent <Online_Player_Status>();
    }
#region Character_Selection
    // Character_Selection :
    public void Diactive_All_Asset_Body_Costume () {
        foreach (Transform si in Asset_Body_Costume) {
            si.gameObject.SetActive (false);
        }
        Diactive_All_Asset_Body_Lower ();
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Body_Costume () {
        foreach (Transform si in Asset_Body_Costume) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
        Destroy_All_Diactive_Asset_Body_Lower ();
    }

    void Diactive_All_Asset_Body_Lower () {
        foreach (Transform si in Asset_Body_Lower) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Diactive_Asset_Body_Lower () {
        foreach (Transform si in Asset_Body_Lower) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    void Diactive_All_Asset_Helmet () {
        foreach (Transform si in Asset_Helmet) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Diactive_Asset_Helmet () {
        foreach (Transform si in Asset_Helmet) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    void Diactive_All_Asset_Glove () {
        foreach (Transform si in Asset_L_Hand) {
            si.gameObject.SetActive (false);
        }
        foreach (Transform si in Asset_R_Hand) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Diactive_Asset_Glove () {
        foreach (Transform si in Asset_L_Hand) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
        foreach (Transform si in Asset_R_Hand) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    void Diactive_All_Asset_Boot () {
        foreach (Transform si in Asset_L_Foot) {
            si.gameObject.SetActive (false);
        }
        foreach (Transform si in Asset_R_Foot) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Diactive_Asset_Boot () {
        foreach (Transform si in Asset_L_Foot) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
        foreach (Transform si in Asset_R_Foot) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    // Character_Selection :
    public void Diactive_All_Asset_Weapon () {
        foreach (Transform si in Asset_Weapon) {
            si.gameObject.SetActive (false);
        }
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Weapon () {
        foreach (Transform si in Asset_Weapon) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    // Character_Selection :
    public void Diactive_All_Asset_Offhand () {
        foreach (Transform si in Asset_Offhand) {
            si.gameObject.SetActive (false);
        }
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Offhand () {
        foreach (Transform si in Asset_Offhand) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    // Character_Selection :
    public void Diactive_All_Asset_Face () {
        foreach (Transform si in Asset_Face) {
            si.gameObject.SetActive (false);
        }
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Face () {
        foreach (Transform si in Asset_Face) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    // Character_Selection :
    public void Diactive_All_Asset_Hair_Type_Front () {
        foreach (Transform si in Asset_Hair_Type_Front) {
            si.gameObject.SetActive (false);
        }
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Hair_Type_Front () {
        foreach (Transform si in Asset_Hair_Type_Front) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    // Character_Selection :
    public void Diactive_All_Asset_Hair_Type_Back () {
        foreach (Transform si in Asset_Hair_Type_Back) {
            si.gameObject.SetActive (false);
        }
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Hair_Type_Back () {
        foreach (Transform si in Asset_Hair_Type_Back) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }

    // Character_Selection :
    public void Diactive_All_Asset_Cape () {
        foreach (Transform si in Asset_Cape) {
            si.gameObject.SetActive (false);
        }
    }
    // Character_Selection :
    public void Destroy_All_Diactive_Asset_Cape () {
        foreach (Transform si in Asset_Cape) {
            if (!si.gameObject.activeInHierarchy) {Destroy (si.gameObject);}
        }
    }
#endregion
#region Load_Refresh_Asset
    [SerializeField] // Home_Status
    public Player_Status _Player_Status;

    // --- Data_Online / Online_Player_Status (Online) :
    public void On_Input_Player_Status (Player_Status Ps) {
        _Player_Status = Ps;
    }

    
    // -- Home_Canvas (Offline) / Online_Player_Status (Online) / Home_Status (Offline - Change Equipment) :
    string Load_Refresh_Asset_Cd = ""; // "Local" / "Online_Clone"
    public void On_Load_Refresh_Asset (string Load_From) {
        Load_Refresh_Asset_Cd = Load_From;
        Home_System.Ins._Character_Selection.On_Chg_Target_Player_2d (this);
        if (Load_Refresh_Asset_Cd == "Local") {
            
        } else if (Load_Refresh_Asset_Cd == "Online_Clone") {

        }

        StartCoroutine (N_On_Load_Refresh_Asset ());
    }

    IEnumerator N_On_Load_Refresh_Asset () {
        if (Load_Refresh_Asset_Cd == "Local") {
            yield return new WaitUntil (() => Home_System.Ins._Home_Status.b_Load_Inventory_Name);
            yield return new WaitUntil (() => Home_System.Ins._Home_Status.b_Load_Inventory_Type);
            yield return new WaitUntil (() => Home_System.Ins._Home_Status.b_Load_Inventory_Value);

            On_Refresh_Costume_Name ();
        } else if (Load_Refresh_Asset_Cd == "Online_Clone") {

        }
        foreach (Gender_Data x in Home_System.Ins._Character_Selection.L_Gender_Data) {
            if (x.Code_Terpilih == _Player_Status.Gender) { // x.Code_Character_Selection
                x.On_Set_To_Player_2d ();
            }
        }

        Diactive_All_Asset_Body_Costume ();
        Diactive_All_Asset_Body_Lower ();
        Diactive_All_Asset_Weapon ();
        Diactive_All_Asset_Offhand ();
        Diactive_All_Asset_Face ();
        Diactive_All_Asset_Hair_Type_Front ();
        Diactive_All_Asset_Hair_Type_Back ();
        Diactive_All_Asset_Cape ();

        Your_Gender = Cur_Gender_GO.GetComponent <Gender_Data>().Gender_Type;

        foreach (Hair_Type_Data x in Home_System.Ins._Character_Selection.L_Hair_Type_Data) {
            if (_Player_Status.Hair_Type == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }
        
        foreach (Face_Data x in Home_System.Ins._Character_Selection.L_Face_Data) {
                if (_Player_Status.Face == x.Code_Terpilih) {
                    x.On_Set_To_Player_2d ();
                }
        }

        foreach (Hair_Colour_Data x in Home_System.Ins._Character_Selection.L_Hair_Colour_Data) {
            if (_Player_Status.Hair_Colour == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        foreach (Skin_Tone_Data x in Home_System.Ins._Character_Selection.L_Skin_Tone_Data) {
            if (_Player_Status.Skin_Tone == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        if (Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_Body_Costume (_Player_Status.Body_Costume, Your_Gender)) {
            foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                
                if (_Player_Status.Body_Costume == x.Code_Terpilih && Your_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Body_Costume");
                }
            }
        } else {
            if (_Player_Status.Body_Costume != "") {
                Debug.LogError ("TIDAK ADA UNTUK GENDER INI");
            }
        }

        if (Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_Body_Costume (_Player_Status.Helmet, Your_Gender)) {
            foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                
                if (_Player_Status.Helmet == x.Code_Terpilih && Your_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Helmet");
                }
            }
        } else {
            if (_Player_Status.Helmet != "") {
                Debug.LogError ("TIDAK ADA UNTUK GENDER INI");
            }
        }

        foreach (Weapon_Data x in Home_System.Ins._Character_Selection.L_Weapon_Data) {
            if (_Player_Status.Weapon == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        foreach (Ring_Data x in Home_System.Ins._Character_Selection.L_Ring_Data) {
            if (_Player_Status.Ring == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        foreach (Earring_Data x in Home_System.Ins._Character_Selection.L_Earring_Data) {
            if (_Player_Status.Earring == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        foreach (Offhand_Data x in Home_System.Ins._Character_Selection.L_Offhand_Data) {
            if (_Player_Status.Offhand == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        if (Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_Body_Costume (_Player_Status.Glove, Your_Gender)) {
            foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                
                if (_Player_Status.Glove == x.Code_Terpilih && Your_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Glove");
                }
            }
        } else {
            if (_Player_Status.Glove != "") {
                Debug.LogError ("TIDAK ADA UNTUK GENDER INI");
            }
        }

        if (Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_Body_Costume (_Player_Status.Boot, Your_Gender)) {
            foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                
                if (_Player_Status.Boot == x.Code_Terpilih && Your_Gender == x.Gender_Type) {
                    x.On_Set_To_Player_2d ("Boot");
                }
            }
        } else {
            if (_Player_Status.Boot != "") {
                Debug.LogError ("TIDAK ADA UNTUK GENDER INI");
            }
        }

        foreach (Cape_Data x in Home_System.Ins._Character_Selection.L_Cape_Data) {
            if (_Player_Status.Cape == x.Code_Terpilih) {
                x.On_Set_To_Player_2d ();
            }
        }

        if (Is_Mine) {Loading_Canvas.Ins.On_Increase_Loading_3 ();}
        Destroy_All_Diactive_Asset_Body_Costume ();
        Destroy_All_Diactive_Asset_Face ();
        Destroy_All_Diactive_Asset_Weapon ();
        Destroy_All_Diactive_Asset_Offhand ();
        Destroy_All_Diactive_Asset_Hair_Type_Front ();
        Destroy_All_Diactive_Asset_Hair_Type_Back ();
        Destroy_All_Diactive_Asset_Cape ();

            Cur_Hair_Type_Front_GO.GetComponent <SpriteRenderer> ().color = Color.HSVToRGB((float)_Player_Status.Hair_Value_Colour/1000, 0.7f, (float)_Player_Status.Hair_Value_Dark/1000);
            if (Cur_Hair_Type_Back_GO) {
                Cur_Hair_Type_Back_GO.GetComponent <SpriteRenderer> ().color = Color.HSVToRGB((float)_Player_Status.Hair_Value_Colour/1000, 0.7f, (float)_Player_Status.Hair_Value_Dark/1000);
            }
            Debug.Log (_Player_Status.Hair_Value_Colour/1000);
        On_Character_Animation ("Idle");
    }
#endregion
#region Load_Skill_Character
    int Jumlah_Max_Skill = 4;
    //[SerializeField]
    // Hall_Of_Masters :
    public Skill_Data_Kumpulan [] A_Skill_Active;
    //[SerializeField]
    public Skill_Data_Kumpulan [] A_Skill_Passive;
    // Home_Canvas :
    public void On_Load_Skill_Character () {
        string [] Host_Server_Field = new string [2]; 
        string [] Host_Server_Value = new string [2]; 
        Host_Server_Field[0] = "table"; Host_Server_Value[0] = "Db_Character_1"; 
        Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
        
        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO (this, "Player_2d_Load_Skill", "Read_All_Table", Host_Server_Field, Host_Server_Value);
    }

    // Load_Host_Server :
    string [] Result_Skill_Character;
    public void Got_Skill_Character (string [] Result) {
        Result_Skill_Character = Result;
        int x = 1;
        for (x= 1; x < Result_Skill_Character.Length; x++) {
            if (x>=1 && x <=Jumlah_Max_Skill) {
                A_Skill_Active[x-1].Database_Load_Skill_Name (Result_Skill_Character[x]);
            } else if (x >=Jumlah_Max_Skill+1 && x<=(Jumlah_Max_Skill + Jumlah_Max_Skill)) { // (Jumlah_Max_Skill + Jumlah_Max_Skill) atau Result_Skill_Character.Length
                A_Skill_Passive[x-1 - Jumlah_Max_Skill].Database_Load_Skill_Name (Result_Skill_Character[x]);
            }
        }
        if (Is_Mine) {Loading_Canvas.Ins.On_Increase_Loading_3 ();}
    }

    public void On_Load_Skill_Level () {
        string [] Host_Server_Field = new string [2]; 
        string [] Host_Server_Value = new string [2]; 
        Host_Server_Field[0] = "table"; Host_Server_Value[0] = "Db_Character_1_Skill_Level"; 
        Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
        
        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO (this, "Player_2d_Load_Skill_Level", "Read_All_Table", Host_Server_Field, Host_Server_Value);
    }

    // Load_Host_Server :
    string [] Result_Skill_Level;
    public void Got_Skill_Level (string [] Result) {
        Result_Skill_Level = Result;
        int x = 1;
        for (x= 1; x < Result_Skill_Level.Length; x++) {
            if (x>=1 && x <=Jumlah_Max_Skill) {
                A_Skill_Active[x-1].Database_Load_Skill_Level (Result_Skill_Level[x]);
            } else if (x >=Jumlah_Max_Skill+1 && x<=(Jumlah_Max_Skill + Jumlah_Max_Skill)) { // (Jumlah_Max_Skill + Jumlah_Max_Skill) atau Result_Skill_Character.Length
                A_Skill_Passive[x-1 - Jumlah_Max_Skill].Database_Load_Skill_Level (Result_Skill_Level[x]);
            }
        }
        if (Is_Mine) {Loading_Canvas.Ins.On_Increase_Loading_3 ();}
    }
    
    // ---- Load_Visual_Novel :
    public void On_Refresh_Skill_Data_Kumpulan () {
        foreach (Skill_Data_Kumpulan Ab in A_Skill_Active) {
            Ab.On_Re_Search_Skill_Data ();
        }
        foreach (Skill_Data_Kumpulan Ab in A_Skill_Passive) {
            Ab.On_Re_Search_Skill_Data ();
        }
    }
#endregion
#region Player_Clone
    void On_Check_Player_Clone () {
        Debug.Log ("Check");
        if (Is_Mine) {
           Raw_Camera.gameObject.SetActive (true);
           Player_Camera.gameObject.SetActive (true);
        } else {
           // Raw_Camera.gameObject.SetActive (false);
           Player_Camera.gameObject.SetActive (false);
        }
    }

#endregion
#region Home_Status

public void On_Load_Home_Status_Character () {
        string [] Host_Server_Field = new string [2]; 
        string [] Host_Server_Value = new string [2]; 
        Host_Server_Field[0] = "table"; Host_Server_Value[0] = "Db_Character_1_Home_Status"; 
        Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;

        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO (this, "Player_2d_Load_Home_Status", "Read_All_Table", Host_Server_Field, Host_Server_Value);
}

    // Home_Status (Local - Mine [Change_Equip]):
public void On_Check_Skill_Passive_Equipment () {
    foreach (Skill_Data_Kumpulan Ab in A_Skill_Passive) {
        Home_System.Ins._Home_Status.On_Add_b_Passive_Equipment_Skill (Ab.Skill_Name);
    }
}
#endregion
#region Tower_Infinity_Manager
// Tower_Infinity_Manager :
public void On_Transfer_Skill_To_Tower_Infinity_Manager () {
    Tower_Infinity_Manager.Ins.On_Refresh_Skill_Active (A_Skill_Active);
    Tower_Infinity_Manager.Ins.On_Refresh_Skill_Passive (A_Skill_Passive);
}
#endregion
#region Flip
// Enemy_2d :
public string Cur_Flip = "Left"; // "Left" / "Right"
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
    this.gameObject.GetComponent <Online_Player_2d>().On_Mine_Lc_Cur_Flip (Cur_Flip);
}
#endregion
#region Character_Animation
// [HideInInspector]
Character_Animation _Character_Animation;
// Skill Active : IsMine
// This (Player) / Skill_Pengaturan_Animasi (Player)
// End Skill Active :
// 
// Idle :
// this, DualJoystickPlayerController
// Walk :
// DualJoystickPlayerController
// Enemy_AI_Control - Enemy_AI_Catch.
// NotMine : this - Enemy_2d_Online :
Online_Player_2d _Online_Player_2d;
// Dual_Joy_Stick, Skill_Pengaturan_Animasi
public string Last_Code = "";


public void On_Character_Animation (string Code_V) { // Skill_Active_0, Idle, Skill_Active_1
    if (Last_Code != Code_V) {
        Last_Code = Code_V;
        _Online_Player_2d = this.gameObject.GetComponent <Online_Player_2d>();
        if (Local_Cd == "Network") {
            if (_Online_Player_2d._PhotonView.IsMine) {
                _Character_Animation.On_Play_Animation (Code_V);
                _Online_Player_2d.On_Mine_Character_Animation (Code_V);
            } else {
                _Character_Animation.On_Play_Animation (Code_V);
            }
        } else if (Local_Cd == "Local") {
            _Character_Animation.On_Play_Animation (Code_V);
        }

        if (!_Gender_Fix_Transform_Anim) {
            _Gender_Fix_Transform_Anim = Gender_Fix_Transform_Anim.gameObject.GetComponent <Gender_Fix_Transform_Anim>();
        }
         // _Gender_Fix_Transform_Anim.On_Refresh_Gender_Fix_Transform ();
    }
}
#endregion
#region b_Can_Move
    // DualJoystickPlayerController :
    public bool b_Can_Move = true;

    string Can_Move_Next_Animation = "";
    float Can_Move_Time = 0.0f;
    [HideInInspector]
    public bool b_On_b_Can_Move_With_Time = false;
    // Skill_Pengaturan_Animasi
    public void On_b_Can_Move_With_Time (string Code_Animation_V, float Time) {
        Can_Move_Next_Animation = Code_Animation_V; Can_Move_Time = Time; b_On_b_Can_Move_With_Time = true;
        StartCoroutine (N_On_b_Can_Move_With_Time ());
    }

    IEnumerator N_On_b_Can_Move_With_Time () {
        yield return new WaitForSeconds (Can_Move_Time);
        _Character_Animation.On_Play_Animation (Can_Move_Next_Animation);
        if (_Online_Player_Status.Stun_Point == 0) {
            On_b_Can_Move ();
            On_b_Can_Skill ();
        }
         b_On_b_Can_Move_With_Time = false;
    }
    // Skill_Pengaturan_Animasi / this / GMP_Out_Of_Zone / Online_Player_Status (Stun) :
    public void On_b_Can_Move () {
        b_Can_Move = true;
    }

    public void Off_b_Can_Move () {
        b_Can_Move = false;
    }

    
#endregion
#region b_Can_Skill
    // DualJoystickPlayerController, GMP_Skill_Button :
    public bool b_Can_Skill = true;

    public void On_b_Can_Skill () {
        b_Can_Skill = true;
        _Player_AI_Utama.On_Finish_Use_Skill ();
    }

    public void Off_b_Can_Skill () {
        b_Can_Skill = false;
    }
#endregion
#region Character_Selection
    public void On_Send_Player_Status_To_Character_Selection () {
        Home_System.Ins._Character_Selection.On_Input_Player_Status (_Player_Status);
    }
#endregion
#region Refresh_Costume_Name (Item_Mall or not)
    // Home_Status & this :
    void On_Refresh_Costume_Name () {
        // Cosmetic (Akan sama seperti Item_Mall) _Player_Status.Hair_Type = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Hair_Type];
        _Player_Status.Helmet = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Helmet];
        _Player_Status.Weapon = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Weapon];
        _Player_Status.Ring = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Ring];
        _Player_Status.Body_Costume = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Body_Costume];
        // // Cosmetic (Akan sama seperti Item_Mall) _Player_Status.Face = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Face];
        _Player_Status.Earring = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Earring];
        _Player_Status.Offhand = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Offhand];
        _Player_Status.Glove = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Glove];
        _Player_Status.Boot = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Boot];
        _Player_Status.Cape = Home_System.Ins._Home_Status.A_Inventory_Name[_Player_Status.Slot_Cape];
    }
#endregion
#region Player_AI_Utama
public Player_AI_Utama _Player_AI_Utama;

#endregion
#region Hiasan_Player
// Online_Player_2d (Start) :
public Hiasan_Player _Hiasan_Player;
#endregion
}
