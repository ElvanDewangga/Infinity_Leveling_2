using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fallback : MonoBehaviour {
    [SerializeField]
    Pendukung_Enemy _Pendukung_Enemy;
    // Enemy_AI_Catchzone & Enemy_AI_Mundur
    public bool b_Enemy_Fallback = false;
    void FixedUpdate () {
        if (b_Enemy_Fallback) {
            if (b_Increase) {
                if (Cur_Power < Max_Power) {
                    Cur_Power = Cur_Power * 1.50f;
                } else {
                    Cur_Power = Max_Power;
                    b_Increase = false;
                }
            } else {
                if (Cur_Power > 0.2f) {
                    Cur_Power = Cur_Power * 0.75f;
                } else  {
                    b_Enemy_Fallback = false;
                }
            }
            MoveTowardsTarget (Target);
        }
    }

    float Cur_Power = 0.0f;
    bool b_Increase = false;
    float Max_Power;
    Vector3 Target;
    float Increase_Power;
    float Decrease_Power;
   // Enemy_2d :
   public void On_Enemy_Fallback (Vector3 Str, float Max_Power_V, float Increase_Power_V, float Decrease_Power_V) {
    _Pendukung_Enemy._Enemy_2d._Enemy_AI_Control.On_Stop_All_Doing ("Enemy_AI_Idle", 1.0f);
    b_Increase = true;
    b_Enemy_Fallback = true;
    Target = Str;
    Max_Power = Max_Power_V; 
    Cur_Power = Increase_Power_V;
    Decrease_Power = Decrease_Power_V;

   } 

    #region Move_Towards
    Vector3 offset;
    void MoveTowardsTarget(Vector3 target) {
        Debug.Log ("Knockback");
       //  var offset = target - _Enemy_AI_Control.Enemy_2d_GO.transform.position;
            offset = new Vector3 (target.x, target.y, _Pendukung_Enemy._Enemy_2d.gameObject.transform.position.z) - _Pendukung_Enemy._Enemy_2d.gameObject.transform.position;
       
        //Get the difference.
       // if(offset.magnitude > .1f) { 
        //If we're further away than .1 unit, move towards the target.
        //The minimum allowable tolerance varies with the speed of the object and the framerate. 
        // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
            offset = offset.normalized * Cur_Power;
            //normalize it and account for movement speed.
            _Pendukung_Enemy._Enemy_2d._Enemy_AI_Control._CC.Move(offset * Time.fixedDeltaTime * -1);
            //actually move the character.
      //  }
    }
    #endregion
}
