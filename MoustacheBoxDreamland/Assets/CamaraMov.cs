using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMov : MonoBehaviour
{

    public GameObject follow;
    public Vector2 minPos, maxPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posx=follow.transform.position.x;
        float posy=follow.transform.position.y;

        transform.position = new Vector3(
            
            Mathf.Clamp(posx,minPos.x,maxPos.x),
            Mathf.Clamp(posy,minPos.y,maxPos.y),
            -10);
    }
}
