using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class System_Settings : MonoBehaviour {
    // Starsky :
    public string Php_Link = "http://liwebgames.com/Php_Uf_34_Infinity_Leveling/";
    [SerializeField]
    GameObject Load_Host_Server_GO_Samp;
    // Login_Canvas :
    public void On_Host_Server_GO (string Rows_Target_V, string Judul_Php, string [] Form_Field_V, string [] Form_Value_V) {
        // Mengecek Spasi diganti dengan _ :
        int i = 0;
        for (i=0; i < Form_Value_V.Length; i++) {
            Form_Value_V[i] = On_Check_Space (Form_Value_V[i]);
        }
       
        GameObject Ins = GameObject.Instantiate (Load_Host_Server_GO_Samp);
        Ins.SetActive (true);
        Ins.GetComponent <Load_Host_Server> ().Read_Data_Rows (Rows_Target_V, Judul_Php, Form_Field_V, Form_Value_V);
        
    }

    // Hall_Of_Masters_Skill_Set
    public void On_Host_Server_GO (Hall_Of_Masters_Skill_Set Skill_Set_V, string Rows_Target_V, string Judul_Php, string [] Form_Field_V, string [] Form_Value_V) {
        // Mengecek Spasi diganti dengan _ :
        int i = 0;
        for (i=0; i < Form_Value_V.Length; i++) {
            Form_Value_V[i] = On_Check_Space (Form_Value_V[i]);
        }

        GameObject Ins = GameObject.Instantiate (Load_Host_Server_GO_Samp);
        Ins.SetActive (true);
        Ins.GetComponent <Load_Host_Server> ()._Hall_Of_Masters_Skill_Set = Skill_Set_V;
        Ins.GetComponent <Load_Host_Server> ().Read_Data_Rows (Rows_Target_V, Judul_Php, Form_Field_V, Form_Value_V);
        
    }

    // Player_2d
    public void On_Host_Server_GO (Player_2d Target_Player, string Rows_Target_V, string Judul_Php, string [] Form_Field_V, string [] Form_Value_V) {
        // Mengecek Spasi diganti dengan _ :
        int i = 0;
        for (i=0; i < Form_Value_V.Length; i++) {
            Form_Value_V[i] = On_Check_Space (Form_Value_V[i]);
        }

        GameObject Ins = GameObject.Instantiate (Load_Host_Server_GO_Samp);
        Ins.SetActive (true);
        Ins.GetComponent <Load_Host_Server> ()._Player_2d = Target_Player;
        Ins.GetComponent <Load_Host_Server> ().Read_Data_Rows (Rows_Target_V, Judul_Php, Form_Field_V, Form_Value_V);
        
    }
    // public Connect_Read_Rows Read_Umum_Rows = new Connect_Read_Rows ();
    
    #region Text Space to _
    public string On_Check_Space (string V) {
        string Result = "";
        char[] A_Text = V.ToCharArray();

        int i = 0;
        for (i=0; i < A_Text.Length; i++) {
            if (A_Text[i] == ' ') {A_Text[i] = '_';}
        }

        // Tar.text = "";
        int j = 0;
        for (j=0; j < A_Text.Length; j++) {
            Result = Result + A_Text[j];
        }
        return Result;
    }

    public string On_Check_Underline(string V) {
        string Result = "";
        char[] A_Text = V.ToCharArray();

        int i = 0;
        for (i=0; i < A_Text.Length; i++) {
            if (A_Text[i] == '_') {A_Text[i] = ' ';}
        }

        // Tar.text = "";
        int j = 0;
        for (j=0; j < A_Text.Length; j++) {
            Result = Result + A_Text[j];
        }
        return Result;
    }
    #endregion
    #region C_Byte_Enemy_To_C_Home_Status
    public void Conv_C_Byte_Enemy_To_C_Home_Status (C_Byte_Enemy from, C_Home_Status to) {

        to.Level = from.Level;
        to.Cur_Exp = from.Cur_Exp;
        to.Rank = from.Rank;
        to.Hp = from.Hp;
        to.Mp = from.Mp;
        to.Attack = from.Attack;
        to.Defense = from.Defense;
        to.Critical_Rate = from.Critical_Rate;
        to.Critical_Damage = from.Critical_Damage;
        to.Block_Chance = from.Block_Chance;
        to.Penetration = from.Penetration;
        to.Vitality = from.Vitality;
        to.Mind = from.Mind;
        to.Strength = from.Strength;
        to.Agility = from.Agility;
    }
    #endregion
    #region Convert_Kilo
    float Result_Kilo;
    string Result_Kilo_Str;
    // Hit_Bubble :
    public string On_Convert_Kilo (float Value) {
        Result_Kilo = Value;
        if (Value <= -1000 && Value >= -999999) {
            Result_Kilo = Value/1000;
            Result_Kilo_Str = Result_Kilo.ToString ("#0.0") + "K";
        } else if (Value <= -1000000 && Value >= -999999999) {
            Result_Kilo = Value/1000000;
            Result_Kilo_Str = Result_Kilo.ToString ("#0.00") + "M";
        } else {
            Result_Kilo_Str = Result_Kilo.ToString ();
        }
        
        return Result_Kilo_Str;
    }
    #endregion
    #region Convert_Rows_Valued
    string [] Result_Rows_Valued;
    
    // This / Blacksmith :
    public string [] On_Convert_Rows_Valued (string Value) {
        Result_Rows_Valued = new string [0];
        Result_Rows_Valued = Value.Split (':');
        return Result_Rows_Valued;
    }

    C_Equipment_Status Result_C_Equipment_Status;
    string Es_Valued_Code = ""; // "Title" / "Value"
    public C_Equipment_Status On_Convert_C_Equipment_Status (string v) {
        Result_C_Equipment_Status = new C_Equipment_Status ();
        string [] Sr = On_Convert_Rows_Valued (v);
        int y = 1;
        Es_Valued_Code = "Value";
        for (y=1; y < Sr.Length; y++ ) {
            if (Es_Valued_Code == "Value") {
                Es_Valued_Code = "Title";
                On_Set_Title_Equipment_Status (Sr[y]);
            } else if (Es_Valued_Code == "Title") {
                Es_Valued_Code = "Value";
                int Val;
                int.TryParse (Sr[y], out Val);
                On_Set_Value_Equipment_Status (Val);
            }
        }
        return Result_C_Equipment_Status;
    }

    string Last_Title_Cd = "Attack"; // "Attack" . "Defense", Etc.
    void On_Set_Title_Equipment_Status (string s ) {
        Last_Title_Cd = s;
    }
    
    void On_Set_Value_Equipment_Status (int v) {
        if (Last_Title_Cd == "Level") {Result_C_Equipment_Status.Level += v;}
        if (Last_Title_Cd == "Hp") {Result_C_Equipment_Status.Hp += v;}
        if (Last_Title_Cd == "Mp") {Result_C_Equipment_Status.Mp += v;}
        if (Last_Title_Cd == "Attack") {Result_C_Equipment_Status.Attack += v;}
        if (Last_Title_Cd == "Defense") {Result_C_Equipment_Status.Defense += v;}
        if (Last_Title_Cd == "Critical_Rate") {Result_C_Equipment_Status.Critical_Rate += v;}
        if (Last_Title_Cd == "Critical_Damage") {Result_C_Equipment_Status.Critical_Damage += v;}
        if (Last_Title_Cd == "Block_Chance") {Result_C_Equipment_Status.Block_Chance += v;}
        if (Last_Title_Cd == "Penetration") {Result_C_Equipment_Status.Penetration += v;}
        if (Last_Title_Cd == "Vitality") {Result_C_Equipment_Status.Vitality += v;}
        if (Last_Title_Cd == "Mind") {Result_C_Equipment_Status.Mind += v;}
        if (Last_Title_Cd == "Strength") {Result_C_Equipment_Status.Strength += v;}
        if (Last_Title_Cd == "Agility") {Result_C_Equipment_Status.Agility += v;}
    }
    #endregion
    #region Rows_Valued_To_String
    string Rows_Valued_To_String;
    // Blacksmith :
    public string On_Convert_Rows_Valued_To_String (string [] Value) {
        Rows_Valued_To_String = "";
        int y = 1;
        for (y=1; y < Value.Length; y++) {
            Rows_Valued_To_String += ":"+Value[y];
        }
   
        return Rows_Valued_To_String;
    }
    #endregion
    #region Rows_Valued_Search_Title
    string Rows_Valued_Search_Title;
    // Blacksmith :
    public string  On_Convert_Rows_Valued_Search_Title (string [] Value, string Title) {
        Rows_Valued_Search_Title = ":";
        int y = 1;
        for (y=1; y < Value.Length; y+=2) {
            if (Value[y] == Title) {
                Rows_Valued_Search_Title = Value[y+1];
            }
        }
   
        return Rows_Valued_Search_Title;
    }
    #endregion
   
}
