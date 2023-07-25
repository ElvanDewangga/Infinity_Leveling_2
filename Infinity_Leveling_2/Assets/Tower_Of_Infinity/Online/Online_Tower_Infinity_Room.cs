using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Starsky;
using System;
public class Online_Tower_Infinity_Room : MonoBehaviourPunCallbacks {
     string Room_Category;
     int Room_Max_Players; // Max room 6
     public int Room_Total_Players; // total player yang ada di room.
     string Room_Name = "";
    int Room_Cur_Players;

    public int Room_Your_Players;
    void On_Refresh_Room_Your_Players () {
        int xy = -1;
        foreach (GameObject Go in A_Clone_Player_2d) {
            xy++;
            if (Go.GetComponent<Online_Player_2d>().Is_Mine == true) {
                Room_Your_Players = xy;
                break;
            }
        }
    }

    [SerializeField]
    // Online_Player_Status :
    public GameObject [] A_Clone_Player_2d;
    // Online_Player_2d : Mine = On_Chg (), !Mine = Start.
    public void On_Set_A_Clone_Player_2d (int Target, GameObject Clone_Player_2d_V) {
        A_Clone_Player_2d [Target] = Clone_Player_2d_V;
    }
    // Tower_Infinity_Manager :
    [HideInInspector]
    public GameObject Mine_Player;
    [HideInInspector] // DualJoyStickPlayerController :
    public Player_2d Mine_Player_2d;
    PhotonView _PhotonView;
    public static Online_Tower_Infinity_Room Ins;
    void Awake () {
        Ins = this;
    }
    void Start () {
        // _Room_Manager = GameObject.Find ("Room_Manager").GetComponent <Room_Manager>();
        Tower_Infinity_Manager.Ins.Start_Hunt_Button.gameObject.SetActive (false);
        _PhotonView = GetComponent <PhotonView>();
        if (!_PhotonView.IsMine) {
            transform.SetParent (Tower_Infinity_Manager.Ins.Tower_Infinity_System_Go.transform);
        }
        StartCoroutine (N_Start ());
        
    }

    IEnumerator N_Start () {
        // Jeda Waktu Utk Konek : (Jika x ada maka error.)
        yield return new WaitForSeconds (4); //4
        Online_Launcher_Photon.Ins.On_Start_Online_Tower_Infinity_Room (this);
    }
   // Online_Launcher_Photon :
    public void OnCreateRoom (string Guess_Id_V, string Nickname_V, string Category, int Max_Players, string Create_Room_Name_V, RoomOptions s) {
        _RoomOptions = s;
        A_Clone_Player_2d = new GameObject [Max_Players];
        Room_Category = Category;
        Room_Max_Players = Max_Players;
        Room_Name = Create_Room_Name_V;  

        GameObject Cln = PhotonNetwork.Instantiate (Tower_Infinity_Manager.Ins.Player_2d_Sample.name,new Vector3 (0,0,0),Quaternion.Euler (0,0,0));
        Mine_Player = Cln;
        Mine_Player_2d = Mine_Player.GetComponent <Player_2d>();
        Tower_Infinity_Manager.Ins.On_Change_Follow_Cinemachine (Mine_Player_2d.transform);
        if (Cln == Mine_Player) {Cln.GetComponent <Player_2d> ().Is_Mine = true;}
       Cln.transform.SetParent (Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone);
        // Cln.GetComponent <Player_2d> (). On_Check_Player_Clone (); // x copy
        Cln.gameObject.SetActive (true);

        Home_System.Ins.All_Home_System_Go.gameObject.SetActive (false);

        Room_Cur_Players = -1;
        Room_Cur_Players ++;
        Room_Total_Players ++;
        Room_Your_Players = Room_Cur_Players;
        Cln.GetComponent<Online_Player_2d>().On_Chg (Room_Your_Players);
        if (PhotonNetwork.IsMasterClient) {
            Lc_Rpc_Player_Masuk (Room_Total_Players, true, Nickname_V,Room_Your_Players);
            _PhotonView.RPC ("Rpc_Room_Total_Players", RpcTarget.All, Room_Total_Players);
           //  _PhotonView.RPC ("Rpc_Player_Masuk",RpcTarget.All, Room_Total_Players, true, Nickname_V,Room_Your_Players);
           // _Photon_View.RPC ("Rpc_Inc_Room_Cur_Players",RpcTarget.All, Room_Cur_Players,Nickname_V);
        } else {
            Lc_Rpc_Player_Masuk (Room_Total_Players, true, Nickname_V,Room_Your_Players);
             _PhotonView.RPC ("Rpc_Room_Total_Players", RpcTarget.All, Room_Total_Players);
           // _PhotonView.RPC ("Rpc_Player_Masuk",RpcTarget.All, Room_Total_Players, false, Nickname_V,Room_Your_Players);
        }
        
        Tower_Infinity_Manager.Ins.On_Tower_Infinity_Canvas ();
        Loading_Canvas.Ins.Off_Loading_2 ();
        // _Room_Manager.On_Ref_Avatar ();
        
    }

    string Join_Nickname = "";
    Online_Player_2d Join_Photon;
    GameObject Join_Go;
    public void OnJoinRoom (string Guess_Id_V, string Nickname_V, int Max_Players_V) {
        Room_Max_Players = Max_Players_V;
        A_Clone_Player_2d = new GameObject [Room_Max_Players];
        try {
        Join_Nickname = Nickname_V;
        Join_Go = PhotonNetwork.Instantiate (Tower_Infinity_Manager.Ins.Player_2d_Sample.name, new Vector3 (0,0,0),Quaternion.Euler (0,0,0));
        Mine_Player = Join_Go;
        Mine_Player_2d = Mine_Player.GetComponent <Player_2d>();
        Tower_Infinity_Manager.Ins.On_Change_Follow_Cinemachine (Mine_Player_2d.transform);
        if (Join_Go == Mine_Player) {Join_Go.GetComponent <Player_2d> ().Is_Mine = true;}
        if (Join_Go == null) {
           // _Utama_Cvs._Loading.On_Room_Cvs ();
           //  return;
        }
        Join_Go.transform.SetParent (Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone);
        
        Join_Photon = Join_Go.GetComponent<Online_Player_2d>();
        StartCoroutine (N_On_Join_Room());
        } catch (NullReferenceException ex) {
            // Jika null maka room penuh / player gagal join :
            Online_Launcher_Photon.Ins.OnPhotonJoinRoomFailed ();
        }
    }

