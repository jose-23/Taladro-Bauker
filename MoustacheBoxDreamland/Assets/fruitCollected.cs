using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitCollected : MonoBehaviour
{
    //public GameObject obj;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            //obj.gameObject.SetActive(true);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
