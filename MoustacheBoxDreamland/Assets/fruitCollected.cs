using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class fruitCollected : MonoBehaviour
{
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //activa la animación de la recolección 
            
            Destroy(gameObject, 0.4f);
            clip.Play();
        }
    }
}
