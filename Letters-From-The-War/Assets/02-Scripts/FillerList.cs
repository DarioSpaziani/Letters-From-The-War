using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillerList : MonoBehaviour
{
    #region FIELDS

    [System.Serializable]
    public class StartLetter
    {
        public string content;
    }

    [System.Serializable]
    public class BodyLetter
    {
        [TextArea(3, 10)]
        public string content;
    }

    [System.Serializable]
    public class EndLetter
    {
        public string content;
    }

    [ShowInInspector] public List<StartLetter> startLettersTexts = new List<StartLetter>();
    [ShowInInspector] public List<BodyLetter> bodyLettersTexts = new List<BodyLetter>();
    [ShowInInspector] public List<EndLetter> endLettersTexts = new List<EndLetter>();

    public List<GameObject> startLetter = new List<GameObject>();
    public List<GameObject> endLetter = new List<GameObject>();

    private GameManager gameManager;
    public List<GameObject> lettersGO = new List<GameObject>();
    public List<GameObject> wordsInGame = new List<GameObject>();
    [SerializeField] private GameObject imageTutorial;

    public Vector2 startPoint;

    public float limitPos = 500;
    public float offsetX;
    public float offsetY;


    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 0; i < lettersGO.Count; i++)
        {
            lettersGO[i].SetActive(false);
        }

        lettersGO[gameManager.day - 1].SetActive(true);

        if (gameManager.day > 1)
        {
            imageTutorial.SetActive(false);
        }
        for (int i = 0; i < startLetter.Count; i++)
        {
            TextMeshProUGUI startLettersText = startLetter[i].GetComponentInChildren<TextMeshProUGUI>();
            startLettersText.text = startLettersTexts[i].content;

            TextMeshProUGUI endLettersText = endLetter[i].GetComponentInChildren<TextMeshProUGUI>();
            endLettersText.text = endLettersTexts[i].content;
        }
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

    void Start()
    {
        Invoke("GridWords",.2f);
    }

    public void FillerWordsText()
    {

        string[] wordsTexts = bodyLettersTexts[gameManager.day - 1].content.Split(new char[] { ' ', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        Word[] allWordComponents = FindObjectsOfType<Word>();

        foreach (var wordComponent in allWordComponents)
        {
            GameObject wordObject = wordComponent.gameObject;
            if (wordObject.name.StartsWith("Start") && !wordsInGame.Contains(wordObject))
            {
                wordsInGame.Add(wordObject);
            }
            if (wordObject.name.StartsWith("Word") && !wordsInGame.Contains(wordObject))
            {
                wordsInGame.Add(wordObject);
                if (wordsInGame.Count >= 1000)
                {
                    wordObject.SetActive(true);
                    break;
                }
            }
            if (wordObject.name.StartsWith("End") && !wordsInGame.Contains(wordObject))
            {
                wordsInGame.Add(wordObject);
            }

        }

        wordsInGame.Reverse();

        int minLength = Mathf.Min(wordsTexts.Length, wordsInGame.Count);
        for (int i = 0; i < minLength; i++)
        {
            GameObject wordObject = wordsInGame[i];

            TextMeshProUGUI textWord = wordObject.GetComponentInChildren<TextMeshProUGUI>();

            if (textWord != null)
            {
                textWord.text = wordsTexts[i];
            }
        }

        for (int i = minLength; i < wordsInGame.Count; i++)
        {
            GameObject wordObject = wordsInGame[i];
            TextMeshProUGUI textWord = wordObject.GetComponentInChildren<TextMeshProUGUI>();


            if (textWord != null)
            {
                textWord.text = "";
                wordObject.SetActive(false);
            }
        }

    }

    public void GridWords()
    {
        //mette le parole nel punto selezionato
        Vector2 currentPos = startPoint;


        for (int i = 0; i < wordsInGame.Count; i++)
        {
            //prende la componente RectTransform per posizionare le parole sul canvas
            RectTransform rect = wordsInGame[i].GetComponent<RectTransform>();
            //Image censoredImage = wordsInGame[i].GetComponent<Image>();

            //in base all'ancora posiziona le parole in quel punto
            rect.anchoredPosition = currentPos;

            //dopo la prima parola calcola la lunghezza della parola più la spazio
            currentPos.x += CalculateLengthWord(wordsInGame[i]) + offsetX;

            //controlla quando finisce l'elenco per evitare errore ArgumentOutOfRangeException
            if(i + 1 < wordsInGame.Count)
            {
                //posiziona le parole dopo aver calcolato lunghezza parola e offset 
                if (rect.anchoredPosition.x + CalculateLengthWord(wordsInGame[i + 1]) >= limitPos)
                {
                    //RectTransform nextRect = wordsInGame[i + 1].GetComponent<RectTransform>();
                    //float newWidth = nextRect.anchoredPosition.x - rect.anchoredPosition.x;
                    //Vector2 originalSize = censoredImage.rectTransform.sizeDelta;
                    //censoredImage.rectTransform.sizeDelta = new Vector2(newWidth, originalSize.y);

                    currentPos.x = startPoint.x;

                    currentPos.y -= offsetY;
                }
            }
        }
    }

    private float CalculateLengthWord(GameObject word)
    {
        RectTransform rt = word.GetComponent<RectTransform>();
 
        return rt.rect.width;
    }

    #endregion
}