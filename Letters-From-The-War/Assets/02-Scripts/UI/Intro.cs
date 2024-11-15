using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    //TO DO fare fade che parte con immagine nera, quando è a 1 cambia immagine e testo e ritorna a 0

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

    #endregion

    #region UNITY CALLS

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        isIntroEnded = false;
        _fade.isFadeEnded = true;
        counter = 0;
        _showedImage.sprite = _imagesList[counter].image;
        _showedText.text = _imagesList[counter].text;
    }

    private void CycleSlide()
    {
        Slide currentSlide = _imagesList[counter];
        _showedImage.sprite = _imagesList[counter].image;
        _showedText.text = _imagesList[counter].text;
    }

    public void Update()
    {
        if (counter >= _imagesList.Count)
        {
            SkipIntro();
        }
        if (counter >= _imagesList.Count)
        {
            isIntroEnded = true;
        }
        if (counter <= _imagesList.Count - 1)
        {
            CycleSlide();
        }
    }

    public void SkipIntro()
    {
        if (!_fade.isFadeEnded)
        {
            SceneManager.LoadScene("02-Boss");
        }
    }
    #endregion
}
