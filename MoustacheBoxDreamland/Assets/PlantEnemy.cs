using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime; //tiempo entre balas
    public float waitTimeToAttack = 3; //tiempo de cada bala
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform lauchSpawnPoint; //posicion de lanzamiento

}
