using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Catch : MonoBehaviour {
    Enemy_AI_Control _Enemy_AI_Control;
    void Start () {
        _Enemy_AI_Control = this.gameObject.GetComponent <Enemy_AI_Control>();
        
    }

    // Enemy_AI_Jarak :
    public GameObject Target_Catch;
    
    int Jumlah_Player_Alive;
    void On_Search_Target_Catch () {
       C_N_On_Search_Target_Catch = StartCoroutine (N_On_Search_Target_Catch ());
    }

    void Off_Search_Target_Catch () {
        if (C_N_On_Search_Target_Catch != null) {
            StopCoroutine (C_N_On_Search_Target_Catch);
        }
        if (C_N_Enemy_AI_Doing != null) {StopCoroutine (C_N_Enemy_AI_Doing);}
    }

    void Doing_Search_Target_Catch () {
        Jumlah_Player_Alive = 0;
        foreach (Transform x in Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone) {
            if (x.gameObject.activeInHierarchy) {
                Jumlah_Player_Alive ++;
            }
        }
        
        Target_Catch = Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone.GetChild (Random.Range (0,Jumlah_Player_Alive)).gameObject;
    }
    
    Coroutine C_N_On_Search_Target_Catch;
    IEnumerator N_On_Search_Target_Catch () {
        Doing_Search_Target_Catch ();
        yield return new WaitForSeconds ((Random.Range (Min_Time_Ganti_Target,Max_Time_Ganti_Target)/10));
        
        
        C_N_On_Search_Target_Catch = StartCoroutine (N_On_Search_Target_Catch ());
        
    }
    #region Pengaturan_AI
    [Header ("Pengaturan_AI")]
    [SerializeField]
    int Min_Time_AI_Doing = 45;
    [SerializeField]
    int Max_Time_AI_Doing = 100;
    [SerializeField]
    int Min_Time_Ganti_Target = 30;
    [SerializeField]
    int Max_Time_Ganti_Target = 80;
    [SerializeField]
    float Target_Jarak = 5.0f;
    [SerializeField]
    float Speed_AI = 5.0f;
    
    #endregion
    // Update is called once per frame
    void FixedUpdate() {
        if (b_On_Enemy_AI_Doing) {
            if (_Enemy_AI_Control._Enemy_2d_Online._PhotonView.IsMine) {
                if (Target_Catch != null) {
                    if (_Enemy_AI_Control.b_Enemy_AI_Jarak) {
                        if (Vector3.Distance (_Enemy_AI_Control._Enemy_AI_Jarak.gameObject.transform.position, Target_Catch.transform.position ) < Target_Jarak || _Enemy_AI_Control.b_Enemy_AI_Jarak_Stop || _Enemy_AI_Control.b_Enemy_On_Spawn || _Enemy_AI_Control._Enemy_2d._Pendukung_Enemy._Enemy_Fallback.b_Enemy_Fallback) {
                        _Enemy_AI_Control.On_Change_Enemy_AI_Movement ("Enemy_AI_Idle");
                        } else {
                            if (_Enemy_AI_Control._Enemy_2d.b_Can_Move) {
                                /*
                                _Enemy_AI_Control.Enemy_2d_GO.transform.position = Vector3.Slerp (_Enemy_AI_Control.Enemy_2d_GO.transform.position, Target_Catch.transform.position, Speed_AI * Time.fixedDeltaTime);
                                */
                                //Flip :
                                if (_Enemy_AI_Control._Enemy_AI_Jarak.gameObject.transform.position.x >= Target_Catch.transform.position.x) {
                                    if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Left") {
                                        _Enemy_AI_Control._Enemy_2d.On_Flip ("Left");
                                    }
                                } else  {
                                    if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Right") {
                                        _Enemy_AI_Control._Enemy_2d.On_Flip ("Right");
                                    }
                                }
                                
                                MoveTowardsTarget (Target_Catch.transform.position);
                            } else {
                                
                            }
                        }
                    } else if (!_Enemy_AI_Control.b_Enemy_AI_Jarak) {
                        if (Vector3.Distance (_Enemy_AI_Control.Enemy_2d_GO.transform.position, Target_Catch.transform.position ) < Target_Jarak || _Enemy_AI_Control.b_Enemy_AI_Jarak_Stop || _Enemy_AI_Control.b_Enemy_On_Spawn  || _Enemy_AI_Control._Enemy_2d._Pendukung_Enemy._Enemy_Fallback.b_Enemy_Fallback) {
                            _Enemy_AI_Control.On_Change_Enemy_AI_Movement ("Enemy_AI_Idle");
                        } else {
                            if (_Enemy_AI_Control._Enemy_2d.b_Can_Move) {
                                /*
                                _Enemy_AI_Control.Enemy_2d_GO.transform.position = Vector3.Slerp (_Enemy_AI_Control.Enemy_2d_GO.transform.position, Target_Catch.transform.position, Speed_AI * Time.fixedDeltaTime);
                                */
                                //Flip :
                                if (_Enemy_AI_Control.Enemy_2d_GO.transform.position.x >= Target_Catch.transform.position.x) {
                                    if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Left") {
                                        _Enemy_AI_Control._Enemy_2d.On_Flip ("Left");
                                    }
                                } else  {
                                    if (_Enemy_AI_Control._Enemy_2d.Cur_Flip != "Right") {
                                        _Enemy_AI_Control._Enemy_2d.On_Flip ("Right");
                                    }
                                }
                                
                                MoveTowardsTarget (Target_Catch.transform.position);
                            } else {
                                
                            }
                        }
                    }

                }
            }
        }
    }
    #region Enemy_AI_Doing
    bool b_On_Enemy_AI_Doing = false;
    // Enemy_AI_Control
    public void Turn_On_Enemy_AI_Doing (bool c) {
        b_On_Enemy_AI_Doing = c;
        if (b_On_Enemy_AI_Doing) {
            On_Search_Target_Catch ();
            C_N_Enemy_AI_Doing = StartCoroutine (N_Enemy_AI_Doing ());
        } else {
            Off_Search_Target_Catch ();
            if (C_N_Enemy_AI_Doing != null) {StopCoroutine (C_N_Enemy_AI_Doing);}
        }
    }

    Coroutine C_N_Enemy_AI_Doing;
    IEnumerator N_Enemy_AI_Doing () {
        yield return new WaitForSeconds ((Random.Range (Min_Time_AI_Doing,Max_Time_AI_Doing)/10));
        _Enemy_AI_Control.On_Random_Enemy_AI_Movement ();
    }
    #endregion
    #region Move_Towards
    Vector3 offset;
    void MoveTowardsTarget(Vector3 target) {
       //  var offset = target - _Enemy_AI_Control.Enemy_2d_GO.transform.position;
       if (_Enemy_AI_Control.b_Enemy_AI_Jarak) {
            offset = target - _Enemy_AI_Control._Enemy_AI_Jarak.gameObject.transform.position;
       } else if (!_Enemy_AI_Control.b_Enemy_AI_Jarak) {
            offset = target - _Enemy_AI_Control.Enemy_2d_GO.transform.position;
       }
        //Get the difference.
        if(offset.magnitude > .1f) {
        //If we're further away than .1 unit, move towards the target.
        //The minimum allowable tolerance varies with the speed of the object and the framerate. 
        // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
            offset = offset.normalized * Speed_AI;
            //normalize it and account for movement speed.
            _Enemy_AI_Control._CC.Move(offset * Time.fixedDeltaTime);
            //actually move the character.
        }
    }
    #endregion
}
