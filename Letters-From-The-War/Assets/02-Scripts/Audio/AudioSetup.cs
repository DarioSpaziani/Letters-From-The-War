using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class AudioSetup : MonoBehaviour
{
    [SerializeField] private AudioClip _loopMusic;
    [SerializeField] [ProgressBar(0,100, 1, 0, 0)] private int _musicVolume = 50;

    private void Start()
    {
        AudioManager.Instance._loopAudioSource.volume = (float)_musicVolume/100;
        AudioManager.Instance._loopAudioSource.clip = _loopMusic;
        AudioManager.Instance._loopAudioSource.Play();
    }
}
