using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public Sound[] sounds;    
    public Sound theme;
   
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
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
