using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Control : MonoBehaviour {
   public string Code_Name = "";
   // Enemy_2d :
   public Vector3 V3_Load_Local_Position;
   [SerializeField]
   bool b_Enemy_Data_Tetap = false;
   public Enemy_Data_Tetap _Enemy_Data_Tetap;
   [SerializeField]
   bool b_Enemy_AI_Catch = false;
   [SerializeField]
   int Enemy_AI_Catch_Point = 0;
   public Enemy_AI_Catch _Enemy_AI_Catch;

   [SerializeField]
   bool b_Enemy_AI_Start_Catch = false;
   [HideInInspector]
   // Enemy_AI_Catch :
   Enemy_AI_Start_Catch _Enemy_AI_Start_Catch;


   [SerializeField]
   bool b_Enemy_AI_Mundur = false;
   [SerializeField]
   int Enemy_AI_Mundur_Point = 0;
   Enemy_AI_Mundur _Enemy_AI_Mundur;
   [SerializeField]
   bool b_Enemy_AI_Idle = false;
   [SerializeField]
   int Enemy_AI_Idle_Point = 0;
   Enemy_AI_Idle _Enemy_AI_Idle;

   //[SerializeField]
   public bool b_Enemy_AI_Jarak = false;
   [HideInInspector]
   // Enemy_AI_Jarak :
   public Enemy_AI_Jarak _Enemy_AI_Jarak;
   [HideInInspector]
   public bool b_Enemy_AI_Jarak_Stop = false;
   // Enemy_AI_Jarak : 
   public void On_b_Enemy_AI_Jarak_Stop () {
      b_Enemy_AI_Jarak_Stop = true;
   }  

   public void Off_b_Enemy_AI_Jarak_Stop () {
       b_Enemy_AI_Jarak_Stop = false;
   }

   [HideInInspector]
   // Enemy_AI_Catch :
   public bool b_Enemy_On_Spawn = false;
   // GMP_Out_Of_Zone : 
   public void On_b_Enemy_On_Spawn () {
      b_Enemy_On_Spawn = true;
   }  
   // GMP_Out_Of_Zone : 
   public void Off_b_Enemy_On_Spawn () {
       b_Enemy_On_Spawn = false;
   }
   // Enemy_AI_Catch :
   [HideInInspector]
   public GameObject Enemy_2d_GO;
   [HideInInspector]
   public Enemy_2d_Online _Enemy_2d_Online;
   [HideInInspector]
   public Enemy_2d _Enemy_2d;
   [HideInInspector]
   public CharacterController _CC;
   // Enemy_2d :
   public void On_Input_Enemy_2d_GO (GameObject Enemy_GO) {
      Enemy_2d_GO = Enemy_GO;
      _Enemy_2d_Online = Enemy_GO.GetComponent <Enemy_2d_Online>();
      _Enemy_2d = Enemy_GO.GetComponent <Enemy_2d> ();
      _CC = Enemy_2d_GO.GetComponent <CharacterController>();
   }

   void Start () {   
      L_Enemy_AI_Movement = new List <string>();
      if (b_Enemy_AI_Catch) {_Enemy_AI_Catch = GetComponent <Enemy_AI_Catch> (); On_Add_L_Enemy_AI_Movement ("Enemy_AI_Catch", Enemy_AI_Catch_Point);}
      if (b_Enemy_AI_Mundur) {_Enemy_AI_Mundur = GetComponent <Enemy_AI_Mundur> (); On_Add_L_Enemy_AI_Movement ("Enemy_AI_Mundur", Enemy_AI_Mundur_Point);}
      if (b_Enemy_AI_Idle) {_Enemy_AI_Idle = GetComponent <Enemy_AI_Idle> (); On_Add_L_Enemy_AI_Movement ("Enemy_AI_Idle", Enemy_AI_Idle_Point);}
      if (b_Enemy_AI_Start_Catch) {_Enemy_AI_Start_Catch = GetComponentInChildren <Enemy_AI_Start_Catch> ();}
      if (b_Enemy_AI_Jarak) {_Enemy_AI_Jarak = GetComponentInChildren <Enemy_AI_Jarak> ();}

      On_Random_Enemy_AI_Movement ();
   }

   #region Enemy_AI_Movement (Enemy_AI_Catch, Enemy_AI_Mundur, Enemy_AI_Idle)
   
   void On_Add_L_Enemy_AI_Movement (string b, int x) {
      int y = 0;
      for (y=0; y < x; y++) {
         L_Enemy_AI_Movement.Add (b);
      }
   }
   List <string> L_Enemy_AI_Movement;
   // Enemy_AI_Catch :
   public void On_Random_Enemy_AI_Movement () {
      int Rdm = Random.Range (0, L_Enemy_AI_Movement.Count);
      On_Change_Enemy_AI_Movement (L_Enemy_AI_Movement[Rdm]);
   }

   // Skill_Pengaturan_Animasi :
   bool b_Use_Skill = false;
   bool b_Wait_Change_AI_Movement = false;
   public void On_Use_Skill () {
      b_Use_Skill = true;
   }
   public void Off_Use_Skill () {
      b_Use_Skill = false;
   }
   string AI_Code_Active = "";
   // this/ Skill_Pengaturan_Animasi/ Enemy_AI_Catch :
   public void On_Change_Enemy_AI_Movement (string Code_Active) {
      if (!b_Wait_Change_AI_Movement) {
         AI_Code_Active = Code_Active;
         b_Wait_Change_AI_Movement = true;
         C_N_On_Change_Enemy_AI_Movement = StartCoroutine (N_On_Change_Enemy_AI_Movement ());
      } else {
         b_Wait_Change_AI_Movement = false;
         StopCoroutine (C_N_On_Change_Enemy_AI_Movement);
         On_Change_Enemy_AI_Movement ("Enemy_AI_Idle");
      }
   }
   Coroutine C_N_On_Change_Enemy_AI_Movement;
   IEnumerator N_On_Change_Enemy_AI_Movement () {
      yield return new WaitUntil (() => b_Use_Skill == false); 
      if (_Enemy_2d_Online._PhotonView.IsMine) {
         if (b_Enemy_AI_Catch) {_Enemy_AI_Catch.Turn_On_Enemy_AI_Doing (false);}
         if (b_Enemy_AI_Mundur) {_Enemy_AI_Mundur.Turn_On_Enemy_AI_Doing (false);}
         if (b_Enemy_AI_Idle) {_Enemy_AI_Idle.Turn_On_Enemy_AI_Doing (false);}
         
         if (AI_Code_Active == "Enemy_AI_Catch") {
            if (b_Enemy_AI_Start_Catch) {
               if (_Enemy_AI_Start_Catch.b_Can_AI_Catch) {
                  _Enemy_AI_Catch.Turn_On_Enemy_AI_Doing (true); On_Change_Character_Animation ("Walk");
               } else {
                  On_Change_Enemy_AI_Movement ("Enemy_AI_Idle");
               }
            } else {
               _Enemy_AI_Catch.Turn_On_Enemy_AI_Doing (true); On_Change_Character_Animation ("Walk");
            }
            if (b_Enemy_AI_Jarak) {
               Off_b_Enemy_AI_Jarak_Stop ();
            }
         }
         else if (AI_Code_Active == "Enemy_AI_Mundur") {_Enemy_AI_Mundur.Turn_On_Enemy_AI_Doing (true); if(_Enemy_2d.b_Can_Move) {On_Change_Character_Animation("Walk");}}
         else if (AI_Code_Active == "Enemy_AI_Idle") {_Enemy_AI_Idle.Turn_On_Enemy_AI_Doing (true); if(_Enemy_2d.b_Can_Move) {On_Change_Character_Animation ("Idle");}}
      }
      b_Wait_Change_AI_Movement = false;
     // if (b_Enemy_AI_Idle) {_Enemy_AI_Idle = GetComponent <Enemy_AI_Idle> ();}
   }

   public string Last_Code_Active = "";
   // This, Enemy_AI_Catch, Enemy_AI_Mundur :
   public void On_Change_Character_Animation (string V) {
      Last_Code_Active = V;
      _Enemy_2d.On_Character_Animation (V);
   }
   #endregion
   #region Stop_All_Doing
   string Code_Animation_Stop_All_Doing;
   float Time_Stop_All_Doing = 0.0f;
   // Enemy_Fallback
   public void On_Stop_All_Doing (string Code_Animation, float Value) {
      if (_Enemy_2d_Online._PhotonView.IsMine) {
         Code_Animation_Stop_All_Doing = Code_Animation;
         Time_Stop_All_Doing = Value;
         if (b_Enemy_AI_Catch) {_Enemy_AI_Catch.Turn_On_Enemy_AI_Doing (false);}
         if (b_Enemy_AI_Mundur) {_Enemy_AI_Mundur.Turn_On_Enemy_AI_Doing (false);}
         if (b_Enemy_AI_Idle) {_Enemy_AI_Idle.Turn_On_Enemy_AI_Doing (false);}
        if (C_N_On_Change_Enemy_AI_Movement != null) {b_Wait_Change_AI_Movement = false; StopCoroutine (C_N_On_Change_Enemy_AI_Movement);}
         StartCoroutine (N_On_Stop_All_Doing ());
      }
   }

   IEnumerator N_On_Stop_All_Doing () {
      yield return new WaitForSeconds (Time_Stop_All_Doing);
      On_Change_Enemy_AI_Movement (Code_Animation_Stop_All_Doing);
   }



   #endregion
}
