using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    #region Modifiers
    [Header("MODIFIERS")]

    //public float greenComprensibility = 0.2f;
    //public float greenDailyPerformance = 0.2f;

    //public float yellowComprensibiltyObscured = 1f;
    //public float yellowComprensibiltyNotObscured = 2f;
    //public float yellowDailyPerformanceObscured = 2f;
    //public float yellowDailyPerformanceNotObscured = 1f;

    //public float redComprensibiltyObscured = 1f;
    //public float redComprensibiltyNotObscured = 3;
    //public float redDailyPerformanceObscured = 3f;
    //public float redDailyPerformanceNotObscured = 2f;
    #endregion

    public List<Word> greenWords = new List<Word>();
    public List<Word> yellowWords = new List<Word>();
    public List<Word> redWords = new List<Word>();

    private void Start()
    {

        if(greenWord == null || yellowWord == null || redWord == null)
        {
            Debug.LogError("Please assign all WordData in the GameManager via Inspector");
            return;
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
        for (int i = 0; i < greenWords.Count; i++)
        {
            if (greenWords[i].obscured == true)
            {
                comprensibility -= greenWord.comprensibilityWordObscured;
                dailyPerformance -= greenWord.dailyPerfomanceWordObscured;
            }
        }

        for (int i = 0; i < yellowWords.Count; i++)
        {
            if(yellowWords[i].obscured == true)
            {
                comprensibility -= yellowWord.comprensibilityWordObscured;
                dailyPerformance += yellowWord.dailyPerfomanceWordObscured;
            }
            if (yellowWords[i].obscured == false)
            {
                comprensibility += yellowWord.comprensibilityWordNotObscured;
                dailyPerformance -= yellowWord.dailyPerfomanceWordNotObscured;
            }
        }

        for (int i = 0; i < redWords.Count; i++)
        {
            if (redWords[i].obscured == true)
            {
                comprensibility -= redWord.comprensibilityWordObscured;
                dailyPerformance += redWord.dailyPerfomanceWordObscured;
            }
            if (redWords[i].obscured == false)
            {
                comprensibility += redWord.comprensibilityWordObscured;
                dailyPerformance -= redWord.comprensibilityWordNotObscured;
            }
        }
        Debug.Log("comprensibility : " + comprensibility);
        Debug.Log("dailyPerformance: " + dailyPerformance);
    }
}
