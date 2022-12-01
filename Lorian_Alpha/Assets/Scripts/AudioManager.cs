using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        instance = this;

        foreach (var s in sounds)
        {
            if (s.myGameObject) 
            { 
                s.source = s.myGameObject.AddComponent<AudioSource>();
            }
            else 
            {
                s.source = gameObject.AddComponent<AudioSource>();
            }
              
            s.source.clip = s.clip;
            s.source.volume = s.vol;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
            s.source.playOnAwake = s.playOnAwake;

            if (s.playOnAwake) 
            {
                s.source.Play();
            }
                
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sonido => sonido.name == name);
        if (s != null)
        {
            s.source.PlayOneShot(s.clip);
        }
    }
}
