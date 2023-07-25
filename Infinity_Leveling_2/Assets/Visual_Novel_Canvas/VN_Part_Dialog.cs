using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_Part_Dialog : MonoBehaviour {
    // [SerializeField]
    // ---- Visual_Novel_Canvas :
    public string Part_Title = "";
    public List <Visual_Novel_Kalimat> L_Visual_Novel_Kalimat = new List <Visual_Novel_Kalimat>();
    Load_Visual_Novel Parent_Load_Visual_Novel;
    [SerializeField]
    Visual_Novel_Kalimat [] A_Visual_Novel_Event_Khusus = new Visual_Novel_Kalimat [0];
    // Visual_Novel_Canvas - Load_Visual_Novel :
    // NON USED :
    public void On_Load_Part_Dialog () {
        Parent_Load_Visual_Novel = this.transform.parent.GetComponent <Load_Visual_Novel>();
        if (Part_Title == "Hall_Of_Masters_1") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=3; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        if (Part_Title == "Hall_Of_Masters_Sword") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        if (Part_Title == "Hall_Of_Masters_Cleric") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        if (Part_Title == "Hall_Of_Masters_Mage") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        if (Part_Title == "Hellper_Awal") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=3; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        if (Part_Title == "Hellper_Continue") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        On_Transfer_To_Visual_Novel_Read_System ();
    }
    // Visual_Novel_Canvas :
    public void On_Load_Dialog_Random (string v) {
        L_Visual_Novel_Kalimat = new List <Visual_Novel_Kalimat> ();
        Part_Title = v;
        Parent_Load_Visual_Novel = this.transform.parent.GetComponent <Load_Visual_Novel>();
        if (Part_Title == "Hall_Of_Masters_1") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=3; x++) {
          
                if (x == 0) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Male_Combat_Master.Dialog_Character_Random[Random.Range (0,Character_Database.Ins.Database_Male_Combat_Master.Dialog_Character_Random.Length)]);}
                if (x == 1) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Female_Mage_Master.Dialog_Character_Random[Random.Range (0,Character_Database.Ins.Database_Female_Mage_Master.Dialog_Character_Random.Length)]);}
                if (x == 2) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Cleric_Master.Dialog_Character_Random[Random.Range (0,Character_Database.Ins.Database_Cleric_Master.Dialog_Character_Random.Length)]);}
                if (x == 3) {L_Visual_Novel_Kalimat.Add (A_Visual_Novel_Event_Khusus[0]);}

            }
           
        }
        if (Part_Title == "Hall_Of_Masters_Sword") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
          
                if (x == 0) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Male_Combat_Master.Dialog_Character_Random[Random.Range (0,Character_Database.Ins.Database_Male_Combat_Master.Dialog_Character_Random.Length)]);}
                if (x == 1) {L_Visual_Novel_Kalimat.Add (A_Visual_Novel_Event_Khusus[0]);}

            }
            
        }
        if (Part_Title == "Hall_Of_Masters_Cleric") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
          
                if (x == 0) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Cleric_Master.Dialog_Character_Random[Random.Range (0,Character_Database.Ins.Database_Cleric_Master.Dialog_Character_Random.Length)]);}
                if (x == 1) {L_Visual_Novel_Kalimat.Add (A_Visual_Novel_Event_Khusus[0]);}

            }
            
        }
        if (Part_Title == "Hall_Of_Masters_Mage") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
          
                if (x == 0) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Female_Mage_Master.Dialog_Character_Random[Random.Range (0,Character_Database.Ins.Database_Female_Mage_Master.Dialog_Character_Random.Length)]);}
                if (x == 1) {L_Visual_Novel_Kalimat.Add (A_Visual_Novel_Event_Khusus[0]);}

            }
            
        }
        /*
        if (Part_Title == "Hellper_Awal") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=3; x++) {
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
    

            }
            
        }
        */
        if (Part_Title == "Hellper_Awal") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=3; x++) {
          
                if (x == 0) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Hellper.Dialog_Character_Random[0]);}
                if (x == 1) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Hellper.Dialog_Character_Random[1]);}
                if (x == 2) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Hellper.Dialog_Character_Random[2]);}
                if (x == 3) {L_Visual_Novel_Kalimat.Add (A_Visual_Novel_Event_Khusus[1]);}

            }
           
        }
        if (Part_Title == "Hellper_Continue") { // Id = 0 -3.
            int x = 0;
            for (x = 0; x <=1; x++) {
          
                if (x == 0) {L_Visual_Novel_Kalimat.Add (Character_Database.Ins.Database_Hellper.Dialog_Character_Random[Random.Range (7, 10)]);}
                if (x == 1) {L_Visual_Novel_Kalimat.Add (A_Visual_Novel_Event_Khusus[1]);}

            }
           
        }
         On_Transfer_To_Visual_Novel_Read_System ();
    }
    // Visual_Novel_Canvas :
    public void On_Transfer_To_Visual_Novel_Read_System () {
        foreach (Visual_Novel_Kalimat Kalimat in L_Visual_Novel_Kalimat) {
            Visual_Novel_Canvas.Ins.On_Add_L_Visual_Novel_Kalimat (Kalimat);
        }
    }
}
