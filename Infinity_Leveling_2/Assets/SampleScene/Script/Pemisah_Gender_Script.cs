using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Pemisah_Gender_Script : MonoBehaviour {
    

    public C_GO_Gender [] A_C_GO_Gender;
    GameObject Result_GO;
    Body_Costume_Data Result_Body_Costume;
    public Body_Costume_Data Conv_Body_Costume (string Name, string Gender_V) {
        Body_Costume_Data Result_Body_Costume = null;
        Debug.Log (Name + Gender_V);
        if (Name != "") {
            foreach (C_GO_Gender x in A_C_GO_Gender) {
                if (x.Cd_Name == Name) {
                    if (Gender_V == "Male" && x.Male_GO ) {
                        Result_GO = x.Male_GO;
                        break;
                    } else if (Gender_V == "Female" && x.Female_GO ) {
                        Result_GO = x.Female_GO;
                        break;
                    }

                }
            }
            if (Result_GO) {
                Result_Body_Costume = Result_GO.GetComponent <Body_Costume_Data>();
            }

            if (Result_Body_Costume) {

            } else {
                Notification_Canvas.Ins.On_Notification_1 ("Notification", "Cannot Equip because your gender is diffirent.", "Okay", "");
            }
        }
        return Result_Body_Costume;
    }

    C_GO_Gender Result_C_GO_Gender;
    public C_GO_Gender Conv_C_GO_Gender (string Name) {
        C_GO_Gender Result_C_GO_Gender = null;
        foreach (C_GO_Gender x in A_C_GO_Gender) {
            if (x.Cd_Name == Name) {
                Result_C_GO_Gender = x;
                break;
            }
        }
        /*
        if (Result_GO) {
            Result_C_GO_Gender = Result_GO.GetComponent <C_GO_Gender>();
        }

        
        if (Result_Body_Costume) {
            
        } else {
            Notification_Canvas.Ins.On_Notification_1 ("Notification", "Cannot Equip because your gender is diffirent.", "");
        }
        */
        return Result_C_GO_Gender;
    }
}
