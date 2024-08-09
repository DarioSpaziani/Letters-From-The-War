using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textMPRO;
    private Fade fade;

    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("non sono bloccato");
        }

    }

    public void SkipIntro()
    {
        fade.StartCoroutine(fade.CheckFadeAndLoadScene("01-BossInterview"));
    }

}