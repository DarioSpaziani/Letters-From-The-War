using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    #region FIELDS
    #region VARIABLES
    private GameManager gameManager;
    [SerializeField] private Fade fade;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private int fired = 4;
    [SerializeField] private Button nextScene;
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
        nextScene = GetComponentInChildren<Button>();
        nextScene.interactable = true;
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
        else
        {
            StartCoroutine(fade.FadeReverse());
        }
        UpdateDialogues();
    }

    public void CycleDialogue()
    {
        if (fade.isFadeEnded)
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
        if (malusDaily == 3) return 3;
        return fired; // Licenziamento
    }

    private void LoadNextScene()
    {
        if (fade.isFadeEnded)
        {
            if (gameManager.hasStarted)
            {
                nextScene.interactable = false;
                gameManager.day++;
                gameManager.hasStarted = false;
                fade.CheckFadeAndLoad("02-Boss");
            }
            else if (DetermineMalusLevel(gameManager.malus) >= fired)
            {
                nextScene.interactable = false;
                Debug.LogWarning("LICENZIATO");
                fade.CheckFadeAndLoad("05-End");
            }
            else
            {
                nextScene.interactable = false;
                gameManager.malusDaily = 0;
                fade.CheckFadeAndLoad("03-Letter");
            }
        }

    }
    #endregion
}