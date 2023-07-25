using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Manual : MonoBehaviour {
    Animator _Animator;
    void Start () {
        _Animator = this.GetComponent <Animator>();
    }

    public void On_Play () {
        _Animator.SetBool ("Enable", true);
    }
}
