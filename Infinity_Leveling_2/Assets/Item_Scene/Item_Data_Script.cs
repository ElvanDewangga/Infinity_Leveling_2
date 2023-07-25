using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Data_Script : MonoBehaviour {
    public string Item_Name_Show = "Health potion";
    public string Item_Name_Cd = "Health_Potion";

    public string Item_Description = "Restore 38% hp 8 sec cooldown";
    [Header ("Equipment bisa tulis 1")]
    public int Max_Slot = 888;
    public Sprite Item_Sprite_Box;
    // Check_Box_Type_2 :
    public bool b_Inventory_Click = false;
    
}
