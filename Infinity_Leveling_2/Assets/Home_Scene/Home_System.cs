using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_System : MonoBehaviour {
    public static Home_System Ins;
    public GameObject All_Home_System_Go;
    public Home_Canvas _Home_Canvas;
    public Character_Selection _Character_Selection;
    public Hall_Of_Masters _Hall_Of_Masters;
    public Home_Status _Home_Status;
    public Tower_Infinity_Choose _Tower_Infinity_Choose;
    
    void Awake () {
        Ins = this;
    }
    
    #region Skill
    public Transform Editor_Skill_Active_Trans;
    public Transform Editor_Skill_Passive_Trans;
    public Transform Skill_Hit;
    #endregion
    
    
}
