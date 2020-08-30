using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime; //tiempo entre balas
    public float waitTimeToAttack = 3; //tiempo de cada bala
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint; //posicion de lanzamiento

    private void Start() {
        waitedTime = waitTimeToAttack;
    }

    private void Update() {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet",0.5f);
        }
        else {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet() {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab,launchSpawnPoint.position,launchSpawnPoint.rotation);
    }
}
