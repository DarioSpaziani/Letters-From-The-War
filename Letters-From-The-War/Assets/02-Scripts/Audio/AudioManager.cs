using Sirenix.OdinInspector;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Background Music")]
    public AudioSource _loopAudioSource;
    [SerializeField] [ProgressBar(0,100, 1, 0, 0)] private int _musicVolume = 50;

    [Header("SFX")]
    public AudioSource _oneShotAudioSource;
    [SerializeField] [ProgressBar(0,100, 1, 0, 0)] private int _sfxVolume = 100;

    private void Start()
    {
        _oneShotAudioSource.volume = (float)_sfxVolume / 100;
        _loopAudioSource.volume = (float)_musicVolume / 100;
    }
}
