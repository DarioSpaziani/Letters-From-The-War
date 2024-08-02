using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textMPRO;

    void Start()
    {
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
        SceneManager.LoadScene("01-BossInterview");
    }
}
