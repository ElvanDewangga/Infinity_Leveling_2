using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Check_Box_Type_3 : MonoBehaviour {
   public string Code_Box = "";
   public string Code_Item = "";
   Button This_Button;
    bool b_Can_Click = false;
   [Header ("Home_Status_Equipment_Left")]
   // A_Img :
   // [0] = Box_Select
   // [1] = Logo
   // [2] = Star

   // A_Tx :
   // [0] = Title
   [SerializeField]
   Image [] A_Img;
    [SerializeField]
    Image Selected_Img;
   [SerializeField]
   TMP_Text [] A_Tx;


   void Awake () {
        This_Button = GetComponent <Button> ();
        This_Button.onClick.AddListener (Cli_Box);
   }

    
    public void Cli_Box () {
        if (!b_Can_Click) {
            On_Box ();
        }
    }

    public void Auto_Off_Box () {
        Off_Box ();
    }

    public void Auto_On_Box () {
        if (Code_Box == "Home_Status_Equipment_Left") {
            Selected_Img.gameObject.SetActive (true);
        }
    }

    void On_Box () {
        if (Code_Box == "Home_Status_Equipment_Left") {
            Home_System.Ins._Home_Status.On_HS_Equipment_Input_Cb_3 (this);
        }
    }
    
    void Off_Box () {
        if (Code_Box == "Home_Status_Equipment_Left") {
            Selected_Img.gameObject.SetActive (false);
        }
        b_Can_Click = false;
    }
#region On_Input_Data
    // Home_Status :
    [HideInInspector]
    public Check_Box_Type_2 _Check_Box_Type_2;
    // Character_Selection :
    public void On_Input_Data_Check_Box_Type_2 (Check_Box_Type_2 Cb) {
        if (Code_Box == "Home_Status_Equipment_Left") {
            _Check_Box_Type_2 = Cb;
            A_Img[1].sprite = _Check_Box_Type_2.Logo_Img.sprite;
            A_Img[1].gameObject.SetActive (true);
        }
    }

    // Home_Status :
    public void Off_Input_Data_Check_Box_Type_2 () {
        if (Code_Box == "Home_Status_Equipment_Left") {
            _Check_Box_Type_2 = null;
             A_Img[1].sprite = null;
            A_Img[1].gameObject.SetActive (false);
        }
    }

#endregion
#region On_Load
    // Home_Status :
    public void On_Load () {
        if (Code_Box == "Home_Status_Equipment_Left") {
            A_Tx[0].text = Dont_Destroy_On_Load.Ins._System_Settings.On_Check_Underline (Code_Item);
        }
    }
#endregion
}
