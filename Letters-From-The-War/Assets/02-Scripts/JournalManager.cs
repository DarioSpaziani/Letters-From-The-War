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
    public DayRange[] dayRanges = new DayRange[8];

    [Header("DAY ONE")]
    public int minRangeOneFirstTitle;
    public int maxRangeOneFirstTitle;
    public int minRangeOneSecondTitle;
    public int maxRangeOneSecondTitle;
    public int minRangeOneThirdTitle;
    public int maxRangeOneThirdTitle;
    public int minRangeOneFourthTitle;
    public int maxRangeOneFourthTitle;

    [Header("DAY TWO")]
    public int minRangeTwoFirstTitle;
    public int maxRangeTwoFirstTitle;
    public int minRangeTwoSecondTitle;
    public int maxRangeTwoSecondTitle;
    public int minRangeTwoThirdTitle;
    public int maxRangeTwoThirdTitle;
    public int minRangeTwoFourthTitle;
    public int maxRangeTwoFourthTitle;

    [Header("DAY THIRD")]
    public int minRangeThirdFirstTitle;
    public int maxRangeThirdFirstTitle;
    public int minRangeThirdSecondTitle;
    public int maxRangeThirdSecondTitle;
    public int minRangeThirdThirdTitle;
    public int maxRangeThirdThirdTitle;
    public int minRangeThirdFourthTitle;
    public int maxRangeThirdFourthTitle;

    [Header("DAY FOUR")]
    public int minRangeFourthFirstTitle;
    public int maxRangeFourthFirstTitle;
    public int minRangeFourthSecondTitle;
    public int maxRangeFourthSecondTitle;
    public int minRangeFourthThirdTitle;
    public int maxRangeFourthThirdTitle;
    public int minRangeFourthFourthTitle;
    public int maxRangeFourthFourthTitle;

    [Header("DAY FIVE")]
    public int minRangeFiveFirstTitle;
    public int maxRangeFiveFirstTitle;
    public int minRangeFiveSecondTitle;
    public int maxRangeFiveSecondTitle;
    public int minRangeFiveThirdTitle;
    public int maxRangeFiveThirdTitle;
    public int minRangeFiveFourthTitle;
    public int maxRangeFiveFourthTitle;

    [Header("DAY SIX")]
    public int minRangeSixFirstTitle;
    public int maxRangeSixFirstTitle;
    public int minRangeSixSecondTitle;
    public int maxRangeSixSecondTitle;
    public int minRangeSixThirdTitle;
    public int maxRangeSixThirdTitle;
    public int minRangeSixFourthTitle;
    public int maxRangeSixFourthTitle;

    [Header("DAY SEVEN")]
    public int minRangeSevenFirstTitle;
    public int maxRangeSevenFirstTitle;
    public int minRangeSevenSecondTitle;
    public int maxRangeSevenSecondTitle;
    public int minRangeSevenThirdTitle;
    public int maxRangeSevenThirdTitle;
    public int minRangeSevenFourthTitle;
    public int maxRangeSevenFourthTitle;
    #endregion

    #region Journal Description

    public TextMeshProUGUI headlineText;

    private Dictionary<int, List<string>> journalDescriptions;

    public List<string> day1Descriptions;
    public List<string> day2Descriptions;
    public List<string> day3Descriptions;
    public List<string> day4Descriptions;
    public List<string> day5Descriptions;
    public List<string> day6Descriptions;
    public List<string> day7Descriptions;

    public class DayRange
    {
        public int minRangeFirstTitle;
        public int maxRangeFirstTitle;
        public int minRangeSecondTitle;
        public int maxRangeSecondTitle;
        public int minRangeThirdTitle;
        public int maxRangeThirdTitle;
        public int minRangeFourthTitle;
        public int maxRangeFourthTitle;
    }

    #endregion

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found!");
        }
        if (dayRanges == null || dayRanges.Length == 0)
        {
            dayRanges = new DayRange[8]; // 0-7 (8 elementi)
            for (int i = 0; i < dayRanges.Length; i++)
            {
                dayRanges[i] = new DayRange();
            }
        }
        AssignDayRanges();
    }

    #region Days
    private void AssignDayRanges()
    {
        // Giorno 1
        dayRanges[1] = new DayRange
        {
            minRangeFirstTitle = minRangeOneFirstTitle,
            maxRangeFirstTitle = maxRangeOneFirstTitle,
            minRangeSecondTitle = minRangeOneSecondTitle,
            maxRangeSecondTitle = maxRangeOneSecondTitle,
            minRangeThirdTitle = minRangeOneThirdTitle,
            maxRangeThirdTitle = maxRangeOneThirdTitle,
            minRangeFourthTitle = minRangeOneFourthTitle,
            maxRangeFourthTitle = maxRangeOneFourthTitle
        };

        // Giorno 2
        dayRanges[2] = new DayRange
        {
            minRangeFirstTitle = minRangeTwoFirstTitle,
            maxRangeFirstTitle = maxRangeTwoFirstTitle,
            minRangeSecondTitle = minRangeTwoSecondTitle,
            maxRangeSecondTitle = maxRangeTwoSecondTitle,
            minRangeThirdTitle = minRangeTwoThirdTitle,
            maxRangeThirdTitle = maxRangeTwoThirdTitle,
            minRangeFourthTitle = minRangeTwoFourthTitle,
            maxRangeFourthTitle = maxRangeTwoFourthTitle
        };

        // Giorno 3
        dayRanges[3] = new DayRange
        {
            minRangeFirstTitle = minRangeThirdFirstTitle,
            maxRangeFirstTitle = maxRangeThirdFirstTitle,
            minRangeSecondTitle = minRangeThirdSecondTitle,
            maxRangeSecondTitle = maxRangeThirdSecondTitle,
            minRangeThirdTitle = minRangeThirdThirdTitle,
            maxRangeThirdTitle = maxRangeThirdThirdTitle,
            minRangeFourthTitle = minRangeThirdFourthTitle,
            maxRangeFourthTitle = maxRangeThirdFourthTitle
        };

        // Giorno 4
        dayRanges[4] = new DayRange
        {
            minRangeFirstTitle = minRangeFourthFirstTitle,
            maxRangeFirstTitle = maxRangeFourthFirstTitle,
            minRangeSecondTitle = minRangeFourthSecondTitle,
            maxRangeSecondTitle = maxRangeFourthSecondTitle,
            minRangeThirdTitle = minRangeFourthThirdTitle,
            maxRangeThirdTitle = maxRangeFourthThirdTitle,
            minRangeFourthTitle = minRangeFourthFourthTitle,
            maxRangeFourthTitle = maxRangeFourthFourthTitle
        };

        // Giorno 5
        dayRanges[5] = new DayRange
        {
            minRangeFirstTitle = minRangeFiveFirstTitle,
            maxRangeFirstTitle = maxRangeFiveFirstTitle,
            minRangeSecondTitle = minRangeFiveSecondTitle,
            maxRangeSecondTitle = maxRangeFiveSecondTitle,
            minRangeThirdTitle = minRangeFiveThirdTitle,
            maxRangeThirdTitle = maxRangeFiveThirdTitle,
            minRangeFourthTitle = minRangeFiveFourthTitle,
            maxRangeFourthTitle = maxRangeFiveFourthTitle
        };

        // Giorno 6
        dayRanges[6] = new DayRange
        {
            minRangeFirstTitle = minRangeSixFirstTitle,
            maxRangeFirstTitle = maxRangeSixFirstTitle,
            minRangeSecondTitle = minRangeSixSecondTitle,
            maxRangeSecondTitle = maxRangeSixSecondTitle,
            minRangeThirdTitle = minRangeSixThirdTitle,
            maxRangeThirdTitle = maxRangeSixThirdTitle,
            minRangeFourthTitle = minRangeSixFourthTitle,
            maxRangeFourthTitle = maxRangeSixFourthTitle
        };

        // Giorno 7
        dayRanges[7] = new DayRange
        {
            minRangeFirstTitle = minRangeSevenFirstTitle,
            maxRangeFirstTitle = maxRangeSevenFirstTitle,
            minRangeSecondTitle = minRangeSevenSecondTitle,
            maxRangeSecondTitle = maxRangeSevenSecondTitle,
            minRangeThirdTitle = minRangeSevenThirdTitle,
            maxRangeThirdTitle = maxRangeSevenThirdTitle,
            minRangeFourthTitle = minRangeSevenFourthTitle,
            maxRangeFourthTitle = maxRangeSevenFourthTitle
        };
    }
    #endregion

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
        Debug.Log($"UpdateJournalDisplay called. Current day: {gameManager.day}, Knowledge: {gameManager.knowledge}");
        ShowTextDescriptions();
        gameManager.day++;
    }

    private void ShowTextDescriptions()
    {

        if (journalDescriptions.TryGetValue(gameManager.day, out List<string> descriptions))
        {
            if (descriptions.Count == 4)
            {
                int knowledgeIndex = GetKnowledgeIndex(gameManager.day, gameManager.knowledge);
                Debug.Log("Showing description for day: {day}");

                Debug.Log($"Current knowledge: {gameManager.knowledge}");
                headlineText.text = (descriptions[knowledgeIndex]);   
            }
            else
            {
                Debug.LogWarning($"Not enough descriptions for day {gameManager.day}");
            }
        }
        else
        {
            Debug.LogError($"No journal descriptions for day {gameManager.day}");
        }
    }

    private int GetKnowledgeIndex(int day, int knowledge)
    {
        Debug.Log($"GetKnowledgeIndex called with day: {day}, knowledge: {knowledge}");

        if (dayRanges == null)
        {
            Debug.LogError("dayRanges is null");
            return 0;
        }

        if (day < 1 || day >= dayRanges.Length)
        {
            Debug.LogError($"Invalid day: {day}. dayRanges length: {dayRanges.Length}");
            return 0;
        }

        DayRange range = dayRanges[day];
        if (range == null)
        {
            Debug.LogError($"DayRange for day {day} is null");
            return 0;
        }

        if (knowledge >= range.minRangeFirstTitle && knowledge <= range.maxRangeFirstTitle) return 0;
        if (knowledge > range.minRangeSecondTitle && knowledge <= range.maxRangeSecondTitle) return 1;
        if (knowledge > range.minRangeThirdTitle && knowledge <= range.maxRangeThirdTitle) return 2;
        if (knowledge > range.minRangeFourthTitle && knowledge <= range.maxRangeFourthTitle) return 3;

        Debug.LogWarning($"Knowledge {knowledge} is out of all ranges for day {day}");
        return 0;
    }
}