using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class SaltoEnemigo : MonoBehaviour
{
    public float speed = 1f;
    public float speed_max = 1f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitspeed = Mathf.Clamp(rb2d.velocity.x, -speed_max, speed_max);
        rb2d.velocity = new Vector2(limitspeed, rb2d.velocity.y);

        //hace que el enemigo cambie de dirección al chocar.
        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector3(speed, rb2d.velocity.y, transform.position.z);
        }

        //Cambio de imagen.
        if (speed < 0)
        { //va hacia la izquierda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (speed > 0)
        { //va hacia la derecha
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    //colision con el protagonista
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //valor de altura sobre el enemigo para aplastarlo
            float yOffset = 1f;
            if ((transform.position.y + yOffset) < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }

        }
    }
}
