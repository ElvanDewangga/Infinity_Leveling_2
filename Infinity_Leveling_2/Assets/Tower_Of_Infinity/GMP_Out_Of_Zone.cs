using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMP_Out_Of_Zone : MonoBehaviour {
    [SerializeField]
    string Code_GO = "Player";
    Player_2d _Player_2d;
    Enemy_2d _Enemy_2d;
    void Start () {
        if (Code_GO == "Enemy") {
            _Enemy_2d = GetComponent <Enemy_2d> ();
        } else if (Code_GO == "Player") {
            _Player_2d = GetComponent <Player_2d> ();
        }
    }
    void FixedUpdate () {
        if (GMP_Area_Generate.Ins) {
            if (GMP_Area_Generate.Ins.Cur_GMP_Square_Field) {
                if (!b_Teleport) {
                    if (transform.position.z > GMP_Area_Generate.Ins.Cur_GMP_Square_Field.GMP_Dinding_Up.transform.position.z) {
                        On_Teleport ("Up");
                    }
                    if (transform.position.z < GMP_Area_Generate.Ins.Cur_GMP_Square_Field.GMP_Dinding_Down.transform.position.z) {
                        On_Teleport ("Down");
                    }
                }
            }
        } 
    }

    #region On_Teleport
    bool b_Teleport = false;
    public void On_Teleport (string v) {
        b_Teleport = true;
        if (Code_GO == "Enemy") {
            _Enemy_2d._Enemy_AI_Control.On_b_Enemy_On_Spawn ();
        } else if (Code_GO == "Player") {
            _Player_2d.On_b_Can_Move ();
        }
       
        if (v == "Up") {
            transform.position = new Vector3(transform.position.x, transform.position.y, GMP_Area_Generate.Ins.Cur_GMP_Square_Field.GMP_Dinding_Up.transform.position.z -1.5f); 
        } else if (v == "Down") {
            transform.position = new Vector3(transform.position.x, transform.position.y, GMP_Area_Generate.Ins.Cur_GMP_Square_Field.GMP_Dinding_Down.transform.position.z +1.5f);
        }

        Invoke ("Off_Teleport", 0.1f);
    }

    

    void Off_Teleport () {
        if (Code_GO == "Enemy") {
            _Enemy_2d._Enemy_AI_Control.Off_b_Enemy_On_Spawn ();
        } else if (Code_GO == "Player") {
            _Player_2d.Off_b_Can_Move ();
        }
        
        b_Teleport = false;
    }
    #endregion
}
