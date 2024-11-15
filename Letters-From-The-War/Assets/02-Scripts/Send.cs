using TMPro;
using UnityEngine;

public class Send : MonoBehaviour
{
    #region FIELDS
    private Fade fade;
    private GameManager gameManager;
    public bool isSended;
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        isSended = false;
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
    }

    public void CheckWords()
    {
        #region GREEN WORDS CHECK
        for (int i = 0; i < gameManager.listGreenWords.Count; i++)
        {
            if (gameManager.listGreenWords[i].obscured == true)
            {
                gameManager.comprensibility -= gameManager.greenWord.comprensibilityWordObscured;
                gameManager.dailyPerformance -= gameManager.greenWord.dailyPerfomanceWordObscured;
            }
            if (gameManager.listGreenWords[i].obscured == false)
            {
                gameManager.comprensibility += gameManager.greenWord.comprensibilityWordNotObscured;
                gameManager.dailyPerformance += gameManager.greenWord.dailyPerfomanceWordNotObscured;
            }
        }
        #endregion

        #region YELLOW WORDS CHECK
        for (int i = 0; i < gameManager.listYellowWords.Count; i++)
        {
            if (gameManager.listYellowWords[i].obscured == true)
            {
                gameManager.comprensibility -= gameManager.yellowWord.comprensibilityWordObscured;
                gameManager.dailyPerformance += gameManager.yellowWord.dailyPerfomanceWordObscured;
            }
            if (gameManager.listYellowWords[i].obscured == false)
            {
                gameManager.comprensibility += gameManager.yellowWord.comprensibilityWordNotObscured;
                gameManager.dailyPerformance -= gameManager.yellowWord.dailyPerfomanceWordNotObscured;
            }
        }
        #endregion

        #region RED WORDS CHECK
        for (int i = 0; i < gameManager.listRedWords.Count; i++)
        {
            if (gameManager.listRedWords[i].obscured == true)
            {
                gameManager.comprensibility -= gameManager.redWord.comprensibilityWordObscured;
                gameManager.dailyPerformance += gameManager.redWord.dailyPerfomanceWordObscured;
            }
            if (gameManager.listRedWords[i].obscured == false)
            {
                gameManager.comprensibility += gameManager.redWord.comprensibilityWordObscured;
                gameManager.dailyPerformance -= gameManager.redWord.comprensibilityWordNotObscured;
            }
        }
        Debug.Log("comprensibility : " + gameManager.comprensibility);
        Debug.Log("daily perf: " + gameManager.dailyPerformance);
        #endregion
    }

    public void LoadJournal()
    {
        isSended = false;
        fade.StartCoroutine(fade.CheckFadeAndLoadScene("04-Journal"));
    }

    public void SeeJournal()
    {
        CheckWords();
        isSended = true;
        
        if (isSended)
        {
            gameManager.Knowledge();
            gameManager.Malus();

            gameManager.listGreenWords.Clear();
            gameManager.listYellowWords.Clear();
            gameManager.listRedWords.Clear();

            gameManager.comprensibility = 0;
            gameManager.dailyPerformance = 0;
        }
        LoadJournal();
    }
    #endregion
}