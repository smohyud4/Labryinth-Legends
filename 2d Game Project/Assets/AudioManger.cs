using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public Sound[] sounds;    
    public Sound theme;
    public static AudioManger instance;
    public bool mainMenu = false;
    public bool bossroom = false;
   
    void Awake()
    {
        if (!mainMenu && !bossroom)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        if (bossroom) {
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            //s.source.volume = 0.5f;
            //s.source.pitch = 1f;
            if (s.name == "Sword Swing") s.source.volume = 0.1f;
        }
    }
    void Start()
    {
        if (theme.name != "NULL") 
        {
            theme.source = gameObject.AddComponent<AudioSource>();
            theme.source.clip = theme.clip;
            //theme.source.volume = theme.volume;
            //theme.source.pitch = theme.pitch;
            theme.source.loop = theme.loop;
            theme.source.Play();
        }
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
