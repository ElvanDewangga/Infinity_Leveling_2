using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiasan_Player : MonoBehaviour {
    #region Char_Penanda
    [SerializeField]
    GameObject Penanda_Mine, Penanda_Not_Mine;
    public void On_Char_Penanda (bool v) {
        if (v) {Penanda_Mine.gameObject.SetActive (true);}else {Penanda_Not_Mine.gameObject.SetActive (true);}
    }
    #endregion
}
