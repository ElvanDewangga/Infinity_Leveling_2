using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class Sp_Normal_Effect : MonoBehaviour {
    // On_Input_Action dipanggil langsung disetiap gameobjek yang kena.
    #region Pengaturan_Umum
    [Header ("Pengaturan Umum :")]
    public List <Class_Ability> L_Class_Ability;
    #endregion
    // Sp_Spawn_Ins :
    GameObject Target_GO;
    string Type_GO;
    Skill_Pengaturan_Animasi _Skill_Pengaturan_Animasi;
    public void On_Input_Action (Skill_Pengaturan_Animasi _Sp,  GameObject s , string Type_GO_V) {
        _Skill_Pengaturan_Animasi = _Sp;
        Target_GO = s;
        Type_GO = Type_GO_V;
        if (_Skill_Pengaturan_Animasi.Code_Mine == "Mine") {
            Lc_Send_Rpc (_Skill_Pengaturan_Animasi.Code_Skill_Name);
        } else {
            Lc_On_Class_Ability ();
        }
    }
    
    // Send Rpc_Playing_Effect (Action) :
    void Lc_Send_Rpc (string Code_Skill_Name_V) {
        if (Type_GO == "Player") {
            Target_GO.GetComponent <Online_Player_2d>().Hit_On_Mine_Lc_Skill_Animation (Code_Skill_Name_V);
        } else if (Type_GO == "Enemy") {
            Target_GO.GetComponent <Enemy_2d_Online>().Hit_On_Mine_Lc_Skill_Animation (Code_Skill_Name_V);
        }

        Lc_On_Class_Ability ();
    }

    #region Class_Ability
    Class_Ability Cls;
    public void Lc_On_Class_Ability () {
        Debug.Log ("0.0");
        int x = 0;
        if (Type_GO == "Player") {
            Debug.Log ("0.5");
            _Skill_Pengaturan_Animasi.On_Damage (Type_GO, Target_GO, this.gameObject);
        } else if (Type_GO == "Enemy") {
            _Skill_Pengaturan_Animasi.On_Damage (Type_GO, Target_GO, this.gameObject);
        }

        for (x =0; x < L_Class_Ability.Count; x++) {
            Cls = L_Class_Ability [x];
            if (Type_GO == "Player") {
                /*
                if (Cls._Ability_Type == Ability_Type.Damage_Power) {
                    Target_GO.gameObject.GetComponent <Online_Player_2d> ().On_Damage (_Skill_Pengaturan_Animasi, _Skill_Pengaturan_Animasi.Result_Damage ());
                } else if (Cls._Ability_Type == Ability_Type.Heal_Power) {

                } else if (Cls._Ability_Type == Ability_Type.Damage_Direct) {
                    
                } else if (Cls._Ability_Type == Ability_Type.Heal_Direct) {
                    Target_GO.gameObject.GetComponent <Online_Player_2d> ().On_Heal_Direct (_Skill_Pengaturan_Animasi, Cls.Value_Int_1);
                }
                */
            } else if (Type_GO == "Enemy") {
                /*
                if (Cls._Ability_Type == Ability_Type.Damage_Power) {
                    Target_GO.gameObject.GetComponent <Enemy_2d_Online> ().On_Damage (_Skill_Pengaturan_Animasi, _Skill_Pengaturan_Animasi.Result_Damage ());
                } else if (Cls._Ability_Type == Ability_Type.Heal_Power) {
                    
                } else if (Cls._Ability_Type == Ability_Type.Damage_Direct) {

                } else if (Cls._Ability_Type == Ability_Type.Heal_Direct) {
                    Target_GO.gameObject.GetComponent <Enemy_2d_Online> ().On_Heal_Direct (_Skill_Pengaturan_Animasi, Cls.Value_Int_1);
                }
                */
            }
        }
    }

    
    #endregion
    
}
