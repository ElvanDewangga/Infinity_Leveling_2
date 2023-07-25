 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Data_Online : MonoBehaviour {
    #region Player_Status
        [HideInInspector]
        // ---Load_Host_Server :
        public string [] Result_Player_Status;

        // Login_Canvas :
        //[HideInInspector]
        public Player_Status _Player_Status = new Player_Status ();
        // Sage_Shrine :
        public C_Home_Status _C_Home_Status = new C_Home_Status ();
        // Home_Canvas & this:
        public void On_Transfer_Player_Status () {
             Dont_Destroy_On_Load.Ins._Player_2d.On_Input_Player_Status (_Player_Status);
        }
        

        // Character_Selection :
        public void On_Save_Player_Status (string Nickname_V, string Gender_V, string Hair_Type_V, string Face_V, string Hair_Colour_V, string Skin_Tone_V, string Body_Costume_V, string Helmet_V, string Weapon_V, string Ring_V, string Earring_V, string Offhand_V, string Glove_V, string Boot_V, string Cape_V) {
            _Player_Status.Nickname = Nickname_V; _Player_Status.Gender = Gender_V; _Player_Status.Hair_Type = Hair_Type_V; _Player_Status.Face = Face_V; _Player_Status.Hair_Colour = Hair_Colour_V; _Player_Status.Skin_Tone = Skin_Tone_V;
            _Player_Status.Body_Costume = Body_Costume_V; _Player_Status.Helmet = Helmet_V; _Player_Status.Weapon = Weapon_V; _Player_Status.Ring = Ring_V; _Player_Status.Earring = Earring_V; _Player_Status.Offhand = Offhand_V; _Player_Status.Glove = Glove_V; _Player_Status.Boot = Boot_V;
            _Player_Status.Cape = Cape_V; 

            string [] Host_Server_Field = new string [47]; string [] Host_Server_Value = new string [47]; 
            Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            Debug.Log (Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id);
            Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "14";

            Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
            Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Nickname";
            Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = _Player_Status.Nickname;

             Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Player_Status";
            Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Gender";
            Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = _Player_Status.Gender;

             Host_Server_Field[8] = "table_2"; Host_Server_Value[8] = "Player_Status";
            Host_Server_Field[9] = "title_2"; Host_Server_Value[9] = "Hair_Type";
            Host_Server_Field[10] = "value_2"; Host_Server_Value[10] = _Player_Status.Hair_Type;

             Host_Server_Field[11] = "table_3"; Host_Server_Value[11] = "Player_Status";
            Host_Server_Field[12] = "title_3"; Host_Server_Value[12] = "Face";
            Host_Server_Field[13] = "value_3"; Host_Server_Value[13] = _Player_Status.Face;

             Host_Server_Field[14] = "table_4"; Host_Server_Value[14] = "Player_Status";
            Host_Server_Field[15] = "title_4"; Host_Server_Value[15] = "Hair_Colour";
            Host_Server_Field[16] = "value_4"; Host_Server_Value[16] = _Player_Status.Hair_Colour;

             Host_Server_Field[17] = "table_5"; Host_Server_Value[17] = "Player_Status";
            Host_Server_Field[18] = "title_5"; Host_Server_Value[18] = "Skin_Tone";
            Host_Server_Field[19] = "value_5"; Host_Server_Value[19] = _Player_Status.Skin_Tone;

             Host_Server_Field[20] = "table_6"; Host_Server_Value[20] = "Player_Status";
            Host_Server_Field[21] = "title_6"; Host_Server_Value[21] = "Body_Costume";
            Host_Server_Field[22] = "value_6"; Host_Server_Value[22] = _Player_Status.Body_Costume;
            
             Host_Server_Field[23] = "table_7"; Host_Server_Value[23] = "Player_Status";
            Host_Server_Field[24] = "title_7"; Host_Server_Value[24] = "Helmet";
            Host_Server_Field[25] = "value_7"; Host_Server_Value[25] = _Player_Status.Helmet;

             Host_Server_Field[26] = "table_8"; Host_Server_Value[26] = "Player_Status";
            Host_Server_Field[27] = "title_8"; Host_Server_Value[27] = "Weapon";
            Host_Server_Field[28] = "value_8"; Host_Server_Value[28] = _Player_Status.Weapon;

             Host_Server_Field[29] = "table_9"; Host_Server_Value[29] = "Player_Status";
            Host_Server_Field[30] = "title_9"; Host_Server_Value[30] = "Ring";
            Host_Server_Field[31] = "value_9"; Host_Server_Value[31] = _Player_Status.Ring;

             Host_Server_Field[32] = "table_10"; Host_Server_Value[32] = "Player_Status";
            Host_Server_Field[33] = "title_10"; Host_Server_Value[33] = "Earring";
            Host_Server_Field[34] = "value_10"; Host_Server_Value[34] = _Player_Status.Earring;

             Host_Server_Field[35] = "table_11"; Host_Server_Value[35] = "Player_Status";
            Host_Server_Field[36] = "title_11"; Host_Server_Value[36] = "Offhand";
            Host_Server_Field[37] = "value_11"; Host_Server_Value[37] = _Player_Status.Offhand;

             Host_Server_Field[38] = "table_12"; Host_Server_Value[38] = "Player_Status";
            Host_Server_Field[39] = "title_12"; Host_Server_Value[39] = "Glove";
            Host_Server_Field[40] = "value_12"; Host_Server_Value[40] = _Player_Status.Glove;

             Host_Server_Field[41] = "table_13"; Host_Server_Value[41] = "Player_Status";
            Host_Server_Field[42] = "title_13"; Host_Server_Value[42] = "Boot";
            Host_Server_Field[43] = "value_13"; Host_Server_Value[43] = _Player_Status.Boot;

             Host_Server_Field[44] = "table_14"; Host_Server_Value[44] = "Player_Status";
            Host_Server_Field[45] = "title_14"; Host_Server_Value[45] = "Cape";
            Host_Server_Field[46] = "value_14"; Host_Server_Value[46] = _Player_Status.Cape;

           
            /*
             Host_Server_Field[47] = "table_15"; Host_Server_Value[47] = "Player_Status";
            Host_Server_Field[48] = "title_15"; Host_Server_Value[48] = "Hair_Value_Colour";
            Host_Server_Field[49] = "value_15"; Host_Server_Value[49] = _Player_Status.Hair_Value_Colour.ToString ();

             Host_Server_Field[50] = "table_16"; Host_Server_Value[50] = "Player_Status";
            Host_Server_Field[51] = "title_16"; Host_Server_Value[51] = "Hair_Value_Dark";
            Host_Server_Field[52] = "value_16"; Host_Server_Value[52] = _Player_Status.Hair_Value_Dark.ToString ();
            */
            
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Close_Character_Selection", "Write_All_Table_Value_20", Host_Server_Field, Host_Server_Value);
            On_Transfer_Player_Status ();
        }
        // Character_Selection
        public void On_Save_Hair_Colour (int Hair_Value_Colour_V, int Hair_Value_Dark_V) {
            _Player_Status.Hair_Value_Colour = Hair_Value_Colour_V; _Player_Status.Hair_Value_Dark = Hair_Value_Dark_V;

             string [] Host_Server_Field = new string [8]; string [] Host_Server_Value = new string [8]; 
            Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            Debug.Log (_Player_Status.Hair_Value_Dark);
            Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "2";

             Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
            Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Hair_Value_Colour";
            Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = _Player_Status.Hair_Value_Colour.ToString ();

             Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Player_Status";
            Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Hair_Value_Dark";
            Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = _Player_Status.Hair_Value_Dark.ToString ();

            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Continue_Save_Player_Status_Equipment_Slot", "Write_All_Table_Value_20", Host_Server_Field, Host_Server_Value);

        }

        // Character_Selection :
        public void On_Save_Player_Status_Equipment_Slot (int Slot_Hair_Type_V, int Slot_Helmet_V, int Slot_Weapon_V, int Slot_Ring_V, int Slot_Body_Costume_V, int Slot_Face_V, int Slot_Earring_V, int Slot_Offhand_V, int Slot_Glove_V, int Slot_Boot_V, int Slot_Cape_V) {
            _Player_Status.Slot_Hair_Type = Slot_Hair_Type_V; _Player_Status.Slot_Helmet = Slot_Helmet_V; _Player_Status.Slot_Weapon = Slot_Weapon_V; _Player_Status.Slot_Ring = Slot_Ring_V; _Player_Status.Slot_Body_Costume = Slot_Body_Costume_V;
            _Player_Status.Slot_Face = Slot_Face_V; _Player_Status.Slot_Earring = Slot_Earring_V; _Player_Status.Slot_Offhand = Slot_Offhand_V; _Player_Status.Slot_Glove = Slot_Glove_V; _Player_Status.Slot_Boot = Slot_Boot_V; _Player_Status.Slot_Cape = Slot_Cape_V;

            string [] Host_Server_Field = new string [35]; string [] Host_Server_Value = new string [35]; 
            Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            Debug.Log (Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id);
            Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "10";

            Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
            Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Slot_Hair_Type";
            Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = _Player_Status.Slot_Hair_Type.ToString ();

            Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Player_Status";
            Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Slot_Helmet";
            Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = _Player_Status.Slot_Helmet.ToString();

            Host_Server_Field[8] = "table_2"; Host_Server_Value[8] = "Player_Status";
            Host_Server_Field[9] = "title_2"; Host_Server_Value[9] = "Slot_Weapon";
            Host_Server_Field[10] = "value_2"; Host_Server_Value[10] = _Player_Status.Slot_Weapon.ToString();

            Host_Server_Field[11] = "table_3"; Host_Server_Value[11] = "Player_Status";
            Host_Server_Field[12] = "title_3"; Host_Server_Value[12] = "Slot_Ring";
            Host_Server_Field[13] = "value_3"; Host_Server_Value[13] = _Player_Status.Slot_Ring.ToString();

            Host_Server_Field[14] = "table_4"; Host_Server_Value[14] = "Player_Status";
            Host_Server_Field[15] = "title_4"; Host_Server_Value[15] = "Slot_Body_Costume";
            Host_Server_Field[16] = "value_4"; Host_Server_Value[16] = _Player_Status.Slot_Body_Costume.ToString();

            Host_Server_Field[17] = "table_5"; Host_Server_Value[17] = "Player_Status";
            Host_Server_Field[18] = "title_5"; Host_Server_Value[18] = "Slot_Face";
            Host_Server_Field[19] = "value_5"; Host_Server_Value[19] = _Player_Status.Slot_Face.ToString();

            Host_Server_Field[20] = "table_6"; Host_Server_Value[20] = "Player_Status";
            Host_Server_Field[21] = "title_6"; Host_Server_Value[21] = "Slot_Earring";
            Host_Server_Field[22] = "value_6"; Host_Server_Value[22] = _Player_Status.Slot_Earring.ToString();

            Host_Server_Field[23] = "table_7"; Host_Server_Value[23] = "Player_Status";
            Host_Server_Field[24] = "title_7"; Host_Server_Value[24] = "Slot_Offhand";
            Host_Server_Field[25] = "value_7"; Host_Server_Value[25] = _Player_Status.Slot_Offhand.ToString();

            Host_Server_Field[26] = "table_8"; Host_Server_Value[26] = "Player_Status";
            Host_Server_Field[27] = "title_8"; Host_Server_Value[27] = "Slot_Glove";
            Host_Server_Field[28] = "value_8"; Host_Server_Value[28] = _Player_Status.Slot_Glove.ToString();

            Host_Server_Field[29] = "table_9"; Host_Server_Value[29] = "Player_Status";
            Host_Server_Field[30] = "title_9"; Host_Server_Value[30] = "Slot_Boot";
            Host_Server_Field[31] = "value_9"; Host_Server_Value[31] = _Player_Status.Slot_Boot.ToString();

            Host_Server_Field[32] = "table_10"; Host_Server_Value[32] = "Player_Status";
            Host_Server_Field[33] = "title_10"; Host_Server_Value[33] = "Slot_Cape";
            Host_Server_Field[34] = "value_10"; Host_Server_Value[34] = _Player_Status.Slot_Cape.ToString();

           
            On_Refresh_Status ();
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Close_Loading_1", "Write_All_Table_Value_20", Host_Server_Field, Host_Server_Value);
            On_Transfer_Player_Status ();
        }

        // Home_Status :
        public void On_Save_Player_Status_Equipment_Slot () {
        
            string [] Host_Server_Field = new string [35]; string [] Host_Server_Value = new string [35]; 
            Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            Debug.Log (Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id);
            Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "10";

            Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
            Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Slot_Hair_Type";
            Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = _Player_Status.Slot_Hair_Type.ToString ();

            Host_Server_Field[5] = "table_1"; Host_Server_Value[5] = "Player_Status";
            Host_Server_Field[6] = "title_1"; Host_Server_Value[6] = "Slot_Helmet";
            Host_Server_Field[7] = "value_1"; Host_Server_Value[7] = _Player_Status.Slot_Helmet.ToString();

            Host_Server_Field[8] = "table_2"; Host_Server_Value[8] = "Player_Status";
            Host_Server_Field[9] = "title_2"; Host_Server_Value[9] = "Slot_Weapon";
            Host_Server_Field[10] = "value_2"; Host_Server_Value[10] = _Player_Status.Slot_Weapon.ToString();

            Host_Server_Field[11] = "table_3"; Host_Server_Value[11] = "Player_Status";
            Host_Server_Field[12] = "title_3"; Host_Server_Value[12] = "Slot_Ring";
            Host_Server_Field[13] = "value_3"; Host_Server_Value[13] = _Player_Status.Slot_Ring.ToString();

            Host_Server_Field[14] = "table_4"; Host_Server_Value[14] = "Player_Status";
            Host_Server_Field[15] = "title_4"; Host_Server_Value[15] = "Slot_Body_Costume";
            Host_Server_Field[16] = "value_4"; Host_Server_Value[16] = _Player_Status.Slot_Body_Costume.ToString();

            Host_Server_Field[17] = "table_5"; Host_Server_Value[17] = "Player_Status";
            Host_Server_Field[18] = "title_5"; Host_Server_Value[18] = "Slot_Face";
            Host_Server_Field[19] = "value_5"; Host_Server_Value[19] = _Player_Status.Slot_Face.ToString();

            Host_Server_Field[20] = "table_6"; Host_Server_Value[20] = "Player_Status";
            Host_Server_Field[21] = "title_6"; Host_Server_Value[21] = "Slot_Earring";
            Host_Server_Field[22] = "value_6"; Host_Server_Value[22] = _Player_Status.Slot_Earring.ToString();

            Host_Server_Field[23] = "table_7"; Host_Server_Value[23] = "Player_Status";
            Host_Server_Field[24] = "title_7"; Host_Server_Value[24] = "Slot_Offhand";
            Host_Server_Field[25] = "value_7"; Host_Server_Value[25] = _Player_Status.Slot_Offhand.ToString();

            Host_Server_Field[26] = "table_8"; Host_Server_Value[26] = "Player_Status";
            Host_Server_Field[27] = "title_8"; Host_Server_Value[27] = "Slot_Glove";
            Host_Server_Field[28] = "value_8"; Host_Server_Value[28] = _Player_Status.Slot_Glove.ToString();

            Host_Server_Field[29] = "table_9"; Host_Server_Value[29] = "Player_Status";
            Host_Server_Field[30] = "title_9"; Host_Server_Value[30] = "Slot_Boot";
            Host_Server_Field[31] = "value_9"; Host_Server_Value[31] = _Player_Status.Slot_Boot.ToString();

            Host_Server_Field[32] = "table_10"; Host_Server_Value[32] = "Player_Status";
            Host_Server_Field[33] = "title_10"; Host_Server_Value[33] = "Slot_Cape";
            Host_Server_Field[34] = "value_10"; Host_Server_Value[34] = _Player_Status.Slot_Cape.ToString();
            
             On_Refresh_Status ();
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Close_Loading_1", "Write_All_Table_Value_20", Host_Server_Field, Host_Server_Value);
        }
        
        string Event_Load_Player_Status;
        // Login_Canvas
        public void On_Load_Player_Status (string Val) {
            Event_Load_Player_Status = Val;
            string [] Host_Server_Field = new string [1]; Host_Server_Field[0] = "Guest_Id";
            string [] Host_Server_Value = new string [1]; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Data_Online_Ke_On_Event_Load_Player_Status", "Read_Player_Status", Host_Server_Field, Host_Server_Value);
        }

        // Load_Host_Server :
        public void On_Event_Load_Player_Status () {
            int.TryParse (Result_Player_Status[1], out _Player_Status.Id);
            _Player_Status.Guest_Id = Result_Player_Status[2];
            _Player_Status.Nickname = Result_Player_Status[3];
            _Player_Status.Token_Google = Result_Player_Status[4];
            int.TryParse (Result_Player_Status[5], out _Player_Status.Accept_Privacy_Policy );
            _Player_Status.Gender = Result_Player_Status[6];
            _Player_Status.Hair_Type = Result_Player_Status[7];
            _Player_Status.Face = Result_Player_Status[8];
            _Player_Status.Hair_Colour = Result_Player_Status[9];
            _Player_Status.Skin_Tone = Result_Player_Status[10];
            int.TryParse (Result_Player_Status[11], out _Player_Status.Yellow_Energy );
            int.TryParse (Result_Player_Status[12], out _Player_Status.Purple_Energy );
            int.TryParse (Result_Player_Status[13], out _Player_Status.Gold_Coin );
            int.TryParse (Result_Player_Status[14], out _Player_Status.Blue_Coin );
            int.TryParse (Result_Player_Status[15], out _Player_Status.Hall_Of_Masters_Once );
            _Player_Status.Body_Costume = Result_Player_Status[16];
            _Player_Status.Helmet = Result_Player_Status[17];
            _Player_Status.Weapon = Result_Player_Status[18];
            _Player_Status.Ring = Result_Player_Status[19];
            _Player_Status.Earring = Result_Player_Status[20];
            _Player_Status.Offhand = Result_Player_Status[21];
            _Player_Status.Glove = Result_Player_Status[22];
            _Player_Status.Boot = Result_Player_Status[23];
            _Player_Status.Cape = Result_Player_Status[24];
            int.TryParse (Result_Player_Status[25], out _Player_Status.Hair_Value_Colour );
            int.TryParse (Result_Player_Status[26], out _Player_Status.Hair_Value_Dark );

            int.TryParse (Result_Player_Status[27], out _Player_Status.Slot_Hair_Type );
            int.TryParse (Result_Player_Status[28], out _Player_Status.Slot_Helmet );
            int.TryParse (Result_Player_Status[29], out _Player_Status.Slot_Weapon );
            int.TryParse (Result_Player_Status[30], out _Player_Status.Slot_Ring );
            int.TryParse (Result_Player_Status[31], out _Player_Status.Slot_Body_Costume );
            int.TryParse (Result_Player_Status[32], out _Player_Status.Slot_Face );
            int.TryParse (Result_Player_Status[33], out _Player_Status.Slot_Earring );
            int.TryParse (Result_Player_Status[34], out _Player_Status.Slot_Offhand );
            int.TryParse (Result_Player_Status[35], out _Player_Status.Slot_Glove );
            int.TryParse (Result_Player_Status[36], out _Player_Status.Slot_Boot );
            int.TryParse (Result_Player_Status[37], out _Player_Status.Slot_Cape );

            

            if (Event_Load_Player_Status == "Login_Canvas_Ke_On_Check_Term_Policy") {
                Login_Canvas.Ins.On_Check_Term_Policy ();
            }

           
        }
    #endregion
    #region Local_Payment
        string [] Target_A_Field, Target_A_Value;
        // Description_Table_1 :
        public void On_Local_Payment (string [] A_Field, string [] A_Value) {
            Target_A_Field = A_Field; Target_A_Value = A_Value;
            b_On_Local_Payment = true;
            int i =0;
            for(i=0; i <= A_Field.Length; i++) {
                if (b_On_Local_Payment) {
                    if (i < A_Field.Length) {
                        if (Target_A_Value[i] == "Gold_Coin") {
                            Target_Cur_Payment = _Player_Status.Gold_Coin;
                            int.TryParse (A_Value[i+1], out Need_Payment); // i+1 karena value ada dibawah title.
                            On_Check_Local_Payment_Enough ();

                        }
                    } else {
                        On_Continue_Local_Payment_1 ();
                    }
                }
            }
        }
        // Hall_Of_masters :
       public bool b_On_Local_Payment = false;
        int Target_Cur_Payment =0; 
        int Need_Payment =0;
        
        void On_Check_Local_Payment_Enough () {
            if(Target_Cur_Payment < Need_Payment) {
                b_On_Local_Payment = false;
                Notification_Canvas.Ins.On_Notification_1 ("Failed Buy", "You dont have enough coin", "Okay", "");
                Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
            } else {
                
            }
        }

        void On_Continue_Local_Payment_1 () {
            // Mengganti Value dengan menjumlahkan baru save. (KARENA SEBELUMNYA DI VALUE ITU ADALAH ANGKA PERUBAHAN(NEED MISAL HARGA SKILL 200)) (GOLD PLAYER)800 - 200 = 600.
            int i =0;
            for(i=0; i <= Target_A_Field.Length; i++) {
                if (i < Target_A_Field.Length) {
                    if (Target_A_Value[i] == "Gold_Coin") { 
                            int.TryParse (Target_A_Value[i+1], out Need_Payment); // i+1 karena value ada dibawah title.
                            _Player_Status.Gold_Coin = (_Player_Status.Gold_Coin - Need_Payment);
                            Target_A_Value[i+1] = _Player_Status.Gold_Coin.ToString ();
                    }
                 }
                
            }
            
            Loading_Canvas.Ins.On_Loading_1 ();
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("On_Refresh_Header_Up", "Write_All_Table_Value_20", Target_A_Field, Target_A_Value);
            
        }
    #endregion
    #region Got_Items
     bool b_Gold = false;
     public void On_b_Gold (bool v) {
        b_Gold = v;
     }
    // Home_Canvas
    public void Got_Gold_Coin (string Value) {
        On_b_Gold (true);
        Code_Loading = "Gold";
        string [] Host_Server_Field = new string [5]; string [] Host_Server_Value = new string [5];
         Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
         Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "1";

         Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
         Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Gold_Coin";
         Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = Value.ToString ();

        Got_Items (Host_Server_Field, Host_Server_Value);   
    }

    public void Exp_Gt (string Value) {
        Code_Loading = "";
        string [] Host_Server_Field = new string [5]; string [] Host_Server_Value = new string [5];
         Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
         Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "1";

         Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
         Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Cur_Exp";
         Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = Value.ToString ();

        Got_Items (Host_Server_Field, Host_Server_Value);   
    }
    // Tower_Infinity_Manager / Character_Selection:
    public void Got_Items (string [] A_Field, string [] A_Value) {
       // Host_Server_Field = new string [0]; Host_Server_Value = new string [0];
        Target_A_Field = A_Field; Target_A_Value = A_Value;
        On_Continue_Saving_Database ();
      
    }
    
    void On_Continue_Saving_Database () { // Mirip On_Continue_Local_Payment_1 (Beda aturan dan mines) kalau yang ini plus.
        int i =0;
            for(i=0; i <= Target_A_Field.Length; i++) {
                if (i < Target_A_Field.Length) {
                    int Value_Penambahan;
                    if (Target_A_Value[i] == "Gold_Coin") { 
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _Player_Status.Gold_Coin = (_Player_Status.Gold_Coin + Value_Penambahan);
                            Target_A_Value[i+1] = _Player_Status.Gold_Coin.ToString ();
                    }
                    else if (Target_A_Value[i] == "Cur_Exp") { 
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Cur_Exp = (_C_Home_Status.Cur_Exp + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Cur_Exp.ToString ();
                           //  Home_System.Ins._Home_Canvas.On_Refresh_Header_Left ();
                    } else if (Target_A_Value[i] == "Level") {
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Level = (_C_Home_Status.Level + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Level.ToString ();
                    } else if (Target_A_Value[i] == "Hp") {
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Hp = (_C_Home_Status.Hp + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Hp.ToString ();
                    }
                    else if (Target_A_Value[i] == "Mp") {
                        
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Mp = (_C_Home_Status.Mp + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Mp.ToString ();
                    }
                    else if (Target_A_Value[i] == "Vitality") {
                        
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Vitality = (_C_Home_Status.Vitality + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Vitality.ToString ();
                    }
                    else if (Target_A_Value[i] == "Mind") {
                        
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Mind = (_C_Home_Status.Mind + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Mind.ToString ();
                    }
                    else if (Target_A_Value[i] == "Strength") {
                        
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Strength = (_C_Home_Status.Strength + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Strength.ToString ();
                    }
                    
                    else if (Target_A_Value[i] == "Agility") {
                        
                            int.TryParse (Target_A_Value[i+1], out Value_Penambahan); // i+1 karena value ada dibawah title.
                            _C_Home_Status.Agility = (_C_Home_Status.Agility + Value_Penambahan);
                            Target_A_Value[i+1] = _C_Home_Status.Agility.ToString ();
                    }
                 }
                
            }
        if (Code_Loading == "Loading_1" || Code_Loading == "Loading_1_Use_Item" || Code_Loading == "Loading_1_On_Refresh_Data_Online") {
            Loading_Canvas.Ins.On_Loading_1 ();
            
        }

        if (Code_Loading == "" || Code_Loading == "Loading_1") {
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("On_Refresh_Header_Up", "Write_All_Table_Value_20", Target_A_Field, Target_A_Value);
        }

        if (Code_Loading == "Loading_1_On_Refresh_Data_Online") {
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Loading_1_On_Refresh_Data_Online", "Write_All_Table_Value_20", Target_A_Field, Target_A_Value);
        }

        if (Code_Loading == "Disable_Item") {
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("On_Refresh_Header_Up", "Write_All_Table_Value_20", Target_A_Field, Target_A_Value);
        }

        if (Code_Loading == "Loading_1_Use_Item") {
            Debug.LogError ("Use Item");
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Loading_1_Use_Item", "Write_All_Table_Value_20", Target_A_Field, Target_A_Value);
        }

        if (Code_Loading == "Gold") {
            Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Gold", "Write_All_Table_Value_20", Target_A_Field, Target_A_Value);
        }

        if (Sage_Shrine.Ins) { Sage_Shrine.Ins.On_Ref_Cur_Exp ();}
        
    }

    // Load_Host_Server
    public void Fin_Save () {
            if ((Str_Now+1) >= L_Ex_Save.Count) {
                Loading_Canvas.Ins.Off_Loading_1 ();
                Code_Loading = "";
               // Home_System.Ins._Home_Status.Cli_On_HS_Inventory ();
                 Home_System.Ins._Home_Canvas.On_Refresh_Header_Up ();
            } else {
                On_Save_Item_L_Arr ();
            }
        
    }
    #endregion
    
    #region Hall_Of_Masters_Once
    // Hall_Of_Masters :
    public void On_Save_Hall_Of_Masters_Once () {
        Loading_Canvas.Ins.On_Loading_1 ();

        _Player_Status.Hall_Of_Masters_Once = 1;
        string [] Host_Server_Field = new string [5]; string [] Host_Server_Value = new string [5]; 
        Host_Server_Field[0] = "guest_id"; Host_Server_Value[0] = Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id;
        Debug.Log (Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id);
        Host_Server_Field[1] = "max_write"; Host_Server_Value[1] = "1";

        Host_Server_Field[2] = "table_0"; Host_Server_Value[2] = "Player_Status";
        Host_Server_Field[3] = "title_0"; Host_Server_Value[3] = "Hall_Of_Masters_Once";
        Host_Server_Field[4] = "value_0"; Host_Server_Value[4] = _Player_Status.Hall_Of_Masters_Once.ToString ();

        Dont_Destroy_On_Load.Ins._System_Settings.On_Host_Server_GO ("Close_Loading_1", "Write_All_Table_Value_20", Host_Server_Field, Host_Server_Value);
    }
    #endregion
    #region Target_A_Field_Settings
    // Character_Selection :
    int Total_Item_yang_Akan_Masuk = 0;
    [SerializeField]
    string [] Sementara_A_Field, Sementara_A_Value = new string [0];
    public void On_Refresh_A_Field () {
        
        L_Ex_Save = new List<Ex_Save>();
        Target_A_Field = new string [0]; Target_A_Value = new string [0];
        L_Server_Field = new List <string> (); L_Server_Value = new List <string> ();
        Sementara_A_Field = new string [0]; Sementara_A_Value = new string [0];
        T_Baris = 0;
        Cur_Slot = 0; Total_Item_yang_Akan_Masuk = 0; L_Local_Write = new List <Local_Write>();
    }
    public List <string> L_Server_Field = new List <string> ();
    public List <string> L_Server_Value = new List <string> ();
    int T_Baris = 0;
    void On_Save_Item (string table, string title, string value) {
        
        L_Server_Field.Add ("table_" + T_Baris);
        L_Server_Field.Add ("title_" + T_Baris);
        L_Server_Field.Add ("value_" + T_Baris);

        L_Server_Value.Add (table);
        L_Server_Value.Add (title);
        L_Server_Value.Add (value);

        T_Baris ++;
    }
    string Code_Loading = ""; // "Loading_1" / "" (No Loading) (Mana_Potion GMP_Item_Button)
    // GMP_Item_Button :
    public void On_Change_Code_Loading (string v) {
        Code_Loading = v;
    }
    // Character_Selection :
    // jika save lebih dari 5 item harus buat coroutine.
    [System.Serializable]
    public class Ex_Save {
        public List <string> Sementara_L_Field = new List <string> ();
        public List <string> Sementara_L_Value  = new List <string> ();
        
    }

    public List <Ex_Save> L_Ex_Save = new List <Ex_Save>();
    int Ex_Cur_Slot = 0; int Ex_Num_Slot = 0;
    int Ex_Max_Slot = 5; int Ex_Col_Slot = 0;
    int Last_Empty = 0;
    string Next_Cd_Loading = "";
    public void Start_Save_Item (string Code_Loading_V) { // E[45]
        Next_Cd_Loading = Code_Loading_V;
        StartCoroutine (N_Start_Save_Item ());
    }

    IEnumerator N_Start_Save_Item () {
        yield return new WaitUntil (()=> b_Gold == false);
        Ex_Cur_Slot = 0; Ex_Max_Slot =5; Ex_Num_Slot = 0; Ex_Col_Slot = 0; Last_Empty =0; Str_Now = -1; 
    L_Ex_Save = new List<Ex_Save>();
        Code_Loading = Next_Cd_Loading;
        //if (Cur_Slot <=5) {
            Ex_Save Sam = new Ex_Save ();
            Sam.Sementara_L_Field = new List <string> ();
            Sam.Sementara_L_Value  = new List <string> ();
            L_Ex_Save.Add (Sam);
           // Sementara_A_Field = L_Ex_Save[0].Sementara_A_Field; Sementara_A_Value = L_Ex_Save[0].Sementara_A_Value;
            // 2+ guest_id, max_write
           // Sementara_A_Field = new string [2+ (Cur_Slot *Total_Db_Inventory*3)]; // [2(guest_id, max_write) + (Cur_Slot(Jumlah item yang masuk) * Total_Db_Inventory *3 [table,title,value component])]
           // Sementara_A_Value = new string [2+ (Cur_Slot *Total_Db_Inventory*3)];
            int xy = 0;
            // 5 per 5 inventory item
            L_Ex_Save[0].Sementara_L_Field.Add ("guest_id"); L_Ex_Save[0].Sementara_L_Value.Add (Dont_Destroy_On_Load.Ins._Data_Offline.Last_Login_Guest_Id);
            L_Ex_Save[0].Sementara_L_Field.Add ("max_write"); L_Ex_Save[0].Sementara_L_Value.Add((Cur_Slot *Total_Db_Inventory).ToString ());
            
            for (xy = 0; xy < L_Server_Field.Count; xy++) {
                Debug.Log ("Call maxwrite");
                Ex_Cur_Slot ++;
                if (Ex_Cur_Slot >= (Total_Db_Inventory*3)) {
                    Ex_Cur_Slot = 0;
                    Ex_Num_Slot ++;
                    if (Ex_Num_Slot >= Ex_Max_Slot) {
                        Ex_Num_Slot =0; Ex_Col_Slot ++;
                        Ex_Save Sam2 = new Ex_Save ();
                        //Sam2.Sementara_A_Value = new string [45];
                       // Sam2.Sementara_A_Field = new string[45];
                        L_Ex_Save.Add (Sam2);
                     //   Sementara_A_Field = L_Ex_Save[Ex_Col_Slot].Sementara_A_Field; Sementara_A_Value = L_Ex_Save[Ex_Col_Slot].Sementara_A_Value;
                    }
                }
                L_Ex_Save[Ex_Col_Slot].Sementara_L_Field.Add (L_Server_Field[xy]);
                L_Ex_Save[Ex_Col_Slot].Sementara_L_Value.Add (L_Server_Value[xy]);
                //Sementara_A_Field [2 + xy] = L_Server_Field[xy];
                //Sementara_A_Value [2 + xy] = L_Server_Value[xy];
               
            }

            On_Save_Item_L_Arr ();
       // } else {
       //      Debug.LogError ("Batal Save Inventory karena memiliki batas MAKSIMAL. GUNAKAN Coroutine !" + Cur_Slot);
             // 2+ guest_id, max_write
             
          //  }
    }
    int Str_Now = -1;
    void On_Save_Item_L_Arr () {
        Str_Now ++;
        Got_Items(On_Cnv_List_Arr(L_Ex_Save[Str_Now].Sementara_L_Field), On_Cnv_List_Arr(L_Ex_Save[Str_Now].Sementara_L_Value));
        Save_L_Local_Write ();
    }
        string[] On_Cnv_List_Arr (List <string> S) {
            string [] A = new string [S.Count];
            int u = 0;
            for (u=0; u < S.Count; u++) {
                A[u] = S[u];
            }
            return A;
        }
        #region Local_Write
        List <Local_Write> L_Local_Write = new List <Local_Write>();
        public class Local_Write { 
            public int Slot_Cd;
            public string Name_V;
            public string Type_V;
            public string Value;
        }

        public void Add_L_Local_Write (int Slot_V, string Na_V, string Ty_V, string Vl) {
            Local_Write Nx = new Local_Write ();
            Nx.Slot_Cd = Slot_V; Nx.Name_V = Na_V; Nx.Type_V = Ty_V; Nx.Value = Vl;
            L_Local_Write.Add (Nx);

        }

        int TotalValue;
        void Save_L_Local_Write () {
            
            foreach (Local_Write x in L_Local_Write) {
                Home_System.Ins._Home_Status.A_Inventory_Name[x.Slot_Cd] = x.Name_V;
                Home_System.Ins._Home_Status.A_Inventory_Type[x.Slot_Cd] = x.Type_V;
                Home_System.Ins._Home_Status.A_Inventory_Value[x.Slot_Cd] = x.Value;

                
            }
             Home_System.Ins._Home_Status.On_Refresh_Total_Cur_Slot ();
             On_Refresh_Status ();
        }
        #endregion
        
    #endregion
    #region Home_Status - Inventory
    int Cur_Slot = 0;
    int Total_Db_Inventory = 3;
    bool Search_On_Same_Slot = false;
    // Character_Selection / Setting_Configuration:
    public void On_Save_Inventory (string Name_V, string Type_V, string Value) {
        Search_On_Same_Slot =false;
        if (Code_Loading != "Disable_Item") {
            if (Cur_Slot == 0) {
                Dont_Destroy_On_Load.Ins._Got_Item_1_Parent.On_Active_Got_Item_Event ("Got_Item_1_Parent", "");
            }
        }
            Dont_Destroy_On_Load.Ins._Got_Item_1_Parent.On_Add_Item_Got_Item_Button_1 (Name_V, Type_V, Value);

        if (Type_V == "Item") {
            On_Inventory_Searching_Same_Slot (Name_V);
            if (result_Seraching_Slot == 0) {
                Search_On_Same_Slot = false;
                On_Save_Item ("Db_Inventory_Name", ("Slot_" + (On_Inventory_Searching_Slot () + Cur_Slot).ToString ()), Name_V);
                On_Save_Item ("Db_Inventory_Type", ("Slot_" + (On_Inventory_Searching_Slot () + Cur_Slot).ToString ()), Type_V);
                int Cur_Value; int Cg_Value;
                int.TryParse (Home_System.Ins._Home_Status.A_Inventory_Value[On_Inventory_Searching_Slot () + Cur_Slot] , out Cur_Value);
                int.TryParse (Value, out Cg_Value);

                TotalValue = Cg_Value + Cur_Value;
                On_Save_Item ("Db_Inventory_Value", ("Slot_" + (On_Inventory_Searching_Slot () + Cur_Slot).ToString ()), Value);
            } else {
                Search_On_Same_Slot = true;
                On_Save_Item ("Db_Inventory_Name", ("Slot_" + (On_Inventory_Searching_Same_Slot (Name_V)).ToString ()), Name_V);
                On_Save_Item ("Db_Inventory_Type", ("Slot_" + (On_Inventory_Searching_Same_Slot (Name_V)).ToString ()), Type_V);
                int Cur_Value; int Cg_Value;
                int.TryParse (Home_System.Ins._Home_Status.A_Inventory_Value[On_Inventory_Searching_Same_Slot (Name_V)] , out Cur_Value);
                int.TryParse (Value, out Cg_Value);

                TotalValue = Cg_Value + Cur_Value;
                On_Save_Item ("Db_Inventory_Value", ("Slot_" + (On_Inventory_Searching_Same_Slot (Name_V)).ToString ()), TotalValue.ToString ());
            }
        } else {
            On_Save_Item ("Db_Inventory_Name", ("Slot_" + (On_Inventory_Searching_Slot () + Cur_Slot).ToString ()), Name_V);
                On_Save_Item ("Db_Inventory_Type", ("Slot_" + (On_Inventory_Searching_Slot () + Cur_Slot).ToString ()), Type_V);
                On_Save_Item ("Db_Inventory_Value", ("Slot_" + (On_Inventory_Searching_Slot () + Cur_Slot).ToString ()), Value);
        }
        
        if (Type_V == "Item") {
            if (Search_On_Same_Slot == false) {
                Add_L_Local_Write ((On_Inventory_Searching_Slot () + Cur_Slot), Name_V, Type_V, Value);
            
            } else {
                Add_L_Local_Write ((On_Inventory_Searching_Same_Slot (Name_V)), Name_V, Type_V, TotalValue.ToString ());
            }
        } else {
            Add_L_Local_Write ((On_Inventory_Searching_Slot () + Cur_Slot), Name_V, Type_V, Value);
        }
        Cur_Slot ++;
    }
    
    // On_Use Item (Loot_Box - Home_Status) / Blacksmith : (KHUSUS ITEM) WEAPON, DLL ADA FUNCTION DIBAWAH
    public void On_Save_Inventory_Value_Changed (int Slot_V, string Value) {
        /*
        if (Cur_Slot == 0) {
            Dont_Destroy_On_Load.Ins._Got_Item_1_Parent.On_Active_Got_Item_Event ("Got_Item_1_Parent", "");
        }
            Dont_Destroy_On_Load.Ins._Got_Item_1_Parent.On_Add_Item_Got_Item_Button_1 (Name_V, Type_V, Value);
        */
        if (Home_System.Ins._Home_Status.A_Inventory_Type[Slot_V] == "Item") {
            int Cur_Value; int Cg_Value;
            int.TryParse (Home_System.Ins._Home_Status.A_Inventory_Value[Slot_V] , out Cur_Value);
            int.TryParse (Value, out Cg_Value);
            
            TotalValue = Cg_Value + Cur_Value;
            
            if (TotalValue > 0) {
                On_Save_Item ("Db_Inventory_Name", ("Slot_" + Slot_V.ToString ()), Home_System.Ins._Home_Status.A_Inventory_Name[Slot_V]);
                On_Save_Item ("Db_Inventory_Type", ("Slot_" + Slot_V.ToString ()), Home_System.Ins._Home_Status.A_Inventory_Type[Slot_V]);
                On_Save_Item ("Db_Inventory_Value", ("Slot_" + Slot_V.ToString ()), TotalValue.ToString ());
                
                Add_L_Local_Write (Slot_V, Home_System.Ins._Home_Status.A_Inventory_Name[Slot_V], Home_System.Ins._Home_Status.A_Inventory_Type[Slot_V], TotalValue.ToString ());
            } else {
                On_Save_Item ("Db_Inventory_Name", ("Slot_" + Slot_V.ToString ()), "");
                On_Save_Item ("Db_Inventory_Type", ("Slot_" + Slot_V.ToString ()), "");
                On_Save_Item ("Db_Inventory_Value", ("Slot_" + Slot_V.ToString ()), TotalValue.ToString ());
                
                Add_L_Local_Write (Slot_V, "", "", "0");
            }

        } else {
            On_Save_Item ("Db_Inventory_Name", ("Slot_" + Slot_V.ToString ()), Home_System.Ins._Home_Status.A_Inventory_Name[Slot_V]);
            On_Save_Item ("Db_Inventory_Type", ("Slot_" + Slot_V.ToString ()), Home_System.Ins._Home_Status.A_Inventory_Type[Slot_V]);
            On_Save_Item ("Db_Inventory_Value", ("Slot_" + Slot_V.ToString ()), Value);
            
            Add_L_Local_Write (Slot_V, Home_System.Ins._Home_Status.A_Inventory_Name[Slot_V], Home_System.Ins._Home_Status.A_Inventory_Type[Slot_V], Value);
        }
        Cur_Slot ++;
    }
    #endregion
    #region Searching_Slot
    int result_Seraching_Slot;
    int On_Inventory_Searching_Slot () {
         result_Seraching_Slot = 0;
        int x = 1;
        for (x=1 ; x < Home_System.Ins._Home_Status.A_Inventory_Name.Length ; x++) {
            string Slot_Name = Home_System.Ins._Home_Status.A_Inventory_Name[x]; 
            if (Slot_Name == "") {
                result_Seraching_Slot = x;
                break;
            }
        }
        return result_Seraching_Slot;
    }

    int On_Inventory_Searching_Same_Slot (string Name_V) {
         result_Seraching_Slot = 0;
        int x = 1;
        for (x=1 ; x < Home_System.Ins._Home_Status.A_Inventory_Name.Length ; x++) {
            string Slot_Name = Home_System.Ins._Home_Status.A_Inventory_Name[x]; 
            if (Slot_Name == Name_V) {
                result_Seraching_Slot = x;
                break;
            }
        }
        return result_Seraching_Slot;
    }
    #endregion
    #region Home_Status
    string [] Result_Home_Status;
    // Player_2d - Load_Host_Server :
    public void On_Got_Home_Status (string [] H) {
        Result_Home_Status = H;
        int.TryParse (Result_Home_Status [1], out _C_Home_Status.Level);
        int.TryParse (Result_Home_Status [2], out _C_Home_Status.Cur_Exp);
        _C_Home_Status.Rank = Result_Home_Status[3];
        int.TryParse (Result_Home_Status [4], out _C_Home_Status.Hp);
        int.TryParse (Result_Home_Status [5], out _C_Home_Status.Mp);
        int.TryParse (Result_Home_Status [6], out _C_Home_Status.Attack);
        int.TryParse (Result_Home_Status [7], out _C_Home_Status.Defense);
        int.TryParse (Result_Home_Status [8], out _C_Home_Status.Critical_Rate);
        int.TryParse (Result_Home_Status [9], out _C_Home_Status.Critical_Damage);
        int.TryParse (Result_Home_Status [10], out _C_Home_Status.Block_Chance);
        int.TryParse (Result_Home_Status [11], out _C_Home_Status.Penetration);
        int.TryParse (Result_Home_Status [12], out _C_Home_Status.Vitality);
        int.TryParse (Result_Home_Status [13], out _C_Home_Status.Mind);
        int.TryParse (Result_Home_Status [14], out _C_Home_Status.Strength);
        int.TryParse (Result_Home_Status [15], out _C_Home_Status.Agility);

        On_Refresh_Status ();
        // Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Body_Costume]);
        Home_System.Ins._Home_Canvas.On_Refresh_Header_Left ();
        Loading_Canvas.Ins.On_Increase_Loading_3 ();
    }

    void On_Refresh_Status () {
        On_Apply_C_Equipment_Status ();
    }
    #endregion
    #region Online_Player_Status
    // Online_Player_Status :
    public void Send_Player_Status (Online_Player_Status Op) {
        Op.On_Got_Local_Player_Status (_Player_Status, _C_Home_Status);
    }

    
    #endregion
    #region C_Equipment_Status
    C_Equipment_Status [] A_C_Equipment_Status = new C_Equipment_Status [6]; // ubah di inspector.
    public C_Equipment_Status Total_C_Equipment_Status = new C_Equipment_Status ();
    // [0] = Weapon
    // [1] = Helmet
    // [2] = Body_Costume
    // [3] = Glove
    // [4] = Boot
    // [5] = Offhand
    void On_Apply_C_Equipment_Status () {
        StartCoroutine (N_On_Apply_C_Equipment_Status ());
    }

    IEnumerator N_On_Apply_C_Equipment_Status () {
        yield return new WaitUntil (() => _Player_Status.Guest_Id != "");
        Total_C_Equipment_Status = new C_Equipment_Status ();
        A_C_Equipment_Status [0] = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Weapon]);
        A_C_Equipment_Status [1] = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Helmet]);
        A_C_Equipment_Status [2] = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Body_Costume]);
        A_C_Equipment_Status [3] = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Glove]);
        A_C_Equipment_Status [4] = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Boot]);
        A_C_Equipment_Status [5] = Dont_Destroy_On_Load.Ins._System_Settings.On_Convert_C_Equipment_Status (Home_System.Ins._Home_Status.A_Inventory_Value[_Player_Status.Slot_Offhand]);

        // Upgrade_Level Bonus : + 8%
        foreach (C_Equipment_Status s in A_C_Equipment_Status) {
            s.On_Upgrade_Level ();
        }


        foreach (C_Equipment_Status s in A_C_Equipment_Status) {
            Total_C_Equipment_Status.Level += s.Level;
            Total_C_Equipment_Status.Hp += s.Hp;
            Total_C_Equipment_Status.Mp += s.Mp;
            Total_C_Equipment_Status.Attack += s.Attack;
            Total_C_Equipment_Status.Defense += s.Defense;
            Total_C_Equipment_Status.Critical_Rate += s.Critical_Rate;
            Total_C_Equipment_Status.Critical_Damage += s.Critical_Damage;
            Total_C_Equipment_Status.Block_Chance += s.Block_Chance;
            Total_C_Equipment_Status.Penetration += s.Penetration;
            Total_C_Equipment_Status.Vitality += s.Vitality;
            Total_C_Equipment_Status.Mind += s.Mind;
            Total_C_Equipment_Status.Strength += s.Strength;
            Total_C_Equipment_Status.Agility += s.Agility;
        }
    }
    #endregion
}
