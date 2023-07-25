using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Transform_Fix : MonoBehaviour {
   // Gender : Harus sesuaikan dengan lokal posisi dan parentnya (Asset_Gender_Trans)
   [System.Serializable]
   public class C_Fix {
      public string Code_Fix = ""; // "Umum" / "Body"/ "R_Arm_Up" / "L_Arm_Up"
      public Vector3 V3_Posisi;
      public Vector3 V3_Scale;
      public bool b_Rotation;
      public Vector3 V3_Rotation;
      
   }

   C_Fix Target_C_Fix;
   [SerializeField]
   C_Fix C_Fix_Umum;
   [SerializeField]
   C_Fix C_Fix_Hair_Type_Front;
   [SerializeField]
   C_Fix C_Fix_Hair_Type_Back;

   [SerializeField]
   C_Fix C_Fix_Helmet;
   [SerializeField]
   C_Fix C_Fix_Body;
   [SerializeField]
   C_Fix C_Fix_Lower_Body;
   [SerializeField]
   C_Fix C_Fix_R_Arm_Up;
   [SerializeField]
   C_Fix C_Fix_L_Arm_Up;
   [SerializeField]
   C_Fix C_Fix_R_Arm_Down;
   [SerializeField]
   C_Fix C_Fix_L_Arm_Down;
   [SerializeField]
   C_Fix C_Fix_R_Hand;
   [SerializeField]
   C_Fix C_Fix_L_Hand;
   [SerializeField]
   C_Fix C_Fix_R_Leg_Up;
   [SerializeField]
   C_Fix C_Fix_L_Leg_Up;
   [SerializeField]
   C_Fix C_Fix_R_Leg_Down;
   [SerializeField]
   C_Fix C_Fix_L_Leg_Down;
   [SerializeField]
   C_Fix C_Fix_R_Foot;
   [SerializeField]
   C_Fix C_Fix_L_Foot;
    // Gender_Data, Body_Costume_Data, Face_Data, dll :
   public void On_Fix_Transform (Transform x, string Bagian) {
      if (Bagian == "Umum") {
         Target_C_Fix = C_Fix_Umum;
      } 
      else if (Bagian == "Hair_Type_Front") {
         Target_C_Fix = C_Fix_Hair_Type_Front;
      }
      else if (Bagian == "Hair_Type_Back") {
         Target_C_Fix = C_Fix_Hair_Type_Back;
      }

      else if (Bagian == "Helmet") {
         Target_C_Fix = C_Fix_Helmet;
      }
      else if (Bagian == "Body") {
         Target_C_Fix = C_Fix_Body;
      }else if (Bagian == "Body_Lower") {
         Target_C_Fix = C_Fix_Lower_Body;
      } else if (Bagian == "R_Arm_Up") {
         Target_C_Fix = C_Fix_R_Arm_Up;
      } else if (Bagian == "L_Arm_Up") {
         Target_C_Fix = C_Fix_L_Arm_Up;
      } else if (Bagian == "R_Arm_Down") {
         Target_C_Fix = C_Fix_R_Arm_Down;
      } else if (Bagian == "L_Arm_Down") {
         Target_C_Fix = C_Fix_L_Arm_Down;
      } else if (Bagian == "R_Hand") {
         Target_C_Fix = C_Fix_R_Hand;
      } else if (Bagian == "L_Hand") {
         Target_C_Fix = C_Fix_L_Hand;
      } 
      else if (Bagian == "R_Leg_Up") {
         Target_C_Fix = C_Fix_R_Leg_Up;
      } else if (Bagian == "L_Leg_Up") {
         Target_C_Fix = C_Fix_L_Leg_Up;
      } else if (Bagian == "R_Leg_Down") {
         Target_C_Fix = C_Fix_R_Leg_Down;
      } else if (Bagian == "L_Leg_Down") {
         Target_C_Fix = C_Fix_L_Leg_Down;
      } else if (Bagian == "R_Foot") {
         Target_C_Fix = C_Fix_R_Foot;
      } else if (Bagian == "L_Foot") {
         Target_C_Fix = C_Fix_L_Foot;
      }

      x.transform.localPosition = Target_C_Fix.V3_Posisi;
      x.transform.localScale = Target_C_Fix.V3_Scale;
      if (Target_C_Fix.b_Rotation) {
         x.transform.localRotation = Quaternion.Euler (Target_C_Fix.V3_Rotation);
      }

   }
}
