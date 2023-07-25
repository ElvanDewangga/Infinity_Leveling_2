using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMP_Area_Generate : MonoBehaviour { // di Tower_Infinity_Manager juga ada setingan GMPnya. Jadi ada 2 setingan GMP localnya.
   public static GMP_Area_Generate Ins;
   void Awake () {
      Ins = this;
   }
   #region Start_Spawn
    
    // [SerializeField]
    public Transform [] A_Start_Spawn;
    // Online_tower_Infinity_Room :
    public void On_Start_Spawn (GameObject Target_Player, int Your_Player) {
        Target_Player.transform.position = A_Start_Spawn[Your_Player].position;
    }
   #endregion
   #region Online_Player_2d
   int Cur_Loading_Confirmation_Spawn;
   int Max_Loading_Confirmation_Spawn;

   //Online_Tower_Infinity_Room :
   public void On_Max_Loading_Confirmation_Spawn (int s) {
      Cur_Loading_Confirmation_Spawn = 0; Max_Loading_Confirmation_Spawn = s;
   }

   // Online_Player_2d :
   public void Lc_Loading_Confirmation_Spawn (string v) {
      Cur_Loading_Confirmation_Spawn ++;
      Debug.LogError ("Spawn");
      if (Cur_Loading_Confirmation_Spawn >= Max_Loading_Confirmation_Spawn) {
         Cur_Loading_Confirmation_Spawn = 0;
         Online_Tower_Infinity_Room.Ins.Increase_Loading_Room_Rpc (v);
      }
   }
   #endregion
   #region GMP_Map_Settings
   [SerializeField]
   GMP_Map_Settings [] A_GMP_Map_Settings;
   
   //[SerializeField]
   // Online_Tower_Infinity_Room :
   public GMP_Map_Settings Cur_GMP_Map_Settings;
   // GMP_Map_Settings :
   public GameObject Enemy_Sample;
   

   public Transform A_Ins_Room_Enemy_Parent;
   public GameObject Room_Enemy_Parent_Sample;

   public Transform A_Ins_Square_Field;
      #region A_Database_Square_Field 
      [SerializeField]
      Transform A_Database_Square_Field;
      // GMP_Map_Settings :
      GameObject Result_Search_Square_Field;
      public GameObject On_Search_Square_Field (string Name_Texture_V, int Cd_Texture_V) {
         // Result = new GameObject ();
        //  GameObject Result_Search_Square_Field = new GameObject ();
       //  Result_Search_Square_Field = new GameObject ();
         foreach (Transform xi in A_Database_Square_Field.transform) {
            GMP_Square_Field Gs = xi.gameObject.GetComponent <GMP_Square_Field>();
            if (Gs._C_Field.Name_Texture == Name_Texture_V && Gs._C_Field.Cd_Texture == Cd_Texture_V) {
               Result_Search_Square_Field = xi.gameObject;
               break;
            } 
         }
         // return Result;
         return Result_Search_Square_Field;
      }
      #endregion
   #endregion
   #region GMP_Masuk_Field
   // Tower_Infinity_Manager (Awal) & Portal - Online_Tower_Infinity_Room (Selanjutnya)
   int Lc_Floor = -1;
   public void On_GMP_Masuk_Field () {
      Lc_Floor ++;
      if (Lc_Floor < Cur_GMP_Map_Settings.Total_Room_In_Map) {
      
         if ((Lc_Floor-1) >= 0) {
            A_Ins_Room_Enemy_Parent.GetChild (Lc_Floor-1).gameObject.SetActive (false);
            A_Ins_Square_Field.GetChild (Lc_Floor-1).gameObject.SetActive (false);
         }
         A_Ins_Room_Enemy_Parent.GetChild (Lc_Floor).gameObject.SetActive (true);
         // A_Ins_Square_Field.GetChild (Lc_Floor).gameObject.SetActive (true);
         Cur_GMP_Square_Field = A_Ins_Square_Field.GetChild (Lc_Floor).GetComponent <GMP_Square_Field>();
         A_Ins_Square_Field.GetChild (Lc_Floor).GetComponent <GMP_Square_Field>().On_Masuk_Field_Ini ();
      } else {
        // Tower_Infinity_Manager.Ins.On_GMP_Finish ("Victory");
      }
   }
   #endregion
   #region GMP_Masuk_Field
      // Online_Tower_Infinity_Room :
   public void On_Menyalakan_Portal () {
      if (Lc_Floor < (Cur_GMP_Map_Settings.Total_Room_In_Map-1)) {
         A_Ins_Square_Field.GetChild (Lc_Floor).GetComponent <GMP_Square_Field>().On_Nyalakan_Portal ();
      } else {
         Tower_Infinity_Manager.Ins.On_GMP_Finish ("Victory");
      }
   }
   #endregion
   #region GMP_Out_Of_Zone
   // GMP_Out_Of_Zone :
   public GMP_Square_Field Cur_GMP_Square_Field;
   #endregion
}
