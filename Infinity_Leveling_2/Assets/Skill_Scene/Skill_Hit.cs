using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Hit : MonoBehaviour {
    public string Code_Name = "";

    // Enemy_2d  / Online_Player_Status :
    public void On_Instantiate_Particle (Transform V) {
        GameObject Ins = GameObject.Instantiate (this.gameObject);
        Ins.transform.position = new Vector3 (V.position.x, V.position.y +0.2f, V.position.z);
        Ins.gameObject.SetActive (true);
        Ins.GetComponent <Skill_Hit> ().void_Destroy ();
    }
    
    // This (Instantiate).
    public void void_Destroy () {
        StartCoroutine (N_On_Destroy ());
    }
    IEnumerator N_On_Destroy () {
        yield return new WaitForSeconds (0.8f);
        Destroy (this.gameObject);
    }
}
