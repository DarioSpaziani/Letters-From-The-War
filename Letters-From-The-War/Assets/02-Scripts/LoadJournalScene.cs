using UnityEngine;
using UnityEngine.UI;

public class LoadJournalScene : MonoBehaviour
{
    #region FIELDS

    private GameManager gameManager;
    private Fade fade;
    private Button nextScene;

    #endregion

    #region UNITY_CALLS

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
            fade.CheckFadeAndLoad("05-End");
        }
        else
        {
            gameManager.day++;
            nextScene.interactable = false;
            fade.CheckFadeAndLoad("02-Boss");
        }
    }

    #endregion
}
