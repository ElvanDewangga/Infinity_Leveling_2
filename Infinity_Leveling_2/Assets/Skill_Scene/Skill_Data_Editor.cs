using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Data_Editor : MonoBehaviour {
    public Sprite Skill_Sprite_Box;
    // Check_Box_Type_2 :
    public Sprite Skill_Sprite_Settings;
   
   // [SerializeField]
   // GMP_Skill_Button :
    public bool b_Skill_Cd_Time = false;
    [HideInInspector]
    public Skill_Cd_Time _Skill_Cd_Time;
    public bool b_Skill_Hold_Time = false;
    [HideInInspector]
    public Skill_Hold_Time _Skill_Hold_Time;
    public bool b_Skill_Multiple_Click = false;
    [HideInInspector]
    public Skill_Multiple_Click _Skill_Multiple_Click;
    void Start () {
        if (b_Skill_Cd_Time) {
            _Skill_Cd_Time = this.GetComponent <Skill_Cd_Time>();
        }
        if (b_Skill_Hold_Time) {
            _Skill_Hold_Time = this.GetComponent <Skill_Hold_Time>();
        }
        if (b_Skill_Multiple_Click) {
            _Skill_Multiple_Click = this.GetComponent <Skill_Multiple_Click>();
        }
    }
    #region Skill_Pengaturan_Animasi
    public Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi;
    Skill_Pengaturan_Animasi Ins_Skill_Pengaturan_Animasi;
    // // GMP_Skill_Button 
    public void On_Play_Skill (Player_2d Target_Player_2d, Skill_Data_Kumpulan Sdk) {
         GameObject Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.gameObject);
        Ins.GetComponent <Skill_Pengaturan_Animasi> ().On_Play_Animasi (Target_Player_2d, Sdk, "Mine");
        Ins_Skill_Pengaturan_Animasi = Ins.GetComponent <Skill_Pengaturan_Animasi>();
    }
    // Skill_Pengaturan_Animasi - Online_Player_2d (Not_Mine Animation Only) :
    public void On_Play_Skill_Animation_Only (Player_2d Target_Player_2d, Skill_Data_Kumpulan Sdk) {
         GameObject Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.gameObject);
        Ins.GetComponent <Skill_Pengaturan_Animasi> ().On_Play_Animasi (Target_Player_2d, Sdk, "Not_Mine");
        Ins_Skill_Pengaturan_Animasi = Ins.GetComponent <Skill_Pengaturan_Animasi>();
    }
    // Skill_Syarat_Keseluruhan :
    public void On_Play_Skill (Enemy_2d Enemy_2d_V, Skill_Data_Kumpulan Sdk) {
         GameObject Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.gameObject);
        Ins.GetComponent <Skill_Pengaturan_Animasi> ().On_Play_Animasi (Enemy_2d_V, Sdk, "Mine");
        Ins_Skill_Pengaturan_Animasi = Ins.GetComponent <Skill_Pengaturan_Animasi>();
    }
    // Skill_Pengaturan_Animasi - Enemy_2d_Online :
    public void On_Play_Skill_Animation_Only (Enemy_2d Enemy_2d_V, Skill_Data_Kumpulan Sdk) {
         GameObject Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.gameObject);
        Ins.GetComponent <Skill_Pengaturan_Animasi> ().On_Play_Animasi (Enemy_2d_V, Sdk, "Not_Mine");
        Ins_Skill_Pengaturan_Animasi = Ins.GetComponent <Skill_Pengaturan_Animasi>();
    }
        #region Sp_Normal_Effect
        public void Rpc_Sp_Normal_Effect_Animation (Enemy_2d Enemy_2d_V, Skill_Data_Kumpulan Sdk) {
            Debug.LogError ("Taiga 0.4");
             GameObject Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.gameObject);
        Ins.GetComponent <Skill_Pengaturan_Animasi> ().Rpc_Sp_Normal_Effect_Animation (Enemy_2d_V, Sdk, "Not_Mine");
        }

        public void Rpc_Sp_Normal_Effect_Animation (Player_2d Target_Player_2d, Skill_Data_Kumpulan Sdk) {
            Debug.LogError ("Taiga 0.4");
                GameObject Ins = GameObject.Instantiate (_Skill_Pengaturan_Animasi.gameObject);
        Ins.GetComponent <Skill_Pengaturan_Animasi> ().Rpc_Sp_Normal_Effect_Animation (Target_Player_2d, Sdk, "Not_Mine");
        }
        #endregion

        #region Direct_Destroy
        // GMP_Skill_Button 
        public void On_Direct_Destroy () {
            Debug.Log ("Destroying");
            
            Ins_Skill_Pengaturan_Animasi.On_Direct_Destroy ();
        }

        // Online_Player_2d / Enemy_2d_Online :
        public void On_Direct_Destroy_Animation_Only (Skill_Pengaturan_Animasi Sk) {
            
            try {
                Sk.On_Direct_Destroy ();
            } catch (System.NullReferenceException) {
                Debug.Log ("Ada Enemy Mati");
            }
        }
        #endregion
    #endregion

    #region Skill_Syarat_Keseluruhan_AI
    public Skill_Syarat_Keseluruhan_AI _Skill_Syarat_Keseluruhan_AI;
    // Enemy_2d - Skill_Data_Kumpulan :
    public void On_Skill_Syarat_Keseluruhan_AI (Enemy_2d E, Skill_Data_Kumpulan Sdk) {
         GameObject Ins = GameObject.Instantiate (_Skill_Syarat_Keseluruhan_AI.gameObject);
        Ins.GetComponent <Skill_Syarat_Keseluruhan_AI>().On_Check_AI (E, Sdk, this);
    }
    #endregion

    
}
