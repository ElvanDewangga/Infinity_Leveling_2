using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Idle : MonoBehaviour {
    Enemy_AI_Control _Enemy_AI_Control;
    void Start () {
        _Enemy_AI_Control = this.gameObject.GetComponent <Enemy_AI_Control>();
        
    }
    
    #region Pengaturan_AI
    [SerializeField]
    int Min_Time_AI_Doing = 15;
    [SerializeField]
    int Max_Time_AI_Doing = 35;
    #endregion

    #region Enemy_AI_Doing
    bool b_On_Enemy_AI_Doing = false;
    // Enemy_AI_Control
    public void Turn_On_Enemy_AI_Doing (bool c) {
        b_On_Enemy_AI_Doing = c;
        if (b_On_Enemy_AI_Doing) {
           // On_Search_Target_Catch ();
            C_N_Enemy_AI_Doing = StartCoroutine (N_Enemy_AI_Doing ());
        } else {
          //  Off_Search_Target_Catch ();
          if (C_N_Enemy_AI_Doing !=null) {
            StopCoroutine (C_N_Enemy_AI_Doing);
          }
        }
    }

    Coroutine C_N_Enemy_AI_Doing;
    IEnumerator N_Enemy_AI_Doing () {
        yield return new WaitForSeconds ((Random.Range (Min_Time_AI_Doing,Max_Time_AI_Doing)/10));
        _Enemy_AI_Control.On_Random_Enemy_AI_Movement ();
    }
    #endregion
}
