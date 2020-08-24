using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour { 

    public GameObject target;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerOne") {
            print("Choque");
            //other.transform.position = target.transform.GetChild(0).transform.position;
        }
    }
    
}
