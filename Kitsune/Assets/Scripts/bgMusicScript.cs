using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusicScript : MonoBehaviour
{
    private AudioSource SoundSource;
    public AudioClip backgroundSong;

    // Start is called before the first frame update
    void Start()
    {
        SoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Awake()
    {
        SoundSource.clip = backgroundSong;
        SoundSource.Play();
    }
}
