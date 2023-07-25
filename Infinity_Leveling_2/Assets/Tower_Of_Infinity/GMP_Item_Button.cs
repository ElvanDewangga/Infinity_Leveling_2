using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Starsky;
public class GMP_Item_Button : MonoBehaviour {
    [SerializeField]
    string Code_Item = "";
    [SerializeField]
    TMP_Text Total_Item_Tx;
    int Cur_Item = 0;
    [SerializeField]
    Skill_Data_Kumpulan _Skill_Data_Kumpulan;
    Player_2d _Player_2d;
    void Start () {
        _Skill_Data_Kumpulan.Database_Load_Skill_Name (Code_Item);
        if (Code_Item == "Health_Potion") {
            Cur_Item = Home_System.Ins._Home_Status.On_Inventory_Search_Multiple_Item (Code_Item);
        }
        if (Code_Item == "Mana_Potion") {
            Cur_Item = Home_System.Ins._Home_Status.On_Inventory_Search_Multiple_Item (Code_Item);
        }
        Max_Cd_Time = _Skill_Data_Kumpulan._Skill_Data_Editor._Skill_Cd_Time.Cd_Time;
        Refresh_Cur_Item ();
    }

    void Refresh_Cur_Item () {
        
        Total_Item_Tx.text = "x " + Cur_Item.ToString ();
        On_Check_Empty ();
    }

    #region Auto
   [SerializeField]
   Button Auto_But;

    public void On_Auto () {
        Auto_But.gameObject.SetActive (true);
    }

    public void Off_Auto () {
        Auto_But.gameObject.SetActive (false);
    }

    
    public void Cli_Auto () {
        if (Code_Item == "Health_Potion") {
            Tower_Infinity_Manager.Ins.On_Disable_Auto_Hp_Potion ();
        }
        if (Code_Item == "Mana_Potion") {
            Tower_Infinity_Manager.Ins.On_Disable_Auto_Mp_Potion ();
        }
    }
    
    // Player_AI_Use_Item :
    public void Cli_Item () {
        if (b_Can_Click_Skill) {
            b_Can_Click_Skill = false;
            
            if (Code_Item == "Health_Potion") {
                // Save_Inventory :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
                Dont_Destroy_On_Load.Ins._Data_Online.On_Change_Code_Loading ("Disable_Item");
            // Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Hair_Type, "Hair_Type", "1");
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Health_Potion", "Item", "-1");
                Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Disable_Item");
                // END
            }
            if (Code_Item == "Mana_Potion") {
                // Save_Inventory :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();
                // supaya tidak muncul tombol claim :
                Dont_Destroy_On_Load.Ins._Data_Online.On_Change_Code_Loading ("Disable_Item");
            // Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (CS_Hair_Type, "Hair_Type", "1");
                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Mana_Potion", "Item", "-1");
                Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Disable_Item");
                // END
            }

            Cur_Item--;

            Refresh_Cur_Item ();
            _Skill_Data_Kumpulan._Skill_Data_Editor.On_Play_Skill (_Player_2d, _Skill_Data_Kumpulan);
            On_Count_Cd_Time ();
        }
    }

    public void On_Input_Data (Player_2d P2_v) {
        _Player_2d = P2_v;
    }
   #endregion
   #region Cd_Time
   bool b_Can_Click_Skill = true;

   [SerializeField]
   Image Black_Locked;
   [SerializeField]
   TMP_Text Cd_Time_Tx;
   [SerializeField]
   int Cur_Cd_Time;
   [SerializeField]
   int Max_Cd_Time;

   void On_Count_Cd_Time () {
      Cur_Cd_Time = Max_Cd_Time;
      Cd_Time_Tx.text = Cur_Cd_Time.ToString ();
      Cd_Time_Tx.gameObject.SetActive (true);
      Black_Locked.gameObject.SetActive (true);
      StartCoroutine (N_On_Count_Cd_Time ());
   }

   IEnumerator N_On_Count_Cd_Time () {
      Cur_Cd_Time --;
      yield return new WaitForSeconds (1);
      Cd_Time_Tx.text = Cur_Cd_Time.ToString ();
      if (Cur_Cd_Time > 0) {
         StartCoroutine (N_On_Count_Cd_Time ());
      } else {
         Finish_Count_Cd_Time ();
      }
   }
   void Finish_Count_Cd_Time () {
      Cd_Time_Tx.gameObject.SetActive (false);
      Black_Locked.gameObject.SetActive (false);
      b_Can_Click_Skill = true;
   }

   #endregion
   #region Empty
    [SerializeField]
    Image Black_Empty;

    void On_Check_Empty () {
        if (Cur_Item >0) {
            Black_Empty.gameObject.SetActive (false);
        } else {
            Black_Empty.gameObject.SetActive (true);
        }
    }
   #endregion
}
