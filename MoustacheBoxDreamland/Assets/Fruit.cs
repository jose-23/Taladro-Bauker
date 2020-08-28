using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public Text total;
    public Text cantidad;
    private int TotalFruits;

    private void Start() {
        TotalFruits = transform.childCount;
    }
    private void Update() {
        allFruitCollected();
        total.text = TotalFruits.ToString();
        cantidad.text = transform.childCount.ToString();
    }

    public void allFruitCollected() {
        if (transform.childCount == 0) {
            //Debug.Log("¡No quedan frutas!");
        }
    }
}
