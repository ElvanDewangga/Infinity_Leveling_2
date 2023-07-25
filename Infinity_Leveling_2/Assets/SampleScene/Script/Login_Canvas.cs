using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login_Canvas : MonoBehaviour {
    [SerializeField]
    Button Sign_In_Gmail;
    [SerializeField]
    Button Sign_In_Guest;
    [SerializeField]
    Button Login;
    
    public static Login_Canvas Ins;

    // Load_Host_Server :
    public string [] Result_Player_Umum = new string [0];
    void Awake () {
        Ins = this;
    }
    
    void Start () {
       //// Sign_In_Gmail.gameObject.SetActive (false);
        Sign_In_Guest.gameObject.SetActive (false);
        Login.gameObject.SetActive (false);

        On_Start ();
    }

    void On_Start () {
        Sound_System.Ins._Music.On_Play ("Opening", false);
        Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id = PlayerPrefs.GetString ("Last_Login_Guest_Id");
        if (Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id == "") {
            Sign_In_Gmail.gameObject.SetActive (true);
            Sign_In_Guest.gameObject.SetActive (true);
        } else {
            Login.gameObject.SetActive (true);
        }
        StartCoroutine (N_Anim_Start ());
    }
    #region Sign_In_Guest
    // But :
    public void On_Sign_In_Guest () {
        Tabel_Sign_In.gameObject.SetActive (false);
        Loading_Canvas.Ins.On_Loading_1  ();
       Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Login_Canvas_Ke_Result_Player_Umum", "Read_Umum", new string [0], new string [0]);
        
      ////  Sign_In_Gmail.gameObject.SetActive (false);
      //  Sign_In_Guest.gameObject.SetActive (false);
    }

    // --- Load_Host_Server :
    public void On_Continue_Sign_In_Guest () {
        string [] Register_Field = new string [2]; Register_Field[0] = "Guest_Id"; Register_Field [1] = "Token_Google";
        string [] Register_Value = new string [2]; Register_Value[0] = Result_Player_Umum[3]; Register_Value [1] = "";
        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Login_Canvas_Ke_On_Continue_Sign_In_Guest", "Register_Infinity_Leveling", Register_Field, Register_Value);
    }

    // --- Load_Host_Server :
    public void On_Continue_Sign_In_Guest_2 () {
        Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id = Result_Player_Umum[3];
        Dont_Destroy_On_Load.Ins._Data_Offline.On_Save_Last_Login_Guest_Id ();
        On_After_Sign_In ();
    }

    #endregion
    #region After_Sign_In
    void On_After_Sign_In () {
        Dont_Destroy_On_Load.Ins._Data_Online.On_Load_Player_Status ("Login_Canvas_Ke_On_Check_Term_Policy");
    }
    #endregion
    #region Term_Policy
    [SerializeField]
    Image Bg_Term_Policy, Tab_Term, Tab_Policy;
    
    // Load_Host_Server - Data_Online :
    public void On_Check_Term_Policy () {
        Term_Next_Button.gameObject.SetActive (false); Policy_Next_Button.gameObject.SetActive (false);
        Tab_Term.gameObject.SetActive (false); Tab_Policy.gameObject.SetActive (false);
        // Bg_Term_Policy.gameObject.SetActive (true);
        if (Dont_Destroy_On_Load.Ins._Data_Online._Player_Status.Accept_Privacy_Policy == 0) {
           // On_Tab_Term ();
            On_Singkat_Term_Policy ();
            Loading_Canvas.Ins.Off_Loading_1 ();
        } else {
           Loading_Canvas.Ins.On_Loading_4 ();
           Loading_Canvas.Ins.Off_Loading_1 ();
           On_Go_To_Home ();
        }
        
    }

    [SerializeField]
    Image Singkat_Term_Policy;

    void On_Singkat_Term_Policy () {
        
        Singkat_Term_Policy.gameObject.SetActive (true);
    }

    void Off_Singkat_Term_Policy () {
        Singkat_Term_Policy.gameObject.SetActive (false);
    }

    public void On_See_Term () {
        On_Tab_Term ();
    }

    public void On_See_Privacy_Policy () {
        On_Tab_Policy ();
    }

    public void On_Cli_Accept_Term_Policy () {
        Off_Singkat_Term_Policy ();
        On_Policy_Next_Button ();
    }

    [SerializeField]
    Button Term_Next_Button;
    // Check_Box :
    public void On_Term_Check_Box () {
        Term_Next_Button.gameObject.SetActive (true);
    }

    public void Off_Term_Check_Box () {
        Term_Next_Button.gameObject.SetActive (false);
    }
    
    public void On_Term_Next_Button () {
        Off_Tab_Term ();
        On_Tab_Policy ();
    }

    void On_Tab_Term () {
        Bg_Term_Policy.gameObject.SetActive (true);
        Tab_Term.gameObject.SetActive (true);
    }

    public void Off_Tab_Term () {
        Bg_Term_Policy.gameObject.SetActive (false);
        Tab_Term.gameObject.SetActive (false);
    }
    
    [SerializeField]
    Button Policy_Next_Button;
    // Check_Box :
    public void On_Policy_Check_Box () {
        Policy_Next_Button.gameObject.SetActive (true);
    }

    public void Off_Policy_Check_Box () {
        Policy_Next_Button.gameObject.SetActive (false);
    }

    public void On_Policy_Next_Button () {
        
        Loading_Canvas.Ins.On_Loading_1 ();
        Off_Tab_Policy ();
        string [] Host_Server_Field = new string [3]; Host_Server_Field[0] = "Guest_Id"; Host_Server_Field[1] = "Code_Write_1"; Host_Server_Field[2] = "Code_Value_1";
        string [] Host_Server_Value = new string [3]; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id; Host_Server_Value[1] = "Accept_Privacy_Policy"; Host_Server_Value[2] = "1";
        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Login_Canvas_Ke_On_Go_To_Video_Opening", "Write_Player_Status", Host_Server_Field, Host_Server_Value);
    }

    void On_Tab_Policy () {
        Bg_Term_Policy.gameObject.SetActive (true);
        Tab_Policy.gameObject.SetActive (true);
    }

    public void Off_Tab_Policy () {
        Bg_Term_Policy.gameObject.SetActive (false);
        Tab_Policy.gameObject.SetActive (false);
    }
    #endregion
    #region Go_To_Home
    void On_Go_To_Home () {
        Loading_Canvas.Ins.On_Loading_4 ();

        SceneManager.LoadScene ("Home_Scene");
    }
    #endregion
    #region Go_To_Video_Opening
    // Load_Host_Server :
    public void On_Go_To_Video_Opening () {
        Loading_Canvas.Ins.On_Loading_4 ();
        Loading_Canvas.Ins.Off_Loading_1 ();

        SceneManager.LoadScene ("Video_Awal_Scene");
    }
    #endregion
    #region Reset_G
    // Google_Sign_In :
    public Image Sign_In_Failed_Img, Sign_In_Success_Img;

    public void On_Reset_G () {
        Dont_Destroy_On_Load.Ins._Data_Offline.On_Reset_Last_Login_Guest_Id ();
    }
    #endregion
    #region Login
    public void On_Login () {
        Tabel_Sign_In.gameObject.SetActive (false);
        Dont_Destroy_On_Load.Ins._Data_Online.On_Load_Player_Status ("Login_Canvas_Ke_On_Check_Term_Policy");
        Loading_Canvas.Ins.On_Loading_1 ();

       // Login.gameObject.SetActive (false);
    }
    
    #endregion
    #region V1_Login
    [SerializeField]
    Image Tabel_Sign_In;

    public void On_Cancel_Term () {
        Tabel_Sign_In.gameObject.SetActive (true);
        Singkat_Term_Policy.gameObject.SetActive (false);
    }

    IEnumerator N_Anim_Start () {
        yield return new WaitForSeconds (3.5f);
        Tabel_Sign_In.gameObject.SetActive (true);
    }
    #endregion
}
