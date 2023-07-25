using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Weapon_Data : MonoBehaviour {


   // Character_Selection :
   public string Code_Terpilih = "Weapon_1";  
   public string Weapon_Type = "Sword"; // "Sword" / "Mace"

   [SerializeField] 
   GameObject Sp_Front;
  // [SerializeField]
  // GameObject Sp_Back;
   
   [SerializeField]
   Sprite Dimensi_283_x_283;
    void Awake () {
       // Code_Character_Selection = "Character_Selection_" + Code_Terpilih;
    }

    // Character_Selection :
   public void On_Set_To_Player_2d () {
      if (Sp_Front) {
         GameObject Sam = GameObject.Instantiate (Sp_Front);
         // Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Hair_Type_Front);
         Sam.transform.SetParent (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Weapon);
         Sam.transform.localPosition = new Vector3 (0,0,0);
         Sam.SetActive (true);
         // Dont_Destroy_On_Load.Ins._Player_2d.Cur_Hair_Type_Front_GO = Sam;
         Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Weapon_GO = Sam;
         this.GetComponent <Char_Transform_Fix> ().On_Fix_Transform (Sam.transform, "Umum");
      }
      /*
      if (Sp_Back) {
         GameObject Sam = GameObject.Instantiate (Sp_Back);
         // Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Hair_Type_Front);
         Sam.transform.SetParent (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Hair_Type_Back);
         Sam.transform.localPosition = new Vector3 (0,0,0);
         Sam.SetActive (true);
         // Dont_Destroy_On_Load.Ins._Player_2d.Cur_Hair_Type_Front_GO = Sam;
         Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Hair_Type_Back_GO = Sam;
         this.GetComponent <Char_Transform_Fix> ().On_Fix_Transform (Sam.transform, "Hair_Type_Back");
      }
      */
   }

   // Character_Selection :
   public void On_Create_Button_To_Character_Selection () {
       // Home_System.Ins._Character_Selection.On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
        GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
        Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
        sc.Code_Box = "Weapon_Data";
        sc.b_Sample = false;
        sc._Weapon_Data = this;
        sc.Code_Item = Code_Terpilih;
        sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
        sc.On_Input_Data (Dimensi_283_x_283, Code_Terpilih);
        Sam.SetActive (true);
        Sam.transform.localScale = new Vector3 (1,1,1);
   } 

   // Character_Selection :
   public void On_Create_Button_To_Specific_Parent (GameObject Samp_Button, Transform Samp_Parent) {
       // Home_System.Ins._Character_Selection.On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
        GameObject Sam = GameObject.Instantiate (Samp_Button);
        Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
        sc.Code_Box = "Weapon_Data";
        sc.b_Sample = false;
        sc._Weapon_Data = this;
        sc.Code_Item = Code_Terpilih;
        sc.gameObject.transform.SetParent (Samp_Parent);
        sc.On_Input_Data (Dimensi_283_x_283, Code_Terpilih);
        Sam.SetActive (true);
        Sam.transform.localScale = new Vector3 (1,1,1);
   } 

   #region Status_Equipment_Random
    [Header ("Status_Equipment_Random :")]
    // [SerializeField]
    // Loot_Box :
    public Status_Equipment_Random [] A_Status_Equipment_Random;
    string Result_Status_Equipment_Random = "";
    public string Get_Value (int Tier_V) {
      Result_Status_Equipment_Random = "";
        if (Tier_V == 1) {
            foreach (Status_Equipment_Random x in A_Status_Equipment_Random) {
              int Min_Value, Max_Value;
              int.TryParse (x.Status_Value_Min, out Min_Value);
              int.TryParse (x.Status_Value_Max, out Max_Value);
              int Res_Value = Random.Range (Min_Value, Max_Value +1);
              Result_Status_Equipment_Random = Result_Status_Equipment_Random + ":" + x.Status_Cd +":" + Res_Value.ToString ();
            } 
        }
        return Result_Status_Equipment_Random;
    }
   /*
    List <string> L_Get_Type = new List <string> ();
    string Result_Status_Random_Get_Type;
    // Loot_Box :
    public string Get_Type () {
      Result_Status_Random_Get_Type = "";
      int x = Random.Range (0,L_Get_Type.Count);
      Result_Status_Random_Get_Type = L_Get_Type[x];
      return Result_Status_Random_Get_Type;
    }
   */
   #endregion
}
