using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Syarat_Keseluruhan_AI : MonoBehaviour {
    #region Pengaturan_Umum
    [SerializeField]
    float No_Cd_Time;
    #endregion
    #region On_Check_AI
    // Sp_Normal_Slash :
    Player_2d Target_Player_2d;
    Enemy_2d Target_Enemy_2d;
    [HideInInspector]
    public string Serangan_From = ""; // "Player" / "Enemy"
    // public C_Home_Status _C_Home_Status;
    // Skill_Data_Editor :
    public void On_Check_AI (Enemy_2d Target_Enemy_2d_V, Skill_Data_Kumpulan Sdk, Skill_Data_Editor Sde) {
        Serangan_From = "Enemy";
        Target_Enemy_2d = Target_Enemy_2d_V; _Skill_Data_Editor = Sde;
        _Skill_Data_Kumpulan = Sdk;
        // _C_Home_Status = Target_Enemy_2d.gameObject.GetComponent <Online_Player_Status> ().GMP_C_Home_Status;
        On_Spawn_Area ();
        this.gameObject.SetActive (true);
        // StartCoroutine (N_On_Destroy ());
    }
    #endregion

    #region Kumpulan_Skill_Syarat_AI_Collider_Check
    public bool b_Enemy_Boleh_Mengeluarkan_Skill = false;
    public List <Skill_Syarat_AI_Collider_Check> L_Skill_Syarat_AI_Collider_Check = new List <Skill_Syarat_AI_Collider_Check> ();
    public List <Skill_Syarat_Cd_Time> L_Skill_Syarat_Cd_Time = new List <Skill_Syarat_Cd_Time> ();
    // Skill_Syarat_AI_Collider_Check / SKill_Syarat_Cd_Time :
    public void On_Skill_Syarat_AI_Collider_Check () {
        b_Enemy_Boleh_Mengeluarkan_Skill = On_Check_Enemy_Boleh_Mengeluarkan_Skill ();
        
        if (b_Enemy_Boleh_Mengeluarkan_Skill) {
            if (C_N_On_Enemy_Mengeluarkan_Skill == null) {
                C_N_On_Enemy_Mengeluarkan_Skill = StartCoroutine (N_On_Enemy_Mengeluarkan_Skill ());
            }
            
        } else {

        }
    }

    void Start () {
        if (L_Skill_Syarat_Cd_Time.Count == 0) {
            StartCoroutine (N_L_Skill_Syarat_Cd_Time ());
        }
    }
    #region No_Cd_Time
    
    IEnumerator N_L_Skill_Syarat_Cd_Time () {
        yield return new WaitForSeconds (No_Cd_Time);

        On_Skill_Syarat_AI_Collider_Check ();
        StartCoroutine (N_L_Skill_Syarat_Cd_Time ());
    }

    #endregion

    Coroutine C_N_On_Enemy_Mengeluarkan_Skill;
    IEnumerator N_On_Enemy_Mengeluarkan_Skill () {
        yield return new WaitUntil (() => Target_Enemy_2d.b_Can_Skill == true);
        On_Enemy_Mengeluarkan_Skill ();
        C_N_On_Enemy_Mengeluarkan_Skill = null;
        
    }

    bool On_Check_Enemy_Boleh_Mengeluarkan_Skill () {
        bool Result = true;
        foreach (Skill_Syarat_AI_Collider_Check Cek  in L_Skill_Syarat_AI_Collider_Check) {
            if (Cek.b_Sub_Syarat == false) {
                Result = false;
                break;
            }
        }
        foreach (Skill_Syarat_Cd_Time Cek  in L_Skill_Syarat_Cd_Time) {
            if (Cek.b_Sub_Syarat == false) {
                Result = false;
                break;
            }
        }
        return Result;
    }
    
    #endregion
    #region Enemy_Mengeluarkan_Skill
    Skill_Data_Editor _Skill_Data_Editor;
    Skill_Data_Kumpulan _Skill_Data_Kumpulan;
    void On_Enemy_Mengeluarkan_Skill () {
        foreach (Skill_Syarat_Cd_Time Cek  in L_Skill_Syarat_Cd_Time) {
            Cek.On_Count_Cd_Time ();
        }
        _Skill_Data_Editor.On_Play_Skill (Target_Enemy_2d,_Skill_Data_Kumpulan);
    }
    #endregion
    #region Spawn_Area
    [SerializeField]
    string Code_Spawn = "";
    /* Code_Spawn :
    1. "Transform_Posisi_Depan" = Player_2d - Posisi_Depan
    2. "Transform_Posisi_Belakang" = Player_2d - Posisi_Belakang
    3. "Player_2d_Posisi_Titik_Tengah" = Player_2d - Asset_2d_Titik_Tengah

    */
    void On_Spawn_Area () {
        if (Code_Spawn == "Transform_Posisi_Depan") {
            this.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Depan);
            this.gameObject.transform.localPosition = Target_Enemy_2d.Posisi_Depan.localPosition;
        } else if (Code_Spawn == "Transform_Posisi_Belakang") {
            this.gameObject.transform.SetParent (Target_Enemy_2d.Posisi_Belakang);
            this.gameObject.transform.localPosition = Target_Enemy_2d.Posisi_Belakang.localPosition;
        } else if (Code_Spawn == "Player_2d_Posisi_Titik_Tengah") {
            this.gameObject.transform.SetParent (Target_Enemy_2d.Asset_2d_Titik_Tengah.transform);
            this.gameObject.transform.localPosition = Target_Enemy_2d.Asset_2d_Titik_Tengah.transform.localPosition;
        }
    }
    #endregion
    #region Destroy
    
    #endregion
}
