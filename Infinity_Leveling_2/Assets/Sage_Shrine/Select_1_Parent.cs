using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_1_Parent : MonoBehaviour {
    string Cd_Select = "";
   string Cd_Event = "";
    
    // Sage_Shrine :
    public List <Select_1_Button> L_Select_1_Button = new List <Select_1_Button> ();
    // Sage_Shrine :
   public void On_Active_Select_Event (string Cd_Select_V , string Cd_Event_V) {
        L_Select_1_Button = new List <Select_1_Button> ();
        Diactive_All_Select_Button_1 ();
        Destroy_All_Select_Button_1 (); 
        Cd_Select = Cd_Select_V; Cd_Event = Cd_Event_V;
        Select_1_Parent_Scale.gameObject.SetActive (true);
   }

   public void Off_Active_Select_Event () {
        Select_1_Parent_Scale.gameObject.SetActive (false);
   }
    // Blacksmith :
   public void On_Add_Select_Button (string Cd_Submit_Code_V, string Cd_Str_Required_V, int Cd_Int_Required_V, Sprite Cd_Sprite_V) {
        GameObject But = GameObject.Instantiate (Select_1_Parent_But_Samp);
        But.transform.parent = Select_1_parent;
        But.GetComponent <Select_1_Button> ().On_Input_Data (Cd_Submit_Code_V, Cd_Str_Required_V, Cd_Int_Required_V, Cd_Sprite_V);
        But.GetComponent <Select_1_Button> ().Code_Antri = L_Select_1_Button.Count;
        L_Select_1_Button.Add (But.GetComponent <Select_1_Button> ());
        But.SetActive (true);
        But.transform.localScale = new Vector3 (1,1,1);
   }

   #region Select_1_Parent
   [SerializeField]
    Canvas Select_1_Parent_Scale;
   [SerializeField]
   Transform Select_1_parent;
    [SerializeField]
    GameObject Select_1_Parent_But_Samp;
    void Diactive_All_Select_Button_1 () {
        
        foreach (Transform si in Select_1_parent) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Select_Button_1 () {
        Debug.LogError ("Destroy_All");
        foreach (Transform si in Select_1_parent) {
            Select_1_Button Sb = si.gameObject.GetComponent <Select_1_Button>();
            if (!si.gameObject.activeInHierarchy && !Sb.b_Sample) {Destroy (si.gameObject);}
        }
    }
   #endregion
   #region Select_Button
    // Sage_Shrine :
    [HideInInspector]
    public Select_1_Button Cur_Select_1_Button;
    
    public void On_Set_Select_Button (Select_1_Button v) {
        Cur_Select_1_Button = v;
        foreach (Select_1_Button x in L_Select_1_Button) {
            if (x != v) {
                x.Off_Select ();
            }
        }
    }
   #endregion
}
