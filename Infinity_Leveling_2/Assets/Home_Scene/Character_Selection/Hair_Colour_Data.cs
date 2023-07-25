using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair_Colour_Data : MonoBehaviour {
    // Character_Selection :
   public string Code_Terpilih = "White_1";

   [SerializeField] 
   Color Colour_Sample;
   
  // [SerializeField]
  // Sprite Dimensi_283_x_283;
    void Awake () {
       // Code_Character_Selection = "Character_Selection_" + Code_Terpilih;
    }

    // Character_Selection :
   public void On_Set_To_Player_2d () {
        /*
        GameObject Sam = GameObject.Instantiate (Sprite_Renderer_Sample);
        Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Hair_Type_Front);
        Sam.transform.localPosition = new Vector3 (0,0,0);
        Sam.SetActive (true);
        */
        // Dont_Destroy_On_Load.Ins._Player_2d.Cur_Hair_Type_Front_GO.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Hair_Type_Front_GO.GetComponent <SpriteRenderer> ().color = Colour_Sample;
        if (Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Hair_Type_Back_GO) {
         Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Hair_Type_Back_GO.GetComponent <SpriteRenderer> ().color = Colour_Sample;
        }
   }

   // Character_Selection :
   public void On_Create_Button_To_Character_Selection () {
        
        GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_2_Character_Select_Check_Box_Sample);
        Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
        sc.Code_Box = "Hair_Colour_Data";
        sc.b_Sample = false;
        sc._Hair_Colour_Data = this;
        sc.Code_Item = Code_Terpilih;
        sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_2_Box_Selection_Panel_Column);
        sc.On_Input_Data (Colour_Sample);
        Sam.SetActive (true);
        
   } 
}
