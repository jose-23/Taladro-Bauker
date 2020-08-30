using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicSource;
    public AudioClip introMusic;
    public AudioClip menuMusic;
    public AudioClip effectClick;

    public static AudioManager instance;

    void Awake()
    {
        instance = this;
        
    }

    public void PlayEffect()
    {
        effectSource.PlayOneShot(effectClick);

    }

    public void PlaySong(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();

    }
}
