using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Syarat_Cd_Time : MonoBehaviour {
    public bool b_Sub_Syarat = true;
    [SerializeField]
    Skill_Syarat_Keseluruhan_AI _Skill_Syarat_Keseluruhan_AI;
    [SerializeField]
    Skill_Cd_Time  _Skill_Cd_Time;

    #region Cd_Time
   [SerializeField]
   int Cur_Cd_Time;
    // Skill_Syarat_Keseluruhan_AI
   public void On_Count_Cd_Time () {
      b_Sub_Syarat = false;
      Cur_Cd_Time = _Skill_Cd_Time.Cd_Time;
      StartCoroutine (N_On_Count_Cd_Time ());
   }

   IEnumerator N_On_Count_Cd_Time () {
      Cur_Cd_Time --;
      yield return new WaitForSeconds (1);
      if (Cur_Cd_Time > 0) {
         StartCoroutine (N_On_Count_Cd_Time ());
      } else {
         Finish_Count_Cd_Time ();
      }
   }
   void Finish_Count_Cd_Time () {
      b_Sub_Syarat = true;
      _Skill_Syarat_Keseluruhan_AI.On_Skill_Syarat_AI_Collider_Check ();
   }

   #endregion
}
