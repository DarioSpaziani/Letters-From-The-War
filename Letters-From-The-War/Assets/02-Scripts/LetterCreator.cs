using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class LetterCreator : MonoBehaviour
{
    #region FIELDS

    [Serializable]
    public class Letter
    {
        [TextArea(3, 10)] public string content;
    }

    [ShowInInspector] public List<Letter> letters = new List<Letter>();
    public TextMeshProUGUI letterText;
    private GameManager gameManager;
    private WordData wordData;
    public GameObject wordPrefab;

    public float spaceBetweenWords = 10f;
    public float lineHeight = 30f;
    public float maxLineWidth = 300f;
    private int currentDay = 0;
    private List<GameObject> wordObjects = new List<GameObject>();
    private Word word;

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

    void DisplayLetter()
    {
        ClearExistingWords();
        if (currentDay < letters.Count)
        {
            letterText.text = FormatLetter(letters[currentDay].content);
        }

        string[] parts = Regex.Split(letters[currentDay].content, @"(\r?\n|\r){2,}");
        Vector3 currentPosition = transform.position;

        foreach (string paragraph in parts)
        {
            string[] words = paragraph.Split(' ');
            foreach (string word in words)
            {
                GameObject wordObject = Instantiate(wordPrefab, currentPosition, Quaternion.identity, transform);

                RectTransform rectTransform = wordObject.GetComponent<RectTransform>();
                currentPosition.x += rectTransform.rect.width + spaceBetweenWords;

                if (currentPosition.x > transform.position.x + maxLineWidth)
                {
                    currentPosition.x = transform.position.x;
                    currentPosition.y -= lineHeight;
                }

                wordObjects.Add(wordObject);
            }

            // Vai a capo dopo ogni paragrafo
            currentPosition.x = transform.position.x;
            currentPosition.y -= lineHeight * 2;
        }
    }

    private string FormatLetter(string content)
    {
        // Dividi la lettera in tre parti: inizio, corpo e fine
        string[] parts = Regex.Split(content, @"(\r?\n|\r){2,}");

        if (parts.Length >= 3)
        {
            string start = parts[0].Trim();
            string end = parts[parts.Length - 1].Trim();
            string body = string.Join("\n", parts, 1, parts.Length - 2).Trim();

            // Formatta la lettera con spaziature appropriate
            return $"{start}\n\n{body}\n\n{end}";
        }
        else
        {
            // Se la lettera non ha la struttura attesa, restituisci il contenuto originale
            return content.Trim();
        }
    }

    WordData CreateOrLoadWordData(string word)
    {
        // Implementa qui la logica per caricare o creare WordData
        // Esempio semplificato:
        WordData wordData = ScriptableObject.CreateInstance<WordData>();
        return wordData;
    }

    void ClearExistingWords()
    {
        foreach (GameObject wordObject in wordObjects)
        {
            Destroy(wordObject);
        }

        wordObjects.Clear();
    }

    #endregion
}