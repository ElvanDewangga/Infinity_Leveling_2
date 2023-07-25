using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprite_Reader : MonoBehaviour {
    [SerializeField]
    Sprite [] A_Sprite_Img;
    [SerializeField]
    Image _Image;
    [SerializeField]
    SpriteRenderer _SpriteRenderer;
    float Time_Smooth = 0.1f;
    void OnEnable () {
        Debug.Log ("Enable");
        Cur_Sp = 0;
        C_N_Animation = StartCoroutine (N_Animation ());
    }

    Coroutine C_N_Animation;
    int Cur_Sp;
    IEnumerator N_Animation () {
        Cur_Sp ++;
        if (Cur_Sp >= A_Sprite_Img.Length) {
            Cur_Sp = 0;
        }
        yield return new WaitForSeconds (Time_Smooth);
        if (_Image) {
            _Image.sprite = A_Sprite_Img[Cur_Sp];
        } else if (_SpriteRenderer) {
            _SpriteRenderer.sprite = A_Sprite_Img[Cur_Sp];
        }
        C_N_Animation = StartCoroutine (N_Animation ());
    }

    void OnDisable () {
        if (C_N_Animation != null) {StopCoroutine (C_N_Animation);}
    }
}