    IEnumerator N_On_Join_Room () {
       yield return new WaitUntil (() => b_MC_Kirim_All_Data_Karena_Player_Baru_Masuk == true);
       yield return new WaitForSeconds (0.5f);
        Join_Go.SetActive (true);
        //Room_Cur_Players ++;
        //Room_Your_Players = Room_Cur_Players;
        
        Home_System.Ins.All_Home_System_Go.gameObject.SetActive (false);
        Room_Total_Players ++;
        Room_Your_Players  =(Room_Total_Players-1);
        /*
        if (Room_Your_Players > Room_Max_Players-1) {
            _Utama_Cvs._Loading.On_Full_Room ();
            yield break;
        }
        */

        Join_Photon.On_Chg (Room_Your_Players);
        if (PhotonNetwork.IsMasterClient) {
            Lc_Rpc_Player_Masuk (Room_Total_Players, true, Join_Nickname,Room_Your_Players);
            _PhotonView.RPC ("Rpc_Room_Total_Players", RpcTarget.All, Room_Total_Players);
            // _PhotonView.RPC ("Rpc_Player_Masuk",RpcTarget.All, Room_Total_Players, true, Join_Nickname,Room_Your_Players);
        } else {
            Lc_Rpc_Player_Masuk (Room_Total_Players, false, Join_Nickname,Room_Your_Players);
            _PhotonView.RPC ("Rpc_Room_Total_Players", RpcTarget.All, Room_Total_Players);
        }
        
        Tower_Infinity_Manager.Ins.On_Tower_Infinity_Canvas ();
        Loading_Canvas.Ins.Off_Loading_2 ();
    }
    
    #region MC_Kirim_All_Data_Karena_Player_Baru_Masuk
    bool b_MC_Kirim_All_Data_Karena_Player_Baru_Masuk = false;
    //  Mine MC (muncul Clone !IsMine) : Online_Player_2d
    public void Lc_MC_Kirim_All_Data_Karena_Player_Baru_Masuk () {
        Tower_Infinity_Manager.Ins.Start_Hunt_Button.gameObject.SetActive (false);
        _PhotonView.RPC ("On_Total_Ready",RpcTarget.All, false, Total_Ready);
         _PhotonView.RPC ("Rpc_Room_Total_Players", RpcTarget.All, Room_Total_Players);
        StartCoroutine (N_Lc_MC_Kirim_All_Data_Karena_Player_Baru_Masuk ());
    }

    IEnumerator N_Lc_MC_Kirim_All_Data_Karena_Player_Baru_Masuk () {
        Cur_Button_Ins_Player_Masuk = 0;
        _PhotonView.RPC ("Rpc_On_Refresh_After_Kirim_All_Data",RpcTarget.All,Cur_Button_Ins_Player_Masuk);
        int y = 0;
        for (y=0; y <= L_C_Rpc_Player_Masuk.Count; y++) {
            yield return new WaitUntil (() => b_Cd_Rpc_Masuk == false);

            if (y < L_C_Rpc_Player_Masuk.Count) {
                b_Cd_Rpc_Masuk= true;
                Lc_Rpc_Player_Masuk (L_C_Rpc_Player_Masuk[y].Room_Total_Players, L_C_Rpc_Player_Masuk[y].MC_V, L_C_Rpc_Player_Masuk[y].Nickname_V,L_C_Rpc_Player_Masuk[y].Your_Players_V);
            } else {
                On_Refresh_All_Client_Rpc_Ready ();
                b_MC_Kirim_All_Data_Karena_Player_Baru_Masuk = true;
                _PhotonView.RPC ("Rpc_MC_Kirim_All_Data_Karena_Player_Baru_Masuk",RpcTarget.All, b_MC_Kirim_All_Data_Karena_Player_Baru_Masuk);
               // On_Refresh_After_Kirim_All_Data ();
            }
        }
    }

    [SerializeField]
    List <GameObject> L_Player_Clone;
    // Online_Player_2d
    public void Add_L_Player_Clone (GameObject Sb) {
        L_Player_Clone.Add (Sb);
       
    }
    // Online_Player_2d : On_Destroy (Clone)
    public void Remove_L_Player_Clone (GameObject Sb) {
        L_Player_Clone.Remove (Sb);
    }
    [PunRPC]
    public void Rpc_On_Refresh_After_Kirim_All_Data (int Cur_Button_Ins_Player_Masuk_V) { // me refesh ketika clone sudah dapat your players.
            Cur_Button_Ins_Player_Masuk = Cur_Button_Ins_Player_Masuk_V;
        // Refresh Urutan child sesuai Your_Players (Clone):
        On_Refresh_All_Players_Sibling ();
        
        

        
    }
    void On_Refresh_All_Players_Sibling () {
        // Refresh Urutan child sesuai Your_Players (Clone):
        foreach (Transform Trm in Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone) {
            Trm.gameObject.GetComponent <Online_Player_2d> ().On_Refresh_Sibling ();
        }
        // Refresh Urutan Array :
        int x = -1;
        
        foreach (Transform Trm in Tower_Infinity_Manager.Ins.A_Tower_Infinity_Clone) {
            x++;
            A_Clone_Player_2d [x] = Trm.gameObject;
            A_Clone_Player_2d[x].GetComponent<Online_Player_2d>().On_Refresh_Player_Status ();
        }

        
        // On_Set_A_Clone_Player_2d (Your_Players_V,L_Player_Clone[Your_Players_V]);
    }
    [PunRPC]
    public void Rpc_MC_Kirim_All_Data_Karena_Player_Baru_Masuk (bool V) {
        b_MC_Kirim_All_Data_Karena_Player_Baru_Masuk = V;
        
    }
   
