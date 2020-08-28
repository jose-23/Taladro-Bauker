using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class spikeRock : MonoBehaviour
{
    //parte spike
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            //Debug.Log("Player Damaged");
            //Destruye al personaje
            Destroy(col.gameObject);
        }
    }
}
