using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioClip CollectibleSound;
    public AudioSource AudioSource;

    
    //plays the collectible sound
    public void playSound()
    {
        AudioSource.Stop();
        AudioSource.clip = CollectibleSound;
        AudioSource.Play();
    }


    
}
