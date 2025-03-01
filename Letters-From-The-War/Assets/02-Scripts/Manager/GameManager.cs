using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region FIELDS

    public static GameManager Instance;

    [Header("SO Words")]
    public WordData greenWord;
    public WordData yellowWord;
    public WordData redWord;

    [Header("Comprensibility One")]
    public int minLevelComprensibilityOne = 0;
    public int maxLevelComprensibilityOne = 6;
    [Header("Comprensibility Two")]
    public int minLevelComprensibilityTwo = 7;
    public int maxLevelComprensibilityTwo = 15;


    [Header("Daily Perfomance One")]
    public int minLevelDailyPerfOne = 0;
    public int maxLevelDailyPerfOne = 5;
    [Header("Daily Perfomance Two")]
    public int minLevelDailyPerfTwo = 6;
    public int maxLevelDailyPerfTwo = 15;


    [Header("Daily Valutation")]
    public int malus = 0;
    public int knowledge = 0;

    [HideInInspector] public float comprensibility = 0;
    [HideInInspector] public float dailyPerformance = 0;
    [HideInInspector] public bool hasStarted = false;
    [HideInInspector] public bool firstAssignement = false;
    [HideInInspector] public bool getFired = false;
    [HideInInspector] public bool hope = false;
    [HideInInspector] public bool invasion = false;
    [HideInInspector] public bool exodus = false;
    [HideInInspector] public bool insurrection = false;
    [HideInInspector] public int malusDaily = 0;
    [ShowInInspector] public int day = 0;

    [Header("Words")]
    public List<Word> listGreenWords = new List<Word>();
    public List<Word> listYellowWords = new List<Word>();
    public List<Word> listRedWords = new List<Word>();

    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.U))
        {
            day += 1;
            SceneManager.LoadScene("03-Letter");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            malus = 0;
        }
#endif

        comprensibility = Mathf.Clamp(comprensibility, minLevelComprensibilityOne, maxLevelComprensibilityTwo);
        dailyPerformance = Mathf.Clamp(dailyPerformance, minLevelDailyPerfOne, maxLevelDailyPerfTwo);

        if (comprensibility < minLevelComprensibilityOne)
        {
            comprensibility = minLevelComprensibilityOne;
        }
        if (comprensibility > maxLevelComprensibilityTwo)
        {
            comprensibility = maxLevelComprensibilityTwo;
        }
    }

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
            return knowledge;
        }
    }

    public int Malus()
    {
        if(dailyPerformance < minLevelDailyPerfOne) 
        {
            malusDaily += 2;
            return malus += 2;
        }
        if (dailyPerformance >= minLevelDailyPerfOne && dailyPerformance <= maxLevelDailyPerfOne)
        {
            malusDaily += 2;
            return malus += 2;
        }
        if(dailyPerformance >= minLevelDailyPerfTwo && dailyPerformance <= maxLevelDailyPerfTwo)
        {
            malusDaily += 1;
            return malus += 1; 
        }
        if(dailyPerformance > maxLevelDailyPerfTwo)
        {
            return malus += 0;
        }
        else
        {
            return malus;
        }
    }

    public void UnlockAchievement(string achievemntID, bool value)
    {
        if (value)
        {
            Steamworks.SteamUserStats.SetAchievement(achievemntID);
            Debug.Log($"Achievement unlocked: {achievemntID}, from game manager");
        }
    }

    #endregion
}