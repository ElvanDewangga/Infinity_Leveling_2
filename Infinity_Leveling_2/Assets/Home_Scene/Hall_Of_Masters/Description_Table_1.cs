using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Description_Table_1 : MonoBehaviour {
   [SerializeField]
   TMP_Text Isi_Text;
  
   // Hall_Of_Masters :
   public void On_Chg_Text (string T) {
      Isi_Text.text = T;
   }

   public void Off_All_But () {
      Off_Active_But_1 (); Off_Active_But_2 ();
   }
   #region But_1
   [SerializeField]
   Button But_1;
   string But_1_Event;
   public void On_Active_But_1 (string Title, string Event) {
      But_1.gameObject.GetComponentInChildren <TMP_Text>().text = Title;
      But_1_Event = Event;
      But_1.gameObject.SetActive (true);
   }

   public void Off_Active_But_1 () {
      But_1.gameObject.GetComponentInChildren <TMP_Text>().text = "";
      But_1_Event = "";
      But_1.gameObject.SetActive (false);
   }

   public void Cli_But_1 () {
      On_Doing_Event (But_1_Event);
   }
   #endregion
   #region But_2
   [SerializeField]
   Button But_2;
   [SerializeField]
   TMP_Text But_2_Title_Tx, But_2_Price_Tx;
   int But_2_Price;
   string But_2_Event;
   // Hall_Of_Masters :
   public void On_Active_But_2 (string Title, int Price, string Event) {
      But_2_Title_Tx.text = Title; But_2_Price_Tx.text = Price.ToString ();
      But_2_Price = Price;
      But_2_Event = Event;
      But_2.gameObject.SetActive (true);
   }

   public void Off_Active_But_2 () {
      But_2_Event = "";
      But_2.gameObject.SetActive (false);
   }

   public void Cli_But_2 () {
      On_Doing_Event (But_2_Event);
   }
   #endregion
   #region Event
   void On_Doing_Event (string Event_V) {
      if (Event_V == "Select_This_Skill_Set") {
         Home_System.Ins._Hall_Of_Masters.On_Skill_Tab_2 ();
      } else if (Event_V == "Buying_With_Gold_Coin") {
         Off_All_But ();
         string [] Host_Server_Field = new string [8]; string [] Host_Server_Value = new string [8];
         Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
         Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "2";

         Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
         Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Gold_Coin";
         Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = But_2_Price.ToString ();

         Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = Home_System.Ins._Hall_Of_Masters.Cur_Hall_Of_Masters_Skill_Set._Hall_Of_Masters_Skill_Set.Load_Title;
         Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = Home_System.Ins._Hall_Of_Masters.Target_Price_Skill_1._Skill_Keterangan.Skill_Name;
         Debug.Log (Home_System.Ins._Hall_Of_Masters.Target_Price_Skill_1._Skill_Keterangan.Skill_Name);
         Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = "1";

         Dont_Destroy_On_Load.Ins._Data_Online.On_Local_Payment (Host_Server_Field, Host_Server_Value);
         // Home_System.Ins._Hall_Of_Masters.Target_Price_Skill_1 = null;
      } else if (Event_V == "Skill_Set_Up_Equip") {
         Off_All_But ();
         Home_System.Ins._Hall_Of_Masters.Skill_Set_Up_Equip ();
      }
      
   }
   #endregion
}
