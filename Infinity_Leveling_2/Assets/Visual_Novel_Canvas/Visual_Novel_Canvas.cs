using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Visual_Novel_Canvas : MonoBehaviour {
   List <Visual_Novel_Kalimat> L_Visual_Novel_Kalimat = new List <Visual_Novel_Kalimat>();
   
   [SerializeField]
   Load_Visual_Novel [] A_Load_Visual_Novel;

   public static Visual_Novel_Canvas Ins;
   void Awake () {
    Ins = this;
   } 
   
   void Start () {
          /*
        foreach (Load_Visual_Novel s in A_Load_Visual_Novel) {
            s.Load_Data ();
        }
        */
        Loading_Canvas.Ins.On_Increase_Loading_3 ();
   }

#region Visual_Novel_Read_System 
   //---- VN_Part_Dialog :
   public void On_Add_L_Visual_Novel_Kalimat (Visual_Novel_Kalimat V) {
        L_Visual_Novel_Kalimat.Add (V);
   }

   // Hall_Of_Masters / Home_Canvas :
   // Non USED :
   /*
   public void On_Load_Visual_Novel_Read_System (string Title_V) {
     L_Visual_Novel_Kalimat.Clear ();
          foreach (Transform x in A_Load_Visual_Novel[0].gameObject.transform) {
               VN_Part_Dialog Pr = x.GetComponent <VN_Part_Dialog> ();
               if (Pr.Part_Title == Title_V) {
                    Pr.On_Transfer_To_Visual_Novel_Read_System ();
               }
          }
          
          On_Dialog_Box ();
   } 
     */
     [SerializeField]
    VN_Part_Dialog _VN_Part_Dialog; 
   public void On_Load_Visual_Novel_Read_System (string Title_V) {
          L_Visual_Novel_Kalimat = new List <Visual_Novel_Kalimat>();
          _VN_Part_Dialog.On_Load_Dialog_Random (Title_V); 
          On_Dialog_Box ();
   } 

   [SerializeField]
   Button VN_Next_But;
   [SerializeField]
   VN_Dialog_Set VN_Dialog_Set_Box_1;
   
   void On_Dialog_Box () {
     
     VN_Next_But.gameObject.SetActive (true);
     VN_Dialog_Set_Box_1.VN_Left_Img.gameObject.SetActive (false);
     VN_Dialog_Set_Box_1.VN_Right_Img.gameObject.SetActive (false);
     VN_Dialog_Set_Box_1.gameObject.SetActive (true);
     On_Refresh_Dialog ();
     
   } 

   void Off_Dialog_Box () {
     L_Visual_Novel_Kalimat.Clear ();
     VN_Next_But.gameObject.SetActive (false);
     VN_Dialog_Set_Box_1.gameObject.SetActive (false);
   }

   public void Cli_Next_Dialog () {
     L_Visual_Novel_Kalimat.RemoveAt (0);
     if (L_Visual_Novel_Kalimat.Count >0) {
          On_Refresh_Dialog ();
     }
   }

   void On_Refresh_Dialog () {
     
          VN_Dialog_Set_Box_1.VN_Left_Tx.text = L_Visual_Novel_Kalimat[0].Left_Name;
          VN_Dialog_Set_Box_1.VN_Right_Tx.text = L_Visual_Novel_Kalimat[0].Right_Name;
          On_Refresh_Img ("Left"); 
          On_Refresh_Img ("Right");
          if(L_Visual_Novel_Kalimat[0].Position == "L") {VN_Dialog_Set_Box_1.VN_Left_Box_Name.gameObject.SetActive (true); VN_Dialog_Set_Box_1.VN_Right_Box_Name.gameObject.SetActive (false);}
          if(L_Visual_Novel_Kalimat[0].Position == "R") {VN_Dialog_Set_Box_1.VN_Left_Box_Name.gameObject.SetActive (false); VN_Dialog_Set_Box_1.VN_Right_Box_Name.gameObject.SetActive (true);}
          VN_Dialog_Set_Box_1.VN_Dialog_Tx.text = L_Visual_Novel_Kalimat[0].Dialog_Text;
          Dialog_Event = L_Visual_Novel_Kalimat[0].Event;
          On_Dialog_Event ();
   }

      string Code_img;
      Sprite Target_Sp;
   void On_Refresh_Img (string V) { // V = "Left" / "Right".
     if (V == "Left") {
          Code_img = L_Visual_Novel_Kalimat[0].Left_Img;
     } else if (V == "Right") {
          Code_img = L_Visual_Novel_Kalimat[0].Right_Img;
     }
   
     if (Code_img != "Disable_Character" && Code_img != "") {
          
               Target_Sp = Character_Database.Ins.On_Get_Character_Database_Part (Code_img).Cg_VN_Normal;

               if (V == "Left") {
                    VN_Dialog_Set_Box_1.VN_Left_Img.sprite = Target_Sp;
                    VN_Dialog_Set_Box_1.VN_Left_Img.gameObject.SetActive (true);
                    
               } else if (V == "Right") {
                    VN_Dialog_Set_Box_1.VN_Right_Img.sprite = Target_Sp;
                    VN_Dialog_Set_Box_1.VN_Right_Img.gameObject.SetActive (true);
                    
               }

          
     } else {
          if (V == "Left") {
               VN_Dialog_Set_Box_1.VN_Left_Img.gameObject.SetActive (false);
          } else if (V == "Right") {
               VN_Dialog_Set_Box_1.VN_Right_Img.gameObject.SetActive (false);
          }
     }

   }

   #region Background
     [System.Serializable]
     public class C_Background {
          public string Cd = "";
          public Sprite Background ;
     }

     [SerializeField]
     C_Background [] A_C_Background;
     void On_Change_Background (string st_cd) {
          foreach (C_Background c in A_C_Background) {
               if (c.Cd == st_cd) {
                    VN_Dialog_Set_Box_1.Background_Img.sprite = c.Background;
               }
          }
     }
   #endregion  

   #region Dialog_Event
   string Dialog_Event = "";
     void On_Dialog_Event () {
          if (Dialog_Event == "Close_VN") {
               Off_Dialog_Box ();
          }
          if (Dialog_Event == "Close_VN_Animation_Home_1") {
               Off_Dialog_Box ();
               Home_System.Ins._Home_Canvas.On_A_Animator_Manual_Home_1 ();
          }
          if (Dialog_Event == "Change_Bg_Hall_Of_Masters" || Dialog_Event == "Change_Bg_Sage_Shrine" || Dialog_Event == "Change_Bg_Store_Owner" || Dialog_Event == "Change_Bg_Transparant") {
               On_Change_Background (Dialog_Event);
          }
     }
   #endregion
#endregion

}
