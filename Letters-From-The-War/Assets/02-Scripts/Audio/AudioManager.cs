using Sirenix.OdinInspector;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Background Music")] public AudioSource _loopAudioSource;

    [SerializeField] [ProgressBar(0, 100, 1, 0, 0)]
    private int _musicVolume = 50;

    [Header("SFX")] public AudioSource _oneShotAudioSource;

    [SerializeField] [ProgressBar(0, 100, 1, 0, 0)]
    private int _sfxVolume = 100;
}