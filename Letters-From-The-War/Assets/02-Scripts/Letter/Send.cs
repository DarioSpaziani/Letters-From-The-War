using UnityEngine;
using UnityEngine.UI;

public class Send : MonoBehaviour
{
    #region FIELDS

    private Fade fade;
    private GameManager gameManager;
    private Button sendButton;

    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        sendButton = GetComponent<Button>();
        sendButton.interactable = true;
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
    }

    private void Update()
    {
#if (UNITY_EDITOR)
    if (Input.GetKeyDown(KeyCode.S))
        {
            for(int i = 0; i < gameManager.listYellowWords.Count; i++)
            {
                gameManager.listYellowWords[i].obscured = true;
            }

            for(int i = 0; i < gameManager.listRedWords.Count; i++)
            {
                gameManager.listRedWords[i].obscured = true;
            }

        }
#endif
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
        #endregion
    }

    public void LoadJournal()
    {
        StartCoroutine(fade.CheckFadeAndLoadScene("04-Journal"));
    }

    public void SeeJournal()
    {
        CheckWords();
        sendButton.interactable = false;

        gameManager.Knowledge();
        gameManager.Malus();
        Debug.Log($"Comprensibility: {gameManager.comprensibility}");
        Debug.Log($"Daily Performance: {gameManager.dailyPerformance}");

        gameManager.listGreenWords.Clear();
        gameManager.listYellowWords.Clear();
        gameManager.listRedWords.Clear();

        gameManager.comprensibility = 0;
        gameManager.dailyPerformance = 0;
        LoadJournal();
    }

#endregion
}