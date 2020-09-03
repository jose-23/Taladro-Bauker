using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Controller : MonoBehaviour
{
    public AudioSource clip;

    public float speed = 2f;
    public float speed_max = 5f;
    private Animator anim;
    private Rigidbody2D rb2d;
    public bool grounded;
    public float jumpPower = 6.5f;
    private bool jump;
    public bool saltar_escalado;
    private bool movement = true;
    private SpriteRenderer spr;
    public bool dead;
    private bool deadf;
    public bool teletransporte;
    public bool cargar_partida;
    int cont_muerte = 0;
    public bool CollisionEnemy;
    public bool CollisionEnemyDef;
    public int vidasPlayer=5;
    public Text VidasRestantes;
    public int cont_guardado = 0;
    public bool sgteLvl;
    public int contLvl=0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spr= GetComponent<SpriteRenderer>();
        infoPartida.realizar = false;
        if (infoPartida.PartidaGuardada) cargarPartida();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !deadf)
        {
            jump = true;
        }//detectamos salto

        if (Input.GetKeyDown(KeyCode.Space) && saltar_escalado && !deadf)
        {
            jump = true;
        }//detectamos salto cuando está escalando


        /*if (Input.GetKeyDown(KeyCode.O)) SceneManager.LoadScene(escenaActual());
        if (Input.GetKeyDown(KeyCode.P)) {
            contLvl += 1;
            if (contLvl == 1)
            { //lvl2
                infoPartida.infoPlayer.posicion = new Vector2(-7, -3);
            }
            if (contLvl == 2)
            { //lvl3
                infoPartida.infoPlayer.posicion = new Vector2(-9, -17);
            }
            SceneManager.LoadScene(escenaActual() + 1);
        }*/
        



        //if (Input.GetKeyDown(KeyCode.K)) guardarPartida();
        if (Input.GetKeyDown(KeyCode.L)) cargarPartida();

        if (cont_guardado == 0) guardarPartida();
        if (cont_guardado == 0) cont_guardado+=1;

    }

    private void FixedUpdate()
    {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //mathf.abs saca el valor absoluto. Estamos asignando la velocidad
        anim.SetBool("Grounded", grounded);

        anim.SetBool("Dead", deadf);

        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        /////////////////LIMITANDO VELOCIDAD//////////////////
        //si la velocidad se pasa del limite la pondremos en 1
        if (rb2d.velocity.x > speed_max && !deadf)
        {
            rb2d.velocity = new Vector3(1, rb2d.velocity.y, transform.position.z);
        }
        //si la velocidad se pasa del limite la pondremos en 1
        if (rb2d.velocity.x < -speed_max && !deadf)
        {
            rb2d.velocity = new Vector3(-1, rb2d.velocity.y, transform.position.z);
        }
        /////////////////LIMITANDO VELOCIDAD//////////////////
        if (!deadf) {
            rb2d.velocity = new Vector3(h * speed, rb2d.velocity.y, transform.position.z);
        }


        //Debug.Log(rb2d.velocity.x); //muestra la velocidad por consola




        ////////PERSONAJE SE GIRE////////////////////////
        if (h < 0 && !deadf)
        { //va hacia la izquierda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (h > 0 && !deadf)
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
        //Camera.main.transform.position = transform.position - new Vector3(0, 0, 20);
        cargar_partida = false;

        infoPartida.infoPlayer.faseDos = teletransporte;

        MuerteDef();
        MuerteDefDos();
        VidasRestantes.text = vidasPlayer.ToString();
        SgteLvl();

        if (infoPartida.realizar) {
            deadf = true;
            infoPartida.realizar = false;
        }

        if (infoPartida.infoPlayer.vidas == 0) {
            GameOver();
        }


    }

    public void GameOver() {
        print("carga creditos pls");
    }

    public void SgteLvl() {
        if (sgteLvl)
        {
            sgteLvl = false;
            contLvl += 1;
            if (contLvl == 1) { //lvl2
                infoPartida.infoPlayer.posicion = new Vector2(-7, -3);
            }
            if (contLvl == 2)
            { //lvl3
                infoPartida.infoPlayer.posicion = new Vector2(-9, -17);
            }


            SceneManager.LoadScene(escenaActual() + 1);
        }
    }

    int escenaActual() {

        return SceneManager.GetActiveScene().buildIndex; //devuelve la escena actual

    }
    public void EnemyJump() {
        jump = true;
    }

    public void MuerteDef() {
        if (CollisionEnemy) {
            deadf = true;
        }
    }

    public void MuerteDefDos()
    {
        if (CollisionEnemyDef)
        {
            deadf = true;
          

        }
    }


    public void EnemyKnockBack(float EnemyPosX) {
        //salto si el enemigo te golpea
        //choca con cualquier parte del cuerpo menos los pies

        if (dead) //choca con los pies
            {
            jump = true;
            float side = Mathf.Sign(EnemyPosX - transform.position.x);
            rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
            


        }
        else {
            deadf = true;
            

        }






        //tiempo de salto sin poder moverse
        movement = false;
        Invoke("EnableMovement",0.7f);

        Color color = new Color(250/255f,82/255f,11/255f);
        spr.color = color;

    }

    void EnableMovement() {
        movement = true;
        spr.color = Color.white;
    }



    void Muerte() {

        infoPartida.infoPlayer.vidas = vidasPlayer-1;
        //Destroy(gameObject);
        //SceneManager.LoadScene(escenaActual());
        //cargarPartida();
        SceneManager.LoadScene(escenaActual());
        clip.Play();


    }



    //muerte personaje al colisionar con un enemigo.
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") {
            UpdateState("Dead");
        }
    }*/



    //El PERSONAJE DESAPARECE DE LA CAMARA
    void OnBecameInvisible() {
        cont_muerte += 1;

        if (infoPartida.infoPlayer.faseDoss) {
            deadf = false;
            infoPartida.infoPlayer.faseDoss=false;
        }


        else if (!cargar_partida)
        {
            deadf = true;
        }

   
    }



    public void guardarPartida() {
        infoPartida.infoPlayer.posicion = transform.position;
        infoPartida.PartidaGuardada = true;
        infoPartida.infoPlayer.vidas = vidasPlayer;
    }

    void cargarPartida() {
        cargar_partida = true;
        transform.position=infoPartida.infoPlayer.posicion;
        teletransporte = infoPartida.infoPlayer.faseDos;
        vidasPlayer=infoPartida.infoPlayer.vidas;
    }

}
