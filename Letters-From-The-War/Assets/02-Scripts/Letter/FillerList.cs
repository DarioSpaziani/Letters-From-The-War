using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillerList : MonoBehaviour
{
    //OPTIMIZE: invece che limitPos usare la larghezza della rectTransform della lettera
    #region FIELDS

    #region CLASSES

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

    #endregion

    #region LISTS
    [ShowInInspector] public List<StartLetter> startLettersTexts = new List<StartLetter>();
    [ShowInInspector] public List<BodyLetter> bodyLettersTexts = new List<BodyLetter>();
    [ShowInInspector] public List<EndLetter> endLettersTexts = new List<EndLetter>();
    
    [ShowInInspector] public List<string> endFirstLetterWord = new List<string>();

    [ShowInInspector] public List<GameObject> startLetter = new List<GameObject>();
    [ShowInInspector] public List<GameObject> bodyLetter = new List<GameObject>();
    [ShowInInspector] public List<GameObject> endLetter = new List<GameObject>();

    [ShowInInspector] public List<GameObject> lettersGO = new List<GameObject>();
    [ShowInInspector] public List<GameObject> wordsInGame = new List<GameObject>();
    [ShowInInspector] public List<GameObject> imagesInGame = new List<GameObject>();

    #endregion

    #region VARIABLES

    [SerializeField] private GameObject imageTutorial;

    private GameManager gameManager;
    private Fade fade;

    public Vector2 startPoint;
    public Vector2 startPoint2;

    public Sprite spriteImageCensoring;

    public float limitPos = 500;
    public float limitPos2;
    public float offsetX;
    public float offsetY;


    #endregion

    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();

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
        StartCoroutine(fade.FadeReverseLetter());
        Invoke("GridWords", .5f);
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
        // Inizializza la posizione corrente con il punto di partenza originale
        Vector2 currentPos = startPoint;
        int a = 0;
        bool isSecondGrid = false; // Flag per indicare se siamo nella seconda griglia

        for (int i = 0; i < wordsInGame.Count; i++)
        {
            TextMeshProUGUI textComponent = wordsInGame[i].GetComponentInChildren<TextMeshProUGUI>();
            string wordText = textComponent != null ? textComponent.text : string.Empty;
            int currentDay = gameManager.day;
            
            //prende la componente RectTransform per posizionare le parole sul canvas
            RectTransform rect = wordsInGame[i].GetComponent<RectTransform>();

            //in base all'ancora posiziona le parole in quel punto
            rect.anchoredPosition = currentPos;
            
            //dopo la prima parola calcola la lunghezza della parola pi� la spazio
            currentPos.x += CalculateLengthWord(wordsInGame[i]) + offsetX -0.1f;
            

            //TODO sarebbe da gestire meglio la posizione dell'immagine uguale allo spazio tra le parole
            Vector2 posFill = new Vector2(currentPos.x - offsetX, currentPos.y);

            FillCensorImage(wordsInGame[i], posFill, a);
            a++;

            if (!isSecondGrid && (currentDay == 2 || currentDay == 3 || currentDay == 4 || currentDay == 5) && endFirstLetterWord.Contains(wordText))
            {
                currentPos = startPoint2;
                isSecondGrid = true;
            }


            //controlla quando finisce l'elenco per evitare errore ArgumentOutOfRangeException
            if (i + 1 < wordsInGame.Count && rect.anchoredPosition.x + CalculateLengthWord(wordsInGame[i + 1]) >= limitPos)
            {
                float currentLimitPos = isSecondGrid ? limitPos2 : limitPos;
                 
                // Se la posizione supera il limite, torna all'inizio della riga
                if (rect.anchoredPosition.x + CalculateLengthWord(wordsInGame[i + 1]) >= currentLimitPos)
                {
                    currentPos.x = isSecondGrid ? startPoint2.x : startPoint.x;
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

    private void FillCensorImage(GameObject preWord, Vector2 pos, int a)
    {
        float width = offsetX + .1f;
        RectTransform heightOriginal = preWord.GetComponent<RectTransform>();
        Vector2 originalSize = heightOriginal.sizeDelta;
        GameObject censorGO = new GameObject($"CensorGO({a})");

        imagesInGame.Add(censorGO );

        Image censorImage = censorGO.AddComponent<Image>();
        censorImage.sprite = spriteImageCensoring;
        censorImage.type = Image.Type.Sliced;
        censorImage.pixelsPerUnitMultiplier = 100;
        censorImage.color = new Color(0, 0, 0, 0);

        RectTransform censorRect = censorImage.GetComponent<RectTransform>();

        censorRect.SetParent(bodyLetter[gameManager.day -1].transform);
        censorRect.anchorMin = new Vector2(0f, 1f);
        censorRect.anchorMax = new Vector2(0f, 1f);

        censorRect.pivot = new Vector2(0f, 0.5f);

        censorRect.anchoredPosition = pos;

        censorRect.sizeDelta = new Vector2(width, originalSize.y);
    }

    public void SyncObscuredStates()
    {
        for (int i = 0; i < wordsInGame.Count; i++)
        {
            Word word = wordsInGame[i].GetComponent<Word>();
            Image image = imagesInGame[i].GetComponent<Image>();

            if (word.obscured)
            {

                image.color = new Color(0, 0, 0, 1);
            }
            else
            {

                image.color = new Color(0, 0, 0, 0);
            }
        }
    }

    #endregion
}