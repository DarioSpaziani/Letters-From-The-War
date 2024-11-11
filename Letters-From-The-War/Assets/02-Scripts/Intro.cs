using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    #region FIELDS
    public TextMeshProUGUI textMPRO;
    private Fade fade;
    private GameManager gameManager;
    #endregion

    #region UNITY_CALLS
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
        if(textMPRO == null)
        {
            return;
        }
        else
        {
            textMPRO.alpha = 0f;
        }
    }

    void Update()
    {
        if (textMPRO != null)
        {
            textMPRO.alpha += 0.002f;
        }
    }

    public void SkipIntro()
    {
        if (!fade.isFadeEnded)
        {
            fade.StartCoroutine(fade.CheckFadeAndLoadScene("02-Boss"));
        }
        if(gameManager.day >= 7)
        {
            fade.StartCoroutine(fade.CheckFadeAndLoadScene("05-End"));
        }
    } 
    #endregion
}