using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    #region FIELDS
    private Image fadeImage;
    private Intro intro;
    private GameManager gameManager;
    private TextMeshProUGUI dayText;
    private TextMeshProUGUI yearText;
    private Color fadeColor;
    public float speedEffect = 1f;
    public float timeDelayScene = 1f;
    public float timeFadePingPong = 1f;
    public bool ping_pong_fade = false;
    public bool isFadeEnded;
    public List<string> daysText;
    public List<string> yearsText;
    #endregion

    #region UNITY_CALLS
    void Awake()
    {
        GameObject child = transform.GetChild(0).gameObject;
        GameObject child1 = transform.GetChild(1).gameObject;
        gameManager = FindObjectOfType<GameManager>();
        fadeImage = GetComponent<Image>();
        fadeImage.canvasRenderer.SetAlpha(0);
        dayText = child.GetComponentInChildren<TextMeshProUGUI>();
        yearText = child1.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start() 
    {
        dayText.text = ""; 
        yearText.text = ""; 
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

    public void FadeEffect() => fadeImage.CrossFadeAlpha(1.0f, speedEffect, false);

    public IEnumerator FadeReverse()
    {
        fadeImage.canvasRenderer.SetAlpha(1f);
        isFadeEnded = false;
        dayText.text = daysText[gameManager.day-1];
        yearText.text = yearsText[gameManager.day-1];

        yield return new WaitForSeconds(timeFadePingPong);

        dayText.text = "";
        yearText.text = "";
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