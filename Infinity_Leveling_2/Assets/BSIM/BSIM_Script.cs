using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BSIM_Script : MonoBehaviour {
   public static BSIM_Script Ins;
   void Awake () {
        Ins = this;
   }
  public Blacksmith_Script _Blacksmith_Script;
  [SerializeField]
  Canvas BSIM_Canvas;
  [SerializeField]
  TMP_Text BSIM_Title;
  public void On_Change_BSIM_Title (string v) {
   BSIM_Title.text = v;
  }
   void On_Canvas () {
      BSIM_Canvas.gameObject.SetActive (true);
   }

   public void Off_Canvas () {
      BSIM_Canvas.gameObject.SetActive (false);
   }
   public void Cli_Blacksmith () {
    _Blacksmith_Script.On_Blacksmith ();
    On_Canvas ();
   }
}
