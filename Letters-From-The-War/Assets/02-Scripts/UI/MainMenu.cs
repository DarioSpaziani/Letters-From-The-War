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
