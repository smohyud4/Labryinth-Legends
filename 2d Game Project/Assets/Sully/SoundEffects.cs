using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    public AudioSource SoundEff;
    public AudioClip button_click;

    public void buttonClick()
    {
        SoundEff.clip = button_click;
        SoundEff.Play();
    }

}
