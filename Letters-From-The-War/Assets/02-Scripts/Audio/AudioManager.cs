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
    [Range(0,1)] public float sfxVolumeMenuHover;
    [Range(0,1)] public float sfxVolumeStamp;
    [Range(0,1)] public float sfxVolumeType;
    [Range(0,1)] public float sfxVolumeSend;
    [Range(0,1)] public float sfxVolumeContinue;

    public AudioClip menuSound, gameLoopSound;
    public AudioClip menuItemHover, stampSound, typeSound, sendSound, continueSound;

    #endregion

    #region UNITY_CALLS

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
        sfxAudioSource.volume = sfxVolumeMenuHover;
        sfxAudioSource.clip = menuItemHover;
        sfxAudioSource.PlayOneShot(menuItemHover);
    }    
    
    public void PlayStampSound()
    {
        sfxAudioSource.volume = sfxVolumeStamp;
        sfxAudioSource.clip = stampSound;
        sfxAudioSource.PlayOneShot(stampSound);
    }    
    
    public void PlayTypeWriterSound()
    {
        sfxAudioSource.volume = sfxVolumeType;
        sfxAudioSource.clip = typeSound;
        sfxAudioSource.PlayOneShot(typeSound);
    }

    public void PlaySendSound()
    {
        sfxAudioSource.volume = sfxVolumeSend;
        sfxAudioSource.clip = sendSound;
        sfxAudioSource.PlayOneShot(sendSound);
    }    
    
    public void PlayContinueSound()
    {
        sfxAudioSource.volume = sfxVolumeContinue;
        sfxAudioSource.clip = continueSound;
        sfxAudioSource.PlayOneShot(continueSound);
    }

    #endregion
}