using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Room_Players_Button : MonoBehaviour {
    [SerializeField]
    TMP_Text Nickname_Tx;
    [SerializeField]
    Image MC_Symbol;
    [SerializeField]
    Button Profile_Button;
    [SerializeField]
    RawImage Profile_Raw_Image;
    [SerializeField]
    TMP_Text Level_Tx;
    [SerializeField]
    Image Ready_Img;
    [SerializeField]
    Texture Profile_Texture;

    // Data :
    bool b_MC = false;
    string Nickname = "";

    // Tower_Infinity_Manager :
    public GameObject _Player_GO;
    // Online_Tower_Infinity_Room :
    public bool b_Ready = false;
    // Tower_Infinity_Manager :
    #region Network
    public void On_Input_Player (bool MC_V, string Nickname_V, GameObject GO_V) {
        b_MC = MC_V; Nickname = Nickname_V; _Player_GO = GO_V;
        On_Refresh_Nickname_Tx ();  
        On_Refresh_MC_Symbol ();    
        
    }
    // Tower_Infinity_Manager :
    public void On_Input_Ready (bool Ready_V) {
        b_Ready = Ready_V ;
        On_Refresh_Ready_Img ();
    }
    #endregion
    #region Local
    void On_Refresh_Nickname_Tx () {
        Nickname_Tx.text = Nickname;
    }

    void On_Refresh_MC_Symbol () {
        if (b_MC) {MC_Symbol.gameObject.SetActive (true);} else {MC_Symbol.gameObject.SetActive (false);}    
    }

    void On_Refresh_Ready_Img () {
        if (b_Ready) {Ready_Img.gameObject.SetActive (true);} else {Ready_Img.gameObject.SetActive (false);}  
    }
    #endregion
}
