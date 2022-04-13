using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;



[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = .75f;
    //[Range(.1f, 3f)] public float pitch = 1.0f;

    public bool loop = false;
    //public AudioMixerGroup mixerGroup;
    [HideInInspector] 
    public AudioSource source;
}
public class SoundManager : MonoBehaviour
{
    
    public static SoundManager soundManager;

    //public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
           //s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    private void Start()
    {
        
    }

    public void PlayAudio(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlaySFX(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void Pause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Pause();
    }

    public void StopAllMusic()
    {
        foreach (var s in sounds)
        {
            s.source.Stop();
        }
    }
}
