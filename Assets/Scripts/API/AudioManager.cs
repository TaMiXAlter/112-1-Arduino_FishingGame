
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Fan, Su, Fever;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        _audioSource.loop = true;
    }

    public void PlayFan()
    {
        _audioSource.clip = Fan;
        _audioSource.Play();
    }
    public void PlaySu()
    {
        _audioSource.clip = Su;
        _audioSource.Play();
    }
    public void PlayFever()
    {
        _audioSource.clip = Fever;
        _audioSource.Play();
    }

    public void Pause() => _audioSource.Pause();

}
