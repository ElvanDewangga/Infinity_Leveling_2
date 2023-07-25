using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Visual_Novel : MonoBehaviour {
   [HideInInspector] 
   public Visual_Novel_Kalimat Blank_Kalimat;
   [HideInInspector] 
   public List <Visual_Novel_Kalimat> L_Visual_Novel_Kalimat = new List <Visual_Novel_Kalimat>();
  
    [HideInInspector] 
   public Skill_Keterangan Blank_Skill_Keterangan;
   public List <Skill_Keterangan> L_Skill_Keterangan= new List <Skill_Keterangan>();
  // Visual_Novel_Canvas / Check_Box_Type_2 :
   public void Load_Data () {
        L_Visual_Novel_Kalimat.Clear ();
        L_Skill_Keterangan.Clear ();

        List <Dictionary<string,object>> data = CSVReader.Read (Title_Csv);

        if (Type_Csv == "Visual_Novel") {
            for (var i = 0; i < data.Count; i++) {
                int Id = int.Parse (data[i]["Id"].ToString (), System.Globalization.NumberStyles.Integer);
                string Left_Name = data[i]["Left_Name"].ToString ();
                string Right_Name = data[i]["Right_Name"].ToString ();
                string Left_Img = data[i]["Left_Img"].ToString ();
                string Right_Img = data[i]["Right_Img"].ToString ();
                string Position = data[i]["Position"].ToString ();
                string Dialog_Text = data[i]["Dialog_Text"].ToString ();
                string Event = data[i]["Event"].ToString ();

                Add_Data (Id,Left_Name,Right_Name,Left_Img,Right_Img,Position,Dialog_Text,Event);
            }

            foreach (Transform x in this.gameObject.transform) {
                x.GetComponent <VN_Part_Dialog> ().On_Load_Part_Dialog ();
            }
        } else if (Type_Csv == "Skill_Set") {
            for (var i = 0; i < data.Count; i++) {
                string Skill_Name = data[i]["Skill_Name"].ToString ();
                Skill_Name = Dont_Destroy_On_Load.Ins._System_Settings.On_Check_Space (Skill_Name);
                
                string Description = data[i]["Description"].ToString ();
                string Skill_Info = data[i]["Skill_Info"].ToString ();
                string Skill_Category = data[i]["Skill_Category"].ToString ();
                int Gold_Learn = int.Parse (data[i]["Gold_Learn"].ToString (), System.Globalization.NumberStyles.Integer);
                int Phase = int.Parse (data[i]["Phase"].ToString (), System.Globalization.NumberStyles.Integer);

                Add_Data_Skill_Set (Skill_Name,Description,Skill_Info,Skill_Category,Gold_Learn,Phase);
            }
            Dont_Destroy_On_Load.Ins._Player_2d.On_Refresh_Skill_Data_Kumpulan ();
        }
   }

   void Add_Data (int Id, string Left_Name, string Right_Name, string Left_Img, string Right_Img, string Position, string Dialog_Text, string Event) {
     Visual_Novel_Kalimat tempData = new Visual_Novel_Kalimat (Blank_Kalimat);
     tempData.Id = Id;
     tempData.Left_Name = Left_Name;
     tempData.Right_Name = Right_Name;
     tempData.Left_Img = Left_Img;
     tempData.Right_Img = Right_Img;
     tempData.Position = Position;
     tempData.Dialog_Text = Dialog_Text;
     tempData.Event = Event;

     L_Visual_Novel_Kalimat.Add (tempData);
   }

   void Add_Data_Skill_Set (string Skill_Name, string Description, string Skill_Info, string Skill_Category, int Gold_Learn, int Phase) {
        
     Skill_Keterangan tempData = new Skill_Keterangan (Blank_Skill_Keterangan);
     tempData.Skill_Name = Skill_Name;
     tempData.Description = Description;
     tempData.Skill_Info = Skill_Info;
     tempData.Skill_Category = Skill_Category;
     tempData.Gold_Learn = Gold_Learn;
     tempData.Phase = Phase;

     L_Skill_Keterangan.Add (tempData);
        // Mencari Skill_Data_Kumpulan untuk send Skill_Keterangan :
        On_Send_Skill_Keteragan_To_Skill_Data_Kumpulan (tempData);
   }

   void On_Send_Skill_Keteragan_To_Skill_Data_Kumpulan (Skill_Keterangan Skill_K) {
         // Transfer Skill_Keterangan Ke : Editor_SKill_Active_Trans   
            foreach (Transform Trs in Home_System.Ins.Editor_Skill_Active_Trans) {
                Skill_Data_Kumpulan Sk= Trs.gameObject.GetComponent <Skill_Data_Kumpulan> ();
                if (Sk.Skill_Name == Skill_K.Skill_Name) {
                    Sk.Database_Tetap_Skill_Keterangan (Skill_K);
                }
            }
            foreach (Transform Trs in Home_System.Ins.Editor_Skill_Passive_Trans) {
                Skill_Data_Kumpulan Sk= Trs.gameObject.GetComponent <Skill_Data_Kumpulan> ();
                if (Sk.Skill_Name == Skill_K.Skill_Name) {
                    Sk.Database_Tetap_Skill_Keterangan (Skill_K);
                }
            }
   }


   [SerializeField]
   string Title_Csv = "Database_Visual_Novel1";
   [SerializeField]
   string Type_Csv = "Visual_Novel";

   
}