    #endregion
    #region Room_Options
    private RoomOptions _RoomOptions = new RoomOptions ();
    
    [PunRPC]
    public void Rpc_Send_Room_Options (bool IsVisible, bool IsOpen, byte MaxPlayers) {
        _RoomOptions.IsVisible = IsVisible;
        _RoomOptions.IsOpen = IsOpen;
        _RoomOptions.MaxPlayers = MaxPlayers;
    }
    #endregion
    #region Room_Refresh
    [SerializeField]
    bool [] A_Room_Slot = new bool [6];
    // when someone left :
    void On_Room_Refresh () {
        On_Refresh_Player_Button ();
        On_Refresh_Player_MC ();
        On_Refresh_All_Players_Sibling ();
        On_Refresh_Room_Your_Players ();
    }

    void On_Refresh_Player_Button () {
        int x  = 0;
        for (x = 0; x < A_Room_Slot.Length; x++) {
            if(x < (A_Room_Slot.Length-1)) {
                if (A_Room_Slot[x] == false) {
                    int Slot_Yang_Ada_Player = On_Search_Player_Available_Button (x);
                    if (Slot_Yang_Ada_Player >-1) { // dpt player & pindahkan ke slot ini.
                        A_Clone_Player_2d[x] = A_Clone_Player_2d [Slot_Yang_Ada_Player];
                        A_Clone_Player_2d[Slot_Yang_Ada_Player] = null; //karena sudah pindah maka hilangkan.
                        A_Clone_Player_2d[x].GetComponent <Online_Player_2d>().On_Chg (x);
                        L_C_Rpc_Player_Masuk[x].Your_Players_V = x;
                        
                        A_Room_Slot[x] = true;
                        A_Room_Slot[Slot_Yang_Ada_Player] = false;
                    }   
                }
            
            } else { // slot terakhir :
                
            }
        }
    }

    void On_Refresh_Player_MC () {
        L_C_Rpc_Player_Masuk[0].MC_V = true;
        Tower_Infinity_Manager.Ins.On_Change_Player (L_C_Rpc_Player_Masuk[0].Your_Players_V, L_C_Rpc_Player_Masuk[0].MC_V, L_C_Rpc_Player_Masuk[0].Nickname_V, A_Clone_Player_2d [0]);
    }

    int On_Search_Player_Available_Button (int Slot_Mulai) { // dari 0 atau diatasnya / 2 diatasnya. NOTE : Lain kali sebaiknya pakai LIST<>(). karena pada saat diremove akan auto turun slotnya.
        int Result =-1;
        int yu = Slot_Mulai;
        for (yu = Slot_Mulai; yu < A_Room_Slot.Length; yu ++) {
            if(yu < (A_Room_Slot.Length-1)) {
                if (A_Room_Slot[yu] == true) {
                    Result = yu;
                    return Result;
                    break;
                }
            
            } else { // slot terakhir :
                Result = -1;
            }
        }
        return Result;
    }
    #endregion
    #region Disconnect
    [HideInInspector]
    public bool Cannot_Destroy = false;
    [HideInInspector]
    public bool Sub_MC = false;

    // Mine :
    public override void OnDisconnected(DisconnectCause cause) {
        Cannot_Destroy = true;
        Notification_Canvas.Ins.On_Notification_2 ("Disconnect", "Cannot connect to server.", "Cancel", "Confirm", "", "Reconnect_Pun");
        Loading_Canvas.Ins.Off_Loading_2 ();
        // Notification_Canvas.Ins.On_Notification_1 ("Disconnect", "Cannot connect to server.", "");
    }

    // ! Mine : Online_Player_2d
    public void On_Dc (int x) {
        Lc_Player_Keluar (x);
        /*
        if (PhotonNetwork.IsMasterClient && x != 0) { // menghindari double effect.
      
        } else if (Sub_MC == true) { // Sub_MC
            if (Room_Your_Players == 1) {
                if (x == 0) { // MC
                    
                     
                }
            }
        }
        */
    }
    // Tower_Infinity_Manager :
    public void Cli_Back_Home () {
        Loading_Canvas.Ins.On_Loading_2 ();
        Cannot_Destroy = true;
        Home_System.Ins._Tower_Infinity_Choose.On_Back_Tower_Infinity_To_Home ();
        //_Utama_Cvs._Loading.On_Loading ();
        //_Utama_Cvs.Room_Back_To_Menu ();
    }
    #endregion
    #region Room_RPC
    byte Loading_Room_Rpc = 0;
    string Last_Event_Loading_Room_Npc = "";
    // GMP_Area_Generate / GMP_Map_Settings :
    public void Increase_Loading_Room_Rpc (string Event_V) {
        _PhotonView.RPC ("Rpc_Loading_Room_Rpc", RpcTarget.All, Event_V);
    }

