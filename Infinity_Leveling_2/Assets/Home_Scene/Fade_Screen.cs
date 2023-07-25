using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Screen : MonoBehaviour {
    [SerializeField]
    float Time_Wait;
    void Start () {
        StartCoroutine (N_Start ());
    }

    IEnumerator N_Start () {
        yield return new WaitForSeconds (Time_Wait);
        this.gameObject.SetActive (false);
    }
}
