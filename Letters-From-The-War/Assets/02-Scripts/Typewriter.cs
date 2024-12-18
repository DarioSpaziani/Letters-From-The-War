using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Typewriter : MonoBehaviour
{
    #region FIELDS

    [Header("Sound")]
    [SerializeField] private AudioClip _typingSound;
    [SerializeField] [Range(1,100)] private int _soundSpeed = 100;
    [SerializeField] [ProgressBar(0, 100, 1f, 0f, 0f)]
    private int _typingVolume = 50;
    
    [Header("Text")]
    [SerializeField] [Range(1,100)] private int _typingSpeed = 4;
    [SerializeField] private bool _toggleOnStart = true;
    public bool endTypeWriting = false;

    private TMP_Text _textField;
    private string _textToShow;
    private AudioManager _audioManager;

    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        endTypeWriting = false ;
        _audioManager.PlayMenuHoverSound();
        
        _textField = GetComponent<TMP_Text>();

            StartTypewriter();
        
    }

    /// <summary>
    /// Rimuove il testo e lo riscrive con i parametri inseriti.
    /// E' importante che venga assegnato il testo al componente TMP_Text prima di chiamare questa funzione,
    /// altrimenti verrà visualizzata l'ultima stringa assegnata.
    /// </summary>
    public void StartTypewriter()
    {
        HideText();
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        endTypeWriting = false;
        float soundTimer = 0;
        foreach (char character in _textToShow)
        {
            soundTimer += Time.deltaTime; 
            if (soundTimer >= 1 / (float)_soundSpeed)
            {
                soundTimer = 0;
                _audioManager.PlayTypeWriterSound();
            }
            _textField.text += character;
            yield return new WaitForSeconds(1 /((float)_typingSpeed*10));
            
        }
        endTypeWriting = true;
    }

    private void HideText()
    {
        _textToShow = _textField.text;
        _textField.text = string.Empty;
    }

    #endregion
}
