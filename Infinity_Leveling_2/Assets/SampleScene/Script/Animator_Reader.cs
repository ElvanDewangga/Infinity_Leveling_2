using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Reader : MonoBehaviour{
    Animation _Animation;
    // Start is called before the first frame update
    void Start(){
         _Animation = this.GetComponent <Animation> ();
    }

    void OnEnable () {
        _Animation.Play ();
    }

    void OnDisable () {
        _Animation.Stop ();
    }

}
