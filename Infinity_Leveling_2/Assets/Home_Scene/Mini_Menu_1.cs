using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Menu_1 : MonoBehaviour {
   // Home_Canvas :
   [SerializeField]
   string Code_Open = "";
   public void On_Refresh (string V) {
        Code_Open = V;
   }
    
   public void Cli_Back_Home () {
      if (Code_Open == "Tower_Infinity") {
         Tower_Infinity_Manager.Ins.Cli_Back_Home ();
      }
   }

   public void Cli_Profile () {

   }

   public void Cli_Market () {

   }

   public void Cli_Setting () {

   }

   public void Cli_Chat () {

   }

}
