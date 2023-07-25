using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Child_Follow_Target : MonoBehaviour{
    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi;
    [SerializeField]
    Transform Target_Trans;
    [SerializeField]
    float Time_Delay = 0.0f;
    [SerializeField]
    float Time_Move = 0.88f;
    bool b_Move = false;
    Vector3 Velocity = Vector3.zero;
    void Start () {
        _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
        StartCoroutine (N_Start ());
    }

    IEnumerator N_Start () {
        yield return new WaitForSeconds (Time_Delay);
        b_Move = true;
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (b_Move) {
            transform.position = Vector3.SmoothDamp (this.gameObject.transform.position, Target_Trans.position, ref Velocity, Time_Move);     
        }
    }
}