    [PunRPC]
    public void Rpc_Loading_Room_Rpc(string Event_V) {
        if (Last_Event_Loading_Room_Npc != "") {
            if (Last_Event_Loading_Room_Npc == Event_V) {
                Loading_Room_Rpc ++;
                Last_Event_Loading_Room_Npc = Event_V;
            } else {
                Debug.Log ("Ketinggalan Loading ! Lost Connection !");
            }
        } else {
            Loading_Room_Rpc ++;
        }
        
        if (Loading_Room_Rpc >= Room_Total_Players) {
            Loading_Room_Rpc = 0;
            if (Event_V == "Lc_All_Finish_Spawn") {
                Lc_All_Finish_Spawn (); 
            }
            if (Event_V == "Lc_All_Finish_Generate_Field_Data") {
                Lc_All_Finish_Generate_Field_Data (); 
            }
            
            if (Event_V == "On_MC_Finish_Generate_Byte_Data_2") {
                On_MC_Finish_Generate_Byte_Data_2 ();
            }
            Last_Event_Loading_Room_Npc = "";
           // C_N_On_Answer_Time = StartCoroutine (N_On_Answer_Time ());
        }
    }
    [PunRPC]
    public void Rpc_Room_Total_Players (int V) {
        Room_Total_Players = V;
        if (PhotonNetwork.IsMasterClient) {
            if (Room_Total_Players >= Room_Max_Players) {
                _RoomOptions.IsVisible = false;
                _RoomOptions.IsOpen = false;
                _PhotonView.RPC ("Rpc_Send_Room_Options",RpcTarget.All,_RoomOptions.IsVisible, _RoomOptions.IsOpen, _RoomOptions.MaxPlayers);
                
            }
        }
        Tower_Infinity_Manager.Ins.On_Number_Of_Players_Tx (Room_Total_Players);
    }
        #region Player_Masuk
        public class C_Rpc_Player_Masuk {
            public int Room_Total_Players;
            public bool MC_V;
            public string Nickname_V;
            public int Your_Players_V;
        }
        List <C_Rpc_Player_Masuk> L_C_Rpc_Player_Masuk = new List <C_Rpc_Player_Masuk>();
        void Add_C_Rpc_Player_Masuk (int Room_Total_Players_V, bool MC_V, string Nickname_V, int Your_Players_V) {
            if (Contains_C_Rpc_Player_Masuk(Your_Players_V) == false) {
                C_Rpc_Player_Masuk New = new C_Rpc_Player_Masuk ();
                New.Room_Total_Players = Room_Total_Players_V;
                New.MC_V = MC_V;
                New.Nickname_V = Nickname_V;
                New.Your_Players_V =Your_Players_V;

                L_C_Rpc_Player_Masuk.Add (New);
            }
        }

        bool Contains_C_Rpc_Player_Masuk (int Yp) {
            bool Result = false;
            foreach (C_Rpc_Player_Masuk xi in L_C_Rpc_Player_Masuk) {
                if (xi.Your_Players_V == Yp) {
                    Result = true;
                    return Result;
                    break;
                }
            }
            return Result;
        }   

        void Remove_C_Rpc_Player_Masuk (int Your_Players_V) {
            foreach (C_Rpc_Player_Masuk X in L_C_Rpc_Player_Masuk) {
                if (X.Your_Players_V == Your_Players_V) {
                    L_C_Rpc_Player_Masuk.Remove (X);
                    break;
                }
            }
        }
        // Respawn time (cannot use foreach)
        bool b_Cd_Rpc_Masuk = false;
        [PunRPC]
        public void Rpc_b_Cd_Rpc_Masuk (bool V) {
            b_Cd_Rpc_Masuk = V;
        }
        int Cur_Button_Ins_Player_Masuk =0;
        void Lc_Rpc_Player_Masuk (int Room_Total_Players_V, bool MC_V, string Nickname_V, int Your_Players_V) {
            
           // if (Cur_Button_Ins_Player_Masuk < Room_Total_Players) {
               Cur_Button_Ins_Player_Masuk ++;
                _PhotonView.RPC ("Rpc_Player_Masuk",RpcTarget.All,Cur_Button_Ins_Player_Masuk, Room_Total_Players_V, MC_V, Nickname_V,Your_Players_V);
                
           // }
        }
        
        [PunRPC]
        public void Rpc_Player_Masuk(int Cur_Button_Ins_Player_Masuk_V, int Room_Total_Players_V, bool MC_V, string Nickname_V, int Your_Players_V) { // x perlu rpc_loading karena backend loading. (loading di belakang layar)
            b_Cd_Rpc_Masuk = true;
            // Room_Total_Players = Room_Total_Players_V;
            Cur_Button_Ins_Player_Masuk = Cur_Button_Ins_Player_Masuk_V;
           // if ( Cur_Button_Ins_Player_Masuk > Tower_Infinity_Manager.Ins.Total_Button) {
            if (Contains_C_Rpc_Player_Masuk(Your_Players_V) == false) {
                Add_C_Rpc_Player_Masuk (Room_Total_Players_V, MC_V, Nickname_V, Your_Players_V);    
                // On_Refresh_All_Players_Sibling () Harus ada 2 supaya tidak bug.
                On_Refresh_All_Players_Sibling ();
                Tower_Infinity_Manager.Ins.On_Input_Player (MC_V, Nickname_V, A_Clone_Player_2d[Your_Players_V]);
                A_Room_Slot [Your_Players_V] = true;
                On_Refresh_All_Players_Sibling ();
                
            }
           // }
           
            b_Cd_Rpc_Masuk = false;
            _PhotonView.RPC ("Rpc_b_Cd_Rpc_Masuk",RpcTarget.All,b_Cd_Rpc_Masuk);
            
        }

        void Lc_Player_Keluar (int Your_Players_V) {
            if (Contains_C_Rpc_Player_Masuk(Your_Players_V) == true) {
                Remove_C_Rpc_Player_Masuk (Your_Players_V);    
                Tower_Infinity_Manager.Ins.On_Remove_Player (Your_Players_V);
                Room_Total_Players --;
                _PhotonView.RPC ("Rpc_Room_Total_Players", RpcTarget.All, Room_Total_Players);
                A_Room_Slot [Your_Players_V] = false;
            }
            On_Room_Refresh ();
        }

        #endregion
        #region Rpc_Ready
        [SerializeField]
        int Total_Ready = 0;
        // Tower_Infinity_Manager :
        public void Lc_On_Ready () {
            Total_Ready ++;
            _PhotonView.RPC ("On_Total_Ready",RpcTarget.All, true, Total_Ready);
            _PhotonView.RPC ("On_Rpc_Ready",RpcTarget.All, Room_Your_Players, true);
            
        }

