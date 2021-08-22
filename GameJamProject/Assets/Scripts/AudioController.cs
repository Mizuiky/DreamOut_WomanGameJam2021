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
            sounds.source.loop = sounds.loop;
        }
    }

    public void play (string name)
    {
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        sound.source.Play();   
    }

    public void stop(string name)
    {
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        sound.source.Stop();
    }

    public void startToWake()
    {
        //Debug.Log("start wake");
        StartCoroutine(wakeUp());
    }

    private IEnumerator wakeUp()
    {
        //Debug.Log("stop dreambackground");
        setSoundVolume("DreamBackground", 0.03f);
        //Debug.Log("play gameover");
        play("WakeUp");
        yield return new WaitForSeconds(0.2f);
        play("GameOver");
    }

    public void setSoundVolume(string name, float volume)
    {
        //Debug.Log("Entered in setsoundvalume");
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        //Debug.Log("source name " + sound.name);
        sound.source.volume = volume;
        //Debug.Log("volume: " + sound.source.volume.ToString());
    }
}
