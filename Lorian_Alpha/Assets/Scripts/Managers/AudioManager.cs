using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] miscSounds, enemySounds, heroSounds, backgroundMusic;

    private void Awake()
    {
        instance = this;

        foreach (var miscS in miscSounds)
        {
            if (miscS.myGameObject) 
            { 
                miscS.source = miscS.myGameObject.AddComponent<AudioSource>();
            }
            else 
            {
                miscS.source = gameObject.AddComponent<AudioSource>();
            }
              
            miscS.source.clip = miscS.clip;
            miscS.source.outputAudioMixerGroup = miscS.mixerGroup;
            miscS.source.volume = miscS.vol;
            miscS.source.pitch = miscS.pitch;
            miscS.source.spatialBlend = miscS.spatialBlend;
            miscS.source.playOnAwake = miscS.playOnAwake;

            if (miscS.playOnAwake) 
            {
                miscS.source.Play();
            }
                
            miscS.source.loop = miscS.loop;
        }

        foreach (var enemyS in enemySounds)
        {
            if (enemyS.myGameObject)
            {
                enemyS.source = enemyS.myGameObject.AddComponent<AudioSource>();
            }
            else
            {
                enemyS.source = gameObject.AddComponent<AudioSource>();
            }

            enemyS.source.clip = enemyS.clip;
            enemyS.source.outputAudioMixerGroup = enemyS.mixerGroup;
            enemyS.source.volume = enemyS.vol;
            enemyS.source.pitch = enemyS.pitch;
            enemyS.source.spatialBlend = enemyS.spatialBlend;
            enemyS.source.playOnAwake = enemyS.playOnAwake;

            if (enemyS.playOnAwake)
            {
                enemyS.source.Play();
            }

            enemyS.source.loop = enemyS.loop;
        }

        foreach (var heroS in heroSounds)
        {
            if (heroS.myGameObject)
            {
                heroS.source = heroS.myGameObject.AddComponent<AudioSource>();
            }
            else
            {
                heroS.source = gameObject.AddComponent<AudioSource>();
            }

            heroS.source.clip = heroS.clip;
            heroS.source.outputAudioMixerGroup = heroS.mixerGroup;
            heroS.source.volume = heroS.vol;
            heroS.source.pitch = heroS.pitch;
            heroS.source.spatialBlend = heroS.spatialBlend;
            heroS.source.playOnAwake = heroS.playOnAwake;

            if (heroS.playOnAwake)
            {
                heroS.source.Play();
            }

            heroS.source.loop = heroS.loop;
        }

        foreach (var backMusic in backgroundMusic)
        {
            if (backMusic.myGameObject)
            {
                backMusic.source = backMusic.myGameObject.AddComponent<AudioSource>();
            }
            else
            {
                backMusic.source = gameObject.AddComponent<AudioSource>();
            }

            backMusic.source.clip = backMusic.clip;
            backMusic.source.outputAudioMixerGroup = backMusic.mixerGroup;
            backMusic.source.volume = backMusic.vol;
            backMusic.source.pitch = backMusic.pitch;
            backMusic.source.spatialBlend = backMusic.spatialBlend;
            backMusic.source.playOnAwake = backMusic.playOnAwake;

            if (backMusic.playOnAwake)
            {
                backMusic.source.Play();
            }

            backMusic.source.loop = backMusic.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound miscS = Array.Find(miscSounds, sound => sound.name == name);
        Sound enemyS = Array.Find(enemySounds, sound => sound.name == name);
        Sound heroS = Array.Find(heroSounds, sound => sound.name == name);
        Sound backMusic = Array.Find(backgroundMusic, sound => sound.name == name);

        if (miscS != null)
        {
            miscS.source.PlayOneShot(miscS.clip);
        }

        if (enemyS != null)
        {
            enemyS.source.PlayOneShot(enemyS.clip);
        }

        if (heroS != null)
        {
            heroS.source.PlayOneShot(heroS.clip);
        }

        if(backMusic != null)
        {
            backMusic.source.PlayOneShot(backMusic.clip);
        }
    }
}