        public void Lc_Off_Ready () {
             Total_Ready --;
            _PhotonView.RPC ("On_Total_Ready",RpcTarget.All, true, Total_Ready);
            _PhotonView.RPC ("On_Rpc_Ready",RpcTarget.All, Room_Your_Players, false);
        }

        [PunRPC]
        public void On_Rpc_Ready (int Your_Players_V, bool Ready_V) {
            Tower_Infinity_Manager.Ins.On_Input_Ready (A_Clone_Player_2d[Your_Players_V],Ready_V);
        
        }

        // MC = Mine (Muncul clone baru)
        void On_Refresh_All_Client_Rpc_Ready () {
            int y = -1;
            foreach (GameObject x in Tower_Infinity_Manager.Ins.L_Room_Players_Button) {
                y++;
                _PhotonView.RPC ("On_Rpc_Ready",RpcTarget.All, L_C_Rpc_Player_Masuk[y].Your_Players_V , Tower_Infinity_Manager.Ins.L_Room_Players_Button[y].GetComponent <Room_Players_Button>().b_Ready);
            } 
        }
        [PunRPC] 
        public void On_Total_Ready (bool Check_Ref_Hunt_V, int V) {
            Total_Ready = V;
            if (Check_Ref_Hunt_V) {
                
                if (Total_Ready >= Room_Total_Players) {
                    if (PhotonNetwork.IsMasterClient) {
                        Tower_Infinity_Manager.Ins.Start_Hunt_Button.gameObject.SetActive (true);
                    } 
                } else {
                    if (PhotonNetwork.IsMasterClient) {
                        Tower_Infinity_Manager.Ins.Start_Hunt_Button.gameObject.SetActive (false);
                    } 
                }
            }
        }

        #endregion
    #endregion
    
    #region Online_Player_Status
    // Online_Player_Status : when he finish load local status.
    
    public void Lc_Load_Player_Status (int Your_Players_V, Player_Status Ps) {
        Player_Status New_Ps = new Player_Status ();
        New_Ps = Ps;
         _PhotonView.RPC ("Rpc_Load_Player_Status",RpcTarget.All, Your_Players_V , New_Ps.Id, New_Ps.Guest_Id, New_Ps.Nickname, New_Ps.Token_Google, New_Ps.Accept_Privacy_Policy, New_Ps.Gender, New_Ps.Hair_Type, New_Ps.Face, New_Ps.Hair_Colour, New_Ps.Skin_Tone, New_Ps.Body_Costume, New_Ps.Helmet, New_Ps.Weapon, New_Ps.Ring, New_Ps.Earring, New_Ps.Offhand, New_Ps.Glove, New_Ps.Boot, New_Ps.Cape, New_Ps.Hair_Value_Colour, New_Ps.Hair_Value_Dark);
    }

    [PunRPC]
    public void Rpc_Load_Player_Status (int Your_Players_V, int Id, string Guest_Id, string Nickname, string Token_Google, int Accept_Privacy_Policy, string Gender, string Hair_Type, string Face, string Hair_Colour, string Skin_Tone, string Body_Costume, string Helmet, string Weapon, string Ring, string Earring, string Offhand, string Glove, string Boot, string Cape, int Hair_Value_Colour, int Hair_Value_Dark) {
        if (Your_Players_V > -1) {
        Online_Player_Status Op = A_Clone_Player_2d[Your_Players_V].GetComponent <Online_Player_Status> ();
        Op.On_Got_Local_Player_Status (Id, Guest_Id, Nickname, Token_Google, Accept_Privacy_Policy, Gender, Hair_Type, Face, Hair_Colour, Skin_Tone, Body_Costume, Helmet, Weapon, Ring, Earring, Offhand, Glove, Boot, Cape, Hair_Value_Colour, Hair_Value_Dark);
        }
    }
    #endregion
    #region Portal
        public int Cur_Enemy_Total = 0;
        // Enemy_2d_Online :
        public void MC_Lc_Increase_Total_Enemy () {
            Cur_Enemy_Total ++;
            _PhotonView.RPC ("Rpc_Cur_Enemy_Total", RpcTarget.All, Cur_Enemy_Total);
        }

        public void MC_Lc_Decrease_Total_Enemy () {
            Cur_Enemy_Total --;
            _PhotonView.RPC ("Rpc_Cur_Enemy_Total", RpcTarget.All, Cur_Enemy_Total);
        }
        
        [PunRPC]
        public void Rpc_Cur_Enemy_Total (int V) {
            Cur_Enemy_Total = V;
            if (Cur_Enemy_Total <= 0) {
                GMP_Area_Generate.Ins.On_Menyalakan_Portal ();
            }
        }

        // Portal_Script :
        public void Lc_On_GMP_Masuk_Field () {
            _PhotonView.RPC ("On_Rpc_GMP_Masuk_Field", RpcTarget.All);
        }

        [PunRPC]
        public void On_Rpc_GMP_Masuk_Field () {
            _PhotonView.RPC ("Rpc_Set_Spawn",RpcTarget.All, "Portal");
           
        }

        [PunRPC] // this
        public void On_Rpc_GMP_Masuk_Field_2 () {
            Tower_Infinity_Manager.Ins.On_Got_Exp (888);
             GMP_Area_Generate.Ins.On_GMP_Masuk_Field ();
        }
    #endregion

    #region GMP_Area_Generate
    // MC - Tower_Infinity_Manager :
    public void On_Start_Hunt () {
        _RoomOptions.IsVisible = false;
        _RoomOptions.IsOpen = false;
        
        _PhotonView.RPC ("Rpc_Send_Room_Options",RpcTarget.All,_RoomOptions.IsVisible, _RoomOptions.IsOpen, _RoomOptions.MaxPlayers);
        
        
        _PhotonView.RPC ("Rpc_Set_Spawn",RpcTarget.All, "Start_Hunt");
    }

