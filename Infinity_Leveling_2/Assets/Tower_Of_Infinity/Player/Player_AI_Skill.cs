using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Player_AI_Skill : MonoBehaviour {
    [SerializeField]
    Player_AI_Utama _Player_AI_Utama;
    public List <GMP_Skill_Button> L_GMP_Skill_Button = new List <GMP_Skill_Button> ();
    bool b_Turn_On_AI_Skill = false;
    bool b_Doing_AI_Skill = false;
    // Tower_Infinity_Manager :
    public void On_Turn_AI_Skill (bool v) {
        b_Turn_On_AI_Skill = v;
        if (b_Turn_On_AI_Skill) {
            C_N_On_Check_Ada_Skill = StartCoroutine (N_On_Check_Ada_Skill ());
        } else {
            if (C_N_On_Check_Ada_Skill != null) {StopCoroutine (C_N_On_Check_Ada_Skill);}
        }
    }

    // GMP_Skill_Button :
    public void On_Add_C_AI_Player_Skill (GMP_Skill_Button GMP_Skill_Button_V) {
       
        if (!L_GMP_Skill_Button.Contains (GMP_Skill_Button_V)) {
            L_GMP_Skill_Button.Add (GMP_Skill_Button_V);
        }

       // On_Check_Ada_Skill ();
    }

    public void On_Remove_C_AI_Player_Skill (GMP_Skill_Button GMP_Skill_Button_V) {
       
        if (L_GMP_Skill_Button.Contains (GMP_Skill_Button_V)) {
            L_GMP_Skill_Button.Remove (GMP_Skill_Button_V);
        }
      // On_Check_Ada_Skill ();
    }
    // Player_2d - Player_AI_Utama :
    public void On_Finish_Use_Skill () {
        b_Doing_AI_Skill = false;
       // On_Check_Ada_Skill ();
    }
    Coroutine C_N_On_Check_Ada_Skill;
    IEnumerator N_On_Check_Ada_Skill () {
        yield return new WaitForSeconds (0.2f);
        yield return new WaitUntil (() => b_Doing_AI_Skill == false);
        if (L_GMP_Skill_Button.Count > 0) {
            _Player_AI_Utama.On_b_Player_AI_Skill ();
        } else {
            _Player_AI_Utama.Off_b_Player_AI_Skill ();
        }

        if (b_Turn_On_AI_Skill) {
            C_N_On_Check_Ada_Skill = StartCoroutine (N_On_Check_Ada_Skill ());
        } else {
           // if (C_N_On_Check_Ada_Skill != null) {StopCoroutine (C_N_On_Check_Ada_Skill);}
        }
    }

    #region Player_AI_Utama
    public void On_Mengeluarkan_Skill () {
         b_Doing_AI_Skill = true;
        int x = Random.Range (0,L_GMP_Skill_Button.Count);
        if (!L_GMP_Skill_Button[x].b_Skill_Hold_Time) {
            L_GMP_Skill_Button[x].Click_Skill ();
        } else {
            L_GMP_Skill_Button[x].Cli_Down ();
        }
    }
    #endregion
}
