using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Starsky;
public class Body_Costume_Data : MonoBehaviour {
    [SerializeField]
   public string Code_Terpilih = "";

   public string Gender_Type = "Male"; // "Male" / "Female" / "All"

   
    [SerializeField]
   Sprite Dimensi_283_x_283;

   [SerializeField]
   Sprite Dimensi_Helmet;
   [SerializeField]
   Sprite Dimensi_Glove;
   [SerializeField]
   Sprite Dimensi_Boot;

   [SerializeField]
   string Name_Body = "Free Body";
   [SerializeField]
   string Name_Helmet = "Free Helmet";
   [SerializeField]
   string Name_Glove = "Free Glove";
   [SerializeField]
   string Name_Boot = "Free Boot";
    

   [SerializeField]
     bool b_Helmet = false;
    [SerializeField] 
    GameObject Helmet_Sample;
     
    [SerializeField]
     bool b_Body = false;
    [SerializeField] 
    GameObject Body_Sample;
    [SerializeField]
    string Body_Code = ""; // Diactive_Polos_All_Leg_Up_Down
    [SerializeField]
     bool b_Body_Lower = false;
    [SerializeField] 
    GameObject Body_Lower_Sample;

     [SerializeField]
     bool b_R_Arm_Up = false;
    [SerializeField] 
    GameObject R_Arm_Up_Sample;

    [SerializeField]
     bool b_L_Arm_Up = false;
    [SerializeField] 
    GameObject L_Arm_Up_Sample;

     [SerializeField]
     bool b_R_Arm_Down = false;
    [SerializeField] 
    GameObject R_Arm_Down_Sample;

    [SerializeField]
     bool b_L_Arm_Down = false;
    [SerializeField] 
    GameObject L_Arm_Down_Sample;

     [SerializeField]
     bool b_R_Hand = false;
    [SerializeField] 
    GameObject R_Hand_Sample;

    [SerializeField]
     bool b_L_Hand = false;
    [SerializeField] 
    GameObject L_Hand_Sample;

     [SerializeField]
     bool b_R_Leg_Up = false;
    [SerializeField] 
    GameObject R_Leg_Up_Sample;

    [SerializeField]
     bool b_L_Leg_Up = false;
    [SerializeField] 
    GameObject L_Leg_Up_Sample;
    
     [SerializeField]
     bool b_R_Leg_Down = false;
    [SerializeField] 
    GameObject R_Leg_Down_Sample;

    [SerializeField]
     bool b_L_Leg_Down = false;
    [SerializeField] 
    GameObject L_Leg_Down_Sample;

      [SerializeField]
     bool b_R_Foot = false;
    [SerializeField] 
    GameObject R_Foot_Sample;

    [SerializeField]
     bool b_L_Foot = false;
    [SerializeField] 
    GameObject L_Foot_Sample;