    public string Spawn_From_Cd;
    [PunRPC]
    public void Rpc_Set_Spawn (string from) { // from = "Start_Hunt"/ "Portal"
        Spawn_From_Cd = from;
        StartCoroutine (N_Rpc_Set_Spawn ());
    }

    IEnumerator N_Rpc_Set_Spawn () {
        Loading_Canvas.Ins.On_Loading_2 ();
        yield return new WaitForSeconds (1.0f);
        Lc_Your_Player_2d_Spawn ();
    }

    void Lc_Your_Player_2d_Spawn () {
        int sp = -1;
        foreach (Transform Spawn in GMP_Area_Generate.Ins.A_Start_Spawn) {
            sp++;
            if (sp < Room_Total_Players) {
                GMP_Area_Generate.Ins.A_Start_Spawn[sp].GetComponent <Spawn_Area> ().On_Input_Player_Target (A_Clone_Player_2d[sp].gameObject);
                A_Clone_Player_2d[sp].gameObject.GetComponent <Online_Player_2d> ().On_Input_Target_Spawn (GMP_Area_Generate.Ins.A_Start_Spawn[sp]);
                
            }
        }
        GMP_Area_Generate.Ins.On_Start_Spawn (A_Clone_Player_2d[Room_Your_Players],Room_Your_Players);

    }

    // Use : Rpc_Loading_Room_Rpc ()
    void Lc_All_Finish_Spawn () {
        if (Spawn_From_Cd == "Start_Hunt") {
            // Tower_Infinity_Manager.Ins.On_Finish_Spawn ();
            if (PhotonNetwork.IsMasterClient) {
                On_Search_Player_Strongers_Hp ();
                On_MC_Create_Field ();
                
            }
        } else if (Spawn_From_Cd == "Portal") {
            
            _PhotonView.RPC ("On_Rpc_GMP_Masuk_Field_2",RpcTarget.All);
            Tower_Infinity_Manager.Ins._Camera_Sementara.On_Event_When_Camera_Reach_Target ();
            // Loading_Canvas.Ins.Off_Loading_2 (); // Camera_Sementara.
        }
    }

        #region GMP_Map_Settings
        
        // Field :
        void On_MC_Create_Field () {
            GMP_Area_Generate.Ins.Cur_GMP_Map_Settings.MC_Create_Field ();
        }
        // GMP_Map_Settings :
        // MC_Create_Generate_Byte_Data - Generate_Byte_Data - Rpc_Byte_Data - Process_Byte_Data - Finish_Loading.
        public void On_MC_Finish_Generate_Byte_Data () {
            // Send data to all players :
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            // Total_Room_In_Map :
            int xui = 0;
            for (xui=0; xui <= Map_Target.L_MC_C_Byte_Field.Count; xui++) {
                if (xui < Map_Target.L_MC_C_Byte_Field.Count) {
                    C_Byte_Field BD = Map_Target.L_MC_C_Byte_Field[xui];
                    _PhotonView.RPC ("On_Rpc_Total_Room_In_Map", RpcTarget.All, BD.Name_Texture, BD.Cd_Texture, BD.Pos_X, BD.Pos_Y, BD.Pos_Z, BD.Scale_X, BD.Scale_Y, BD.Scale_Z, BD.Name_Floor);
                } else { // List sudah habis :
                    _PhotonView.RPC ("On_Rpc_Proccess_Total_Room_In_Map", RpcTarget.All);
                    // Map_Target.On_Process_Room_In_Map (); 
                }
            }
            
            
            
            
        }

