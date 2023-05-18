using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    public AudioSource audioSource;
    public List<AudioClip> clips;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOne(int idx)
    {
        audioSource.PlayOneShot(clips[idx]);
    }
}
