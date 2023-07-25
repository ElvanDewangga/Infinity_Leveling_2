using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Setting_Configuration : MonoBehaviour {
    public static Setting_Configuration Ins;
    void Awake () {
        Ins = this;
    }
    [SerializeField]
    Canvas Setting_Canvas;
    [SerializeField]
    Check_Box_Type_2 [] A_Check_Box_Type_2_Setting_Configuration_Left;
    public void Cli_Setting_Configuration () {
        Setting_Canvas.gameObject.SetActive (true);
        A_Check_Box_Type_2_Setting_Configuration_Left[0].Cli_Box ();
    }

    public void Off_Setting_Configuration () {
        Setting_Canvas.gameObject.SetActive (false);
    }
    
    public void Cli_Setting_Configuration_Left (Check_Box_Type_2 v) {
        Off_All_Setting ();
        foreach (Check_Box_Type_2 x in A_Check_Box_Type_2_Setting_Configuration_Left) {
            if (v != x) {
                x.Auto_Off_Box ();
            }
        }
        if (v.Code_Item == "System") {
            On_System ();
        } else if (v.Code_Item == "News") {
            On_News ();
        } else if (v.Code_Item == "Event") {
            On_Event ();
        } else if (v.Code_Item == "Redeem_Code") {
            On_Redeem_Code ();
        }
    }

    void Off_All_Setting () {
        Off_System ();
        Off_Event ();
        Off_News ();
        Off_Redeem_Code ();
    }
    #region Setting_System
    [SerializeField]
    Image Setting_System;
    void On_System () {
        Setting_System.gameObject.SetActive (true);
    }
    void Off_System () {
        Setting_System.gameObject.SetActive (false);
    }
    #endregion
    #region News
    [SerializeField]
    Image Setting_News;
    void On_News () {
        Setting_News.gameObject.SetActive (true);
    }
    void Off_News () {
        Setting_News.gameObject.SetActive (false);
    }
    #endregion
    #region Event
    [SerializeField]
    Image Setting_Event;
    void On_Event () {
        Setting_Event.gameObject.SetActive (true);
    }
    void Off_Event () {
        Setting_Event.gameObject.SetActive (false);
    }
    #endregion
    #region Redeem_Code
    [SerializeField]
    Image Setting_Redeem_Code;
    void On_Redeem_Code () {
        Setting_Redeem_Code.gameObject.SetActive (true);
    }
    void Off_Redeem_Code () {
        Setting_Redeem_Code.gameObject.SetActive (false);
    }

    [SerializeField]
    TMP_InputField IF_Redeem_Code;
    
    public void Cli_Start_Redeem_Code () {
        Loading_Canvas.Ins.On_Loading_1 ();
        string [] Host_Server_Field = new string [1]; string [] Host_Server_Value = new string [1];
         Host_Server_Field[0] = "Code_Voucher"; Host_Server_Value[0] = IF_Redeem_Code.text;
         Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Input_Redeem_Code", "Read_Db_Redeem_Code", Host_Server_Field, Host_Server_Value);

    }

    [SerializeField]
    string [] Result_Redeem;
    public void On_Result_Redeem_Code (string [] Result) {
        Result_Redeem = new string [0];
        Result_Redeem = Result;
        if (Result_Redeem[1] == "") {
            Notification_Canvas.Ins.On_Notification_1 ("Notification", "Invalid redeem code.", "Okay", "");
            Loading_Canvas.Ins.Off_Loading_1 ();
        } else {
            // Save_Inventory :
            Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
        
            
            int x = 2;
            for (x = 2; x < Result_Redeem.Length; x= x+3) {
                if (Result_Redeem[x] != "") {
                    Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (Result_Redeem[x], Result_Redeem[x+1], Result_Redeem[x+2]);
                }
            }
            Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
            // END
            
        }
    }


    #endregion
}
