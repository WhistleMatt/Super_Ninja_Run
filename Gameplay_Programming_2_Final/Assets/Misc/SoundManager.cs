using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public List<AudioClip> clips = new List<AudioClip>();
    public static SoundManager instance;
    private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestSound(int clip)
    {
        audioPlayer.clip = clips[clip];
        audioPlayer.Play();
    }
}
