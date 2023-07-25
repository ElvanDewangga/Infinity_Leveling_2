using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_System : MonoBehaviour {
    public static Sound_System Ins;
    public Music_Script _Music;
    // public Sfx_Script _Sfx;

    void Awake () {
        Ins = this;
    }
}
