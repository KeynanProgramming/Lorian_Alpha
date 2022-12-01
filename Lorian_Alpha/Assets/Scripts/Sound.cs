using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;
    [HideInInspector]
    public GameObject myGameObject;
    [Range(0, 1)]
    public float vol = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    [Range(0, 1)]
    public float spatialBlend = 0;
    public bool playOnAwake;
    public bool loop;
}