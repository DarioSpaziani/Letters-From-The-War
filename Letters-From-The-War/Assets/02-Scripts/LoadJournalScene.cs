using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadJournalScene : MonoBehaviour
{
    private GameManager gameManager;
    private Fade fade;
    private Button nextScene;

    private void Awake()
    {
        nextScene = GetComponentInChildren<Button>();
        nextScene.interactable = true;
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
    }
    public void LoadScene()
    {
        if(gameManager.day >= 7)
        {
            nextScene.interactable = false;
            fade.CheckFadeAndLoad("06-End");
        }
        else
        {
            gameManager.day++;
            nextScene.interactable = false;
            fade.CheckFadeAndLoad("02-Boss");
        }
    }
}
