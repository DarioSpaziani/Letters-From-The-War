using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using UnityEngine.UI;

public class IntroImages : MonoBehaviour
{
    [Header("Images")] 
    [SerializeField] private List<Sprite> _imagesList;
    [SerializeField] private float _showTime = 3f;
    [SerializeField] private float _intervalTime = 0.5f;
    [SerializeField] private Image _showedImage;
    [Header("Game Object References")]
    [SerializeField] private Fade _fade;
    [SerializeField] private Intro _canvasIntro;

    private void Start()
    {
        _showedImage.sprite = _imagesList[0];
        StartCoroutine(SlideImages());
    }

    private IEnumerator SlideImages()
    {
        foreach (Sprite sprite in _imagesList)
        {
            yield return new WaitForSeconds(_intervalTime+0.2f);
            _showedImage.sprite = sprite;
            _showedImage.CrossFadeColor(Color.white, _intervalTime, false, false);
            yield return new WaitForSeconds(_showTime);
            _showedImage.CrossFadeColor(Color.black, _intervalTime+0.2f, false, false);
            yield return new WaitForSeconds(_intervalTime);
        }
        _canvasIntro.SkipIntro();
    }
}
