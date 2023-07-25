using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
 // System_Settings :
public class Load_Host_Server : MonoBehaviour {
        string Read_Umum = "Read_Umum.php";

        string Target_Read = "";
        [SerializeField]
        string [] Rows_Target;
        string [] Form_Field, Form_Value;

        string Code_Read_Data_Rows = "";
        // --- Setelah selesai Read :
        void Search_Row_Target (string V) {
            if (V == "Login_Canvas_Ke_Result_Player_Umum" ) {
                Login_Canvas.Ins.Result_Player_Umum = Rows_Target;
                Login_Canvas.Ins.On_Continue_Sign_In_Guest ();
            }
            if (V == "Login_Canvas_Ke_On_Continue_Sign_In_Guest" ) {
                Login_Canvas.Ins.On_Continue_Sign_In_Guest_2 ();
            }
            if (V == "Login_Canvas_Ke_On_Go_To_Video_Opening" ) {
                Login_Canvas.Ins.On_Go_To_Video_Opening ();
            }
            if (V == "Data_Online_Ke_On_Event_Load_Player_Status" ) {
                Dont_Destroy_On_Load.Ins._Data_Online.Result_Player_Status = Rows_Target;
                Dont_Destroy_On_Load.Ins._Data_Online.On_Event_Load_Player_Status ();
            } 
            if (V == "Close_Character_Selection" ) { // Data_Online
                Home_System.Ins._Character_Selection.Off_Character_Selection ();
                
            }
            if (V == "Continue_Save_Player_Status_Equipment_Slot" ) { // Data_Online
                Home_System.Ins._Character_Selection.On_Correct_Nickname_3 ();
                
            }
            if (V == "On_Increase_Loading_3" ) { // Data_Online
                Loading_Canvas.Ins.On_Increase_Loading_3 ();
            } 
            if (V == "Hall_Of_Masters_Skill_Set" ) { // Hall_Of_Masters_Skill_Set
                _Hall_Of_Masters_Skill_Set.Got_Data_A_Skill_Set_Data (Rows_Target);
            }
            if (V == "On_Refresh_Header_Up" ) { // Data_Online
                Loading_Canvas.Ins.Off_Loading_1 ();
                Home_System.Ins._Home_Status.Cli_On_HS_Inventory ();
                Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
            }
            if (V == "Loading_1_On_Refresh_Data_Online" ) { // Data_Online

               // Loading_Canvas.Ins.Off_Loading_1 ();
               Dont_Destroy_On_Load.Ins._Data_Online.Fin_Save ();
                // Home_System.Ins._Home_Status.Cli_On_HS_Inventory ();
                // Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
            }
            if (V == "Player_2d_Load_Skill" ) { // Player_2d
                _Player_2d.Got_Skill_Character (Rows_Target);
                
            }
            if (V == "Player_2d_Load_Skill_Level" ) { // Player_2d
                _Player_2d.Got_Skill_Level (Rows_Target);
            }
            if (V == "Skill_Set_Up_Equip") { // Hall_Of_Masters
                Home_System.Ins._Hall_Of_Masters.On_Finish_Skill_Set_Up_Equip ();
            }
            if (V == "Close_Loading_1") { // Hall_Of_Masters
                Loading_Canvas.Ins.Off_Loading_1 ();
                
            }
            if (V == "Player_2d_Load_Home_Status") { // Hall_Of_Masters
                Dont_Destroy_On_Load.Ins._Data_Online.On_Got_Home_Status (Rows_Target);
            }
            if (V == "On_Load_Inventory_Name" ) { // Home_Status
                Home_System.Ins._Home_Status.On_Got_Data_Inventory_Name (Rows_Target);
                Loading_Canvas.Ins.On_Increase_Loading_3 ();
            } 
            if (V == "On_Load_Inventory_Type" ) { // Home_Status
                Home_System.Ins._Home_Status.On_Got_Data_Inventory_Type (Rows_Target);
                Loading_Canvas.Ins.On_Increase_Loading_3 ();
            } 
            if (V == "On_Load_Inventory_Value" ) { // Home_Status
                Home_System.Ins._Home_Status.On_Got_Data_Inventory_Value (Rows_Target);
                Loading_Canvas.Ins.On_Increase_Loading_3 ();
            } 
            if (V == "Input_Redeem_Code" ) { // Home_Status
               Setting_Configuration.Ins.On_Result_Redeem_Code (Rows_Target);
            } 
            if (V == "Loading_1_Use_Item") { // Data_Online
                // Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
                Loading_Canvas.Ins.Off_Loading_1 ();
                Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
                Home_System.Ins._Home_Status.Cli_On_HS_Inventory ();
                Item_Scene_Script.Ins.On_Call_Item_Configuration ("Give_Effect");
            }
            if (V == "Gold") { // Data_Online
                // Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
                Dont_Destroy_On_Load.Ins._Data_Online.On_b_Gold (false);
              //  Item_Scene_Script.Ins.On_Call_Item_Configuration ("Give_Effect");
            }
        }

