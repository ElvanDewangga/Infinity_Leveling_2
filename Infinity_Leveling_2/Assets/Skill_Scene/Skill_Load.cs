using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Load : MonoBehaviour {
   // GO : Skill_Scene - Skill_Data_Editor - Skill_Active / Passive :
   public static Skill_Load Ins;
   void Awake () {
        Ins = GetComponent <Skill_Load> ();
   }
   Skill_Data_Kumpulan Result;
   // Check_Box_Type_2 :
   public Skill_Data_Kumpulan On_Skill_Load (string Name) {
        Result = null;
        foreach (Transform x in this.gameObject.transform) {
            Skill_Data_Kumpulan s = x.GetComponent <Skill_Data_Kumpulan>();
            if (s.Skill_Name == Name) {
                Result = s;
                break;
            }
        }

        return Result;
   }
}
