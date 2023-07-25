using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Starsky;
public class GMP_Skill_Button : MonoBehaviour {
   Button _Button;
   int Code_Urutan = 0; // 0 -3. Skill Active.
   bool b_Sample = true;
   void Start () {
        _Button = this.GetComponent <Button>();
        _Button.onClick.AddListener (Click_Skill);
   }

   #region Click_Skill
   bool b_Can_Click_Skill = false;
   // But :
   public void Click_Skill () {
       if (_Player_2d.b_Can_Skill && b_Memenuhi_Syarat) {
         if (!b_Skill_Hold_Time) {
            if (b_Can_Click_Skill) {
                Cur_Chance_Click --;
               if (Cur_Chance_Click <= 0) {
                  On_Remove_Auto_Skill ();
                  b_Can_Click_Skill = false;
                  On_Count_Cd_Time ();
               }
               _Skill_Data_Kumpulan._Skill_Data_Editor.On_Play_Skill (_Player_2d, _Skill_Data_Kumpulan);
            }
         }
         Tower_Infinity_Manager.Ins.On_Refresh_Syarat_Skill_Active ();
       }
   }
   #endregion
   #region Input_Data
   Skill_Data_Kumpulan _Skill_Data_Kumpulan;
   Player_2d _Player_2d;
   // Tower_Infinity_Manager
   public void On_Input_Data (Skill_Data_Kumpulan Sd, Player_2d P2_v) {
      _Skill_Data_Kumpulan = Sd; _Player_2d = P2_v;
      
      b_Skill_Hold_Time = _Skill_Data_Kumpulan._Skill_Data_Editor.b_Skill_Hold_Time;
      if (b_Skill_Hold_Time) {
         On_Input_Skill_Hold_Time (_Skill_Data_Kumpulan._Skill_Data_Editor._Skill_Hold_Time);
      }

      b_Skill_Multiple_Click = _Skill_Data_Kumpulan._Skill_Data_Editor.b_Skill_Multiple_Click;
      if (b_Skill_Multiple_Click) {
         On_Input_Skill_Multiple_Click (_Skill_Data_Kumpulan._Skill_Data_Editor._Skill_Multiple_Click);
      } else {
         Max_Chance_Click = 1;
         Cur_Chance_Click = Max_Chance_Click;
      }
      
      _Button = this.GetComponent <Button>();
      _Button.onClick.AddListener (Click_Skill);
      Cd_Time_Tx.gameObject.SetActive (false);
      b_Sample = false;
      b_Can_Click_Skill = true;
      if (Sd._Skill_Data_Editor.b_Skill_Cd_Time) {
         Max_Cd_Time = Sd._Skill_Data_Editor._Skill_Cd_Time.Cd_Time;
         _Button.image.sprite = Sd._Skill_Data_Editor.Skill_Sprite_Box;
      }
   }
   #endregion
   #region Cd_Time
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
      Refresh_Chance_Click ();
      On_Add_Auto_Skill ();
   }

   #endregion
   #region b_Skill_Hold_Time
   [HideInInspector]
   public bool b_Skill_Hold_Time = false;
   bool b_In_Hold =false;
   [SerializeField]
   float Cur_Hold_Time = 0.0f;
   float Max_Hold_Time = 0.0f;
   Skill_Hold_Time _Skill_Hold_Time;
   void On_Input_Skill_Hold_Time (Skill_Hold_Time Sh) {
      _Skill_Hold_Time = Sh;
      Max_Hold_Time = _Skill_Hold_Time.Max_Hold_Time;
      Cur_Hold_Time = Max_Hold_Time;
      On_Count_Hold_Time ();
   }

   public void Cli_Down () {
      if (_Player_2d.b_Can_Skill && b_Skill_Hold_Time && b_Memenuhi_Syarat) {
         if (!b_In_Hold) {
            if (b_Can_Click_Skill) {
               Debug.Log ("Down");
               b_In_Hold = true;
               _Skill_Data_Kumpulan._Skill_Data_Editor.On_Play_Skill (_Player_2d, _Skill_Data_Kumpulan);
               On_Remove_Auto_Skill ();
            }
         }
      }
   }

   public void Cli_Up () {
      if (b_In_Hold) {
            
            Debug.Log ("Up");
            _Skill_Data_Kumpulan._Skill_Data_Editor.On_Direct_Destroy ();
            b_In_Hold = false;
      }
   }

   void Hold_Times_Gone () {
      b_Can_Click_Skill = false;
      On_Count_Cd_Time ();
      Cli_Up ();
   }
   void On_Count_Hold_Time () {
     // this.gameObject.SetActive (true);
      StartCoroutine (N_On_Count_Hold_Time ());
   }

   IEnumerator N_On_Count_Hold_Time () {
      
      if (b_In_Hold) {
         if (Cur_Hold_Time >0) {
            Cur_Hold_Time -= 0.1f;
         } else {
            Hold_Times_Gone ();
         }
      } else {
         if (Cur_Hold_Time < Max_Hold_Time) {
            Cur_Hold_Time += 0.1f;
         } else {
            // Cli_Up ();
         }
      }

      yield return new WaitForSeconds (0.1f);
      StartCoroutine (N_On_Count_Hold_Time ());
   }
   #endregion
   #region b_Skill_Multiple_Click
   bool b_Skill_Multiple_Click = false;
   [SerializeField]
   int Cur_Chance_Click;
   int Max_Chance_Click;
   Skill_Multiple_Click _Skill_Multiple_Click;
   void On_Input_Skill_Multiple_Click (Skill_Multiple_Click Sh) {
      _Skill_Multiple_Click = Sh; 
      Max_Chance_Click = Sh.Chance_Click;
      Cur_Chance_Click = Sh.Chance_Click;
   }

   void Refresh_Chance_Click () {
      Cur_Chance_Click = Max_Chance_Click;
   }

   #endregion
   #region b_Tidak_Memenuhi_Syarat
   bool b_Memenuhi_Syarat = false;
   [SerializeField]
   Image b_Block_Memenuhi_Syarat;
      // Tower_Infinity_Manager :
      public void Check_b_Memenuhi_Syarat () {
         b_Memenuhi_Syarat = false;
         if(_Skill_Data_Kumpulan._Skill_Data_Editor._Skill_Pengaturan_Animasi.On_Check_Ability_Self(_Player_2d.gameObject, "Player")) {
            On_b_Memenuhi_Syarat ();
            
         } else {
            Off_b_Memenuhi_Syarat ();
         }

      }

      void On_b_Memenuhi_Syarat () {
         b_Memenuhi_Syarat = true;
         b_Block_Memenuhi_Syarat.gameObject.SetActive (false);
      }

      void Off_b_Memenuhi_Syarat () {
         Debug.Log (" Tidak Memenuhi SYarat");
         if (b_In_Hold) {Cli_Up ();}
         b_Memenuhi_Syarat = false;
         b_Block_Memenuhi_Syarat.gameObject.SetActive (true);
      }
   #endregion
   #region Auto
   bool b_Auto = false;
   [SerializeField]
   Button Auto_But;

   // Tower_Infinity_Manager :
   public void On_Auto_Skill () {
      b_Auto = true;
      Auto_But.gameObject.SetActive (true);
      On_Add_Auto_Skill ();
   }

   // Tower_Infinity_Manager :
   public void Off_Auto_Skill () {
      b_Auto = false;
      Auto_But.gameObject.SetActive (false);
      On_Remove_Auto_Skill ();
   }

   public void Cli_Auto_Skill () {
      Off_Auto_Skill ();
   }

   //  Cd_Time_Finish, On Auto
   void On_Add_Auto_Skill () {
      if (_Player_2d.b_Can_Skill && b_Memenuhi_Syarat) {
         // if (!b_Skill_Hold_Time) {
            if (b_Can_Click_Skill) {
               _Player_2d._Player_AI_Utama._Player_AI_Skill.On_Add_C_AI_Player_Skill (this);
            }
         // }
      } // Syaratnya sama kayak Click down.
   }

   // Pas sudah click, Off Auto
   void On_Remove_Auto_Skill () {
      _Player_2d._Player_AI_Utama._Player_AI_Skill.On_Remove_C_AI_Player_Skill (this);
   }
   #endregion
}
