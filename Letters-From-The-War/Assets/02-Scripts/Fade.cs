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
    private Image fadeImage;
    private Intro intro;
    private GameManager gameManager;
    [ShowInInspector]private TextMeshProUGUI dayText;
    private Color fadeColor;
    public float speedEffect = 1f;
    public float timeDelayScene = 1f;
    public float timeFadePingPong = 1f;
    public bool ping_pong_fade = false;
    public bool isFadeEnded;
    public List<string> daysString;
    #endregion

    #region UNITY_CALLS

    void Awake()
    {
        //if(_typewriter == null)
        //{
        //    return;
        //}
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

    public void FadeEffect() => fadeImage.CrossFadeAlpha(1.0f, speedEffect, false);

    public IEnumerator FadeReverse()
    {
        fadeImage.canvasRenderer.SetAlpha(1f);
        isFadeEnded = false;
        dayText.text = daysString[gameManager.day]; 
        //_typewriter.StartTypewriter();

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
    #endregion
}