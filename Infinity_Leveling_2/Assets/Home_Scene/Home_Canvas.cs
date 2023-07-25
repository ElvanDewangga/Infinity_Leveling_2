using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class Home_Canvas : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        On_Masuk_Home ();
    }

    void On_Masuk_Home () {
        Home_System.Ins._Character_Selection.On_Character_Selection ();
        On_Start_Music ();
        Loading_Canvas.Ins.Off_Loading_2 ();
        Loading_Canvas.Ins.Off_Loading_4 ();
    }

    // Character_Selection :
    public void Character_Selection_To_Home (bool Refresh_Player_2d) {
        if (Refresh_Player_2d) { // Load_Char :
            
            StartCoroutine (N_Visual_Novel_Hellper_Continue ());
        } else { // New_Char :
            Loading_Canvas.Ins.On_Loading_3 (2, "", ""); //Visual_Novel_Canvas (1), Player_2d (1), Home_Status (3)
            Dont_Destroy_On_Load.Ins._Player_2d.On_Load_Home_Status_Character ();
            // Home_System.Ins._Home_Status.On_Load_Data_Inventory (); // Home_Status (3)
        } 

        if (Visual_Novel_Canvas.Ins == null) {
            SceneManager.LoadScene ("Visual_Novel_Scene", LoadSceneMode.Additive);
        }
        
        On_Refresh_Header_Left ();
        On_Refresh_Header_Up ();
    }

    IEnumerator N_Visual_Novel_Hellper_Continue () {
        Loading_Canvas.Ins.On_Loading_3 (8, "", ""); // Player_2d (4), Visual_Novel_Canvas (1), Home_Status (3)
            Dont_Destroy_On_Load.Ins._Data_Online.On_Transfer_Player_Status ();
            Home_System.Ins._Home_Status.On_Load_Data_Inventory (); // Home_Status (3)
            yield return new WaitUntil (()=>Home_System.Ins._Home_Status.b_Load_Inventory_Name);
            yield return new WaitUntil (()=>Home_System.Ins._Home_Status.b_Load_Inventory_Type);
            yield return new WaitUntil (()=>Home_System.Ins._Home_Status.b_Load_Inventory_Value);
            Dont_Destroy_On_Load.Ins._Player_2d.On_Load_Refresh_Asset ("Local");
            Dont_Destroy_On_Load.Ins._Player_2d.On_Load_Skill_Character ();
            Dont_Destroy_On_Load.Ins._Player_2d.On_Load_Skill_Level ();
            Dont_Destroy_On_Load.Ins._Player_2d.On_Load_Home_Status_Character ();
        yield return new WaitUntil (() => Visual_Novel_Canvas.Ins);
        Visual_Novel_Canvas.Ins.On_Load_Visual_Novel_Read_System ("Hellper_Continue");
    }
    // Character_Selection :
    public void On_Visual_Novel_Hellper_Awal () {
        StartCoroutine (N_Visual_Novel_Hellper_Awal ());
    }
    IEnumerator N_Visual_Novel_Hellper_Awal () {
        yield return new WaitUntil (() => Visual_Novel_Canvas.Ins);
        Visual_Novel_Canvas.Ins.On_Load_Visual_Novel_Read_System ("Hellper_Awal");
    }
    #region Bg_Header_Left
    [SerializeField]
    Image Bg_Header_Left;
    [SerializeField]
    TMP_Text Header_Left_Nickname, Header_Left_Lv;
    int Max_Level = 8;
    // Home_Status
    public int Target_Exp = 14880;
    [SerializeField]
    Slider Exp_Slider;
    // Data_Online :
    public void On_Refresh_Header_Left () {
        Data_Online _Data_Online = Dont_Destroy_On_Load.Ins._Data_Online;
        
        Header_Left_Nickname.text = _Data_Online._Player_Status.Nickname;
        Header_Left_Lv.text = "Lv." + _Data_Online._C_Home_Status.Level;
        On_Refresh_Header_Level_And_Exp ();
    }

    void On_Refresh_Header_Level_And_Exp () {
        Data_Online _Data_Online = Dont_Destroy_On_Load.Ins._Data_Online;
        Exp_Slider.maxValue = Target_Exp;
        if (_Data_Online._C_Home_Status.Cur_Exp >= Target_Exp) {
            Exp_Slider.value = Target_Exp;
        } else  {
            Exp_Slider.value = _Data_Online._C_Home_Status.Cur_Exp;
        }
        if (_Data_Online._C_Home_Status.Level < Max_Level) {
            if (_Data_Online._C_Home_Status.Cur_Exp >= Target_Exp) {
                On_Level_Up ();
            }
        }
    }

    void On_Level_Up () {
        Data_Online _Data_Online = Dont_Destroy_On_Load.Ins._Data_Online;

        string [] Host_Server_Field = new string [8]; string [] Host_Server_Value = new string [8];
        Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
        Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "2";
                         // Cur_Exp :
        Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Db_Character_1_Home_Status";
        Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Cur_Exp";
        Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = (Target_Exp *-1).ToString ();
                         // Loot :
        Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Db_Character_1_Home_Status";
        Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Level";
        Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1";

        Dont_Destroy_On_Load.Ins._Data_Online.Got_Items (Host_Server_Field, Host_Server_Value);  
    }
    #endregion
    #region Bg_Header_Up
    [SerializeField]
    Image Bg_Header_Up;
    // Clone_Bg_Header_Up :
    public TMP_Text Yellow_Energy_Tx, Purple_Energy_Tx, Gold_Coin_Tx, Blue_Coin_Tx;
    int Max_Yellow_Energy =88;
    int Max_Purple_Energy = 88;
    //--- Load_Host_Server / Data_Online :
    public void On_Refresh_Header_Up () { 
         
        Bg_Header_Up.gameObject.SetActive (true);
        Data_Online _Data_Online = Dont_Destroy_On_Load.Ins._Data_Online;
        Yellow_Energy_Tx.text = _Data_Online._Player_Status.Yellow_Energy.ToString () + " / " + Max_Yellow_Energy.ToString ();
        Purple_Energy_Tx.text = _Data_Online._Player_Status.Purple_Energy.ToString () + " / " + Max_Purple_Energy.ToString ();
        Gold_Coin_Tx.text = _Data_Online._Player_Status.Gold_Coin.ToString ();
        Blue_Coin_Tx.text = _Data_Online._Player_Status.Blue_Coin.ToString ();

        On_Refresh_Clone_Bg_Header_Up ();
        On_Refresh_Header_Left ();
        On_Refresh_Event ();
        
    }

        #region Clone_Bg_Header_Up
        [SerializeField]
        Clone_Bg_Header_Up [] A_Clone_Bg_Header_Up;
        // [0] = Hall_Of_Masters
        sbyte Target_Bg_Header_Up;
        // Hall_Of_Masters :
        public void On_Clone_Bg_Header_Up (sbyte x) {
            Target_Bg_Header_Up = x;
            A_Clone_Bg_Header_Up[x].gameObject.SetActive (true);
             A_Clone_Bg_Header_Up[x].On_Refresh ();
        }
        // Hall_Of_Masters :
        public void Off_Clone_Bg_Header_Up () {
            Target_Bg_Header_Up = -1;
            foreach (Clone_Bg_Header_Up x in A_Clone_Bg_Header_Up) {
                if (x.gameObject.activeInHierarchy) {
                    x.gameObject.SetActive (false);
                }
            }
        }
        void On_Refresh_Clone_Bg_Header_Up () {
            if (Target_Bg_Header_Up >-1) {
                A_Clone_Bg_Header_Up[Target_Bg_Header_Up].On_Refresh ();
            }
        }
        #endregion
    #endregion
    #region Refresh_Event
   

    void On_Refresh_Event () {
        if (Home_System.Ins._Hall_Of_Masters.b_Skill_Tab_2) {
            Home_System.Ins._Hall_Of_Masters.On_Refresh_Skill_Tab_2 ();
        }
    }
    #endregion
    #region Mini_Menu_1
        string Mini_Menu_1_Code_From = "";
        [SerializeField]
        Mini_Menu_1 [] A_Clone_Mini_Menu_1;
        // [0] = Tower_Infinity_System, Arena (Pending).
        sbyte Target_Mini_Menu_1;
        // Tower_Infinity_System :
        public void On_Clone_Mini_Menu_1 (sbyte x) {
            Target_Mini_Menu_1 = x;
            A_Clone_Mini_Menu_1[x].gameObject.SetActive (true);
            A_Clone_Mini_Menu_1[x].On_Refresh (Mini_Menu_1_Code_From);
        }
        // Tower_Infinity_System :
        public void Off_Clone_Mini_Menu_1 () {
            Target_Mini_Menu_1 = -1;
            foreach (Mini_Menu_1 x in A_Clone_Mini_Menu_1) {
                if (x.gameObject.activeInHierarchy) {
                    x.gameObject.SetActive (false);
                }
            }
        }
        void On_Refresh_Clone_Mini_Menu_1 () {
            if (Target_Mini_Menu_1 >-1) {
                A_Clone_Mini_Menu_1[Target_Mini_Menu_1].On_Refresh (Mini_Menu_1_Code_From);
            }
        }
    #endregion
    #region Test (Sementara)
    // Button (Test)
    public void Cli_On_Gold_Plus_1000 () {
        Dont_Destroy_On_Load.Ins._Data_Online.Got_Gold_Coin ("1000");
    }

    public void Cli_On_Add_Potion () {
        // Save_Inventory :
        Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
       // Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Hair_Type, "Hair_Type", "1");
        Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Loot_Box", "Item", "3");
        Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
        // END
    }

    public void On_Test_Exp (){
        Dont_Destroy_On_Load.Ins._Data_Online.Exp_Gt ("1000000");
    }
    #endregion
    #region Music_Script
    // This/ Tower_Infinity_Choose :
    public void On_Start_Music () {
        Sound_System.Ins._Music.On_Clear_Playlist ();
        Sound_System.Ins._Music.On_Add_Playlist ("Town_1");
        Sound_System.Ins._Music.On_Add_Playlist ("Town_2");
        Sound_System.Ins._Music.On_Add_Playlist ("Town_3");
        Sound_System.Ins._Music.On_Next_Playlist ();
    }
    #endregion
    #region Animator_Manual
    [SerializeField]
    Animator_Manual [] A_Animator_Manual_Home_1;
    // Visual_Novel_Canvas :
    public void On_A_Animator_Manual_Home_1 () {
        foreach (Animator_Manual x in A_Animator_Manual_Home_1) {
            x.On_Play ();
        }
    }
    #endregion
}
