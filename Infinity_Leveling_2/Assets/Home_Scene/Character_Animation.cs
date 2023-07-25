using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Animation : MonoBehaviour {
   GameObject Character_GO;
   Animator _Animator;
   
   // Enemy_2d :
   public void On_Input_Character_GO (GameObject x) {
        Character_GO = x;
        _Animator = Character_GO.GetComponent <Animator> ();
   }

   // Player_2d :
   public void On_Input_Character_GO (GameObject x, Animator y) {
        Character_GO = x;
        _Animator = y;
   }

   string Cur_Parameter, Last_Parameter;
    // Skill_Pengaturan_Animasi - Enemy_2d (Skill_Active) :
   public void On_Play_Animation (string Code_Parameter_V) {
     Debug.Log ("Play " + Code_Parameter_V);
        Cur_Parameter = Code_Parameter_V;
        if (Last_Parameter != "") {Off_Last_Animation (Last_Parameter);}
        _Animator.SetBool (Cur_Parameter, true);
        Last_Parameter = Code_Parameter_V;
   }

   void Off_Last_Animation (string Code_Parameter_V) {
        _Animator.SetBool (Code_Parameter_V, false);
   }
}
