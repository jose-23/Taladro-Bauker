using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCuerpo : MonoBehaviour
{
    private Controller player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Controller>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            player.CollisionEnemy = true;
        }

    }
}
