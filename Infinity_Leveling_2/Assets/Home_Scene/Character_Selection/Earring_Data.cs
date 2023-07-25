using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earring_Data : MonoBehaviour {


   // Character_Selection :
   public string Code_Terpilih = "Earring_1";  
   // public string Gender_Type = "Male"; // "Male" / "Female" / "All"

   //[SerializeField] 
  // GameObject Sp_Front;
   //[SerializeField]
  // GameObject Sp_Back;
   
   [SerializeField]
   Sprite Dimensi_283_x_283;
    void Awake () {
       // Code_Character_Selection = "Character_Selection_" + Code_Terpilih;
    }

    // Character_Selection :
   public void On_Set_To_Player_2d () {
      /*
      if (Sp_Front) {
         GameObject Sam = GameObject.Instantiate (Sp_Front);
         // Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Hair_Type_Front);
         Sam.transform.SetParent (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Hair_Type_Front);
         Sam.transform.localPosition = new Vector3 (0,0,0);
         Sam.SetActive (true);
         // Dont_Destroy_On_Load.Ins._Player_2d.Cur_Hair_Type_Front_GO = Sam;
         Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Hair_Type_Front_GO = Sam;
         this.GetComponent <Char_Transform_Fix> ().On_Fix_Transform (Sam.transform, "Hair_Type_Front");
      }
      if (Sp_Back) {
         GameObject Sam = GameObject.Instantiate (Sp_Back);
         // Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Hair_Type_Front);
         Sam.transform.SetParent (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Hair_Type_Back);
         Sam.transform.localPosition = new Vector3 (0,0,0);
         Sam.SetActive (true);
         // Dont_Destroy_On_Load.Ins._Player_2d.Cur_Hair_Type_Front_GO = Sam;
         Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Hair_Type_Back_GO = Sam;
         this.GetComponent <Char_Transform_Fix> ().On_Fix_Transform (Sam.transform, "Hair_Type_Back");
      } else {

      }
      */
   }

   // Character_Selection :
   public void On_Create_Button_To_Character_Selection () {
        // Home_System.Ins._Character_Selection.On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
        GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
        Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
        sc.Code_Box = "Earring_Data";
        sc.b_Sample = false;
        sc._Earring_Data = this;
        sc.Code_Item = Code_Terpilih;
        sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
        sc.On_Input_Data (Dimensi_283_x_283);
        Sam.SetActive (true);
   } 

   // Character_Selection :
   public void On_Create_Button_To_Specific_Parent (GameObject Samp_Button, Transform Samp_Parent) {
        // Home_System.Ins._Character_Selection.On_Increase_Vertical_Layout_Type_1_Skill_Tab_2 ();
        GameObject Sam = GameObject.Instantiate (Samp_Button);
        Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
        sc.Code_Box = "Earring_Data";
        sc.b_Sample = false;
        sc._Earring_Data = this;
        sc.Code_Item = Code_Terpilih;
        sc.gameObject.transform.SetParent (Samp_Parent);
        sc.On_Input_Data (Dimensi_283_x_283);
        Sam.SetActive (true);
   } 
}
