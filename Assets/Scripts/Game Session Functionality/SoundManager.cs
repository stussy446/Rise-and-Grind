using System;
using UnityEngine;

public class SoundManager: MonoBehaviour
{

    [SerializeField] Sound[] sounds;
    float[] soundVolumes;
    int count = 0;

    public static SoundManager instance; // static reference to current SoundManager in scene


    private void Awake()
    {
        // singleton pattern to make sure only one SoundManager persists per scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // for every Sound in the array, creates a new audiosource on the sound with setup
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;

        }


    }


    private void Start()
    {
        Play("Effervesce");
        soundVolumes = new float[sounds.Length];
        foreach (Sound sound  in sounds)
        {
            soundVolumes[count] = sound.audioSource.volume;
            count++;
        }

        count = 0;
    }


    /// <summary>
    /// Designed for use throughout game, allows you to call play on a Sound of
    /// your choice by passing in the name of the Sound (each Sound has a name in inspector)
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound != null)
        {
            sound.audioSource.Play();

        }
    }


    public void Mute()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource.volume = 0f; 
        }
    }


    public void UnMute()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource.volume = soundVolumes[count];
            count++;
        }

        count = 0;
    }

    public void ResetSound()
    {
        Destroy(this.gameObject);
    }
    
}
