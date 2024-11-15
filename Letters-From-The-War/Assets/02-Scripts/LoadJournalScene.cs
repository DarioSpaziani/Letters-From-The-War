using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadJournalScene : MonoBehaviour
{
    private GameManager gameManager;
    private Fade fade;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
    }
    public void LoadScene()
    {
        if(gameManager.day >= 7)
        {
            StartCoroutine(fade.CheckFadeAndLoadScene("06-End"));
        }
        else
        {
            StartCoroutine(fade.CheckFadeAndLoadScene("02-Boss"));
        }
    }
}
