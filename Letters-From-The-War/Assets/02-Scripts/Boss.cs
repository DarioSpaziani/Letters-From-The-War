using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region FIELDS
    #region VARIABLES
    private GameManager gameManager;
    [ShowInInspector] private Fade fade;

    public TextMeshProUGUI dialogueText;

    [ShowInInspector] private int fired = 4;
    private int currentIndex = 0;
    #endregion

    #region SENTENCES
    [Header("WARNING SENTENCES")]
    public List<string> warningOne;
    public List<string> warningTwo;


    [Header("FIRED SENTENCES")]
    public List<string> firedDialogue;
    #endregion

    #region DIALOGUES DATA
    [System.Serializable]
    public class DialogueSet
    {
        public List<string> currentDialogue;
    }

    [System.Serializable]
    public class DailyDialogue
    {
        public DialogueSet zeroMalusDaily;
        public DialogueSet oneMalusDaily;
        public DialogueSet twoMalusDaily;
    }

    public DayZero dayZero;
    public DayOne dayOne;
    public DayTwo dayTwo;
    public DayThree dayThree;
    public DayFour dayFour;
    public DayFive dayFive;
    public DaySix daySix;
    public DaySeven daySeven;

    private List<DailyDialogue> dailyDialogues;
    #endregion
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
        InitializeDailyDialogues();
    }
    
    private void InitializeDailyDialogues()
    {
        dailyDialogues = new List<DailyDialogue>
        {
            dayZero, dayOne, dayTwo, dayThree, dayFour, dayFive, daySix, daySeven
        };
    }

    private void Start()
    {
        switch (gameManager.malusDaily)
        {
            case 1:

                foreach(string warningSentence in warningOne)
                {
                    GetCurrentDialogueSet().currentDialogue.Add(warningSentence);
                }
                break;

            case 2:
                foreach (string warningSentence in warningTwo) 
                { 
                    GetCurrentDialogueSet().currentDialogue.Add(warningSentence);
                }
                break;

            default:
                break;
        }
        if (gameManager.malus >= fired)
        {
            foreach(string firedSentences in firedDialogue)
                GetCurrentDialogueSet().currentDialogue.Add(firedSentences);
        }
        if (!gameManager.hasStarted)
        {
            StartCoroutine(fade.FadeReverse());
        }
        UpdateDialogues();
    }

    public void CycleDialogue()
    {
        if (!fade.isFadeEnded)
        {
            if (currentIndex < GetCurrentDialogueSet().currentDialogue.Count - 1)
            {
                currentIndex++;
                UpdateDialogues();
            }
            else
            {
                LoadNextScene(); 
            }
        }
    }

    private DialogueSet GetCurrentDialogueSet()
    {
        DailyDialogue dailyDialogue = dailyDialogues[gameManager.day];

        int malusLevel = DetermineMalusLevel(gameManager.malusDaily);

        switch (malusLevel)
        {
            case 0: return dailyDialogue.zeroMalusDaily;
            case 1: return dailyDialogue.oneMalusDaily;
            case 2: return dailyDialogue.twoMalusDaily;
            default: return dailyDialogue.zeroMalusDaily;
        }
    }

    private void UpdateDialogues()
    {
        DialogueSet currentDialogueSet = GetCurrentDialogueSet();
        dialogueText.text = currentDialogueSet.currentDialogue[currentIndex];
    }
    
    private int DetermineMalusLevel(int malusDaily)
    {
        if (malusDaily == 0) return 0;
        if (malusDaily == 1) return 1;
        if (malusDaily == 2) return 2;
        return fired; // Licenziamento
    }

    private void LoadNextScene()
    {
        if (gameManager.hasStarted)
        {
            gameManager.day++;
            gameManager.hasStarted = false;
            fade.StartCoroutine(fade.CheckFadeAndLoadScene("02-Boss"));
        }
        else if(DetermineMalusLevel(gameManager.malus) >= fired)
        {
            Debug.LogWarning("LICENZIATO");
            fade.StartCoroutine(fade.CheckFadeAndLoadScene("05-End"));
        }
        else 
        {
            gameManager.malusDaily = 0;
            fade.StartCoroutine(fade.CheckFadeAndLoadScene("03-Letter"));
        }
    }
    #endregion
}