using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Camera_Sementara : MonoBehaviour {
    [SerializeField]
    CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    // CinemachineTransposer Ct;
    [SerializeField]
    Vector3 bla;
    [SerializeField]
    float Selisih_Target = 1.0f;
    [SerializeField]
    float Min_X, Max_X;
    void Start(){
        bla = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset; 
    }

    void FixedUpdate () {
        if (b_Event_When_Camera_Reach_Target) {
            Min_X = Target_Follow.transform.position.x + bla.x - Selisih_Target;
            Max_X = Target_Follow.transform.position.x + bla.x + Selisih_Target;
            if (this.transform.position.x  >= Min_X && this.transform.position.x <= Max_X) {
                On_Doing_Event_When_Camera_Reach_Target ();
            }
        }
    }

    bool b_Event_When_Camera_Reach_Target = false;
    // Online_Tower_Infinity_Room "Portal" :
    public void On_Event_When_Camera_Reach_Target () {
        b_Event_When_Camera_Reach_Target = true;
    }

    void On_Doing_Event_When_Camera_Reach_Target () {
        b_Event_When_Camera_Reach_Target = false;
        Loading_Canvas.Ins.Off_Loading_2 ();
    }

    Transform Target_Follow;
    // Tower_Infinity_Manager :
    public void On_Change_Target_Follow (Transform x) {
        Target_Follow = x;
    }
}
