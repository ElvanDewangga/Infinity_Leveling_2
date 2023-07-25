using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Loading_Canvas : MonoBehaviour {
    
    public static Loading_Canvas Ins;

    void Awake () {
        Ins = this;
    }

    [SerializeField]
    Image Bg_Loading_1;
    public void On_Loading_1 () {
        Bg_Loading_1.gameObject.SetActive (true);
    }

    public void Off_Loading_1 () {
        Bg_Loading_1.gameObject.SetActive (false);
    }
    [SerializeField]
    Sprite [] A_Sp_Loading_2;
    [SerializeField]
    string [] A_Petunjuk_Loading_2;
    [SerializeField]
    Image [] A_Char_Loading_2;
    [SerializeField]
    Image Bg_Loading_2;
    [SerializeField]
    TMP_Text Loading_2_Petunjuk_Tx;
    public void On_Loading_2 () {
        int x = Random.Range (0, A_Petunjuk_Loading_2.Length);
        Bg_Loading_2.sprite = A_Sp_Loading_2[x];
        Loading_2_Petunjuk_Tx.text = A_Petunjuk_Loading_2[x];
        foreach (Image tu in A_Char_Loading_2) {
            tu.gameObject.SetActive (false);
        }
        A_Char_Loading_2[x].gameObject.SetActive (true);
        Bg_Loading_2.gameObject.SetActive (true);
        
    }

    public void Off_Loading_2 () {
        Bg_Loading_2.gameObject.SetActive (false);
    }

    [SerializeField]
    Image Bg_Loading_4;
    public void On_Loading_4 () {
        Bg_Loading_4.gameObject.SetActive (true);
    }

    public void Off_Loading_4 () {
        Bg_Loading_4.gameObject.SetActive (false);
    }

    [SerializeField]
    Image BG_Loading_3;
    int Cur_Loading_3, Max_Loading_3;
    string Event_Loading_3;
    string Connect_Loading = ""; // Ld_2
    public void On_Loading_3 (int Max_V, string Event_V, string Connect_Loading_V) {
        Debug.Log ("Loading_3");
        Cur_Loading_3 = 0;
        Max_Loading_3 = Max_V; Event_Loading_3 = Event_V;
        Connect_Loading = Connect_Loading_V;
        if (Connect_Loading == "") {
            BG_Loading_3.gameObject.SetActive (true);
        } else if (Connect_Loading == "Ld_2") {
            On_Loading_2 ();
        }
    }

    public void On_Increase_Loading_3 () {
        Cur_Loading_3 ++;
        if (Cur_Loading_3 >= Max_Loading_3) {
            Cur_Loading_3 = 0;
            Off_Increase_Loading_3 ();
        }
    }

    void Off_Increase_Loading_3 () {
        if (Connect_Loading == "") {
            BG_Loading_3.gameObject.SetActive (false);
        } else if (Connect_Loading == "Ld_2") {
            Off_Loading_2 ();
        }
        if(Event_Loading_3 == "") {

        } else if (Event_Loading_3 == "On_Finish_Load_Hall_Of_Masters") {
            Home_System.Ins._Hall_Of_Masters.On_Finish_Load_Hall_Of_Masters ();
        }
         Event_Loading_3 = ""; Connect_Loading = "";
    }/*
    [SerializeField]
    Image BG_Loading_4;
    int Cur_Loading_4, Max_Loading_4;
    string Event_Loading_4;
    public void On_Loading_4 (int Max_V, string Event_V) {
        Cur_Loading_4 = 0;
        Max_Loading_4 = Max_V; Event_Loading_4 = Event_V;
        BG_Loading_4.gameObject.SetActive (true);
    }

    public void On_Increase_Loading_4 () {
        Cur_Loading_4 ++;
        if (Cur_Loading_4 >= Max_Loading_4) {
            Cur_Loading_4 = 0;
            Off_Increase_Loading_4 ();
        }
    }

    void Off_Increase_Loading_4 () {
        BG_Loading_4.gameObject.SetActive (false);
        if(Event_Loading_4 == "") {

        } else if (Event_Loading_4 == "Online_Tower_Infinty_Success_Load") { // Online_Tower_Infinity_Room
            Home_System.Ins._Hall_Of_Masters.On_Finish_Load_Hall_Of_Masters ();
        }
    }
    */
}
