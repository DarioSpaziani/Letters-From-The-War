using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private Typewriter typewriter;
    [SerializeField] private Intro intro;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private Image _dayTextSprite;
    [SerializeField] private List<Sprite> _spritesDays;
    private GameManager gameManager;
    private Color fadeColor;
    public float speedEffectText = 1f;
    public float speedEffectGradient = 1f;
    public float timeDelayLoadScene = 1f;
    public float timeFadePingPong = 1f;
    public float timeFadeReverse = 1f;
    public float timeFadeReverseLetter = 1f;
    public float timeFadeDay = 1f;
    public float timeFadeEffect = 1f;
    public bool isFadeEnded;

    #endregion

    #region UNITY_CALLS

    void Awake()
    {
        _dayTextSprite.canvasRenderer.SetAlpha(0);
        isFadeEnded = true;
        gameManager = FindObjectOfType<GameManager>();
        _fadeImage.canvasRenderer.SetAlpha(0);
    }

    public void ButtonFadeImages()
    {
        if (isFadeEnded && !intro.isIntroEnded && typewriter.endTypeWriting)
        {
            intro.counter++;
            StartCoroutine(FadePingPong());
        }
    }

    public void ButtonFadeScene()
    {
        if (intro.CheckEnd())
        {
            StartCoroutine(FadeEffect());
        }
    } 

    public void FadeEffectFunc()
    {
        if(isFadeEnded) StartCoroutine(FadeEffect());
    }

    public IEnumerator FadeEffect()
    {
        isFadeEnded = false;
        _fadeImage.canvasRenderer.SetAlpha(0f);
        _fadeImage.CrossFadeAlpha(1.0f,speedEffectGradient, false);
        yield return new WaitForSeconds(timeFadeEffect);
        isFadeEnded = true;
    }

    public void FadeReverseEffect()
    {
        if (isFadeEnded)
            StartCoroutine(FadeReverse());
    }    
    
    public IEnumerator FadeReverse()
    {
        isFadeEnded = false;
        _fadeImage.canvasRenderer.SetAlpha(1f);
        _fadeImage.CrossFadeColor(Color.black, speedEffectGradient, false, false);
        _fadeImage.CrossFadeColor(Color.white, speedEffectGradient, false, false);
        _dayTextSprite.sprite = _spritesDays[gameManager.day];
        yield return new WaitForSeconds(timeFadeDay);
        StartCoroutine(FadeDay());
        
        yield return new WaitForSeconds(timeFadeReverse);

        _fadeImage.CrossFadeAlpha(0.0f, speedEffectGradient, false);
        isFadeEnded = true;
    }

    public void FadeReverseLetterEffect()
    {
        if (isFadeEnded)
            StartCoroutine(FadeReverseLetter());
    }

    public IEnumerator FadeReverseLetter()
    {
        isFadeEnded = false;
        _fadeImage.canvasRenderer.SetAlpha(1f);
        _fadeImage.CrossFadeColor(Color.black, speedEffectGradient, false, false);
        _fadeImage.CrossFadeColor(Color.white, speedEffectGradient, false, false);
                
        yield return new WaitForSeconds(timeFadeReverseLetter);

        _fadeImage.CrossFadeAlpha(0.0f, speedEffectGradient, false);
        isFadeEnded = true;
    }

    public IEnumerator FadeDay()
    {
        isFadeEnded = false;
        _dayTextSprite.canvasRenderer.SetAlpha(0f);
        _dayTextSprite.CrossFadeAlpha(1.0f, speedEffectGradient, false);

        while (Mathf.Abs(_dayTextSprite.canvasRenderer.GetAlpha() - 1.0f) > 0.01f)
        {
            yield return null;
        }
        yield return new WaitForSeconds(timeFadeDay);

        _dayTextSprite.CrossFadeAlpha(0.0f, speedEffectGradient, false);
        isFadeEnded = true;
    }

    public void FadePingPongEffect()
    {
        if(isFadeEnded) StartCoroutine (FadePingPong());
    }

    public IEnumerator FadePingPong()
    {
        isFadeEnded = false;
        _fadeImage.canvasRenderer.SetAlpha(0f);
        _fadeImage.CrossFadeAlpha(1.0f, speedEffectGradient, false);

        while (Mathf.Abs(_fadeImage.canvasRenderer.GetAlpha() - 1.0f) > 0.01f)
        {
            yield return null;
        }
        intro.CycleSlide();
        yield return new WaitForSeconds(timeFadePingPong);
        typewriter.StartTypewriter();
        _fadeImage.CrossFadeAlpha(0.0f, speedEffectGradient, false);
        isFadeEnded = true;
    }

    public void CheckFadeAndLoad(string sceneName)
    {
        if (isFadeEnded)
        {
            StartCoroutine(CheckFadeAndLoadScene(sceneName));
        }
    }

    public IEnumerator CheckFadeAndLoadScene(string sceneName)
    {
        FadeEffectFunc();
        yield return new WaitUntil(() => isFadeEnded);
        yield return new WaitForSeconds(timeDelayLoadScene);
        SceneManager.LoadScene(sceneName);
    }

    #endregion
}