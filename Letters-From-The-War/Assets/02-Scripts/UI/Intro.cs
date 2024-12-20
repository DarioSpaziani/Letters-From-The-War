using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    #region SLIDE

    [Serializable]
    private struct Slide
    {
        public Sprite image;
        [TextArea(3, 10)] public string text;
    }
    
    #endregion

    #region FIELDS

    [Header("Images")] 
    [SerializeField] private List<Slide> _imagesList;
    [SerializeField] private Image _showedImage;
    [SerializeField] private TMP_Text _showedText;
    public int counter = 0;
    [Header("Game Object References")]
    [SerializeField] private Fade _fade;
    private GameManager _gameManager;
    public bool isIntroEnded = false;
    [SerializeField] private Typewriter _typewriter;
    [SerializeField] private AudioManager _audioManager;

    #endregion

    #region UNITY CALLS

    private void Awake()
    {

        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.malus = 0;
        _gameManager.knowledge = 0;
        _gameManager.day = 0;
        _gameManager.hasStarted = true;
        _gameManager.malusDaily = 0;
    }

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.PlayGameSound();
        isIntroEnded = false;
        _fade.isFadeEnded = true;
        counter = 0;
        _showedImage.sprite = _imagesList[counter].image;
        _showedText.text = _imagesList[counter].text;
    }

    public void CycleSlide()
    {
        _typewriter.timer = 1f;
        Slide currentSlide = _imagesList[counter];
        _showedImage.sprite = _imagesList[counter].image;
        _showedText.text = _imagesList[counter].text;
        
    }

    public void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipIntro();
        }
#endif
        if (CheckEnd())
        {
            SkipIntro();
        }
        if (counter > _imagesList.Count -1)
        {
            isIntroEnded = true;
        }
    }

    public bool CheckEnd()
    {
        if (counter > _imagesList.Count - 1)
        {
            return true;
        }
        return false;
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene("02-Boss");
    }

    #endregion
}
