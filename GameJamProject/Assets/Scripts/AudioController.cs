using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] Sounds [] gameSounds;

    // Start is called before the first frame update

    private void Awake()
    {
        foreach (Sounds sounds in gameSounds)
        {
            sounds.source = gameObject.AddComponent<AudioSource>();
            sounds.source.clip = sounds.clip;

            sounds.source.volume = sounds.volume;
            sounds.source.pitch = sounds.pitch;
        }
    }

    public void Play (string name)
    {
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        sound.source.Play();
    }
}
