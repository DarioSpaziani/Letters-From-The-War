using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private Typewriter _typewriter;
    public Image fadeImage;
    [SerializeField] private Intro intro;
    private GameManager gameManager;
    [ShowInInspector] private TextMeshProUGUI dayText;
    private Color fadeColor;
    public float speedEffect = 1f;
    public float timeDelayScene = 1f;
    public float timeFadePingPong = 1f;
    public bool isFadeEnded;
    public List<string> daysString;

    #endregion

    #region UNITY_CALLS

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        fadeImage.canvasRenderer.SetAlpha(0);
        dayText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void FadeImages()
    {
        if (isFadeEnded)
        {
            StartCoroutine(FadePingPong());
        }
    }

    public void FadeEffect() => fadeImage.CrossFadeAlpha(1.0f, speedEffect, false);

    public IEnumerator FadeReverse()
    {
        fadeImage.canvasRenderer.SetAlpha(1f);
        isFadeEnded = false;
        dayText.text = daysString[gameManager.day]; 

        yield return new WaitForSeconds(timeFadePingPong);

        dayText.text = "";
        fadeImage.CrossFadeAlpha(0.0f, speedEffect, false);
        isFadeEnded = true;
    }

    public IEnumerator FadePingPong()
    {
        isFadeEnded = false;
        fadeImage.canvasRenderer.SetAlpha(0f);
        fadeImage.CrossFadeAlpha(1.0f, speedEffect, false);

        while (Mathf.Abs(fadeImage.canvasRenderer.GetAlpha() - 1.0f) > 0.01f)
        {
            yield return null;
        }
        yield return new WaitForSeconds(timeFadePingPong);

        intro.counter++;
        fadeImage.CrossFadeAlpha(0.0f, speedEffect, false);
        isFadeEnded = true;
    }

    public IEnumerator CheckFadeAndLoadScene(string sceneName)
    {
        FadeEffect();
        yield return new WaitUntil(() => isFadeEnded);
        yield return new WaitForSeconds(timeDelayScene);
        SceneManager.LoadScene(sceneName);
    }
    #endregion
}