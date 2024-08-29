using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class LetterCreator : MonoBehaviour
{
    #region FIELDS
    [System.Serializable]
    public class Letter
    {
        [TextArea(3, 10)]
        public string content;
    }

    [ShowInInspector]public List<Letter> letters = new List<Letter> ();
    public TextMeshProUGUI letterText;
    private GameManager gameManager;
    private int currentDay = 0;
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        currentDay = gameManager.day;
        DisplayLetter();
    }

    public void DisplayLetter()
    {
        if (currentDay < letters.Count)
        {
            letterText.text = FormatLetter(letters[currentDay].content);
        }
    }

    private string FormatLetter(string content)
    {
        string[] parts = Regex.Split(content, @"(\r?\n|\r){2,}");

        if (parts.Length >= 3)
        {
            string start = parts[0].Trim();
            string end = parts[parts.Length - 1].Trim();
            string body = string.Join("\n", parts, 1, parts.Length - 2).Trim();

            return $"{start}\n\n{body}\n\n{end}";
        }
        else
        {
            // Se la lettera non ha la struttura attesa, restituisci il contenuto originale
            return content.Trim();
        }
    }
    public void NextLetter()
    {
        currentDay = (currentDay + 1) % letters.Count;
        DisplayLetter();
    }
    #endregion
}
