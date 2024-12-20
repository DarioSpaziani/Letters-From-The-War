using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private AudioManager _audioManager;
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.PlayMenuSound();
    }

}
