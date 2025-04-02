using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip musicClip2;
    private AudioSource musicSource;

    public static MusicManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void RestartTracks()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void ChangeTrack()
    {
        musicSource.Stop();
        musicSource.clip = musicClip2;
        musicSource.Play();
    }
}
