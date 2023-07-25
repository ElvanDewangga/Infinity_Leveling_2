using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Visual_Novel_Kalimat {
    public int Id;
    public string Left_Name;
    public string Right_Name;
    public string Left_Img;
    public string Right_Img;
    public string Position;
    public string Dialog_Text;
    public string Event;
    
    public Visual_Novel_Kalimat (Visual_Novel_Kalimat d) {
        Id = d.Id;
        Left_Name = d.Left_Name;
        Right_Name = d.Right_Name;
        Left_Img = d.Left_Img;
        Right_Img = d.Right_Img;
        Position = d.Position;
        Dialog_Text = d.Dialog_Text;
        Event = d.Event;
        
    }

    public Visual_Novel_Kalimat () {
        
    }
}
