using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendukung_Enemy : MonoBehaviour {
    [HideInInspector]
    public Enemy_2d _Enemy_2d;
    void Awake () {
        _Enemy_2d = this.gameObject.transform.parent.gameObject.GetComponent <Enemy_2d>();
    }

    #region Enemy_Fallback
    public Enemy_Fallback _Enemy_Fallback;
    #endregion
    /*
    #region Position_X
    // Target ada berada di...
    [SerializeField]
    string Result_Position_X = "Left";
    public string Cek_Position_X (Transform Trans) {
        if (this.transform.position < Trans.position) {
            Result_Position_X = "Left";
        } else if (this.transform.position > Trans.position) {
            Result_Position_X = "Right";
        } else {
            Result_Position_X = "Middle";
        }

        return Result_POsition_x;
    }
    #endregion
    #region Position_Y

    #endregion
    */
}
