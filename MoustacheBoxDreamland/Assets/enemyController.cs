using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
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
        float limitEspeed = Mathf.Clamp(rb2d.velocity.x, -speed_max, speed_max);
        rb2d.velocity = new Vector3(limitEspeed, rb2d.velocity.y);
        Debug.Log(rb2d.velocity.x);
        if (rb2d.velocity.x > 0.01f && rb2d.velocity.x < -0.01f) {
            speed = -speed;
            rb2d.velocity = new Vector3(speed, rb2d.velocity.y, transform.position.z);
        }
    }
}
