using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Both of these are public to allow for access throughout the program
    public AudioSource musicSource;
    public AudioSource SFXSource;


    public AudioClip Wizard_intro;


    void Start()
    {
        // When the game starts, this mp3 file will be played
        musicSource.clip = Wizard_intro;
        musicSource.Play();
    }

}





