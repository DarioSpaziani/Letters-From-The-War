using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FillerList : MonoBehaviour
{
    #region FIELDS
    [System.Serializable]
    public class Letter
    {
        [TextArea(3, 10)]
        public string content;
    }

    [ShowInInspector] public List<Letter> lettersTexts = new List<Letter>();

    private GameManager gameManager;
    public List<GameObject> lettersGO = new List<GameObject>();
    public List<GameObject> wordsInGame = new List<GameObject>();
    
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        for(int i = 0; i < lettersGO.Count; i++)
        {
            lettersGO[i].SetActive(false);
        }
        lettersGO[gameManager.day - 1].SetActive(true);

        
    }

    void Start()
    {
        Word[] words = FindObjectsOfType<Word>();

        foreach (var word in words)
        {
            if (word.wordData.category == WordData.wordCategory.GREEN)
            {
                gameManager.listGreenWords.Add(word);
            }
            else if (word.wordData.category == WordData.wordCategory.YELLOW)
            {
                gameManager.listYellowWords.Add(word);
            }
            else if (word.wordData.category == WordData.wordCategory.RED)
            {
                gameManager.listRedWords.Add(word);
            }
        }

        FillerWordsText();
    }

    public void FillerWordsText()
    {
        string[] wordsTexts = lettersTexts[gameManager.day-1].content.Split(new char[] { ' ', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        Word[] allWordComponents = FindObjectsOfType<Word>();
        
        foreach(var wordComponent in allWordComponents)
        {
            GameObject wordObject = wordComponent.gameObject;
            if (wordObject.name.StartsWith("Word") && !wordsInGame.Contains(wordObject))
            {
                wordsInGame.Add(wordObject);
                if (wordsInGame.Count >= 600)
                    break;
            }
        }

        int minLength = Mathf.Min(wordsTexts.Length, wordsInGame.Count);
        for (int i = 0; i < minLength; i++)
        {
            int reverseIndex = wordsInGame.Count - 1 - i;
            if (reverseIndex >= 0 && reverseIndex < wordsInGame.Count)
            {
                GameObject wordObject = wordsInGame[i]; 
                TextMeshProUGUI textWord = wordObject.GetComponentInChildren<TextMeshProUGUI>();
                if (textWord != null)
                {
                    textWord.text = wordsTexts[reverseIndex];
                }
            }
        }
    }
    #endregion
}