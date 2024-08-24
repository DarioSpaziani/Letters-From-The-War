using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;


public class JournalManager : MonoBehaviour
    {
        [System.Serializable]
    public class DayRange
    {
        public float minRangeFirstTitle;
        public float maxRangeFirstTitle;
        public float minRangeSecondTitle;
        public float maxRangeSecondTitle;
        public float minRangeThirdTitle;
        public float maxRangeThirdTitle;
        public float minRangeFourthTitle;
        public float maxRangeFourthTitle;
    }

    [System.Serializable]
    public class DayDescriptions
    {
        public string descriptionFirstRange;
        public string descriptionSecondRange;
        public string descriptionThirdRange;
        public string descriptionFourthRange;
    }

    [System.Serializable]
    public class DayData
    {
        public DayRange range;
        public DayDescriptions descriptions;
    }

    private GameManager gameManager;

    [Header("Day One")]

    public DayData dayOne;
    [Header("Day Two")]

    public DayData dayTwo; 
    [Header("Day Three")]

    public DayData dayThree;
    [Header("Day Four")]

    public DayData dayFour;
    [Header("Day Five")]

    public DayData dayFive;
    [Header("Day Six")]
    public DayData daySix;

    [Header("Day Seven")]
    public DayData daySeven;

    private DayData[] dayData = new DayData[6]; // 0-7 (8 elementi)

    public TextMeshProUGUI headlineText;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found!");
        }
        dayData = new DayData[] { dayOne, dayTwo, dayThree, dayFour, dayFive, daySix, daySeven };
    }

    private void Start()
    {
        UpdateJournalDisplay();
    }

    public void UpdateJournalDisplay()
    {
        ShowTextDescriptions();
        Debug.Log($"Day: {gameManager.day}, Knowledge: {gameManager.knowledge}, Index: {GetKnowledgeIndex(gameManager.day, gameManager.knowledge)}");
    }

    private void ShowTextDescriptions()
    {
        Debug.Log($"Showing description for day: {gameManager.day}");
        Debug.Log($"Current knowledge: {gameManager.knowledge}");

        if (gameManager.day >= 1 && gameManager.day < dayData.Length)
        {
            DayData currentDay = dayData[gameManager.day - 1];
            int knowledgeIndex = GetKnowledgeIndex(gameManager.day, gameManager.knowledge);
            Debug.Log($"Knowledge index: {knowledgeIndex}");

            switch (knowledgeIndex)
            {
                case 0:
                    headlineText.text = currentDay.descriptions.descriptionFirstRange;
                    break;
                case 1:
                    headlineText.text = currentDay.descriptions.descriptionSecondRange;
                    break;
                case 2:
                    headlineText.text = currentDay.descriptions.descriptionThirdRange;
                    break;
                case 3:
                    headlineText.text = currentDay.descriptions.descriptionFourthRange;
                    break;
                default:
                    Debug.LogError($"Invalid knowledge index: {knowledgeIndex}");
                    break;
            }
        }
        else
        {
            Debug.LogError($"Invalid day: {gameManager.day}");
        }
    }

    private int GetKnowledgeIndex(int day, int knowledge)
    {
        Debug.Log($"GetKnowledgeIndex called with day: {day}, knowledge: {knowledge}");

        if (day < 1 || day >= dayData.Length)
        {
            Debug.LogError($"Invalid day: {day}. dayData length: {dayData.Length}");
            return 0;
        }

        DayRange range = dayData[day].range;

        if (knowledge >= range.minRangeFirstTitle && knowledge <= range.maxRangeFirstTitle) return 0;
        if (knowledge > range.minRangeSecondTitle && knowledge <= range.maxRangeSecondTitle) return 1;
        if (knowledge > range.minRangeThirdTitle && knowledge <= range.maxRangeThirdTitle) return 2;
        if (knowledge > range.minRangeFourthTitle && knowledge <= range.maxRangeFourthTitle) return 3;

        Debug.LogWarning($"Knowledge {knowledge} is out of all ranges for day {day}");
        return 0;
    }
}