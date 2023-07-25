using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Scene_Script : MonoBehaviour {
    public static Item_Scene_Script Ins;
    void Awake () {
        Ins = this;
    }
    [SerializeField]
    Transform Item_Scene_Trans;
    Item_Data_Script result;
    // Character_Selection :
    public Item_Data_Script On_Search_Item_Data_Script (string Item_Name_Cd_V) {
        result = null;
        foreach (Transform x in Item_Scene_Trans) {
            Item_Data_Script item = x.GetComponent <Item_Data_Script>();
            if (item.Item_Name_Cd == Item_Name_Cd_V) {
                result = item;
                break;
            }
        }
        return result;
    }

    [SerializeField]
    Transform Item_Configuration_Trans;
    string Code_Item_Configuration;
    string Code_Item_Event = ""; // "Ask_Inventory" "Use_Item"
    // Loot_Box
    public void On_Input_Code_Item_Configuration (string Code) {
        Code_Item_Configuration = Code;
    }
    // Notification_Canvas / this / Load_Host_Server :
    public void On_Call_Item_Configuration (string v) {
        Code_Item_Event = v;
        foreach (Transform x in Item_Configuration_Trans.transform) {
            if (x.gameObject.name == Code_Item_Configuration) {
                On_Set_Item_Configuration (x);
                break;
            }
        }
    }

    void On_Set_Item_Configuration (Transform v) {
        
        if (Code_Item_Configuration == "Loot_Box") {
            if (Code_Item_Event == "Ask_Inventory") {
                v.gameObject.GetComponent <Loot_Box> ().On_Use_Item ();
            }
            if (Code_Item_Event == "Use_Item") {
                v.gameObject.GetComponent <Loot_Box> ().On_Use_Item_2 ();
            }
            if (Code_Item_Event == "Give_Effect") { // Load_Host_Server
             Debug.LogError ("Use Loot Box 1.5");
                v.gameObject.GetComponent <Loot_Box> ().On_Use_Item_Effect ();
            }
        }
    }

    // Check_Box_Type_2 :
    public void On_Click_Inventory (Item_Data_Script s) {
        On_Input_Code_Item_Configuration (s.Item_Name_Cd);
        On_Call_Item_Configuration ("Ask_Inventory");
    }

}
