using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    private GameManager gameManager;

    #region Values journal
    [Header("VALUES JOURNAL TITLES")]
    [Header("DAY ONE")]
    public float minRangeOneFirstTitle;
    public float maxRangeOneFirstTitle;
    public float minRangeOneSecondTitle;
    public float maxRangeOneSecondTitle;
    public float minRangeOneThirdTitle;
    public float maxRangeOneThirdTitle; 
    [Header("DAY TWO")]
    public float minRangeTwoFirstTitle;
    public float maxRangeTwoFirstTitle;
    public float minRangeTwoSecondTitle;
    public float maxRangeTwoSecondTitle;
    public float minRangeTwoThirdTitle;
    public float maxRangeTwoThirdTitle;
    [Header("DAY THIRD")]
    public float minRangeThirdFirstTitle;
    public float maxRangeThirdFirstTitle;
    public float minRangeThirdSecondTitle;
    public float maxRangeThirdSecondTitle;
    public float minRangeThirdThirdTitle;
    public float maxRangeThirdThirdTitle;
    [Header("DAY FOUR")]
    public float minRangeFourthFirstTitle;
    public float maxRangeFourthFirstTitle;
    public float minRangeFourthSecondTitle;
    public float maxRangeFourthSecondTitle;
    public float minRangeFourthThirdTitle;
    public float maxRangeFourthThirdTitle;
    [Header("DAY FIVE")]
    public float minRangeFiveFirstTitle;
    public float maxRangeFiveFirstTitle;
    public float minRangeFiveSecondTitle;
    public float maxRangeFiveSecondTitle;
    public float minRangeFiveThirdTitle;
    public float maxRangeFiveThirdTitle;
    [Header("DAY SIX")]
    public float minRangeSixFirstTitle;
    public float maxRangeSixFirstTitle;
    public float minRangeSixSecondTitle;
    public float maxRangeSixSecondTitle;
    public float minRangeSixThirdTitle;
    public float maxRangeSixThirdTitle;
    [Header("DAY SEVEN")]
    public float minRangeSevenFirstTitle;
    public float maxRangeSevenFirstTitle;
    public float minRangeSevenSecondTitle;
    public float maxRangeSevenSecondTitle;
    public float minRangeSevenThirdTitle;
    public float maxRangeSevenThirdTitle;
#endregion

    #region Journal Description
    public TextMeshProUGUI headline;

    private Dictionary<int, List<string>> journalDescriptions;

    public List<string> day1Descriptions;
    public List<string> day2Descriptions;
    public List<string> day3Descriptions;
    public List<string> day4Descriptions;
    public List<string> day5Descriptions;
    public List<string> day6Descriptions;
    public List<string> day7Descriptions;
    #endregion

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        InitializeJournal();
        UpdateJournalDisplay();
    }

    private void InitializeJournal()
    {
        journalDescriptions = new Dictionary<int, List<string>>
        {
            { 1, day1Descriptions },
            { 2, day2Descriptions },
            { 3, day3Descriptions },
            { 4, day4Descriptions },
            { 5, day5Descriptions },
            { 6, day6Descriptions },
            { 7, day7Descriptions },
        };
    }

    public void UpdateJournalDisplay()
    {
        ShowTextDescriptions(gameManager.day);
    }

    private void ShowTextDescriptions(int day)
    {
        if (journalDescriptions.TryGetValue(day, out List<string> descriptions))
        {
            if (descriptions.Count == 4)
            {
                int knowledgeIndex = GetKnowledgeIndex(gameManager.knowledge);
                headline.text = (descriptions[knowledgeIndex]);   
            }
            else
            {
                Debug.LogWarning($"Not enough descriptions for day {day}");
            }
        }
        else
        {
            Debug.LogError($"No journal descriptions for day {day}");
        }
        gameManager.day++;
    }

    private int GetKnowledgeIndex(int knowledge)
    {
        //le modifiche devono essere modificabili a seconda del giorno
        if (knowledge >= 0 && knowledge <= 0) return 0;
        if (knowledge >= 0 || knowledge <= 0) return 1;
        if (knowledge >= 0 && knowledge <= 0) return 2;
        return 3;
    }
}