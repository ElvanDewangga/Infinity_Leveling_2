using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Script : MonoBehaviour {
    

    #region Volume
    [SerializeField]
    float Volume = 0.8f;

    public void On_Set_Volume () {

    }

    #endregion
    #region AudioSource
    [SerializeField]
    AudioSource _AudioSource;
    #endregion
    #region Music_List
    [System.Serializable]
    public class C_Audio_Clip {
        public string Title = "";
        public AudioClip Ac;
    }

    [SerializeField]
    C_Audio_Clip [] A_C_Audio_Clip;
    public void On_Play (string Code_V, bool Repeat_V) {
        b_Repeat = Repeat_V;
        if(C_N_On_Check_Repeat!= null) {StopCoroutine (C_N_On_Check_Repeat); C_N_On_Check_Repeat = null;}
        foreach (C_Audio_Clip s in A_C_Audio_Clip) {
            if (Code_V == s.Title) {
                _AudioSource.volume = Volume;
                _AudioSource.clip = s.Ac;
                _AudioSource.Play ();

                if (b_Repeat) {
                     On_Check_Repeat (s.Ac);
                } else {

                }

                break;
            }
        }

        
    }
    #endregion
    #region Playlist
    int Cur_Playlist = -1;
    // List <C_Audio_Clip> L_C_Audio_Clip = new List <C_Audio_Clip> ();
    List <string> L_C_Audio_Clip = new List <string> ();
    public void On_Clear_Playlist () {
        Cur_Playlist = -1;
        L_C_Audio_Clip = new List <string>();
        if(C_N_On_Check_Repeat!= null) {StopCoroutine (C_N_On_Check_Repeat); C_N_On_Check_Repeat = null;}
    }
    public void On_Add_Playlist (string Code_V) {
        L_C_Audio_Clip.Add (Code_V);
    }
    public void On_Next_Playlist () {
        Cur_Playlist ++;
        if (Cur_Playlist < L_C_Audio_Clip.Count) {
            
        } else {
            Cur_Playlist = 0;
        }
        On_Play (L_C_Audio_Clip[Cur_Playlist], true);
    }
    #endregion
    #region Repeat & Looping
    bool b_Repeat = false;
    float Duration;
    void On_Check_Repeat (AudioClip ac) {
        Duration = ac.length;
        C_N_On_Check_Repeat = StartCoroutine (N_On_Check_Repeat ());
    }
    Coroutine C_N_On_Check_Repeat;
    IEnumerator N_On_Check_Repeat () {
        yield return new WaitForSeconds (Duration);
        On_Next_Playlist ();
    }
    #endregion
}
