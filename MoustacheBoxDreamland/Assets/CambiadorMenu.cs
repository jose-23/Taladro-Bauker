﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambiadorMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EscenaJuego()
    {
        infoPartida.multi = false;
        SceneManager.LoadScene("NivelUno");

    }

    public void MultiJugadorInicia()
    {
        infoPartida.multi = true;
        SceneManager.LoadScene("NivelUno");

    }

    public void Salir()
    {

        Application.Quit();
    }
}
