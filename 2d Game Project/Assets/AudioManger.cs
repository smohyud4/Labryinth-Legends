using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public Sound[] sounds;    
    public Sound theme;
    public static AudioManger instance;
    public bool proceed = false;
   
    void Awake()
    {

        if (proceed)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("Audio not Destroyed!");
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = 0.5f;
            //s.source.pitch = 1f;
            s.source.volume = s.volume;
        }

        theme.source = gameObject.AddComponent<AudioSource>();
        theme.source.volume = theme.volume;
        theme.source.clip = theme.clip;
        theme.source.loop = theme.loop;
    }
    void Start()
    {
        if (theme.name != "NULL") theme.source.Play();
    }
    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
        //Debug.LogWarning("Sound: " + name + " played!");
    }
}
