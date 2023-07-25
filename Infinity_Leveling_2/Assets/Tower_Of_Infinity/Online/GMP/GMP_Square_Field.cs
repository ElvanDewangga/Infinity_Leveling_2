using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class GMP_Square_Field : MonoBehaviour {
   public string Name_Floor;
   int Code_Floor;
   Transform Cur_Room_Enemy_Parent;
   
   
   public void On_Input_Data_To_GMP_Square_Field (string Name_Floor_V,int Code_Floor_V) {
      Name_Floor = Name_Floor_V;
      Code_Floor = Code_Floor_V;
      Cur_Room_Enemy_Parent = GMP_Area_Generate.Ins.A_Ins_Room_Enemy_Parent.GetChild (Code_Floor_V);
   }
   // GMP_Area_Generate :
   public void On_Masuk_Field_Ini () {
      Tower_Infinity_Manager.Ins.On_Refresh_Floor_Tx (Name_Floor);
      gameObject.SetActive (true);
      foreach (Transform Enemy in Cur_Room_Enemy_Parent) {
         Enemy.gameObject.SetActive (true);
      }
   }

   void On_Keluar_Field_Ini () {
      gameObject.SetActive (false);
   }
   public C_Field _C_Field;
   #region A_Spawn_Area
   [SerializeField]
   // Generate_Map_Settings :
   public Transform A_Spawn_Area;
   // GMP_Map_Settings :
   public int Count_Total_Spawn_Area () {
      int Result =0;
      foreach (Transform Ch in A_Spawn_Area) {
         Result ++;
      }
      return Result;
   }
   #endregion
   #region A_Portal_Field
   [SerializeField]
   Transform A_Portal_Field;
   int Total_Portal_Field;
   // GMP_Area_Generate :
   public void On_Nyalakan_Portal () {
      Total_Portal_Field = 0;
     foreach (Transform x in A_Portal_Field.transform) {
         Total_Portal_Field ++;
     }

     int Cur_Random = Random.Range (0, Total_Portal_Field);
     A_Portal_Field.GetChild(Cur_Random).gameObject.SetActive (true);
   }
   #endregion
   #region  GMP_Area_Generate
   // GMP_Out_Of_Zone - GMP_Area_Generate :
   public Transform GMP_Dinding_Up;
   public Transform GMP_Dinding_Down;
   #endregion
}
