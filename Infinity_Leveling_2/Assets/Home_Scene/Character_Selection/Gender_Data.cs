using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender_Data : MonoBehaviour {
   [HideInInspector]
   // Character_Selection & Player_2d:
   // Tidak dipakai lagi :
   public string Code_Character_Selection = "";

   // [SerializeField]
   // Character_Selection & Player_2d:
   public string Code_Terpilih = "Male";
   public string Gender_Type = "Male"; // "Male" / "Female" / "All"
   [SerializeField] 
   GameObject Sprite_Renderer_Sample;
   
    void Awake () {
        Code_Character_Selection = "Character_Selection_" + Code_Terpilih;
    }

    // Character_Selection :
   public void On_Set_To_Player_2d () {
        if (Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Gender_GO != null) {
            Destroy (Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Gender_GO);
        }
        GameObject Sam = GameObject.Instantiate (this.gameObject);
        // Sam.transform.SetParent (Dont_Destroy_On_Load.Ins._Player_2d.Asset_Body);
        Sam.transform.SetParent (Home_System.Ins._Character_Selection.Target_Player_2d.Gender_Fix_Transform_Anim);
        Sam.transform.localPosition = new Vector3 (0,0,0);
        Sam.SetActive (true);
        // Dont_Destroy_On_Load.Ins._Player_2d.Cur_Body_GO = Sam;
       Home_System.Ins._Character_Selection.Target_Player_2d.Cur_Gender_GO =Sam;
       Home_System.Ins._Character_Selection.Target_Player_2d.On_Set_Asset_Gender (Sam.transform);
       this.GetComponent <Char_Transform_Fix> ().On_Fix_Transform (Sam.transform, "Umum");
   } 

   #region V1
   public GameObject Polos_Body;
    public GameObject Polos_R_Arm_Up;
    public GameObject Polos_L_Arm_Up;
    public GameObject Polos_R_Arm_Down;
    public GameObject Polos_L_Arm_Down;
    public GameObject Polos_R_Hand;
    public GameObject Polos_L_Hand;
    
    public GameObject Polos_R_Leg_Up;
    public GameObject Polos_L_Leg_Up;
    public GameObject Polos_R_Leg_Down;
    public GameObject Polos_L_Leg_Down;
    public GameObject Polos_R_Foot;
    public GameObject Polos_L_Foot;

    public GameObject Polos_Face;
   // Player_2d :
    public Transform Asset_Helmet;
    public Transform Asset_Body_Costume;
    public Transform Asset_Body_Lower;
    public Transform Asset_Weapon;
    public Transform Asset_Offhand;
    public Transform Asset_Cape;
    public Transform Asset_R_Arm_Up;
    public Transform Asset_L_Arm_Up;
    public Transform Asset_R_Arm_Down;
    public Transform Asset_L_Arm_Down;
    public Transform Asset_R_Hand;
    public Transform Asset_L_Hand;
    
    public Transform Asset_R_Leg_Up;
    public Transform Asset_L_Leg_Up;
    public Transform Asset_R_Leg_Down;
    public Transform Asset_L_Leg_Down;
    public Transform Asset_R_Foot;
    public Transform Asset_L_Foot;

    public Transform Asset_Face;
    public Transform Asset_Hair_Type_Front;
    public Transform Asset_Hair_Type_Back;
   #endregion
}
