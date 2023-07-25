using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_Z_Script : MonoBehaviour{
    [SerializeField]
    float Z_Lock_Position = 200;

    // Update is called once per frame
    void Update() {
        this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, Z_Lock_Position);
    }
}
