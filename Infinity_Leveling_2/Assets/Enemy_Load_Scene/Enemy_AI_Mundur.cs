using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Mundur : MonoBehaviour
{
    Enemy_AI_Control _Enemy_AI_Control;
    void Start () {
        _Enemy_AI_Control = this.gameObject.GetComponent <Enemy_AI_Control>();
        
    }

    void On_Doing_AI_Mundur () {
        //Flip :
        _Enemy_AI_Control = this.gameObject.GetComponent <Enemy_AI_Control>();
        if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Left") {
                _Enemy_AI_Control._Enemy_2d.On_Flip ("Left");
        }
        else if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Right") {
                _Enemy_AI_Control._Enemy_2d.On_Flip ("Right");
        }
    }
    #region Pengaturan_AI
    [SerializeField]
    int Min_Time_AI_Doing = 5;
    [SerializeField]
    int Max_Time_AI_Doing = 20;
    [Header ("Pengaturan_AI")]
   // [SerializeField]
   // float Target_Jarak = 5.0f;
    [SerializeField]
    float Speed_AI = 5.0f;
    #endregion
    
    // Update is called once per frame
    void FixedUpdate() {
        if (b_On_Enemy_AI_Doing) {
            if (_Enemy_AI_Control._Enemy_2d_Online._PhotonView.IsMine) {
                    // _Enemy_AI_Control.Enemy_2d_GO.transform.position = Vector3.Slerp (_Enemy_AI_Control.Enemy_2d_GO.transform.position, _Enemy_AI_Control._Enemy_2d.Posisi_Belakang.position, Speed_AI *5 * Time.fixedDeltaTime);
                        // Flip :
                        /*
                        if (_Enemy_AI_Control.Enemy_2d_GO.transform.position.x >= _Enemy_AI_Control._Enemy_2d.Posisi_Depan.position.x) {
                            if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Left") {
                                _Enemy_AI_Control._Enemy_2d.On_Flip ("Left");
                            }
                        } else  {
                            if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Right") {
                            _Enemy_AI_Control._Enemy_2d.On_Flip ("Right");
                            }
                        }
                        */
                        
                        MoveTowardsTarget (_Enemy_AI_Control._Enemy_2d.Posisi_Depan.position); // Posisi depan karena sudah diflip sekali
            }
        }
    }

    #region Enemy_AI_Doing
    bool b_On_Enemy_AI_Doing = false;
    // Enemy_AI_Control
    public void Turn_On_Enemy_AI_Doing (bool c) {
        b_On_Enemy_AI_Doing = c;
        if (b_On_Enemy_AI_Doing) {
            On_Doing_AI_Mundur ();
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
    #region Move_Towards
    void MoveTowardsTarget(Vector3 target) {
        var offset = target - _Enemy_AI_Control.Enemy_2d_GO.transform.position;
        //Get the difference.
        if(offset.magnitude > .1f) {
        //If we're further away than .1 unit, move towards the target.
        //The minimum allowable tolerance varies with the speed of the object and the framerate. 
        // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
            offset = offset.normalized * Speed_AI;
            
            //normalize it and account for movement speed.
            _Enemy_AI_Control._CC.Move(offset * Time.fixedDeltaTime);
            //actually move the character.
        } else {

        }
    }
    #endregion
}
