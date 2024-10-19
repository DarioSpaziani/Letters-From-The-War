using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuItem : MonoBehaviour, IPointerEnterHandler
{
    #region FIELDS
    private AudioManager _audioManager;
    [Header("Flags")]
    [SerializeField] private bool _isEnabled = true;
    
    [Header("SFX Parametes")]
    [SerializeField] private AudioClip _sfx;
    [SerializeField] [ProgressBar(0,100, 1f, 0f, 0f)]private int _sfxVolume = 100;

    //Non si gestirebbe così sta roba, servirebbe un manager, ma noi siamo spiriti liberi \(°^°)/
    [Header("UI FX")] 
    [SerializeField] private GameObject _lettersFTWImage;
    [SerializeField] private GameObject _creditsScreen;
    [SerializeField] private GameObject _timbre;
    [SerializeField] private float _waitAfterTimbre;
    
    #endregion

    #region UNITY_CALLS

    private void Start()
    {
        _audioManager = AudioManager.Instance;
        _audioManager._oneShotAudioSource.volume = _sfxVolume;
    }

    public void NewGame() => StartCoroutine(SpawnTimbre(0));

    public void ShowCredits() => StartCoroutine(SpawnTimbre(1));

    public void Quit() => StartCoroutine(SpawnTimbre(2));

    public void BackToMenu()
    {
        transform.parent.gameObject.SetActive(true);
        _creditsScreen.SetActive(false);
        _lettersFTWImage.SetActive(true);
    }
    
    private IEnumerator SpawnTimbre(int command)
    {
        _timbre.SetActive(true);
        yield return new WaitForSeconds(1 / _timbre.GetComponent<Animator>().speed + _waitAfterTimbre);
        switch (command)
        {
            case 0:
                SceneManager.LoadScene("01-Intro");
                break;
            case 1:
                _lettersFTWImage.SetActive(false);
                _timbre.SetActive(false);
                _creditsScreen.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                break;
            case 2:
                Application.Quit();
                break;
        }
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