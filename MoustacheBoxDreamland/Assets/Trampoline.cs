using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Trampoline : MonoBehaviour
{
    public AudioSource clip;

    public Animator animator;
    public float jumpForce = 2f;


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.transform.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            animator.Play("JumpTrampoline");
            clip.Play();
        }
    }
}
