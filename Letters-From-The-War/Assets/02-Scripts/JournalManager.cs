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
        if (knowledge == 0) return 0;
        if (knowledge >= 1 && knowledge <= 3) return 1;
        if (knowledge >= 4 && knowledge <= 10) return 2;
        return 3;
    }
}