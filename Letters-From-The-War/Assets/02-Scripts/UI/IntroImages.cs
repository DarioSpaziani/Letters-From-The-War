using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class IntroImages : MonoBehaviour
{
    #region FIELDS

    [Header("Images")] 
    [SerializeField] private List<Slide> _imagesList;
    [SerializeField] private float _showTime = 3f;
    [FormerlySerializedAs("_intervalTime")] [SerializeField] private float _fadeTime = 0.5f;
    [SerializeField] private Image _showedImage;
    [SerializeField] private TMP_Text _showedText;
    [Header("Game Object References")]
    [SerializeField] private Fade _fade;
    [SerializeField] private Intro _canvasIntro;

    #endregion

    #region UNITY CALLS

    private void Start()
    {
        _showedImage.sprite = _imagesList[0].image;
        _showedText.text = _imagesList[0].text;
        StartCoroutine(SlideImages());
    }

    private IEnumerator SlideImages()
    {
        foreach (Slide slide in _imagesList)
        {
            yield return new WaitForSeconds(_fadeTime+0.2f);
            _showedImage.sprite = slide.image;
            _showedText.text = slide.text;
            _showedImage.CrossFadeColor(Color.white, _fadeTime, false, false);
            _showedText.CrossFadeColor(Color.white, _fadeTime, false, false);
            yield return new WaitForSeconds(_showTime);
            _showedImage.CrossFadeColor(Color.black, _fadeTime+0.2f, false, false);
            _showedText.CrossFadeColor(Color.black, _fadeTime+0.2f, false, false);
            yield return new WaitForSeconds(_fadeTime);
        }
        _canvasIntro.SkipIntro();
    }
    
    [Serializable]
    private struct Slide
    {
        public Sprite image;
        public string text;
    }

    #endregion
}
