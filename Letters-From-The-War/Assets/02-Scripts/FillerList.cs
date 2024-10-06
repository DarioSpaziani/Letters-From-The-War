using System.Collections.Generic;
using UnityEngine;

public class FillerList : MonoBehaviour
{
    #region FIELDS
    private GameManager gameManager;
    public List<GameObject> letters = new List<GameObject>();
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        for(int i = 0; i < letters.Count; i++)
        {
            letters[i].SetActive(false);
        }
        letters[gameManager.day - 1].SetActive(true);

    }

    void Start()
    {
        Word[] words = FindObjectsOfType<Word>();

        foreach (var w in words)
        {
            if (w.wordData.category == WordData.wordCategory.GREEN)
            {
                gameManager.listGreenWords.Add(w);
            }
            else if (w.wordData.category == WordData.wordCategory.YELLOW)
            {
                gameManager.listYellowWords.Add(w);
            }
            else if (w.wordData.category == WordData.wordCategory.RED)
            {
                gameManager.listRedWords.Add(w);
            }
        }
    }
    #endregion
}