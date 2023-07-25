using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Submit_1_Parent : MonoBehaviour {
   string Cd_Submit = "";
   string Cd_Event = "";
    
    
    // Blacksmith :
    public List <Submit_Button_1> L_Submit_Button_1 = new List <Submit_Button_1> ();
    public List <int> L_Int_Submit_Button_1 = new List <int> ();
    // Blacksmith :
   public void On_Active_Submit_Event (string Cd_Submit_V , string Cd_Event_V) {
        Parent_Submit_Items_1 = null;
        L_Submit_Button_1 = new List <Submit_Button_1> (); L_Int_Submit_Button_1 = new List <int>();
        Diactive_All_Submit_Button_1 ();
        Destroy_All_Submit_Button_1 (); 
        Cd_Submit = Cd_Submit_V; Cd_Event = Cd_Event_V;
        Submit_1_Parent_Scale.gameObject.SetActive (true);
   }

   public void Off_Active_Submit_Event () {
        Submit_1_Parent_Scale.gameObject.SetActive (false);
   }
    // Blacksmith :
   public void On_Add_Submit_Button (string Cd_Submit_Code_V, string Cd_Submit_For_V, int Required_V) {
        GameObject But = GameObject.Instantiate (Submit_1_Parent_But_Samp);
        But.transform.parent = Submit_1_parent;
        But.GetComponent <Submit_Button_1> ().On_Input_Needs (Cd_Submit_Code_V, Cd_Submit_For_V, Required_V);
        But.GetComponent <Submit_Button_1> ().Code_Antri = L_Submit_Button_1.Count;
        L_Submit_Button_1.Add (But.GetComponent <Submit_Button_1> ()); L_Int_Submit_Button_1.Add (0);
        But.SetActive (true);
        But.transform.localScale = new Vector3 (1,1,1);
   }
   #region Submit_1_Parent
   [SerializeField]
    Canvas Submit_1_Parent_Scale;
   [SerializeField]
   Transform Submit_1_parent;
    [SerializeField]
    GameObject Submit_1_Parent_But_Samp;
    void Diactive_All_Submit_Button_1 () {
        
        foreach (Transform si in Submit_1_parent) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Submit_Button_1 () {
        Debug.LogError ("Destroy_All");
        foreach (Transform si in Submit_1_parent) {
            Submit_Button_1 Sb = si.gameObject.GetComponent <Submit_Button_1>();
            if (!si.gameObject.activeInHierarchy && !Sb.b_Sample) {Destroy (si.gameObject);}
        }
    }
   #endregion
 
   #region On_Set_Submit_Button_1

   [SerializeField]
   Transform Super_Parent_Submit_1;
   [SerializeField]
    GameObject Parent_Submit_1_Samp;
    
    int Cur_Parent_Submit_1 = 0;
    int Max_Parent_Submit_1 = 7;
    public void On_Inc_Cur_Parent_Submit_1 () {
        Cur_Parent_Submit_1 ++;
        if (Cur_Parent_Submit_1 > Max_Parent_Submit_1) {
            Cur_Parent_Submit_1 =1 ;

            GameObject Ins = GameObject.Instantiate (Parent_Submit_1_Samp);
            Ins.gameObject.GetComponent <Type_1_Vertical_Layout>().b_Sample = false;
            Ins.transform.SetParent (Super_Parent_Submit_1);
            Parent_Submit_Items_1 = Ins.transform;
            Ins.transform.localScale = new Vector3 (1,1,1);
            Ins.SetActive (true);
        } else if (Parent_Submit_Items_1 == null) {
            GameObject Ins = GameObject.Instantiate (Parent_Submit_1_Samp);
            Ins.gameObject.GetComponent <Type_1_Vertical_Layout>().b_Sample = false;
            Ins.transform.SetParent (Super_Parent_Submit_1);
            Parent_Submit_Items_1 = Ins.transform;
            Ins.transform.localScale = new Vector3 (1,1,1);
            Ins.SetActive (true);
        }
       
    }

    void Diactive_All_Items_Button_Submit_1 () {
        
        foreach (Transform si in Super_Parent_Submit_1) {
            si.gameObject.SetActive (false);
        }
    }
    void Destroy_All_Items_Button_Submit_1 () {
        Debug.LogError ("Destroy_All 2");
        foreach (Transform si in Super_Parent_Submit_1) {
            Type_1_Vertical_Layout Sb = si.gameObject.GetComponent <Type_1_Vertical_Layout>();
            if (!si.gameObject.activeInHierarchy && !Sb.b_Sample) {Destroy (si.gameObject);}
        }
    }

    Transform Parent_Submit_Items_1;
    
    [SerializeField]
    GameObject Item_Button_1_Samp;

    [SerializeField]
    Canvas Submit_Canvas;
    // Submit_Button_1 :
    Submit_Button_1 Cur_Submit_Button_1;
    
    [SerializeField]
    Button Confirm_Submit_Button;
    public void On_Set_Submit_Button (Submit_Button_1 v) {
        Cur_Submit_Button_1 = v;
        
        On_Show_Submit_Button_1 ();
        Submit_Canvas.gameObject.SetActive (true);
    }

    int Target_Submit_Button_1_Penyesuaian_Type;
    public void Close_Set_Submit () {
        Submit_Canvas.gameObject.SetActive (false);
        
        if (Cd_Event == "Echance_Weapon" || Cd_Event == "Echance_Armor") {
            BSIM_Script.Ins._Blacksmith_Script.On_Check_Submitted_Echance (Check_Required ());
        }
        if (Cd_Event == "Transfer_Status_Weapon" || Cd_Event == "Transfer_Status_Armor") {
            int x = 0;
            for (x =0; x < L_Submit_Button_1.Count; x ++) {
                if (L_Submit_Button_1[x].Cd_Submit_For == "Weapon_Offhand" || L_Submit_Button_1[x].Cd_Submit_For == "Bodyparts") { 
                    if (L_Submit_Button_1[x].Cur_Slot_Inventory > 0) {
                        Target_Submit_Button_1_Penyesuaian_Type = x;
                        break;
                    } 
                }
            }

            if (Target_Submit_Button_1_Penyesuaian_Type > 0) {
                int y = 0;
                for (y =0; y < L_Submit_Button_1.Count; y ++) {
                    if (L_Submit_Button_1[y].Cd_Submit_For == "Weapon_Offhand" || L_Submit_Button_1[y].Cd_Submit_For == "Bodyparts") { 
                    // if (Target_Submit_Button_1_Penyesuaian_Type !=y) {
                        // if (L_Submit_Button_1[y].Cur_Slot_Inventory == 0) {
                            string Type_Target = Home_System.Ins._Home_Status.A_Inventory_Type[L_Submit_Button_1[Target_Submit_Button_1_Penyesuaian_Type].Cur_Slot_Inventory];
                            L_Submit_Button_1[y].On_Input_Needs ("Type", Type_Target,1);
                    // }
                    // } 
                    }
                }
            }
            BSIM_Script.Ins._Blacksmith_Script.On_Check_Submitted_Transfer_Status (Check_Required ());
        }

        if (Cd_Event == "Craft_Equipment") {
            BSIM_Script.Ins._Blacksmith_Script.On_Check_Submitted_Craft_Equipment (Check_Required ());
        }
    }

    bool b_Required = false;
    bool Check_Required () {
        b_Required = true; 
        foreach (Submit_Button_1 s in L_Submit_Button_1) {
            s.On_Check_Required ();
        }

        foreach (Transform si in Submit_1_parent) {
            Submit_Button_1 Sb = si.gameObject.GetComponent <Submit_Button_1>();
            if (si.gameObject.activeInHierarchy && !Sb.b_Sample && !Sb.b_Required) {
                
                b_Required = false;
            }
        }
        return b_Required;
    }

    public void On_Show_Submit_Button_1 () {
        Cur_Parent_Submit_1 = 0; Parent_Submit_Items_1 = null;
        Diactive_All_Items_Button_Submit_1 ();
        Destroy_All_Items_Button_Submit_1 ();
        Confirm_Submit_Button.gameObject.SetActive (false);
        L_Item_Slot = new List <int>(); L_Check_Box_Type_2 = new List <Check_Box_Type_2>();
        Home_System.Ins._Home_Status.On_Submit_1_Parent_Filler_Show_Inventory (Cur_Submit_Button_1.Cd_Submit_Code, Cur_Submit_Button_1.Cd_Submit_For);
    }
    [SerializeField]
    List <int> L_Item_Slot = new List <int>();
    // Home_Status :
    public void On_Add_Item_Submit_Button_1 (int Slot) {
        if (!L_Int_Submit_Button_1.Contains (Slot)) {
            L_Item_Slot.Add (Slot);
            On_Inc_Cur_Parent_Submit_1 ();
            Debug.LogError (Home_System.Ins._Home_Status.A_Inventory_Type [Slot]);
            Home_System.Ins._Character_Selection.On_Specific_Item_Button (Item_Button_1_Samp, Parent_Submit_Items_1, Home_System.Ins._Home_Status.A_Inventory_Name [Slot],  Home_System.Ins._Home_Status.A_Inventory_Type [Slot],  Home_System.Ins._Home_Status.A_Inventory_Value [Slot]);
        }
    }

    // Checkbox_Type_2 :
    [SerializeField]
    List <Check_Box_Type_2> L_Check_Box_Type_2 = new List <Check_Box_Type_2>();
    public void Add_Check_Box_Type_2 (Check_Box_Type_2 s) {
        if (!L_Check_Box_Type_2.Contains (s)) {
            s.Code_Urutan = L_Check_Box_Type_2.Count;
            L_Check_Box_Type_2.Add (s);
        }
    }
    // Checkbox_Type_2 :
    Check_Box_Type_2 Cur_Check_Box_Type_2;
    public void On_Choose_Items (Check_Box_Type_2 s) {
        Cur_Check_Box_Type_2 = s;
        foreach (Check_Box_Type_2 u in L_Check_Box_Type_2) {
            if (s!= u) {
                u.Auto_Off_Box ();
            }
        }
        Confirm_Submit_Button.gameObject.SetActive (true);
    }
    
    public void On_Confirm_Submit_Items_Button () {
        L_Int_Submit_Button_1[Cur_Submit_Button_1.Code_Antri] = L_Item_Slot[Cur_Check_Box_Type_2.Code_Urutan];
        Cur_Submit_Button_1.On_Input_Items (Cur_Check_Box_Type_2.Item_Name, Cur_Check_Box_Type_2.Sp_283, L_Item_Slot[Cur_Check_Box_Type_2.Code_Urutan]);
        Close_Set_Submit ();
    }
   #endregion
}
