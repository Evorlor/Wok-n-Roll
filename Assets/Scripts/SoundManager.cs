using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioLoop
{
    public AudioSource source;
    public float lastPlayTime;
}

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

    public float LoopTime = 5.0f;

    private Dictionary<AudioClip, AudioLoop> audioSourceList = new Dictionary<AudioClip, AudioLoop>();

    void Awake()
    {
		instance = this;

    }


    void FixedUpdate()
    {
        var keys = new List<AudioClip>(audioSourceList.Keys);
        foreach (var key in keys)
        {
            if (Time.fixedTime - audioSourceList[key].lastPlayTime > LoopTime)
            {
                if (!audioSourceList[key].source.isPlaying)
                {
                    audioSourceList[key].lastPlayTime = Time.fixedTime;
                    audioSourceList[key].source.Play();
                }
            }
        }
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }


    public void PlayLoop(AudioClip clip)
    {
        if (!audioSourceList.ContainsKey(clip))
        {
            AudioLoop loop = new AudioLoop();
            loop.source = this.gameObject.AddComponent<AudioSource>();
            loop.lastPlayTime = Time.fixedTime;
            loop.source.clip = clip;
            loop.source.Play();
            audioSourceList.Add(clip, loop);
        }
    }

    public void StopLoop(AudioClip clip)
    {
        if (audioSourceList.ContainsKey(clip))
        {
            if (audioSourceList[clip].source.isPlaying)
                audioSourceList[clip].source.Stop();
            Destroy(audioSourceList[clip].source);
            audioSourceList.Remove(clip);
        }
    }
}