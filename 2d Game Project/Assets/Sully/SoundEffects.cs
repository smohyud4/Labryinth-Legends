using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    public AudioSource SoundEff;
    //public AudioClip button_click;
    public void buttonClick(AudioClip clip)
    {
        SoundEff.clip = clip;
        SoundEff.Play();
    }

}
