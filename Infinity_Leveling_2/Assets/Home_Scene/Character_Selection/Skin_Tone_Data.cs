using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin_Tone_Data : MonoBehaviour {
    // Character_Selection :
   public string Code_Terpilih = "Skin_Tone_1";

   [SerializeField] 
   Color Colour_Sample;
   [SerializeField]
   Sprite Sprite_Skin;
  // [SerializeField]
  // Sprite Dimensi_283_x_283;
    void Awake () {
       // Code_Character_Selection = "Character_Selection_" + Code_Terpilih;
    }

    // Character_Selection :
   public void On_Set_To_Player_2d () {
       
       //  Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Gender_GO.GetComponent <SpriteRenderer> ().color = Colour_Sample;
        Home_System.Ins._Character_Selection.Target_Player_2d.Polos_Body.GetComponent <SpriteRenderer> ().color = Colour_Sample;

         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_R_Arm_Up.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_L_Arm_Up.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_R_Arm_Down.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_L_Arm_Down.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_R_Hand.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_L_Hand.GetComponent <SpriteRenderer> ().color = Colour_Sample;

         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_R_Leg_Up.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_L_Leg_Up.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_R_Leg_Down.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_L_Leg_Down.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_R_Foot.GetComponent <SpriteRenderer> ().color = Colour_Sample;
         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_L_Foot.GetComponent <SpriteRenderer> ().color = Colour_Sample;

         Home_System.Ins._Character_Selection.Target_Player_2d.Polos_Face.GetComponent <SpriteRenderer> ().color = Colour_Sample;
   }

   // Character_Selection :
   public void On_Create_Button_To_Character_Selection () {
        
        GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
        Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
        sc.Code_Box = "Skin_Tone_Data";
        sc.b_Sample = false;
        sc._Skin_Tone_Data = this;
        sc.Code_Item = Code_Terpilih;
        sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
        sc.On_Input_Data (Sprite_Skin);
        Sam.SetActive (true);
        
   } 
}
