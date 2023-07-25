using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.SceneManagement;

public class Online_Launcher_Photon : MonoBehaviourPunCallbacks, ILobbyCallbacks {
   // Create_Category = "Tower_Infinity" / "Arena"
   string Create_Guest_Id, Create_Nickname, Create_Category; int Create_Max_Players; string Create_Room_Name;
   Online_Tower_Infinity_Room _Online_Tower_Infinity_Room;
   
   public const string Lobby_Key = "Key_1";
   string Launcher_Do = ""; // "Create" / "Join" / "Quick_Join"
   public static Online_Launcher_Photon Ins;
   void Awake () {
        Ins = this;
   } 

   // Online_Launcher_Photon - Online_Tower_Infinity_Room :
   public void On_Start_Online_Tower_Infinity_Room (Online_Tower_Infinity_Room xi) {
      if (Launcher_Do == "Create") {
         _Online_Tower_Infinity_Room = xi;
         _Online_Tower_Infinity_Room.OnCreateRoom (Create_Guest_Id,Create_Nickname,Create_Category,Create_Max_Players,Create_Room_Name,roomOptions);
      } else if (Launcher_Do == "Quick_Join" || Launcher_Do == "Join") {
         _Online_Tower_Infinity_Room = xi;
         _Online_Tower_Infinity_Room.OnJoinRoom (Create_Guest_Id,Create_Nickname,Create_Max_Players);
      }
   }

   // Tower_Infinity_Choose :
   public void OnCreateRoom (string Guess_Id_V, string Nickname_V, string Category, int Max_Players) {
        Loading_Canvas.Ins.On_Loading_2 ();
       Create_Guest_Id = Guess_Id_V; Create_Nickname = Nickname_V; Create_Category = Category; Create_Max_Players = Max_Players;
       On_Connect_Photon_Create ();
       // On_Start_Create ();
   }

    
   void Start () {
        PhotonNetwork.AutomaticallySyncScene = false;
      
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby ();
         Debug.Log ("Lobby Start");
   }

   public override void OnConnectedToMaster() {
         Debug.Log ("Join lobby");
    }
   

   void On_Connect_Photon_Create () {
        // PhotonNetwork.AutomaticallySyncScene = false;
      
        // PhotonNetwork.ConnectUsingSettings();
        // PhotonNetwork.JoinLobby ();

         On_Start_Create ();
   }

   RoomOptions roomOptions = new RoomOptions();
   void On_Start_Create () {
      if (!PhotonNetwork.IsConnected) {
         Loading_Canvas.Ins.Off_Loading_2 ();
         Notification_Canvas.Ins.On_Notification_2 ("Cannot Connect to Server", "Please check your connection, try to refresh the game & try again later.", "Cancel", "Confirm", "", "Reconnect_Launcher");
         // _Utama_Cvs._Loading.On_Disconnect ();
         return;
      }
      Launcher_Do = "Create";
		PhotonNetwork.GameVersion = "0";
      Create_Room_Name = "Room_" + Random.Range (100,100000);
	   roomOptions = new RoomOptions();
      roomOptions.IsVisible = true;
      roomOptions.IsOpen = true;
      roomOptions.MaxPlayers = (byte)Create_Max_Players;
      //  roomOptions.MaxPlayers = Create_Max_Players;
      
      PhotonNetwork.CreateRoom(Create_Room_Name, roomOptions, null);
      Debug.Log ("Create");
     SceneManager.LoadScene ("Tower_Of_Infinity_Scene", LoadSceneMode.Additive);
   }

   public override void OnRoomListUpdate(List<RoomInfo> infos)
    {
        Debug.Log("*** OnRoomListUpdate");
        Debug.Log("Room count: " + infos.Count); // XXX
        foreach (RoomInfo info in infos)
        {
            Debug.Log(info);
        }
    }
    // Tower_Infinity_Choose (Player_Invite) :
   public void OnJoinRoom (string Guess_Id_V, string Nickname_V, string Code_Room) {
      Loading_Canvas.Ins.On_Loading_2 ();
      Create_Guest_Id = Guess_Id_V;
      Create_Nickname = Nickname_V;
      PhotonNetwork.JoinRoom (Code_Room);
      Launcher_Do = "Join";
      
      SceneManager.LoadScene ("Tower_Of_Infinity_Scene",LoadSceneMode.Additive);
   }

   // Tower_Infinity_Choose (Quick_Join) : New
   public void OnQuickJoinRoom (string Guess_Id_V,string Nickname_V) {
      Loading_Canvas.Ins.On_Loading_2 ();
      Create_Guest_Id = Guess_Id_V;
      Create_Nickname = Nickname_V;
      Create_Max_Players = 6;
     // PhotonNetwork.JoinRoom (Code_Room);
      PhotonNetwork.JoinRandomRoom ();
      Launcher_Do = "Quick_Join";
      SceneManager.LoadScene ("Tower_Of_Infinity_Scene",LoadSceneMode.Additive);
      Debug.Log("Join");
   }
   // Online_Tower_Infinity_Room :
   public void OnPhotonJoinRoomFailed () {
      Loading_Canvas.Ins.On_Loading_2 ();
      Home_System.Ins._Tower_Infinity_Choose.On_Back_Tower_Infinity_To_Home ();
      Debug.LogError ("Failed");
      if (Launcher_Do == "Quick_Join") {
         Notification_Canvas.Ins.On_Notification_2 ("Notification", "There is no one room available. Try to create one.", "Cancel", "Confirm", "", "");
      } else if (Launcher_Do == "Join") {
         Notification_Canvas.Ins.On_Notification_2 ("Notification", "The room is full, cannot join.", "Cancel", "Confirm", "", "");
      }
   }
   // Tower_Infinity_Choose :
   public void On_Leave () {
      PhotonNetwork.LeaveRoom ();
      
   }

}
