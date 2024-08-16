using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image fadeImage;
    private TextMeshProUGUI dayText;
    //modificabile scritta fade
    public float speedEffect = 1f;
    public bool isFadeEnded;
    private Color fadeColor;
    private Intro intro;
    private GameManager gameManager;
    public float timeDelayScene = 1f;
    public float timeFadePingPong = 1f;
    public bool ping_pong_fade = false;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        fadeImage = GetComponent<Image>();
        fadeImage.canvasRenderer.SetAlpha(0);
        dayText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        dayText.text = "";
    }

    public void Update()
    {
        float alpha = fadeImage.canvasRenderer.GetAlpha();
        if (alpha >= 0.99f)
        {
            isFadeEnded = true;
        }
        else
        {
            isFadeEnded = false;
            
        }
    }

    public void FadeEffect()
    {
        fadeImage.CrossFadeAlpha(1.0f, speedEffect, false);
    }

    public IEnumerator FadeReverse()
    {
        fadeImage.canvasRenderer.SetAlpha(1f);
        isFadeEnded = false;
        dayText.text = "DAY : " + gameManager.day;
        yield return new WaitForSeconds(timeFadePingPong);

        dayText.text = "";
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
}