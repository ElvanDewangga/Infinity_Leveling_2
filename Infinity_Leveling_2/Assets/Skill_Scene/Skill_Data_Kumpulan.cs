using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skill_Data_Kumpulan : MonoBehaviour {
    // Attach at Skill_Active / Passive (Player_2d & Skill_Data_Editor (Children)).
#region Database_Load
    public string Skill_Name = "";
    public int Skill_Level = 0;
    [SerializeField]
    string Skill_Type = ""; // Active / Passive.

    // ----- Player_2d : (Player_2d) (Online) / Load_Local_Hall_Of_Masters.
    // Online_Player_2d (Animation Only - Not_Mine)
    public void Database_Load_Skill_Name (string Name) {
        Skill_Name= Name;
        On_Search_Skill_Data ();
    }

    public void Database_Load_Skill_Level (string Level) {
        int.TryParse (Level, out Skill_Level);
    }

    
    // Load_Visual_Novel - Player_2d : Dipanggil ketika sudah load skill_Keterangan.
    public void On_Re_Search_Skill_Data () {
        On_Search_Skill_Data ();
    }
    // (Skill_Data_Editor (Children)) = langsung diisi di inspector.
#endregion
#region Database_Tetap
    [SerializeField]
    Skill_Data_Online _Skill_Data_Online;

    [SerializeField]
    // GMP_SKill_Button / Online_Player_2d (Animation_Only Not_Mine) :
    public Skill_Data_Editor _Skill_Data_Editor;

    [HideInInspector]
    public Skill_Keterangan _Skill_Keterangan;
    
    
    // Load_Visual_Novel : (Setelah load skill keterangan dari Hall_Of_Masters - Load_Visual_Novel).
    public void Database_Tetap_Skill_Keterangan (Skill_Keterangan Sk) {
        _Skill_Keterangan = Sk;
        On_Search_Skill_Data ();
    }

    void On_Search_Skill_Data () {
        if (Skill_Type == "Active") {
            foreach (Transform Trs in Home_System.Ins.Editor_Skill_Active_Trans) {
                Skill_Data_Kumpulan Sk= Trs.gameObject.GetComponent <Skill_Data_Kumpulan> ();
                if (Sk.Skill_Name == Skill_Name) {
                    On_Transfer_Database_Tetap_to_This (Sk);
                }
            }
        } else if (Skill_Type == "Passive") {
            foreach (Transform Trs in Home_System.Ins.Editor_Skill_Passive_Trans) {
                Skill_Data_Kumpulan Sk= Trs.gameObject.GetComponent <Skill_Data_Kumpulan> ();
                if (Sk.Skill_Name == Skill_Name) {
                    On_Transfer_Database_Tetap_to_This (Sk);
                }
            }
        }
    }
    
    void On_Transfer_Database_Tetap_to_This (Skill_Data_Kumpulan V) {
        _Skill_Data_Online = V._Skill_Data_Online;
        _Skill_Data_Editor = V._Skill_Data_Editor;
        _Skill_Keterangan = V._Skill_Keterangan;
    }

#endregion
#region Enemy_2d
    // Enemy_2d (Load Skill untuk Enemy):
    public int Urutan_Skill = -1; // 0 -3
    public void Database_Load_Skill_Name_And_Skill_Level (int Urutan_Skill_V, string Name, int Level, Enemy_2d V) {
        Urutan_Skill = Urutan_Skill_V;
        Skill_Name = Name;
        Skill_Level = Level;
        On_Search_Skill_Data ();
        if (_Skill_Data_Editor != null) {
            _Skill_Data_Editor.On_Skill_Syarat_Keseluruhan_AI  (V, this);
        }
    }
#endregion
}
