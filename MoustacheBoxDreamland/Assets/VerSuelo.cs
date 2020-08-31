using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerSuelo : MonoBehaviour
{
    private Controller player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Controller>();
    }

    // Update is called once per frame

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player.grounded = true;
        }

        if (col.gameObject.tag == "GroundDan")
        {
            player.grounded = true;
            player.CollisionEnemyDef = true;
        }

        if (col.gameObject.tag == "platform")
        {
            player.transform.parent = col.transform; //se cambia las coordenadas junto con la plataforma, se usa col pq hace referencia al objeto
            player.grounded = true;
        }

        /*if (col.gameObject.tag == "Enemy") {
            player.dead = true;
        }*/
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player.grounded = false;
        }



        if (col.gameObject.tag == "platform")
        {
            player.transform.parent = null; //ya no está junto a la plataforma
            player.grounded = false;
        }
    }
}
