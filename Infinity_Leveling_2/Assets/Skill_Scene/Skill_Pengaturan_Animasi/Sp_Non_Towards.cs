using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Non_Towards : MonoBehaviour {
    #region Towards
    [SerializeField]
    bool b_Use_Towards = false;
    [SerializeField]
    Transform Towards;
    [SerializeField]
    float Spd;

    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi; 

    void Start () {
            _Skill_Pengaturan_Animasi = this.gameObject.transform.parent.gameObject.GetComponent <Skill_Pengaturan_Animasi> ();
    }
    void FixedUpdate () {
        if (b_Use_Towards) {
            if (Towards) {
                transform.position = Vector3.MoveTowards (transform.position, Towards.position, Spd * Time.fixedDeltaTime);
            }
        }
     
    }

    #endregion
    #region Follow_Target
    
    #endregion
}
