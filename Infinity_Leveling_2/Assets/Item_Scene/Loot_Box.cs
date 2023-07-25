using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Loot_Box : MonoBehaviour {
    
    public void On_Use_Item () {
        Item_Scene_Script.Ins.On_Input_Code_Item_Configuration (this.gameObject.name);
        Notification_Canvas.Ins.On_Notification_2 ("Notification", "Are you want to use this ?", "No", "Yes", "", "Use_Item");
    }
    // Item_Scene :
    public void On_Use_Item_2 () {
        Debug.LogError ("Use Loot Box");
        Home_System.Ins._Home_Status.On_Use_Cur_Select_Inventory () ;
    }
    // Item_Scene :
    public void On_Use_Item_Effect () {
        Debug.LogError ("Use Loot Box 2");
        On_Item_Effect ();
    }

    #region Item_Effect
    [SerializeField]
    string [] Result_Code = new string [8];
    // Give 1 random item
    int Urt =0;
    List<string> L_Str_Code = new List <string> ();
    public void On_Item_Effect () {
        L_Str_Code = new List <string> ();
        L_Str_Code.Add ("Health_Potion");
        L_Str_Code.Add ("Mana_Potion");
        L_Str_Code.Add ("Weapon_Echant_Stone");
        L_Str_Code.Add ("Armor_Echant_Stone");
        L_Str_Code.Add ("Weapon_Fragment");
        L_Str_Code.Add ("Armor_Fragment");
        L_Str_Code.Add ("Gold");
        L_Str_Code.Add ("Weapon");
        L_Str_Code.Add ("Offhand");

        Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

        Result_Code =  new string [8];
        int x= 0;
        for( x=0; x<Result_Code.Length; x++) {
            Result_Code[x] = L_Str_Code[Random.Range (0,L_Str_Code.Count)];
        }
        /*
        int Urt = 0;
        for (Urt=0; Urt < Result_Code.Length; Urt++) {
            int Res = Random.Range (0,100);
            
            if (Res>= 0 && Res <= 15) {Result_Code[Urt] = "Health_Potion";}
            if (Res>= 16 && Res <= 30) {Result_Code[Urt] = "Mana_Potion";}
            
            if (Res>= 31 && Res <= 40) {Result_Code[Urt] = "Weapon_Echant_Stone";}
            if (Res>= 41 && Res <= 55) {Result_Code[Urt] = "Armor_Echant_Stone";}
            if (Res>= 56 && Res <= 65) {Result_Code[Urt] = "Weapon_Fragment";}
            if (Res>= 66 && Res <= 75) {Result_Code[Urt] = "Armor_Fragment";}
            if (Res>= 76 && Res <= 85) {Result_Code[Urt] = "Gold";}
            if (Res>= 86 && Res <= 89) {Result_Code[Urt] = "Weapon";}
            if (Res>= 90 && Res <= 93) {Result_Code[Urt] = "Offhand";}
            
            if (Res>= 94 && Res <= 100) {Result_Code[Urt] = "Armor";}
            // if (Res>= 0 && Res <= 50) {Result_Code = "Weapon_Fragment";}
            // if (Res>= 51 && Res <= 100) {Result_Code = "Armor_Fragment";}
            
        }
        */
        On_Result_Code ();
    }

    void On_Result_Code () {
        foreach (string x in Result_Code) {
            if (x == "Health_Potion") {On_Health_Potion ();}
            if (x == "Mana_Potion") {On_Mana_Potion ();}
            if (x == "Weapon_Echant_Stone") {On_Weapon_Echant_Stone ();}
            if (x == "Armor_Echant_Stone") {On_Armor_Echant_Stone ();}
            if (x == "Weapon_Fragment") {On_Weapon_Fragment ();}
            if (x == "Armor_Fragment") {On_Armor_Fragment ();}
            if (x == "Gold") {On_Gold ();}
            if (x == "Weapon") {On_Weapon ();}
            if (x == "Armor") {On_Armor ();}
            if (x == "Offhand") {On_Offhand ();}
        }

        Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1_On_Refresh_Data_Online");
    }

        #region Health_Potion
        int Health_Potion_Qty_Min = 4;
        int Health_Potion_Qty_Max = 8;

            public void On_Health_Potion () {
                int Total_Value = Random.Range (Health_Potion_Qty_Min, Health_Potion_Qty_Max +1);

                // Save_Inventory :
               // Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Health_Potion", "Item", Total_Value.ToString ());
                
                // END
            }
        #endregion
        #region Mana_Potion
        int Mana_Potion_Qty_Min = 4;
        int Mana_Potion_Qty_Max = 8;

            public void On_Mana_Potion () {
                int Total_Value = Random.Range (Mana_Potion_Qty_Min, Mana_Potion_Qty_Max +1);

                // Save_Inventory :
             //   Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Mana_Potion", "Item", Total_Value.ToString ());
               // Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
                // END
            }
        #endregion
        #region Weapon_Echant_Stone
        int Weapon_Echant_Stone_Qty_Min = 2;
        int Weapon_Echant_Stone_Qty_Max = 4;

            public void On_Weapon_Echant_Stone () {
                int Total_Value = Random.Range (Weapon_Echant_Stone_Qty_Min, Weapon_Echant_Stone_Qty_Max +1);

                // Save_Inventory :
              //  Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Weapon_Echant_Stone", "Item", Total_Value.ToString ());
               // Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
                // END
            }
        #endregion
        #region Armor_Echant_Stone
        int Armor_Echant_Stone_Qty_Min = 2;
        int Armor_Echant_Stone_Qty_Max = 4;

            public void On_Armor_Echant_Stone () {
                int Total_Value = Random.Range (Armor_Echant_Stone_Qty_Min, Armor_Echant_Stone_Qty_Max +1);

                // Save_Inventory :
              //  Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Armor_Echant_Stone", "Item", Total_Value.ToString ());
              //  Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
                // END
            }
        #endregion
        #region Weapon_Fragment
        int Weapon_Fragment_Qty_Min = 2;
        int Weapon_Fragment_Qty_Max = 4;

            public void On_Weapon_Fragment () {
                int Total_Value = Random.Range (Weapon_Fragment_Qty_Min, Weapon_Fragment_Qty_Max +1);

                // Save_Inventory :
             //   Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Weapon_Fragment", "Item", Total_Value.ToString ());
              //  Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
                // END
            }
        #endregion
        #region Armor_Fragment
        int Armor_Fragment_Qty_Min = 2;
        int Armor_Fragment_Qty_Max = 4;

            public void On_Armor_Fragment () {
                int Total_Value = Random.Range (Armor_Fragment_Qty_Min, Armor_Fragment_Qty_Max +1);

                // Save_Inventory :
             //   Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory ("Armor_Fragment", "Item", Total_Value.ToString ());
             //   Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
                // END
            }
        #endregion
        #region Gold
        int Gold_Qty_Min = 8;
        int Gold_Qty_Max = 20;
       

            public void On_Gold () {
                int Total_Value = Random.Range (Gold_Qty_Min, Gold_Qty_Max +1);
                Total_Value = Total_Value *100;
                Dont_Destroy_On_Load.Ins._Data_Online.Got_Gold_Coin (Total_Value.ToString ());
            }
        #endregion
        #region Weapon
         [SerializeField]
        string [] A_Weapon_Str;
        [SerializeField]
        string Result_Weapon_Name;
        [SerializeField]
        string Result_Weapon_Type;
        [SerializeField]
        string Result_Weapon_Value;
        void On_Weapon () {
            int Rand = Random.Range (0,A_Weapon_Str.Length);
            string Name =A_Weapon_Str[Rand];
            Result_Weapon_Name = Name;
            foreach (Weapon_Data x in Home_System.Ins._Character_Selection.L_Weapon_Data) {
                    if (Name == x.Code_Terpilih) {
                        Result_Weapon_Type = "Weapon";
                        Result_Weapon_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                    }
            }

            // Save_Inventory :
              //  Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (Result_Weapon_Name, Result_Weapon_Type, Result_Weapon_Value);
             //   Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
            // END

        }
        #endregion
        #region Offhand
         [SerializeField]
        string [] A_Offhand_Str;
        [SerializeField]
        string Result_Offhand_Name;
        [SerializeField]
        string Result_Offhand_Type;
        [SerializeField]
        string Result_Offhand_Value;
        void On_Offhand () {
            int Rand = Random.Range (0,A_Offhand_Str.Length);
            string Name =A_Offhand_Str[Rand];
            Result_Offhand_Name = Name;
            foreach (Offhand_Data x in Home_System.Ins._Character_Selection.L_Offhand_Data) {
                    if (Name == x.Code_Terpilih) {
                        Result_Offhand_Type = "Offhand";
                        Result_Offhand_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                    }
            }

            // Save_Inventory :
            //    Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (Result_Offhand_Name, Result_Offhand_Type, Result_Offhand_Value);
             //   Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
            // END

        }
        #endregion
        #region Armor
        [SerializeField]
        string [] A_Armor_Str;
        [SerializeField]
        string Result_Armor_Name;
        [SerializeField]
        string Result_Armor_Type;
        [SerializeField]
        string Result_Armor_Value;
        void On_Armor () {
            int Rand = Random.Range (0,A_Armor_Str.Length);
            string Name =A_Armor_Str[Rand];
            Result_Armor_Name = Name;
            Home_System.Ins._Character_Selection.On_Refresh_Gender ();
            foreach (Body_Costume_Data x in Home_System.Ins._Character_Selection.L_Body_Costume_Data) {
                    C_GO_Gender Cg= Home_System.Ins._Character_Selection.PG_Body_Costume.Conv_C_GO_Gender(x.Code_Terpilih);
                    if (Cg.Male_GO && Cg.Female_GO) {
                        if (Name == x.Code_Terpilih && Home_System.Ins._Character_Selection.Target_Type_Gender == x.Gender_Type) {
                           Result_Armor_Type = x.Get_Type();
                           Result_Armor_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                            break;
                        }
                    } else {
                        if (Name == x.Code_Terpilih) {
                            Result_Armor_Type = x.Get_Type();
                           Result_Armor_Value = ":" +"Level" + ":" + "1" + x.Get_Value(1);
                            break;
                        }
                    }
            }

            // Save_Inventory :
             //   Dont_Destroy_On_Load.Ins._Data_Online.On_Refresh_A_Field ();

                Dont_Destroy_On_Load.Ins._Data_Online.On_Save_Inventory (Result_Armor_Name, Result_Armor_Type, Result_Armor_Value);
             //   Dont_Destroy_On_Load.Ins._Data_Online.Start_Save_Item ("Loading_1");
            // END

        }
        #endregion
    
    #endregion
}
