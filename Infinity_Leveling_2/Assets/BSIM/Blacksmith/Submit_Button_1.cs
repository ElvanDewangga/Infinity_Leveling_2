using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Submit_Button_1 : MonoBehaviour { 
   // [SerializeField]
   //Blacksmith_Script :
    public Image Item_Img;
    public TMP_Text Item_Title;
    [SerializeField]
    TMP_Text Item_Required;
    public int Code_Antri = 0;
    Button _Submit_Button_1;
    public bool b_Sample = true;
    void Start () {
        _Submit_Button_1 = this.GetComponent <Button>();
        _Submit_Button_1.onClick.AddListener (On_Submit);
    }

    public void On_Submit () {
        Debug.LogError ("Submit1");
        Dont_Destroy_On_Load.Ins._Submit_1_Parent.On_Set_Submit_Button (this);
    }

    public void Off_Submit () {
    }

    #region Input_Data
    [SerializeField]
    public string Cd_Submit_Code = ""; // "Type" / "Name"
    [SerializeField]
    public string Cd_Submit_For = ""; // "Weapon_Fragment", "Weapon", "Armor_Fragment", etc.
    [SerializeField]
    int Cd_Required = 0;
    // Blacksmith - Submit_1_Parent :
    public void On_Input_Needs (string Cd_Submit_Code_V, string Cd_Submit_For_V, int Required_V) {
        b_Required = false; b_Sample = false;
        Cd_Submit_Code = Cd_Submit_Code_V; 
        Cd_Submit_For = Cd_Submit_For_V;
        if (Cd_Submit_For == "Weapon_Offhand") {  
            Item_Title.text = "Weapon / Offhand";
        } 
        else {
            Item_Title.text = Cd_Submit_For;
        }
        Cd_Required = Required_V;
        
        Item_Required.text = "Required: " + Cd_Required.ToString () + " x";
    
        
    }

    // Submit_1_Parent : (From : Inventory Input)
    // Blacksmith/ Submit_1_Parent :
    public int Cur_Slot_Inventory;
    public void On_Input_Items (string Name, Sprite Sp,int Slot_V) {
        
        Cur_Slot_Inventory = Slot_V;
        Item_Title.text = Name;
        Item_Img.sprite = Sp;
        Own_Value = Home_System.Ins._Home_Status.A_Inventory_Value[Cur_Slot_Inventory];
        On_Check_Required ();
    }
    // Submit_1_Parent :
    public bool b_Required = false;
    string Own_Value = "0";
    public void On_Check_Required () {
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
        
    }
    #endregion
}
