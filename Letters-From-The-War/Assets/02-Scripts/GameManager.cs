using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region FIELDS
    public WordData greenWord;
    public WordData yellowWord;
    public WordData redWord;

    public int minLevelComprensibilityOne = 0;
    public int maxLevelComprensibilityOne = 6;
    public int minLevelComprensibilityTwo = 7;
    public int maxLevelComprensibilityTwo = 15;

    public int minLevelDailyPerfOne = 0;
    public int maxLevelDailyPerfOne = 5;
    public int minLevelDailyPerfTwo = 6;
    public int maxLevelDailyPerfTwo = 10;

    [HideInInspector] public float comprensibility = 0;
    [HideInInspector] public float dailyPerformance = 0;
    public int malus = 0;
    public int knowledge = 0;
    [HideInInspector] public int malusDaily = 0;
    [HideInInspector] public int day = 0;
    [HideInInspector] public bool hasStarted = true;

    public List<Word> listGreenWords = new List<Word>();
    public List<Word> listYellowWords = new List<Word>();
    public List<Word> listRedWords = new List<Word>();
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    //public void Update()
    //{
    //    comprensibility = Mathf.Clamp(comprensibility, minLevelComprensibilityOne, maxLevelComprensibilityTwo);
    //    dailyPerformance = Mathf.Clamp(dailyPerformance, minLevelDailyPerfOne, maxLevelDailyPerfTwo);

    //    if(comprensibility < minLevelComprensibilityOne)
    //    {
    //        comprensibility = minLevelComprensibilityOne;
    //    }
    //    if (comprensibility > maxLevelComprensibilityTwo)
    //    {
    //        comprensibility = maxLevelComprensibilityTwo;
    //    }
    //}
    
    public int Knowledge()
    {
        if (comprensibility >= minLevelComprensibilityOne && comprensibility <= maxLevelComprensibilityOne)
        {
            return knowledge += 1;
        }
        if (comprensibility >= minLevelComprensibilityTwo && comprensibility >= maxLevelComprensibilityTwo)
        {
            return knowledge += 2;
        }
        else
        {
            Debug.Log("Knowledge unchanged");
            return knowledge;
        }
    }

    public int Malus()
    {
        if(dailyPerformance <= minLevelDailyPerfOne && dailyPerformance <= maxLevelDailyPerfOne)
        {
            malusDaily += 2;
            return malus += 2;
        }
        if(dailyPerformance >= minLevelDailyPerfTwo && dailyPerformance >= maxLevelDailyPerfTwo)
        {
            malusDaily += 1;
            return malus += 1; 
        }
        else
        {
            Debug.Log("Malus unchanged");
            return malus;
        }
    }

    #endregion
}