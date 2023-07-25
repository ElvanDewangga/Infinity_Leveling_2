using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Notification_Canvas : MonoBehaviour {
    public static Notification_Canvas Ins;

    void Awake () {
        Ins = this;
    }

    void Start_Event_Button (string v) {
      if (v == "") {
        
      }
      if (v == "Reconnect_Launcher") {
      }
      if (v == "Reconnect_Pun") {
      }
      if (v == "Quit_Tower_Infinity") {
        Tower_Infinity_Manager.Ins.On_Quit ();
      }
      if (v == "Use_Item") {
        Item_Scene_Script.Ins.On_Call_Item_Configuration ("Use_Item");
      }
      Notification_2_Img.gameObject.SetActive (false);
    }
  // Notification_1
  [SerializeField]
  Image Notification_1_Img;
  [SerializeField]
  TMP_Text Notification_1_Title_Tx, Notification_1_Subtitle_Tx;
  [SerializeField]
  Button Notification_1_But;
  string Notification_1_Event;  
  public void On_Notification_1 (string Title_V, string Subtitle_V, string Sub_V, string Event_V) {
    Notification_1_Event = Event_V;
    Notification_1_But.gameObject.GetComponentInChildren <TMP_Text> ().text = Sub_V;
    Notification_1_Title_Tx.text = Title_V; Notification_1_Subtitle_Tx.text = Subtitle_V;
    Notification_1_Img.gameObject.SetActive (true);
  }

  public void Off_Notification_1 () {
    Notification_1_Img.gameObject.SetActive (false);
  }

  public void Cli_Notification_1 () {
     if (Notification_1_Event == "") {
        Off_Notification_1 ();
     }
  }

  [SerializeField]
  Image Notification_2_Img;
  [SerializeField]
  TMP_Text Notification_2_Title_Tx, Notification_2_Subtitle_Tx;
  [SerializeField]
  Button Notification_2_1_But, Notification_2_2_But;
  string Notification_2_1_Event, Notification_2_2_Event;  
  public void On_Notification_2 (string Title_V, string Subtitle_V, string Sub_2_1, string Sub_2_2, string Event_2_1, string Event_2_2) {
    Notification_2_1_But.gameObject.GetComponentInChildren <TMP_Text> ().text = Sub_2_1; Notification_2_2_But.gameObject.GetComponentInChildren <TMP_Text> ().text = Sub_2_2;
    Notification_2_1_Event = Event_2_1; Notification_2_2_Event = Event_2_2;
    Notification_2_Title_Tx.text = Title_V; Notification_2_Subtitle_Tx.text = Subtitle_V;
    Notification_2_Img.gameObject.SetActive (true);
  }

  public void Off_Notification_2 () {
    Notification_2_Img.gameObject.SetActive (false);
  }

  public void Cli_Notification_2_1 () {
    Start_Event_Button (Notification_2_1_Event);
  }

  public void Cli_Notification_2_2 () {
      Start_Event_Button (Notification_2_2_Event);
  }

}
