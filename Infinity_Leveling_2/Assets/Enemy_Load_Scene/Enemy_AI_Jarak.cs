using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Jarak : MonoBehaviour {
   Enemy_AI_Control _Enemy_AI_Control;
   public bool b_Enemy_AI_Control = false; 
    List <GameObject> L_GameObject_Trigger = new List <GameObject>();
    void Start () {
        _Enemy_AI_Control = this.gameObject.transform.parent.gameObject.GetComponent <Enemy_AI_Control>();
        
    }

    void OnTriggerEnter (Collider Col) {
        _Enemy_AI_Control = this.gameObject.transform.parent.gameObject.GetComponent <Enemy_AI_Control>();
        if (!_Enemy_AI_Control.b_Enemy_AI_Jarak_Stop) {
            if (Col.gameObject.tag == "Player" || Col.gameObject.tag == "Enemy") {
                if (_Enemy_AI_Control._Enemy_AI_Catch.Target_Catch) {
                    if (_Enemy_AI_Control._Enemy_AI_Catch.Target_Catch == Col.gameObject) {
                        if (!L_GameObject_Trigger.Contains (Col.gameObject)) {
                            L_GameObject_Trigger.Add (Col.gameObject);
                        }
                        _Enemy_AI_Control.On_b_Enemy_AI_Jarak_Stop ();
                    }
                }
            } else if (Col.gameObject.tag == "Enemy") {
                if (_Enemy_AI_Control._Enemy_AI_Catch.Target_Catch) {
                        if (!L_GameObject_Trigger.Contains (Col.gameObject)) {
                            L_GameObject_Trigger.Add (Col.gameObject);
                        }
                        _Enemy_AI_Control.On_b_Enemy_AI_Jarak_Stop ();
                }
            }
        }
    }

    void OnTriggerExit (Collider Col) {
        _Enemy_AI_Control = this.gameObject.transform.parent.gameObject.GetComponent <Enemy_AI_Control>();
        if (_Enemy_AI_Control.b_Enemy_AI_Jarak_Stop) {
            if (Col.gameObject.tag == "Player") {
                if (_Enemy_AI_Control._Enemy_AI_Catch.Target_Catch) {
                    if (_Enemy_AI_Control._Enemy_AI_Catch.Target_Catch == Col.gameObject) {
                        if (L_GameObject_Trigger.Contains (Col.gameObject)) {
                            L_GameObject_Trigger.Remove (Col.gameObject);
                        }
                        if (L_GameObject_Trigger.Count == 0) {
                        _Enemy_AI_Control.Off_b_Enemy_AI_Jarak_Stop ();
                        }
                    }
                }
            } else if (Col.gameObject.tag == "Enemy") {
                if (_Enemy_AI_Control._Enemy_AI_Catch.Target_Catch == Col.gameObject) {
                    if (L_GameObject_Trigger.Contains (Col.gameObject)) {
                        L_GameObject_Trigger.Remove (Col.gameObject);
                    }
                    if (L_GameObject_Trigger.Count == 0) {
                        _Enemy_AI_Control.Off_b_Enemy_AI_Jarak_Stop ();
                    }
                }
            }
        }
    }
}
