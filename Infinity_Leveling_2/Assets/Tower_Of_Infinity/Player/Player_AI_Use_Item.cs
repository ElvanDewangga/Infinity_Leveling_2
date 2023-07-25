using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI_Use_Item : MonoBehaviour {
    [SerializeField]
    Player_AI_Utama _Player_AI_Utama;

    #region Hp_Potion
    bool b_Auto_Hp_Potion = false;
    int Target_Below_Hp_Potion = 0;
    // Tower_Infinity_Manager :
    public void On_Auto_Hp_Potion (int v) {
        b_Auto_Hp_Potion = true;
        Target_Below_Hp_Potion = v;
        On_Check_Use_Hp_Potion ();
    }

    public void Off_Auto_Hp_Potion () {
        b_Auto_Hp_Potion = false;
        Target_Below_Hp_Potion = 0;
    }

    // Changed_Value : Online_Player_Status
    public void On_Check_Use_Hp_Potion () {
        if (b_Auto_Hp_Potion) {
            if (_Player_AI_Utama._Player_2d._Online_Player_Status.GMP_C_Home_Status.Hp <= (_Player_AI_Utama._Player_2d._Online_Player_Status._C_Home_Status.Hp*Target_Below_Hp_Potion/100)) {
                Tower_Infinity_Manager.Ins.Auto_Hp_Potion_Button.Cli_Item ();
                Debug.LogError ("Use Hp Auto");
            }
        }
    }
    #endregion
    #region Mp_Potion
    bool b_Auto_Mp_Potion = false;
    int Target_Below_Mp_Potion = 0;
    // Tower_Infinity_Manager :
    public void On_Auto_Mp_Potion (int v) {
        b_Auto_Mp_Potion = true;
        Target_Below_Mp_Potion = v;
        On_Check_Use_Mp_Potion ();
    }

    public void Off_Auto_Mp_Potion () {
        b_Auto_Mp_Potion = false;
        Target_Below_Mp_Potion = 0;
    }

    // Changed_Value : Online_Player_Status
    public void On_Check_Use_Mp_Potion () {
        if (b_Auto_Mp_Potion) {
            if (_Player_AI_Utama._Player_2d._Online_Player_Status.GMP_C_Home_Status.Mp <= (_Player_AI_Utama._Player_2d._Online_Player_Status._C_Home_Status.Mp*Target_Below_Mp_Potion/100)) {
                Tower_Infinity_Manager.Ins.Auto_Mp_Potion_Button.Cli_Item ();
            }
        }
    }
    #endregion
}
