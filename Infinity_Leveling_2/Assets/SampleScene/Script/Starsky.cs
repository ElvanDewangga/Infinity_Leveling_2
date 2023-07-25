using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starsky {
    [System.Serializable]
        public class Player_Status {
            public int Id = 0;
            public string Guest_Id = "";
            public string Nickname = "";
            public string Token_Google = "";
            public int Accept_Privacy_Policy = 0;
            public string Gender = "";
            public string Hair_Type = "";
            public string Face = "";
            public string Hair_Colour = "";
            public string Skin_Tone = "";
            public int Yellow_Energy =0;
            public int Purple_Energy = 0;
            public int Gold_Coin = 0;
            public int Blue_Coin = 0;
            public int Hall_Of_Masters_Once = 0;
            public string Body_Costume = "";
            public string Helmet = "";
            public string Weapon = "";
            public string Ring = "";
            public string Earring = "";
            public string Offhand = "";
            public string Glove = "";
            public string Boot = "";
            public string Cape = "";
            public int Hair_Value_Colour;
            public int Hair_Value_Dark;
            public int Slot_Hair_Type;
            public int Slot_Helmet;
            public int Slot_Weapon;
            public int Slot_Ring;
            public int Slot_Body_Costume;
            public int Slot_Face;
            public int Slot_Earring;
            public int Slot_Offhand;
            public int Slot_Glove;
            public int Slot_Boot;
            public int Slot_Cape;
        }
    
    [System.Serializable]
    public class C_Skill {
        public string Skill_Name;
        public Skill_Keterangan _Skill_Keterangan;
        public Skill_Data_Editor _Skill_Data_Editor;
        public Skill_Data_Online _Skill_Data_Online;
    }
    [System.Serializable]
    public class C_Enemy_Skill_Data {
        public string Skill_Name = "";
        public int Skill_Level = 1;
    }    

    [System.Serializable]
    public class C_Home_Status {
        public int Level = 0;
        public int Cur_Exp = 0;
        public string Rank = "";
        public int Hp = 0;
        public int Mp = 0;
        public int Attack = 0;
        public int Defense = 0;
        public int Critical_Rate = 0;
        public int Critical_Damage = 0;
        public int Block_Chance = 0;
        public int Penetration = 0;
        public int Vitality =0;
        public int Mind = 0;
        public int Strength = 0;
        public int Agility = 0;
    
    }

    // System_Settings, Data_Online, Online_Player_Status :
    [System.Serializable]
    public class C_Equipment_Status {
        public int Level = 0;
        public int Hp = 0;
        public int Mp = 0;
        public int Attack = 0;
        public int Defense = 0;
        public int Critical_Rate = 0;
        public int Critical_Damage = 0;
        public int Block_Chance = 0;
        public int Penetration = 0;
        public int Vitality =0;
        public int Mind = 0;
        public int Strength = 0;
        public int Agility = 0;

        // Data_Online :
        public void On_Upgrade_Level () { // +8%
            Hp = Hp + (Hp * (8 * (Level-1)) / 100);
            Mp = Mp + (Mp * (8 * (Level-1)) / 100);
            Attack = Attack + (Attack * (8 * (Level-1)) / 100);
            Defense = Defense + (Defense * (8 * (Level-1)) / 100);
            Critical_Rate = Critical_Rate + (Critical_Rate * (8 * (Level-1)) / 100);
            Critical_Damage = Critical_Damage + (Critical_Damage * (8 * (Level-1)) / 100);
            Block_Chance = Block_Chance + (Block_Chance * (8 * (Level-1)) / 100);
            Penetration = Penetration + (Penetration * (8 * (Level-1)) / 100);
            Vitality = Vitality + (Vitality * (8 * (Level-1)) / 100);
            Mind = Mind + (Mind * (8 * (Level-1)) / 100);
            Strength = Strength + (Strength * (8 * (Level-1)) / 100);
            Agility = Agility + (Agility * (8 * (Level-1)) / 100);
            Debug.LogError ("Level" + Level + " Upgraded bonus Def " + Defense);
        }
    }

    // 
    [System.Serializable]
    public class C_Byte_Enemy {
        public string Code_Name;
        public string Nickname;
        public int Min_Power_Up; // Memberikan power dinamis dikalian beberapa persen
        public int Max_Power_Up; // Memberikan power dinamis dikalian beberapa persen
        public int Level = 0;
        public int Cur_Exp = 0;
        public string Rank = "";
        public int Hp = 0;
        public int Mp = 0;
        public int Attack = 0;
        public int Defense = 0;
        public int Critical_Rate = 0;
        public int Critical_Damage = 0;
        public int Block_Chance = 0;
        public int Penetration = 0;
        public int Vitality =0;
        public int Mind = 0;
        public int Strength = 0;
        public int Agility = 0;
        public string Type_Status_Balancing;

        public int Element_Room = 0;
        public int Element_Spawn = 0;
        
    }
    [System.Serializable]
    public class C_Enemy_Status_Balancing {
        public string Type_Status_Balancing;
        public int Hp_Times;
        
    }
    [System.Serializable]
    public class C_Byte_Field {
        public string Name_Texture = "";
        public int Cd_Texture = 0;
        public float Pos_X, Pos_Y, Pos_Z;
        public float Scale_X, Scale_Y, Scale_Z;
        // Need Load progress after finish equal Name_Texture.
       // public List <Enemy_2d> L_Enemy_2d = new List <Enemy_2d>();
       // public GameObject [] A_Portal_Field;
       // public GameObject [] A_Spawn_Field;
        // Generate Random :
        public string Name_Floor = "";
        public int Total_Spawn_Area = 0;
    }
    [System.Serializable]
    public class C_Field {
        public string Name_Texture = "";
        public int Cd_Texture = 0;
        // Need Load progress after finish equal Name_Texture.
        public List <Enemy_2d> L_Enemy_2d = new List <Enemy_2d>();
        public GameObject [] A_Portal_Field;
        public GameObject [] A_Spawn_Field;
    }
    
    [System.Serializable]
    public enum Skill_Target { // TIDAK BOLEH DIHAPUS ATAU NAMBAH DARI DEPAN KARENA AKAN MEMPENGARUHI ATAU DIGESER LANGSUNG DI EDITOR
        Allies, Enemies, Self, Allies_Except_Self
    }

    [System.Serializable]
    public class Class_Ability {
        
        public Ability_Type _Ability_Type;
        public int Value_Int_1;
        
    }

    [System.Serializable]
    public class Skill_Class_Ability {
        public int Id;
        public int Your_Players_Id;
        public string Title_Skill;
        [HideInInspector]
        public int Cur_Cd_Seconds;
        public Skill_Target _Skill_Target;
        public List <Class_Ability> L_Class_Ability = new List <Class_Ability> ();

        Skill_Target Result_Skill_Target;
        public Skill_Target Conv_String_To_Skill_Target (string v) {
            Result_Skill_Target = new Skill_Target ();
            if (v == "Allies") {Result_Skill_Target = Skill_Target.Allies;}
            if (v == "Enemies") {Result_Skill_Target = Skill_Target.Enemies;}
            if (v == "Self") {Result_Skill_Target = Skill_Target.Self;}
            if (v == "Allies_Except_Self") {Result_Skill_Target = Skill_Target.Allies_Except_Self;}
            return Result_Skill_Target;
        }

        string Result_String_Sk;
        // Online_Player_2d :
        public string Conv_Skill_Target_To_String (Skill_Target v) {
            Result_String_Sk = "";
            if (v == Skill_Target.Allies) {Result_String_Sk = "Allies";}
            if (v== Skill_Target.Enemies) {Result_String_Sk = "Enemies";}
            if (v == Skill_Target.Self) {Result_String_Sk = "Self";}
            if (v == Skill_Target.Allies_Except_Self) {Result_String_Sk = "Allies_Except_Self";}
            return Result_String_Sk;
        }

        Ability_Type Result_Ability_Type;
        public Ability_Type Conv_String_To_Ability_Type (string v) {
            Result_Ability_Type = new Ability_Type ();
            
            if (v == "Stun_Seconds") {Result_Ability_Type = Ability_Type.Stun_Seconds;}
            if (v == "Damage_Power") {Result_Ability_Type = Ability_Type.Damage_Power;}
            if (v == "Heal_Power") {Result_Ability_Type = Ability_Type.Heal_Power;}
            if (v == "Damage_Direct") {Result_Ability_Type = Ability_Type.Damage_Direct;}
            if (v == "Heal_Direct") {Result_Ability_Type = Ability_Type.Heal_Direct;}
            if (v == "Decrease_Atk_Point") {Result_Ability_Type = Ability_Type.Decrease_Atk_Point;}
            if (v == "Increase_Atk_Point") {Result_Ability_Type = Ability_Type.Increase_Atk_Point;}
            if (v == "Decrease_Mp") {Result_Ability_Type = Ability_Type.Decrease_Mp;}
            if (v == "Increase_Atk_Percent") {Result_Ability_Type = Ability_Type.Increase_Atk_Percent;}
            if (v == "Decrease_Atk_Percent") {Result_Ability_Type = Ability_Type.Decrease_Atk_Percent;}
            if (v == "Increase_Def_Percent") {Result_Ability_Type = Ability_Type.Increase_Def_Percent;}
            if (v == "Decrease_Def_Percent") {Result_Ability_Type = Ability_Type.Decrease_Def_Percent;}
            if (v == "Increase_Hp_Percent") {Result_Ability_Type = Ability_Type.Increase_Hp_Percent;}
            if (v == "Decrease_Hp_Percent") {Result_Ability_Type = Ability_Type.Decrease_Hp_Percent;}
            
            if (v == "Increase_Mp_Percent") {Result_Ability_Type = Ability_Type.Increase_Mp_Percent;}
            if (v == "Decrease_Mp_Percent") {Result_Ability_Type = Ability_Type.Decrease_Mp_Percent;}
            if (v == "Increase_Damage_By_Cur_Hp_Percent") {Result_Ability_Type = Ability_Type.Increase_Damage_By_Cur_Hp_Percent;}
            if (v == "Increase_Damage_By_Cur_Mp_Percent") {Result_Ability_Type = Ability_Type.Increase_Damage_By_Cur_Mp_Percent;}
            if (v == "Increase_Damage_By_Attack_Percent") {Result_Ability_Type = Ability_Type.Increase_Damage_By_Attack_Percent;}
            if (v == "Cd_Seconds") {Result_Ability_Type = Ability_Type.Cd_Seconds;}
            if (v == "Increase_Coming_Damage_Percent") {Result_Ability_Type = Ability_Type.Increase_Coming_Damage_Percent;}
            if (v == "stun") {Result_Ability_Type = Ability_Type.stun;}
            if (v == "Increase_Critical_Rate_Percent") {Result_Ability_Type = Ability_Type.Increase_Critical_Rate_Percent;}
            if (v == "Increase_Critical_Damage_Percent") {Result_Ability_Type = Ability_Type.Increase_Critical_Damage_Percent;}
            if (v == "Immunity") {Result_Ability_Type = Ability_Type.Immunity;}
            if (v == "Decrease_Cur_Hp_Percent") {Result_Ability_Type = Ability_Type.Decrease_Cur_Hp_Percent;}
            if (v == "Decrease_Cur_Mp_Percent") {Result_Ability_Type = Ability_Type.Decrease_Cur_Mp_Percent;}
            return Result_Ability_Type; 

        }

        string Result_String_At;
        public string Conv_Ability_Type_To_String (Ability_Type v) {

            Result_String_At = "";
            if (v == Ability_Type.Stun_Seconds) {Result_String_At = "Stun_Seconds";}
            if (v == Ability_Type.Damage_Power) {Result_String_At = "Damage_Power";}
            if (v == Ability_Type.Heal_Power) {Result_String_At = "Heal_Power";}
            if (v == Ability_Type.Damage_Direct) {Result_String_At = "Damage_Direct";}
            if (v == Ability_Type.Heal_Direct) {Result_String_At = "Heal_Direct";}
            if (v == Ability_Type.Decrease_Atk_Point) {Result_String_At = "Decrease_Atk_Point";}
            if (v == Ability_Type.Increase_Atk_Point) {Result_String_At = "Increase_Atk_Point";}
            if (v == Ability_Type.Decrease_Mp) {Result_String_At = "Decrease_Mp";}

            if (v == Ability_Type.Increase_Atk_Percent) {Result_String_At = "Increase_Atk_Percent";}
            if (v == Ability_Type.Decrease_Atk_Percent) {Result_String_At = "Decrease_Atk_Percent";}
            if (v == Ability_Type.Increase_Def_Percent) {Result_String_At = "Increase_Def_Percent";}
            if (v == Ability_Type.Decrease_Def_Percent) {Result_String_At = "Decrease_Def_Percent";}
            if (v == Ability_Type.Increase_Hp_Percent) {Result_String_At = "Increase_Hp_Percent";}
            if (v == Ability_Type.Decrease_Hp_Percent) {Result_String_At = "Decrease_Hp_Percent";}

            if (v == Ability_Type.Increase_Mp_Percent) {Result_String_At = "Increase_Mp_Percent";}
            if (v == Ability_Type.Decrease_Mp_Percent) {Result_String_At = "Decrease_Mp_Percent";}
            if (v == Ability_Type.Increase_Damage_By_Cur_Hp_Percent) {Result_String_At = "Increase_Damage_By_Cur_Hp_Percent";}
            if (v == Ability_Type.Increase_Damage_By_Cur_Mp_Percent) {Result_String_At = "Increase_Damage_By_Cur_Mp_Percent";}
            if (v == Ability_Type.Increase_Damage_By_Attack_Percent) {Result_String_At = "Increase_Damage_By_Attack_Percent";}
            if (v == Ability_Type.Cd_Seconds) {Result_String_At = "Cd_Seconds";}
            if (v == Ability_Type.Increase_Coming_Damage_Percent) {Result_String_At = "Increase_Coming_Damage_Percent";}
            if (v == Ability_Type.stun) {Result_String_At = "stun";}
            if (v == Ability_Type.Increase_Critical_Rate_Percent) {Result_String_At = "Increase_Critical_Rate_Percent";}
            if (v == Ability_Type.Increase_Critical_Damage_Percent) {Result_String_At = "Increase_Critical_Damage_Percent";}
            if (v == Ability_Type.Immunity) {Result_String_At = "Immunity";}
            if (v == Ability_Type.Decrease_Cur_Hp_Percent) {Result_String_At = "Decrease_Cur_Hp_Percent";}
            if (v == Ability_Type.Decrease_Cur_Mp_Percent) {Result_String_At = "Decrease_Cur_Mp_Percent";}
            return Result_String_At;
        }
    }

    

    [System.Serializable]
    // Online_Player_Status / Enemy_2d : (Apply Effect)
    public enum Ability_Type { // TIDAK BOLEH DIHAPUS ATAU NAMBAH DARI DEPAN KARENA AKAN MEMPENGARUHI ATAU DIGESER LANGSUNG DI EDITOR
        Stun_Seconds, Damage_Power , Heal_Power, Damage_Direct, Heal_Direct, Decrease_Atk_Point, Increase_Atk_Point, Decrease_Mp, Increase_Atk_Percent, Decrease_Atk_Percent, Increase_Def_Percent, Decrease_Def_Percent, Increase_Hp_Percent, Decrease_Hp_Percent, Increase_Mp_Percent, Decrease_Mp_Percent, Increase_Damage_By_Cur_Hp_Percent, Increase_Damage_By_Cur_Mp_Percent, Increase_Damage_By_Attack_Percent, Cd_Seconds, Increase_Coming_Damage_Percent, stun, Increase_Critical_Rate_Percent, Increase_Critical_Damage_Percent, Immunity, Decrease_Cur_Hp_Percent, Decrease_Cur_Mp_Percent
    }

    

    [System.Serializable]
    public class C_GO_Gender {
        public string Cd_Name;
        public GameObject Male_GO;
        public GameObject Female_GO;
    }

    [System.Serializable]
    public class Status_Equipment {
        public string Status_Cd;
        public string Status_Value;
    }

    [System.Serializable]
    public class Status_Equipment_Random {
        public string Status_Cd;
        public string Status_Value_Min;
        public string Status_Value_Max;
    }
}
