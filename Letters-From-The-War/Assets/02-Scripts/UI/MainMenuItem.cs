using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuItem : MonoBehaviour, IPointerEnterHandler
{
    #region FIELDS
    private AudioManager _audioManager;
    [Header("Flags")]
    [SerializeField] private bool _isEnabled = true;
    
    [Header("SFX Parametes")]
    [SerializeField] private AudioClip _sfx;
    [SerializeField] [ProgressBar(0,100, 1f, 0f, 0f)]private int _sfxVolume = 100;
    
    #endregion

    #region UNITY_CALLS

    private void Start()
    {
        _audioManager = AudioManager.Instance;
        _audioManager._oneShotAudioSource.volume = _sfxVolume;
    }

    public void NewGame() => SceneManager.LoadScene("01-Intro");

    public void ContinueGame(){}

    public void ShowCredits() {}

    public void Quit() 
    {
        Application.Quit();
    }
    
    #region Pointer Events Management
    public void OnPointerEnter(PointerEventData eventData) => ToggleHighlited();

    private void ToggleHighlited()
    {
        if (_isEnabled)
        {
            _audioManager._oneShotAudioSource.PlayOneShot(_sfx);
        }
    }

    #endregion
    #endregion
}