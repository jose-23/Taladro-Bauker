using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamara : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minPos, maxPos, minPoss, maxPoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool fase=infoPartida.infoPlayer.faseDos;

        float posx = follow.transform.position.x;
        float posy = follow.transform.position.y;

        float posxx = follow.transform.position.x;
        float posyy = follow.transform.position.y;

        transform.position = new Vector3(

            Mathf.Clamp(posx, minPos.x, maxPos.x),
            Mathf.Clamp(posy, minPos.y, maxPos.y),
            -10);

        if (fase) {
            
            
            transform.position = new Vector3(

            Mathf.Clamp(posxx, minPoss.x, maxPoss.x),
            Mathf.Clamp(posyy, minPoss.y, maxPoss.y),
            -10);

        }
    }
}
