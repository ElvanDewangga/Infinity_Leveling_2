using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Loading_Text : MonoBehaviour {
   [SerializeField]
    string [] A_String;
    [SerializeField]
    TMP_Text _Text;
    float Time_Smooth = 0.5f;
    void OnEnable () {
        Debug.Log ("Enable");
        Cur_Sp = -1;
        C_N_Animation = StartCoroutine (N_Animation ());
    }

    Coroutine C_N_Animation;
    int Cur_Sp;

    IEnumerator N_Animation () {
        Cur_Sp ++;
        if (Cur_Sp >= A_String.Length) {
            Cur_Sp = 0;
        }
        yield return new WaitForSeconds (Time_Smooth);
        _Text.text = A_String[Cur_Sp];
        C_N_Animation = StartCoroutine (N_Animation ());
    }

    void OnDisable () {
        if (C_N_Animation != null) {StopCoroutine (C_N_Animation);}
    }
}
