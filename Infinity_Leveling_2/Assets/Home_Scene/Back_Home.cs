using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Home : MonoBehaviour {
    [SerializeField]
    string Code = "";
    
    public void Cli_Back_Home () {
        if (Code == "Hall_Of_Masters") {
            Home_System.Ins._Hall_Of_Masters.Cli_Back_Profile ();
            Home_System.Ins._Hall_Of_Masters.Cli_Off_Hall_Of_Masters ();
        } else if (Code == "Skill_Set_Up") {
            Home_System.Ins._Hall_Of_Masters.Cli_Back_Profile ();
            Home_System.Ins._Hall_Of_Masters.Cli_Off_Hall_Of_Masters ();
            Home_System.Ins._Home_Status.Cli_Off_Home_Status ();
        } else if (Code == "Home_Status") {
            Home_System.Ins._Home_Status.Cli_Off_Home_Status ();
        } else if (Code == "Blacksmith") {
           BSIM_Script.Ins._Blacksmith_Script.Off_Blacksmith ();
        } else if (Code == "Sage_Shrine") {
            Sage_Shrine.Ins.Off_Sage ();
        }
    }
}
