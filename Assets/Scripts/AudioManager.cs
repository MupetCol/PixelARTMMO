using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private bool replaceTheme;

    public Sound[] sounds;

    public static AudioManager instance;



    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (instance == null)
            instance = this;
        else if(instance.sounds[0].name != sounds[0].name)
        {
            instance.StopPlaying(instance.sounds[0].name);
            Destroy(instance);
            instance = this;
            Play(sounds[0].name);
            return;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        Play(sounds[0].name);
    }

    public void Play(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not founnd!");
            return;
        }
        Debug.Log("Tried to play");
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not founnd!");
            return;
        }
        s.source.Stop();
    }

}
