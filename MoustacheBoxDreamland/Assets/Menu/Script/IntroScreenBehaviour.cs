using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreenBehaviour : MonoBehaviour
{
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey == true)
        {
            //pasar a la pantalla de opciones
            optionsMenu.SetActive(true);
            gameObject.SetActive(false);
            AudioManager.instance.PlayEffect();
            AudioManager.instance.PlaySong(AudioManager.instance.menuMusic);
        }
        
    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene("NivelUno");

    }
}
