using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Send : MonoBehaviour
{
    private GameManager gameManager;
    private bool hasBeenSend = false;
    private bool calculationCompleted = false;

    public TextMeshProUGUI SendText;

    private void Awake()
    {
        SendText.text = "SEND";
        hasBeenSend = false;
        calculationCompleted = false;
        gameManager = FindObjectOfType<GameManager>();
    }
    public void SendLetter()
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
        #endregion
        hasBeenSend = true;
    }

    public void Update()
    {
        if (hasBeenSend && !calculationCompleted)
        {
            gameManager.Knowledge();
            gameManager.Malus();

            calculationCompleted = true;
            hasBeenSend = false;

            SendText.text = "NEXT";
        }
    }

    public void SeeJournal()
    {
        if (calculationCompleted)
        {
            gameManager.listGreenWords.Clear();
            gameManager.listYellowWords.Clear();
            gameManager.listRedWords.Clear();

            gameManager.comprensibility = 0;
            gameManager.dailyPerformance = 0;

            SceneManager.LoadScene("04-Journal");
        }
    }

}