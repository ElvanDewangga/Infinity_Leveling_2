using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Database : MonoBehaviour {
    public static Character_Database Ins;
    void Awake () {
        Ins = this;
    }

    // Visual_Novel_Canvas :
    Character_Database_Part Cpc;
    public Character_Database_Part On_Get_Character_Database_Part (string Title) {
        Character_Database_Part Cp = new Character_Database_Part ();
        foreach (Transform x in this.gameObject.transform) {
            Cpc = x.GetComponent <Character_Database_Part>();
            if (Cpc.Name_Character == Title) {
                Cp = Cpc;
            }
        }
        return Cp;
    }

    #region VN_Part_Dialog
    // VN_Part_Dialog :
    public Character_Database_Part Database_Male_Combat_Master;
     public Character_Database_Part Database_Female_Mage_Master;
      public Character_Database_Part Database_Cleric_Master;
      public Character_Database_Part Database_Sage_Shrine;
      public Character_Database_Part Database_Blacksmith_Master;
      public Character_Database_Part Database_Store_Owner;
      public Character_Database_Part Database_Hellper;

    #endregion
}
