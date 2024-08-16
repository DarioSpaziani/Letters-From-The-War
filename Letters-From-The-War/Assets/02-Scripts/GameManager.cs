using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TO DO modificabili valori licenziamento
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

    public bool hasStarted = true;
    [HideInInspector] public int malusDaily = 0;
    [HideInInspector] public int day = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Update()
    {
        comprensibility = Mathf.Clamp(comprensibility, minLevelComprensibilityOne, maxLevelComprensibilityTwo);
        dailyPerformance = Mathf.Clamp(dailyPerformance, minLevelDailyPerfOne, maxLevelDailyPerfTwo);

        if(comprensibility < minLevelComprensibilityOne)
        {
            comprensibility = minLevelComprensibilityOne;
        }
        if (comprensibility > maxLevelComprensibilityTwo)
        {
            comprensibility = maxLevelComprensibilityTwo;
        }
    }

    
    public void Knowledge()
    {
        if (comprensibility >= minLevelComprensibilityOne && comprensibility <= maxLevelComprensibilityOne)
        {
            knowledge += 1;
        }
        if (comprensibility >= minLevelComprensibilityTwo && comprensibility <= minLevelComprensibilityTwo)
        {
            knowledge += 2;
        }
    }

    public void Malus()
    {
        if(dailyPerformance >= minLevelDailyPerfOne && dailyPerformance <= maxLevelDailyPerfOne)
        {
            malus += 2;
            malusDaily += 2;
        }
        if(dailyPerformance >= minLevelDailyPerfTwo && dailyPerformance <= maxLevelDailyPerfTwo)
        {
            malus += 1; 
            malusDaily += 1;
        } 
    }    
}