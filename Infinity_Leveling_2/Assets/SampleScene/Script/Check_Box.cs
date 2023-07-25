using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check_Box : MonoBehaviour {
    // Character_Selection :
    public string Code_Box = "";

    
   [SerializeField]
    Button Box_Button;

    [SerializeField]
    Sprite Sprite_On, Sprite_Off;

    [SerializeField]
    Color Color_On, Color_Off;
    [SerializeField]
    Image Selected_Img;

    [HideInInspector]
    bool b_Check = false;
    void Awake () {
        Box_Button.onClick.AddListener (Cli_Box);
    }
    public void Cli_Box () {
        if (!b_Check) {
            b_Check = true;
            if (Code_Box == "Term_Box" || Code_Box == "Policy_Box") {
                Box_Button.image.sprite = Sprite_On;
                // Code_Box == "Rig_Male_1" || Code_Box == "Rig_Female_1"
            } else if (Code_Box == "Character_Selection_Hair_Type" || Code_Box == "Character_Selection_Face" || Code_Box == "Character_Selection_Hair_Colour" || Code_Box == "Character_Selection_Skin_Tone") {
           //     Box_Button.image.color = Color_On;
                Selected_Img.gameObject.SetActive (true);
            }
            On_Box ();
            Debug.Log ("On = " + Code_Box);
        } else {
            
            if (Code_Box == "Term_Box" || Code_Box == "Policy_Box") {
                b_Check = false;
                Box_Button.image.sprite = Sprite_Off;
                 Off_Box ();
            }
           
        }
    }

    public void Auto_Off_Box () {
        if (b_Check) {
            if (Code_Box == "Rig_Male_1" || Code_Box == "Rig_Female_1" || Code_Box == "Character_Selection_Hair_Type"  || Code_Box == "Character_Selection_Face" || Code_Box == "Character_Selection_Hair_Colour" || Code_Box == "Character_Selection_Skin_Tone") {
                b_Check = false;
              //  Box_Button.image.color = Color_Off;
                Off_Box ();
                Debug.Log ("Auto Off");
            }
        }
    }

    void On_Box () {
        if (Code_Box == "Term_Box") {
            Login_Canvas.Ins.On_Term_Check_Box ();
        }
        else if (Code_Box == "Policy_Box") {
            Login_Canvas.Ins.On_Policy_Check_Box ();
        }
        else if (Code_Box == "Rig_Male_1") {
            Home_System.Ins._Character_Selection.On_Refresh_Gender (Code_Box);
        }
        else if (Code_Box == "Rig_Female_1") {
            Home_System.Ins._Character_Selection.On_Refresh_Gender (Code_Box);
        }
        else if (Code_Box == "Character_Selection_Hair_Type"  || Code_Box == "Character_Selection_Face" || Code_Box == "Character_Selection_Hair_Colour" || Code_Box == "Character_Selection_Skin_Tone") {
            Home_System.Ins._Character_Selection.On_Refresh_Accesories (Code_Box);
        }
    }
    
    void Off_Box () {
        if (Code_Box == "Term_Box") {
             Login_Canvas.Ins.Off_Term_Check_Box ();
        }
        else if (Code_Box == "Policy_Box") {
            Login_Canvas.Ins.Off_Policy_Check_Box ();
        }
        else if (Code_Box == "Rig_Male_1") {

        }
        else if (Code_Box == "Rig_Female_1") {

        }
        else if (Code_Box == "Character_Selection_Hair_Type"  || Code_Box == "Character_Selection_Face" || Code_Box == "Character_Selection_Hair_Colour" || Code_Box == "Character_Selection_Skin_Tone") {
           // Box_Button.image.color = Color_Off;
           Selected_Img.gameObject.SetActive (false);
        }
    }
}
