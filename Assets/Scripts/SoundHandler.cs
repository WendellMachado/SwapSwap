using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;

    public void Play(int audio)
    {
        audioSource.clip = audioClips[audio];
        audioSource.Play();
    }
}
