using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalado : MonoBehaviour
{
    private Controller player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Controller>();
    }


    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "SaltarEscalado")
        {
            player.saltar_escalado = true;
        }

        if (col.gameObject.tag == "Transporte")
        {
            player.transform.position= new Vector2(119, -71);
            player.teletransporte = true;
        }


    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "SaltarEscalado")
        {
            player.saltar_escalado = false;
        }
    }
}
