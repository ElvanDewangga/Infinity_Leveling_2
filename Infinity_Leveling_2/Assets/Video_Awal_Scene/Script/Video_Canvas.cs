using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Video_Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Loading_Canvas.Ins.Off_Loading_4 ();
    }

    public void On_Skip () {
        Loading_Canvas.Ins.On_Loading_4 ();
        SceneManager.LoadScene ("Home_Scene");
    }

}
