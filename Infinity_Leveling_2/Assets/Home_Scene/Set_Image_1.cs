using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Set_Image_1 : MonoBehaviour {
    [SerializeField]
    TMP_Text [] A_Text;

    // Hall_Of_Masters :
    public void On_Write_Text (string Text_1, string Text_2) {
        A_Text[0].text = Text_1;
        A_Text[1].text = Text_2;
    }
}
