using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    #region FIELDS

    private static AudioManager Instance;

    [Header("Background Music")] 
    public AudioSource audioSource;
    public AudioSource sfxAudioSource;
    public float timerModifyVolume;

    public AudioClip menuSound, gameLoopSound;
    public AudioClip menuItemHover, stampSound, typeSound;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    public void PlayMenuSound()
    {
        audioSource.clip = menuSound;
        audioSource.Play();
    }

    public void PlayGameSound()
    {
        audioSource.clip = gameLoopSound;
        audioSource.Play();
    }

    public void PlayMenuHoverSound()
    {
        sfxAudioSource.clip = menuItemHover;
        sfxAudioSource.PlayOneShot(menuItemHover);
    }    
    
    public void PlayStampSound()
    {
        sfxAudioSource.clip = stampSound;
        sfxAudioSource.PlayOneShot(stampSound);
    }    
    
    public void PlayTypeWriterSound()
    {
        sfxAudioSource.clip = typeSound;
        sfxAudioSource.PlayOneShot(typeSound);
    }

    #endregion
}