        // After all loading instiate room_enemy.
        void On_MC_Finish_Generate_Byte_Data_2 () {
            if (PhotonNetwork.IsMasterClient) {
                Debug.Log ("Call Master");
                 GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
                // Total_Enemy_Map :
                int x = 0;
                for (x=0; x <= Map_Target.L_MC_C_Byte_Enemy.Count; x++) {
                    if (x < Map_Target.L_MC_C_Byte_Enemy.Count) {
                        C_Byte_Enemy BD = Map_Target.L_MC_C_Byte_Enemy[x];
                        _PhotonView.RPC ("On_Rpc_Total_Enemy_Map", RpcTarget.All, BD.Code_Name, BD.Nickname, BD.Min_Power_Up, BD.Max_Power_Up, BD.Level, BD.Cur_Exp, BD.Rank, BD.Hp, BD.Mp, BD.Attack, BD.Defense, BD.Critical_Rate, BD.Critical_Damage, BD.Block_Chance, BD.Penetration, BD.Vitality, BD.Mind, BD.Strength, BD.Agility, BD.Element_Room, BD.Element_Spawn);
                    } else { // List sudah habis :
                        // Map_Target.On_Process_Enemy_In_Map ();
                        _PhotonView.RPC ("On_Rpc_Process_Total_Enemy_Map", RpcTarget.All);
                    }
                }

                // Total_Mini_Boss_Map :
                int xoa = 0;
                for (xoa=0; xoa <= Map_Target.L_MC_C_Byte_Mini_Boss.Count; xoa++) {
                    if (xoa < Map_Target.L_MC_C_Byte_Mini_Boss.Count) {

                        // L_Cur_C_Random_Boss_Skill :
                        int xoa3 = 0;
                        for (xoa3=0; xoa3 <= Map_Target.L_MC_C_Random_Mini_Boss_Skill.Count; xoa3++) {
                            if (xoa3 < Map_Target.L_MC_C_Random_Mini_Boss_Skill.Count) {
                                string Skill_Name = Map_Target.L_MC_C_Random_Mini_Boss_Skill[xoa3];
                                _PhotonView.RPC ("On_Rpc_Mini_Boss_Random_Skill", RpcTarget.All, Skill_Name);
                            } else { // List sudah habis :
                                // Map_Target.On_Process_Enemy_In_Map ();
                            // _PhotonView.RPC ("On_Rpc_Process_Total_Boss_Enemy_Map", RpcTarget.All);
                            }
                        }
                        // END
                        
                        C_Byte_Enemy BD = Map_Target.L_MC_C_Byte_Mini_Boss[xoa];
                        _PhotonView.RPC ("On_Rpc_Total_Mini_Boss_Map", RpcTarget.All, BD.Code_Name, BD.Nickname, BD.Min_Power_Up, BD.Max_Power_Up, BD.Level, BD.Cur_Exp, BD.Rank, BD.Hp, BD.Mp, BD.Attack, BD.Defense, BD.Critical_Rate, BD.Critical_Damage, BD.Block_Chance, BD.Penetration, BD.Vitality, BD.Mind, BD.Strength, BD.Agility, BD.Element_Room, BD.Element_Spawn);
                    } else { // List sudah habis :
                        // Map_Target.On_Process_Enemy_In_Map ();
                        _PhotonView.RPC ("On_Rpc_Process_Total_Mini_Boss_Map", RpcTarget.All);
                    }
                }

                // Total_Boss_Map :
                int xoa2 = 0;
                for (xoa2=0; xoa2 <= Map_Target.L_MC_C_Byte_Boss_Enemy.Count; xoa2++) {
                    if (xoa2 < Map_Target.L_MC_C_Byte_Boss_Enemy.Count) {

                        // L_Cur_C_Random_Boss_Skill :
                        int xoa3 = 0;
                        for (xoa3=0; xoa3 <= Map_Target.L_MC_C_Random_Boss_Skill.Count; xoa3++) {
                            if (xoa3 < Map_Target.L_MC_C_Random_Boss_Skill.Count) {
                                string Skill_Name = Map_Target.L_MC_C_Random_Boss_Skill[xoa3];
                                _PhotonView.RPC ("On_Rpc_Boss_Enemy_Random_Skill", RpcTarget.All, Skill_Name);
                            } else { // List sudah habis :
                                // Map_Target.On_Process_Enemy_In_Map ();
                            // _PhotonView.RPC ("On_Rpc_Process_Total_Boss_Enemy_Map", RpcTarget.All);
                            }
                        }
                        // END

                        C_Byte_Enemy BD = Map_Target.L_MC_C_Byte_Boss_Enemy[xoa2];
                        _PhotonView.RPC ("On_Rpc_Total_Boss_Enemy_Map", RpcTarget.All, BD.Code_Name, BD.Nickname, BD.Min_Power_Up, BD.Max_Power_Up, BD.Level, BD.Cur_Exp, BD.Rank, BD.Hp, BD.Mp, BD.Attack, BD.Defense, BD.Critical_Rate, BD.Critical_Damage, BD.Block_Chance, BD.Penetration, BD.Vitality, BD.Mind, BD.Strength, BD.Agility, BD.Element_Room, BD.Element_Spawn);
                    } else { // List sudah habis :
                        // Map_Target.On_Process_Enemy_In_Map ();
                        _PhotonView.RPC ("On_Rpc_Process_Total_Boss_Enemy_Map", RpcTarget.All);
                    }
                }
            }
        }

        

        #region Total_Room_In_Map
        [PunRPC]
        public void On_Rpc_Total_Room_In_Map (string Name_Texture, int Cd_Texture, float Pos_X, float Pos_Y, float Pos_Z, float Scale_X, float Scale_Y, float Scale_Z, string Name_Floor) {
            Debug.Log ("Call Master 0");
            C_Byte_Field New = new C_Byte_Field ();
            New.Name_Texture = Name_Texture;
            New.Cd_Texture = Cd_Texture;
            New.Pos_X = Pos_X; New.Pos_Y = Pos_Y; New.Pos_Z = Pos_Z;
            New.Scale_X = Scale_X; New.Scale_Y = Scale_Y; New.Scale_Z = Scale_Z;
            
            New.Name_Floor = Name_Floor;
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Add_L_Cur_C_Byte_Field (New);
        }

        [PunRPC]
        public void On_Rpc_Proccess_Total_Room_In_Map () {
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Process_Room_In_Map ();
        }

        
        #endregion
        #region Total_Enemy_Map
        [PunRPC]
        public void On_Rpc_Total_Enemy_Map (string Code_Name, string Nickname, int Min_Power_Up, int Max_Power_Up, int Level, int Cur_Exp, string Rank, int Hp, int Mp, int Attack, int Defense, int Critical_Rate, int Critical_Damage, int Block_Chance, int Penetration, int Vitality, int Mind, int Strength, int Agility, int Element_Room, int Element_Spawn) {
             C_Byte_Enemy New = new C_Byte_Enemy ();
            New.Code_Name = Code_Name;
            New.Nickname = Nickname;
            New.Min_Power_Up = Min_Power_Up;
            New.Max_Power_Up = Max_Power_Up;
            New.Level = Level;
            New.Cur_Exp = Cur_Exp;
            New.Rank = Rank;
            New.Hp = Hp;
            New.Mp = Mp;
            New.Attack = Attack;
            New.Defense = Defense;
            New.Critical_Rate = Critical_Rate;
            New.Critical_Damage = Critical_Damage;
            New.Block_Chance = Block_Chance;
            New.Penetration = Penetration;
            New.Vitality = Vitality;
            New.Mind = Mind;
            New.Strength = Strength;
            New.Agility = Agility;
            
            New.Element_Room = Element_Room;
            New.Element_Spawn = Element_Spawn;
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Add_L_Cur_C_Byte_Enemy (New);
        }

        [PunRPC]
        public void On_Rpc_Process_Total_Enemy_Map () {
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Process_Enemy_In_Map ();
        }