    void Start () {
      L_Get_Type = new List <string>();
      if (b_Helmet){L_Get_Type.Add ("Helmet");}
      if (b_Body){L_Get_Type.Add ("Body_Costume");}
      if (b_R_Hand){L_Get_Type.Add ("Glove");}
      if (b_R_Foot){L_Get_Type.Add ("Boot");}
    }
    // Character_Selection :
   public void On_Set_To_Player_2d (string Type_V) { // Type_V == "Body_Costume", "Helmet", "Glove", "Boot".
        if (Type_V == "Helmet") {
          if (b_Helmet) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Helmet, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Helmet_GO, Helmet_Sample, "Helmet");}
        }

        if (Type_V == "Body_Costume") {  
          if (b_Body) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Body_Costume, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Body_Costume_GO, Body_Sample, "Body");}
          if (b_Body_Lower) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_Body_Lower, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Body_Lower_GO, Body_Lower_Sample, "Body_Lower");}
          if (b_R_Arm_Up) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_R_Arm_Up, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_R_Arm_Up_GO, R_Arm_Up_Sample, "R_Arm_Up");}
          if (b_L_Arm_Up) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_L_Arm_Up, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_L_Arm_Up_GO, L_Arm_Up_Sample, "L_Arm_Up");}
          if (b_R_Arm_Down) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_R_Arm_Down, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_R_Arm_Down_GO, R_Arm_Down_Sample, "R_Arm_Down");}
          if (b_L_Arm_Down) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_L_Arm_Down, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_L_Arm_Down_GO, L_Arm_Down_Sample, "L_Arm_Down");}
          
          if (b_R_Leg_Up) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_R_Leg_Up, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_R_Leg_Up_GO, R_Leg_Up_Sample, "R_Leg_Up");}
          if (b_L_Leg_Up) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_L_Leg_Up, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_L_Leg_Up_GO, L_Leg_Up_Sample, "L_Leg_Up");}
          Home_System.Ins._Character_Selection.Target_Player_2d.On_Active_Body_Costume_Code (Body_Code);
        }

        if (Type_V == "Glove") {  
          if (b_R_Hand) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_R_Hand, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_R_Hand_GO, R_Hand_Sample, "R_Hand");}
          if (b_L_Hand) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_L_Hand, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_L_Hand_GO, L_Hand_Sample, "L_Hand");}  
        }
        if (Type_V == "Boot") {  
          if (b_R_Leg_Down) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_R_Leg_Down, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_R_Leg_Down_GO, R_Leg_Down_Sample, "R_Leg_Down");}
          if (b_L_Leg_Down) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_L_Leg_Down, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_L_Leg_Down_GO, L_Leg_Down_Sample, "L_Leg_Down");}
          
          if (b_R_Foot) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_R_Foot, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_R_Foot_GO, R_Foot_Sample, "R_Foot");}
          if (b_L_Foot) {Instantiate_Sample (Home_System.Ins._Character_Selection.Target_Player_2d.Asset_L_Foot, Home_System.Ins._Character_Selection.Target_Player_2d.Cur_L_Foot_GO, L_Foot_Sample, "L_Foot");}  
        
        }
   } 

   void Instantiate_Sample (Transform Parent_Sample_Tar, GameObject P2_Cur_GO, GameObject Sample, string bagian) {
        GameObject Sam = GameObject.Instantiate (Sample);
        // Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Body);
        Sam.transform.SetParent (Parent_Sample_Tar);
        Sam.transform.localPosition = new Vector3 (0,0,0);
        Sam.SetActive (true);
        // Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Body_Costume_GO =Sam;
        P2_Cur_GO = Sam;
        this.GetComponent <Char_Transform_Fix> ().On_Fix_Transform (Sam.transform, bagian);
   }

   // Character_Selection :
   public void On_Create_Button_To_Character_Selection (string v) {
        if (v == "Body_Costume") {
            GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Body_Costume_Data"; // Body_Costume
            sc.b_Sample = false;
            sc._Body_Costume_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
            sc.On_Input_Data (Dimensi_283_x_283, Name_Body);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        } else if (v == "Helmet") {
            GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Helmet_Data";
            sc.b_Sample = false;
            sc._Helmet_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
            sc.On_Input_Data (Dimensi_Helmet, Name_Helmet);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        } else if (v == "Glove") {
            GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Glove_Data";
            sc.b_Sample = false;
            sc._Glove_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
            sc.On_Input_Data (Dimensi_Glove, Name_Glove);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        } else if (v == "Boot") {
            GameObject Sam = GameObject.Instantiate (Home_System.Ins._Character_Selection.Type_1_Character_Select_Check_Box_Sample);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Boot_Data";
            sc.b_Sample = false;
            sc._Boot_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Home_System.Ins._Character_Selection.Type_1_Box_Selection_Panel_Column);
            sc.On_Input_Data (Dimensi_Boot, Name_Boot);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        }
   } 

   // Submit_1_Parent :
   public void On_Create_Button_To_Specific_Parent (string v, GameObject Samp_Button, Transform Samp_Parent) {
        if (v == "Body_Costume") {
            GameObject Sam = GameObject.Instantiate (Samp_Button);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Body_Costume_Data"; // Body_Costume
            sc.b_Sample = false;
            sc._Body_Costume_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Samp_Parent);
            sc.On_Input_Data (Dimensi_283_x_283, Name_Body);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        } else if (v == "Helmet") {
            GameObject Sam = GameObject.Instantiate (Samp_Button);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Helmet_Data";
            sc.b_Sample = false;
            sc._Helmet_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Samp_Parent);
            sc.On_Input_Data (Dimensi_Helmet, Name_Helmet);
            Sam.transform.localScale = new Vector3 (1,1,1);
            Sam.SetActive (true);
        } else if (v == "Glove") {
            GameObject Sam = GameObject.Instantiate (Samp_Button);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Glove_Data";
            sc.b_Sample = false;
            sc._Glove_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Samp_Parent);
            sc.On_Input_Data (Dimensi_Glove, Name_Glove);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        } else if (v == "Boot") {
            GameObject Sam = GameObject.Instantiate (Samp_Button);
            Check_Box_Type_2 sc = Sam.GetComponent <Check_Box_Type_2>();
            sc.Code_Box = "Boot_Data";
            sc.b_Sample = false;
            sc._Boot_Data = this;
            sc.Code_Item = Code_Terpilih;
            sc.gameObject.transform.SetParent (Samp_Parent);
            sc.On_Input_Data (Dimensi_Boot, Name_Boot);
            Sam.SetActive (true);
            Sam.transform.localScale = new Vector3 (1,1,1);
        }
   } 

   #region Status_Equipment_Random
    [Header ("Status_Equipment_Random :")]
    // [SerializeField]
    // Loot_Box :
    public Status_Equipment_Random [] A_Status_Equipment_Random;
    string Result_Status_Equipment_Random = "";
    public string Get_Value (int Tier_V) {
      Result_Status_Equipment_Random = "";
        if (Tier_V == 1) {
            foreach (Status_Equipment_Random x in A_Status_Equipment_Random) {
              int Min_Value, Max_Value;
              int.TryParse (x.Status_Value_Min, out Min_Value);
              int.TryParse (x.Status_Value_Max, out Max_Value);
              int Res_Value = Random.Range (Min_Value, Max_Value +1);
              Result_Status_Equipment_Random = Result_Status_Equipment_Random + ":" + x.Status_Cd +":" + Res_Value.ToString ();
            } 
        }
        return Result_Status_Equipment_Random;
    }

    List <string> L_Get_Type = new List <string> ();
    string Result_Status_Random_Get_Type;
    // Loot_Box :
    public string Get_Type () {
      Result_Status_Random_Get_Type = "";
      int x = Random.Range (0,L_Get_Type.Count);
      Result_Status_Random_Get_Type = L_Get_Type[x];
      return Result_Status_Random_Get_Type;
    }

   #endregion
}
