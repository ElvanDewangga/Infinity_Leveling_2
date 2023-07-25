using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI_Utama : MonoBehaviour {
    public GameObject _Player_2d_GO;
    [HideInInspector]
    public Player_2d _Player_2d;
    public Player_AI_Skill _Player_AI_Skill;
    void Start () {
        _Player_2d = _Player_2d_GO.GetComponent <Player_2d>();
    }
    #region Player_AI_Doing
    bool b_AI_Doing = false;
    int Cur_Random_Doing_Something = 0; // 0-100.

    float Min_Random_Doing_Something = 0.0f;
     float Max_Random_Doing_Something = 0.0f;
    public void On_Start_AI () {
        b_AI_Doing = true;
    }

    void Off_Start_AI () {
        b_AI_Doing = false;
    }
    
    bool b_Random_Doing_Something = false;
    void On_Random_Doing_Something () { // Not Used for now.
        if (b_Force_Doing_Something) {
            Cur_Random_Doing_Something = Random.Range (0,100);
            if (Cur_Random_Doing_Something >= 0 && Cur_Random_Doing_Something <= 100) {
                if (b_Player_AI_Skill) {
                    
                } else {
                    C_N_Random_Doing_Something = StartCoroutine (N_Random_Doing_Something()); 
                }
            }
        }
    }
    Coroutine C_N_Random_Doing_Something;
    IEnumerator N_Random_Doing_Something () {
        yield return new WaitForSeconds (Random.Range (Min_Random_Doing_Something, Max_Random_Doing_Something));
        On_Random_Doing_Something ();
    }

    bool b_Force_Doing_Something = false;
    void On_Force_Doing_Something (string Event) {
        b_Force_Doing_Something = true;
        if (C_N_Random_Doing_Something != null) {StopCoroutine (C_N_Random_Doing_Something);}
        Off_Start_AI ();
        On_Do_Something (Event);
    }
    public void Off_Force_Doing_Something () {
        b_Force_Doing_Something = false;
    }

    void On_Do_Something (string Event_V) { 
        if (Event_V == "Force_Auto_Skill") {
            _Player_AI_Skill.On_Mengeluarkan_Skill ();
        } 
    }
    #endregion
    #region Player_AI_Skill
    bool b_Player_AI_Skill = false;
    /* Tiap ada Cd selesai atau auto on / Off maka akan dipanggil di Player_AI_SKill Add dan akan di On_b_Player_AI_Skill.

    */
    public void On_b_Player_AI_Skill () {
        b_Player_AI_Skill = true;
        On_Force_Doing_Something ("Force_Auto_Skill");
    }
    public void Off_b_Player_AI_Skill () {
        b_Player_AI_Skill = false;
    }
    // Player_2d:
    public void On_Finish_Use_Skill () {
        _Player_AI_Skill.On_Finish_Use_Skill ();
    }
    #endregion
    #region Player_AI_Use_Item
    public Player_AI_Use_Item _Player_AI_Use_Item;
    #endregion
}
