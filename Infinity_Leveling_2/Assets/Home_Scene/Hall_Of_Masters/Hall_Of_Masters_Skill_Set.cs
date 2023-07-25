using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall_Of_Masters_Skill_Set : MonoBehaviour {
   // Attach at button : Hall_Of_Masters_Brown_Box.
   // Check_Box_Type_2 :
    public string Title;
    public string Keterangan_Skill_Set;
    [HideInInspector]
    // Description_Table_1 :
    public string Load_Title;
    // Hall_Of_Masters :
    public string [] A_Skill_Set_Data;
    // On_Load_Set () - Load_Host_Server :
    public void Got_Data_A_Skill_Set_Data (string [] V) {
        A_Skill_Set_Data = V;
        Loading_Canvas.Ins.On_Increase_Loading_3 ();
    }
    // Hall_Of_Masters :
    public void On_Load_Set () {
        Load_Title = "Db_Skill_"+Title;
        
        string [] Host_Server_Field = new string [2]; 
        string [] Host_Server_Value = new string [2]; 
        Host_Server_Field[0] = "table"; Host_Server_Value[0] = Load_Title; 
        Host_Server_Field[1] = "Guest_Id"; Host_Server_Value[1] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
        
        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO (this.gameObject.GetComponent <Hall_Of_Masters_Skill_Set> (), "Hall_Of_Masters_Skill_Set", "Read_All_Table", Host_Server_Field, Host_Server_Value);
    }
}
