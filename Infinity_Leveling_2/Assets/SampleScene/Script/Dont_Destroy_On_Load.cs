using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_On_Load : MonoBehaviour {

   public static Dont_Destroy_On_Load Ins;
    [HideInInspector]
   public Data_Online _Data_Online;
   [HideInInspector]
   public Data_Offline _Data_Offline;
   [HideInInspector]
   public Loading_Canvas _Loading_Canvas;
   [HideInInspector]
   public Notification_Canvas _Notification_Canvas;
   [HideInInspector]
   public System_Settings _System_Settings;
   [HideInInspector]
   public Submit_1_Parent _Submit_1_Parent;
   [HideInInspector]
   public Got_Item_1_Parent _Got_Item_1_Parent;
   [HideInInspector]
   public Select_1_Parent _Select_1_Parent;
   [HideInInspector] // Home_Scene :
   public Player_2d _Player_2d;

   void Awake () {
        Ins = this;
        _Data_Online = this.GetComponentInChildren <Data_Online>();
        _Data_Offline = this.GetComponentInChildren <Data_Offline> ();
        _Loading_Canvas = this.GetComponentInChildren <Loading_Canvas> ();
        _Notification_Canvas = this.GetComponentInChildren <Notification_Canvas> ();
        _System_Settings = this.GetComponentInChildren <System_Settings> ();
      _Submit_1_Parent = this.GetComponentInChildren <Submit_1_Parent> ();
      _Got_Item_1_Parent = this.GetComponentInChildren <Got_Item_1_Parent> ();
      _Select_1_Parent = this.GetComponentInChildren <Select_1_Parent> ();
        DontDestroyOnLoad (this.gameObject);
   }

}
