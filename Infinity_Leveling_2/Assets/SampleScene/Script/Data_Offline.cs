using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Offline : MonoBehaviour {
    // Login_Canvas :
    public string Last_Login_Guest_Id;

    // Load_Host_Server :
    public void On_Save_Last_Login_Guest_Id () {
        PlayerPrefs.SetString ("Last_Login_Guest_Id", Last_Login_Guest_Id);
    }

    // Login_Canvas : (Test Only)
    public void On_Reset_Last_Login_Guest_Id () {
        PlayerPrefs.SetString ("Last_Login_Guest_Id", "");
    }

}
