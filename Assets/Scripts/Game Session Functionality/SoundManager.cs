using System;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager: MonoBehaviour
{

    [SerializeField] Sound[] sounds;


    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }  
    }


    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound != null)
        {
            sound.audioSource.Play();

        }
    }
}
