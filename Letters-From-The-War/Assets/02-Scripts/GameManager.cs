using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private GameManager instance;
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

    public bool hasStarted = true;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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

    
    public void Knowledge()
    {
        if (comprensibility >= 6 && comprensibility <= 15)
        {
            knowledge += 1;
        }
        if (comprensibility >= 16 && comprensibility <= 20)
        {
            knowledge += 2;
        }
    }

    public void Malus()
    {
        if(dailyPerformance >= 0 && dailyPerformance <= 5)
        {
            malus += 2;
        }
        if(dailyPerformance >= 6 && dailyPerformance <= 15)
        {
            malus += 1;
        } 
    }    
}
