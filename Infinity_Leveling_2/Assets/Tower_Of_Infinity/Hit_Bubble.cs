using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hit_Bubble : MonoBehaviour {
   [SerializeField]
   Image Bg_Critical;

   [SerializeField]
   TMP_Text Critical_Tx;

   [SerializeField]
   TMP_Text Damage_Tx;

   // Enemy_2d_Online / Online_Player_2d : 
   public void On_Hit_Bubble (bool Critical, int Damage) {
        if(Critical) {
            Critical_Tx.text = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Kilo ((float)Damage);
            Bg_Critical.gameObject.SetActive (true);
            Critical_Tx.gameObject.SetActive (true);
            Bg_Critical.gameObject.SetActive (true);
        } else {
            Damage_Tx.text = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_Kilo ((float)Damage);
            Bg_Critical.gameObject.SetActive (false);
            Damage_Tx.gameObject.SetActive (true);
        }
        this.gameObject.SetActive (true);
        StartCoroutine (N_Hit_Bubble ());
   }

   IEnumerator N_Hit_Bubble () {
    yield return new WaitForSeconds (2);
    Destroy (this.gameObject);
   }

}
