using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Starsky;
public class Tower_Infinity_Choose : MonoBehaviour {
    [SerializeField]
    Canvas Tower_Infinity_Choose_Canvas;
    
    public void Cli_Tower_Infinity_Choose () {
        On_Tower_Infinity_Choose ();
    }
    
    void On_Tower_Infinity_Choose () {
        Tower_Infinity_Choose_Canvas.gameObject.SetActive (true);
    }

    void Off_Tower_Infinity_Choose () {
        Tower_Infinity_Choose_Canvas.gameObject.SetActive (false);
    }

    public void Cli_Close_Tower_Infinity_Choose () {
        Off_Tower_Infinity_Choose ();
    }
    #region Quick_Join
    public void Cli_Quick_Join () {
        Data_Online Your_Data = Dont_Destroy_On_Load.Ins._Data_Online;
        Off_Tower_Infinity_Choose ();
        Online_Launcher_Photon.Ins.OnQuickJoinRoom (Your_Data._Player_Status.Guest_Id, Your_Data._Player_Status.Nickname);
    }

    #endregion
    #region Create_Room
    public void Cli_Create_Room () {
        Data_Online Your_Data = Dont_Destroy_On_Load.Ins._Data_Online;
        Online_Launcher_Photon.Ins.OnCreateRoom (Your_Data._Player_Status.Guest_Id, Your_Data._Player_Status.Nickname, "Tower_Infinity", 6);
        Off_Tower_Infinity_Choose ();
    }
    #endregion
    #region Tower_Infinity_To_Home
    // Online_Tower_Infinity_Room :
    public void On_Back_Tower_Infinity_To_Home () {
        Home_System.Ins.All_Home_System_Go.SetActive (true);
        Home_System.Ins._Home_Canvas.On_Start_Music ();
        Online_Launcher_Photon.Ins.On_Leave ();
        StartCoroutine (N_On_Back_Tower_Infinity_To_Home ());
    }

    IEnumerator N_On_Back_Tower_Infinity_To_Home () {
        AsyncOperation Ao = SceneManager.UnloadSceneAsync ("Tower_Of_Infinity_Scene");
        
        yield return new WaitUntil (() => Ao.isDone);
        
        Loading_Canvas.Ins.Off_Loading_2 ();
    }
    #endregion
}
