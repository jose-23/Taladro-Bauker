using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public float speed = 2f;
    public float speed_max = 5f;
    private Animator anim;
    private Rigidbody2D rb2d;
    public bool grounded;
    public float jumpPower = 6.5f;
    private bool jump;
    public bool saltar_escalado;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
        }//detectamos salto

        if (Input.GetKeyDown(KeyCode.Space) && saltar_escalado)
        {
            jump = true;
        }//detectamos salto cuando está escalando


        if (Input.GetKeyDown(KeyCode.O)) SceneManager.LoadScene(escenaActual());
        if (Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene(escenaActual()+1);

    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //mathf.abs saca el valor absoluto. Estamos asignando la velocidad
        anim.SetBool("Grounded", grounded);




        float h = Input.GetAxis("Horizontal");

        /////////////////LIMITANDO VELOCIDAD//////////////////
        //si la velocidad se pasa del limite la pondremos en 1
        if (rb2d.velocity.x > speed_max)
        {
            rb2d.velocity = new Vector3(1, rb2d.velocity.y, transform.position.z);
        }
        //si la velocidad se pasa del limite la pondremos en 1
        if (rb2d.velocity.x < -speed_max)
        {
            rb2d.velocity = new Vector3(-1, rb2d.velocity.y, transform.position.z);
        }
        /////////////////LIMITANDO VELOCIDAD//////////////////

        rb2d.velocity = new Vector3(h * speed, rb2d.velocity.y, transform.position.z);

        Debug.Log(rb2d.velocity.x); //muestra la velocidad por consola




        ////////PERSONAJE SE GIRE////////////////////////
        if (h < 0)
        { //va hacia la izquierda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (h > 0)
        { //va hacia la derecha
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        ////////PERSONAJE SE GIRE////////////////////////


        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }


        //CAMARA SE MUEVA
        Camera.main.transform.position = transform.position - new Vector3(0, 0, 20);

    }

    int escenaActual() {
        return SceneManager.GetActiveScene().buildIndex; //devuelve la escena actual

    }
}
