using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip hit;
    public AudioClip death;
    public AudioClip speedBomb;

    void Start()
    {
        soundManager = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