        //  System_Settings : Sedang memuat . . .
        public void Read_Data_Rows (string Code_Php, string Judul_Php, string [] Form_Field_V, string [] Form_Value_V) {
            Debug.LogError ("Item 3");
            Code_Read_Data_Rows = Code_Php;
            Form_Field = Form_Field_V; Form_Value = Form_Value_V;
            switch(Judul_Php)  {
            case "Read_Umum":
                Target_Read = "Read_Umum.php";
                break;
            case "Read_All_Table": // table
                Target_Read = "Read_All_Table.php";
                break;
            case "Read_All_Table_2": // table
                Target_Read = "Read_All_Table_2.php";
                break;
            case "Read_All_Table_3": // table
                Target_Read = "Read_All_Table_3.php";
                break;
            case "Read_All_Table_4": // table
                Target_Read = "Read_All_Table_4.php";
                break;
            case "Read_All_Table_5": // table
                Target_Read = "Read_All_Table_5.php";
                break;
            case "Read_Db_Redeem_Code":
                Target_Read = "Read_Db_Redeem_Code.php";
                break;

            case "Register_Infinity_Leveling":
                Target_Read = "Register_Infinity_Leveling.php";
                break; 
            case "Read_Player_Status":
                Target_Read = "Read_Player_Status.php";
                break;
            case "Write_Player_Status":
                Target_Read = "Write_Player_Status.php";
                break;
            case "Write_All_Table_Value":
                Target_Read = "Write_All_Table_Value.php";
                break; 
            case "Write_All_Table_Value_20":
                Target_Read = "Write_All_Table_Value_20.php";
                break; 
            default:
                Target_Read = "";
                
                break;
            }
            StartCoroutine (N_Read_Data_Rows ());
        }
         WWW php_login;  WWWForm php_form;
        UnityWebRequest Uwr_login;

        IEnumerator N_Read_Data_Rows () {
            if (Target_Read != "") {
                yield return new WaitForSeconds (0.05f);
                php_form = new WWWForm ();
                int frm = 0;
                for (frm=0; frm < Form_Field.Length; frm ++) {
                    php_form.AddField (Form_Field[frm], Form_Value[frm]);
                }
            // php_form.AddField ("unity_user", String_Username);
            // php_form.AddField ("unity_pass", String_Password);

                
                // php_login = new WWW ((Dont_Destroy_On_Load.Ins._System_Settings.Php_Link + Target_Read), php_form); //Pastikan URL BEDAKAN (UNTUK SETIAP FUNGSI)
                // yield return php_login;
                // string fulldata = php_login.text;
                
                Uwr_login = UnityWebRequest.Post ((Dont_Destroy_On_Load.Ins._System_Settings.Php_Link + Target_Read), php_form); //Pastikan URL BEDAKAN (UNTUK SETIAP FUNGSI)
			    yield return Uwr_login.SendWebRequest ();
			    string fulldata = Uwr_login.downloadHandler.text;
                yield return new WaitForSeconds (0.1f);
                Rows_Target = fulldata.Split (';');
                yield return new WaitForSeconds (0.1f);
               // try {
                    /*
                    if (Rows_Target[1] == "") {
                        
                    }
                    */
                    if (Uwr_login.isNetworkError) {
                        Debug.Log ("ReadError_1");
                        StartCoroutine (N_Read_Data_Rows ());
                        yield break;
                    }
                    if (Rows_Target.Length >1) { // Network tidak error. // harusnya 0
                            /*
                            int x = 1;
                            for (x=1; x < Rows_Target.Length; x++) {
                                Debug.Log (Rows_Target[x]);
                            }
                            */
                            Search_Row_Target (Code_Read_Data_Rows);
                            Destroy (this.gameObject);
                    } else {
                      //  StartCoroutine (N_Read_Data_Rows ());
                    }
                //}  catch (System.IndexOutOfRangeException) {
                   // StartCoroutine (N_Read_Data_Rows ());
                // }
            } else {
                Debug.LogError ("Judul belum di Add !");
            }
        }
#region Hall_Of_Masters_Skill_Set
    //--- System_Settings :
    [HideInInspector]
    public Hall_Of_Masters_Skill_Set _Hall_Of_Masters_Skill_Set;
    
#endregion
#region Player_2d
    //--- System_Settings :
    [HideInInspector]
    public Player_2d _Player_2d;
    
#endregion
}
