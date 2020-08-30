using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 2; //para que se destruya la bala cada cierto tiempo
    public bool left; //si quiero cambiar la direccion del enemigo

    private void Start() {
        Destroy(gameObject,lifeTime);
    }
    private void Update() {
        if (left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
