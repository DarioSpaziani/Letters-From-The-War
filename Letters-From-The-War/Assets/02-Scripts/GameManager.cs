using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0, 20)]
    public int comprensibility = 0;

    [Range(0, 20)]
    public int dailyPerformance = 0;

    [Range(0, 20)]
    public int malus = 0;

    [Range(0, 20)]
    public int knowledge = 0;

    public List<Word> greenWords = new List<Word>();
    public List<Word> yellowWords = new List<Word>();
    public List<Word> redWords = new List<Word>();

    public void Update()
    {
        if (comprensibility <= 0) comprensibility = 0;
        if (comprensibility >= 20) comprensibility = 20;
    }

    public void Send()
    {
        Debug.Log("Entrato");
        for (int i = 0; i < greenWords.Count; i++)
        {
            if (greenWords[i].obscured == true)
            {
                comprensibility -= 1;
                Debug.Log(comprensibility);
            }
            if (greenWords[i].obscured == false)
            {
                comprensibility += 1;
                Debug.Log(comprensibility);
            }
        }

        for (int i = 0; i < yellowWords.Count; i++)
        {
            if(yellowWords[i].obscured == true)
            {
                comprensibility += 1;
                Debug.Log(comprensibility);
            }
            if (yellowWords[i].obscured == false)
            {
                comprensibility -= 1;
                Debug.Log(comprensibility);
            }
        }

        for (int i = 0; i < redWords.Count; i++)
        {
            if (redWords[i].obscured == true)
            {
                comprensibility += 2;
                Debug.Log(comprensibility);
            }
            if (redWords[i].obscured == false)
            {
                comprensibility -= 2;
                Debug.Log(comprensibility);
            }
        }
    }
}