        #endregion
        #region Total_Mini_Boss_Map
        [PunRPC]
        public void On_Rpc_Total_Mini_Boss_Map (string Code_Name, string Nickname, int Min_Power_Up, int Max_Power_Up, int Level, int Cur_Exp, string Rank, int Hp, int Mp, int Attack, int Defense, int Critical_Rate, int Critical_Damage, int Block_Chance, int Penetration, int Vitality, int Mind, int Strength, int Agility, int Element_Room, int Element_Spawn) {
             C_Byte_Enemy New = new C_Byte_Enemy ();
            New.Code_Name = Code_Name;
            New.Nickname = Nickname;
            New.Min_Power_Up = Min_Power_Up;
            New.Max_Power_Up = Max_Power_Up;
            New.Level = Level;
            New.Cur_Exp = Cur_Exp;
            New.Rank = Rank;
            New.Hp = Hp;
            New.Mp = Mp;
            New.Attack = Attack;
            New.Defense = Defense;
            New.Critical_Rate = Critical_Rate;
            New.Critical_Damage = Critical_Damage;
            New.Block_Chance = Block_Chance;
            New.Penetration = Penetration;
            New.Vitality = Vitality;
            New.Mind = Mind;
            New.Strength = Strength;
            New.Agility = Agility;
            
            New.Element_Room = Element_Room;
            New.Element_Spawn = Element_Spawn;
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Add_L_Cur_C_Byte_Mini_Boss (New);
        }

        [PunRPC]
        public void On_Rpc_Process_Total_Mini_Boss_Map () {
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Process_Mini_Boss_In_Map ();
        }
            #region Random_Skill
            [PunRPC]
            public void On_Rpc_Mini_Boss_Random_Skill (string Sk) {
                 GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
                Map_Target.On_Add_L_Cur_C_Random_Mini_Boss_Skill (Sk);
            }
            #endregion
        #endregion
        #region Total_Boss_Enemy
        [PunRPC]
        public void On_Rpc_Total_Boss_Enemy_Map (string Code_Name, string Nickname, int Min_Power_Up, int Max_Power_Up, int Level, int Cur_Exp, string Rank, int Hp, int Mp, int Attack, int Defense, int Critical_Rate, int Critical_Damage, int Block_Chance, int Penetration, int Vitality, int Mind, int Strength, int Agility, int Element_Room, int Element_Spawn) {
             C_Byte_Enemy New = new C_Byte_Enemy ();
            New.Code_Name = Code_Name;
            New.Nickname = Nickname;
            New.Min_Power_Up = Min_Power_Up;
            New.Max_Power_Up = Max_Power_Up;
            New.Level = Level;
            New.Cur_Exp = Cur_Exp;
            New.Rank = Rank;
            New.Hp = Hp;
            New.Mp = Mp;
            New.Attack = Attack;
            New.Defense = Defense;
            New.Critical_Rate = Critical_Rate;
            New.Critical_Damage = Critical_Damage;
            New.Block_Chance = Block_Chance;
            New.Penetration = Penetration;
            New.Vitality = Vitality;
            New.Mind = Mind;
            New.Strength = Strength;
            New.Agility = Agility;
            
            New.Element_Room = Element_Room;
            New.Element_Spawn = Element_Spawn;
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Add_L_Cur_C_Byte_Boss_Enemy (New);
        }

        [PunRPC]
        public void On_Rpc_Process_Total_Boss_Enemy_Map () {
            GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
            Map_Target.On_Process_Boss_Enemy_In_Map ();
        }
            #region Random_Skill
            [PunRPC]
            public void On_Rpc_Boss_Enemy_Random_Skill (string Sk) {
                 GMP_Map_Settings Map_Target = GMP_Area_Generate.Ins.Cur_GMP_Map_Settings;
                Map_Target.On_Add_L_Cur_C_Random_Boss_Skill (Sk);
            }
            #endregion
        #endregion

        // GMP_Map_Settings :
        public void On_Finish_Ld_Process_Byte_Data () {
            _PhotonView.RPC ("Rpc_Loading_Room_Rpc", RpcTarget.All, "Lc_All_Finish_Generate_Field_Data");
        }

        // Use : Rpc_Loading_Room_Rpc ()
        void Lc_All_Finish_Generate_Field_Data () {
            Debug.Log ("Call Master 2");
            Tower_Infinity_Manager.Ins.On_Finish_Loading_Generate ();
            Tower_Infinity_Manager.Ins.On_Start_Music ();
            // Called 4 times #Sementara : supaya jika room master koneksinya lambat tidak ada error :
            _PhotonView.RPC ("On_Rpc_Total_Players_Alive", RpcTarget.All, Room_Total_Players);
            /*
            if (PhotonNetwork.IsMasterClient) {
                On_MC_Create_Field ();
            }
            */
        }
        #endregion
    #endregion
    #region Players_Strongers_Hp
    [HideInInspector]
    public GameObject Player_Strongers_Hp;
    int High_Hp;
    void On_Search_Player_Strongers_Hp () {
        High_Hp = 0;
        foreach (GameObject x in L_Player_Clone) {
            Online_Player_Status Op = x.GetComponent<Online_Player_Status> ();
            if (Op.GMP_C_Home_Status.Hp > High_Hp) {
                High_Hp = Op.GMP_C_Home_Status.Hp;
                Player_Strongers_Hp = x;
            }
        }

        Debug.LogError (High_Hp);
    }
    #endregion
    #region Team_Defeat
    public int Total_Players_Alive = 0;
    // Online_Player_Status :
    public void On_Lc_Player_Dead () {
        Total_Players_Alive --;
        _PhotonView.RPC ("On_Rpc_Total_Players_Alive", RpcTarget.All, Total_Players_Alive);
    }

    [PunRPC]
    public void On_Rpc_Total_Players_Alive (int v) {
        Total_Players_Alive = v;
        if (Total_Players_Alive <=0) {
            Tower_Infinity_Manager.Ins.On_GMP_Finish ("Defeat");
        }
    }

    
    #endregion
}
