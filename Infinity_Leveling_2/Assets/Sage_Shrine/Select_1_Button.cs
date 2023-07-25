using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Select_1_Button : MonoBehaviour {
  
    public Image Item_Img;
    public TMP_Text Item_Title;
    [SerializeField]
    public Image Item_Selected;
    [SerializeField]
    TMP_Text Item_Required;
    public int Code_Antri = 0;
    Button _Select_1_Button;
    public bool b_Sample = true;
    void Start () {
        _Select_1_Button = this.GetComponent <Button>();
        _Select_1_Button.onClick.AddListener (On_Select);
    }

    public void On_Select () {
        Dont_Destroy_On_Load.Ins._Select_1_Parent.On_Set_Select_Button (this);
        Item_Selected.gameObject.SetActive (true);
    }

    // Select_1_Parent :
    public void Off_Select () {
        Item_Selected.gameObject.SetActive (false);
    }

    #region Input_Data
    [SerializeField]
    public string Cd_Submit_Code = ""; // "Vitality"
    [SerializeField]
    public string Cd_Str_Required = ""; // "Cur_Exp"
    [SerializeField]
    public int Cd_Int_Required = 0;
    [SerializeField]
    Sprite Cd_Sprite;

    // Select_1_Parent :
    //public int Cur_Slot_Inventory;
    public void On_Input_Data (string Cd_Submit_Code_V, string Cd_Str_Required_V, int Cd_Int_Required_V, Sprite Cd_Sprite_V ) {
        Cd_Submit_Code = Cd_Submit_Code_V;
        Cd_Str_Required = Cd_Str_Required_V;
        Cd_Int_Required = Cd_Int_Required_V;
        Cd_Sprite = Cd_Sprite_V;

        Item_Title.text = Cd_Submit_Code;
        Item_Img.sprite = Cd_Sprite;
        Item_Required.text = "Required : " + Cd_Int_Required.ToString () + " " + Cd_Str_Required_V;
        On_Check_Required ();
    }
    // Submit_1_Parent :
    public bool b_Required = false;
    string Own_Value = "0";
    public void On_Check_Required () {
        /*
        Own_Value = Home_System.Ins._Home_Status.A_Inventory_Value[Cur_Slot_Inventory];
        if (Cd_Submit_For == "Weapon" || Cd_Submit_For == "Bodyparts" || Cd_Submit_For == "Weapon_Offhand" || Cd_Submit_For == "Offhand" || Cd_Submit_For == "Body_Costume" || Cd_Submit_For == "Helmet" || Cd_Submit_For == "Glove" || Cd_Submit_For == "Boot") {
            if (Cur_Slot_Inventory >0) {
                b_Required = true;
            } else  {
                b_Required = false;
            }
        } else {
            int Valued_Item;
            int.TryParse (Own_Value, out Valued_Item);
            if (Valued_Item >= Cd_Required) {
                b_Required = true;
            } else  {
                b_Required = false;
            }
        }
        */
        
    }
    #endregion
}
