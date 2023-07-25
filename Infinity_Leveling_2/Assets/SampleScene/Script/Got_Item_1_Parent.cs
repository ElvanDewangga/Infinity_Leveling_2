using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Starsky;
public class Got_Item_1_Parent : MonoBehaviour {
     string Cd_Got_Item = "";
   string Cd_Event = "";
    
    // Data_Online :
   public void On_Active_Got_Item_Event (string Cd_Got_Item_V , string Cd_Event_V) {
    Debug.LogError ("Showed");
        Home_System.Ins._Character_Selection.On_Refresh_Gender ();
        Debug.LogError (Cd_Got_Item_V + Cd_Event_V);
        Diactive_All_Got_Item_Button_1 ();
        Destroy_All_Got_Item_Button_1 (); 
        On_Show_Got_Item_Button_1 ();
        Cd_Got_Item = Cd_Got_Item_V; Cd_Event = Cd_Event_V;
        Got_Item_1_Parent_Scale.gameObject.SetActive (true);
   }

    // But :
   public void Off_Active_Got_Item_Event () {
        Got_Item_1_Parent_Scale.gameObject.SetActive (false);
   }
   /*
    // Blacksmith :
   void On_Add_Got_Item_Button (string Cd_Got_Item_Code_V, string Cd_Got_Item_For_V, int Required_V) {
        GameObject But = GameObject.Instantiate (Got_Item_1_Parent_But_Samp);
        But.transform.parent = Parent_Got_Item_1;
        But.GetComponent <Got_Item_Button_1> ().On_Input_Needs (Cd_Got_Item_Code_V, Cd_Got_Item_For_V, Required_V);
        But.SetActive (true);
        
   }
   */
   #region Got_Item_1_Parent
    [SerializeField]
    Transform Parent_Got_Item_1;
    [SerializeField]
    Canvas Got_Item_1_Parent_Scale;
    [SerializeField]
    GameObject Got_Item_1_Parent_But_Samp;

    void Diactive_All_Got_Item_Button_1 () {
        foreach (Transform si in Parent_Got_Item_1) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Got_Item_Button_1 () {
        foreach (Transform si in Parent_Got_Item_1) {
            Check_Box_Type_2 Sb = si.gameObject.GetComponent <Check_Box_Type_2>();
            if (!si.gameObject.activeInHierarchy && !Sb.b_Sample) {Destroy (si.gameObject);}
        }
    }
   #endregion
 
   #region On_Set_Got_Item_Button_1
    
    public void Close_Set_Got_Item () {
        // Got_Item_Canvas.gameObject.SetActive (false);
    }

    void On_Show_Got_Item_Button_1 () {
      //  L_Item_Slot = new List <int>();
    }

    // Data_Online :
    public void On_Add_Item_Got_Item_Button_1 (string Name, string Type, string Value) {
        Home_System.Ins._Character_Selection.On_Specific_Item_Button (Got_Item_1_Parent_But_Samp, Parent_Got_Item_1, Name, Type, Value);
    }

    
   #endregion
}
