using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameManager instance;
    public WordData greenWord;
    public WordData yellowWord;
    public WordData redWord;

    [Range(0, 20)]
    public float comprensibility = 0;

    [Range(0, 20)]
    public float dailyPerformance = 0;

    [Range(0, 20)]
    public int malus = 0;

    [Range(0, 20)]
    public int knowledge = 0;

    public List<Word> listGreenWords = new List<Word>();
    public List<Word> listYellowWords = new List<Word>();
    public List<Word> listRedWords = new List<Word>();

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        FillLists();
    }

    private void FillLists()
    {
        Word[] words = FindObjectsOfType<Word>();

        foreach (var w in words)
        {
            if (w.wordData.category == WordData.wordCategory.GREEN)
            {
                listGreenWords.Add(w);
            }
            else if (w.wordData.category == WordData.wordCategory.YELLOW)
            {
                listYellowWords.Add(w);
            }
            else if (w.wordData.category == WordData.wordCategory.RED)
            {
                listRedWords.Add(w);
            }

        }
    }

    public void Update()
    {
        comprensibility = Mathf.Clamp(comprensibility, 0, 20);
        dailyPerformance = Mathf.Clamp(dailyPerformance, 0, 20);

        if(comprensibility < 0)
        {
            comprensibility = 0;
        }
        if (comprensibility > 20)
        {
            comprensibility = 20;
        }
    }

    public void Send()
    {
        #region GREEN WORDS CHECK
        for (int i = 0; i < listGreenWords.Count; i++)
        {
            if (listGreenWords[i].obscured == true)
            {
                comprensibility -= greenWord.comprensibilityWordObscured;
                dailyPerformance -= greenWord.dailyPerfomanceWordObscured;
            }
            if (listGreenWords[i].obscured == false)
            {
                comprensibility += greenWord.comprensibilityWordNotObscured;
                dailyPerformance += greenWord.dailyPerfomanceWordNotObscured;
            }
        }
        #endregion

        #region YELLOW WORDS CHECK
        for (int i = 0; i < listYellowWords.Count; i++)
        {
            if(listYellowWords[i].obscured == true)
            {
                comprensibility -= yellowWord.comprensibilityWordObscured;
                dailyPerformance += yellowWord.dailyPerfomanceWordObscured;
            }
            if (listYellowWords[i].obscured == false)
            {
                comprensibility += yellowWord.comprensibilityWordNotObscured;
                dailyPerformance -= yellowWord.dailyPerfomanceWordNotObscured;
            }
        }
        #endregion

        #region RED WORDS CHECK
        for (int i = 0; i < listRedWords.Count; i++)
        {
            if (listRedWords[i].obscured == true)
            {
                comprensibility -= redWord.comprensibilityWordObscured;
                dailyPerformance += redWord.dailyPerfomanceWordObscured;
            }
            if (listRedWords[i].obscured == false)
            {
                comprensibility += redWord.comprensibilityWordObscured;
                dailyPerformance -= redWord.comprensibilityWordNotObscured;
            }
        }
        #endregion

        Debug.Log("comprensibility : " + comprensibility);
        Debug.Log("dailyPerformance: " + dailyPerformance);
    }
}
