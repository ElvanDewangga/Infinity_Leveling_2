using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Clone_Bg_Header_Up : MonoBehaviour {
   [SerializeField]
    TMP_Text Yellow_Energy_Tx, Purple_Energy_Tx, Gold_Coin_Tx, Blue_Coin_Tx;

   public void On_Refresh () {
        Yellow_Energy_Tx.text = Home_System.Ins._Home_Canvas.Yellow_Energy_Tx.text;
        Purple_Energy_Tx.text = Home_System.Ins._Home_Canvas.Purple_Energy_Tx.text;
        Gold_Coin_Tx.text = Home_System.Ins._Home_Canvas.Gold_Coin_Tx.text;
        Blue_Coin_Tx.text = Home_System.Ins._Home_Canvas.Blue_Coin_Tx.text;
   } 
}
