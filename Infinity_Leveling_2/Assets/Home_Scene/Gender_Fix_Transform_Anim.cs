using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender_Fix_Transform_Anim : MonoBehaviour {
    [SerializeField]
    GameObject Parent_GO;
    Player_2d _Player_2d;
    Enemy_2d _Enemy_2d;
    [SerializeField]
    bool b_Got_Parent = false;
    [SerializeField]
    string Parent_Cd = "";
    Vector3 Start_Pos = new Vector3 (0,0,0);
    void FixedUpdate () {
        if (!b_Got_Parent) {
            if (Parent_GO) {
                if (Parent_GO.tag == "Player") {
                    _Player_2d = Parent_GO.GetComponent <Player_2d> ();
                    b_Got_Parent = true;
                    Parent_Cd = "Player";
                } else if (Parent_GO.tag == "Enemy") {
                    _Enemy_2d = Parent_GO.GetComponent <Enemy_2d> ();
                    b_Got_Parent = true;
                    Parent_Cd = "Enemy";
                }
            }
        }

        //if (!b_On_Refresh) {
            if (Parent_Cd == "Player") {
                
              //  if (Start_Pos == new Vector3 (0,0,0)) {
                    Start_Pos =  _Player_2d.Cur_Gender_GO.transform.localPosition;
               // }
               // this.transform.localPosition = new Vector3 (Start_Pos.x * -1, Start_Pos.y*-1, Start_Pos.z *-1);
                _Player_2d.Cur_Gender_GO.transform.localPosition = new Vector3 (0,0,0);
                b_On_Refresh = true;
            } else if (Parent_Cd == "Enemy") {
              //  if (Start_Pos == new Vector3 (0,0,0)) {
                    Start_Pos =  _Enemy_2d.Enemy_Load_GO.transform.localPosition;
               // }
                //this.transform.localPosition = new Vector3 (Start_Pos.x * -1, Start_Pos.y*-1, Start_Pos.z *-1);
                _Player_2d.Cur_Gender_GO.transform.localPosition = new Vector3 (0,0,0);
                b_On_Refresh = true;
            }
        
        //}

    }
    [SerializeField]
    bool b_On_Refresh = false;
    // Not Use For little Time : Player_2d
    public void On_Refresh_Gender_Fix_Transform () {
        Start_Pos = new Vector3 (0,0,0);
        b_On_Refresh = false;
    }
}
