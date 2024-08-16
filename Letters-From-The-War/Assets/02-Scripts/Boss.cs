using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;
    private Fade fade;

    public TextMeshProUGUI dialogue1;
    public TextMeshProUGUI dialogue2;
    public TextMeshProUGUI buttonSkip;

    [Header("WARNING SENTENCES")]
    public List<string> warningOneMalusTop;
    public List<string> warningOneMalusBottom;
    public List<string> warningTwoMalusTop;
    public List<string> warningTwoMalusBottom;


    [Header("FIRED SENTENCES")]
    public List<string> firedDialogueTop;
    public List<string> firedDialogueBottom;

    [System.Serializable]
    public class DialogueSet
    {
        public List<string> topDialogues;
        public List<string> bottomDialogues;
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

    [ShowInInspector] private int fired = 4;

    private int currentIndex = 0;

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

        Debug.Log("day : " + gameManager.day);
        Debug.Log("malusDaily : " + gameManager.malusDaily);
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
            DialogueSet currentDialogueSet = GetCurrentDialogueSet();
            if (currentIndex < currentDialogueSet.topDialogues.Count - 1)
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
        dialogue1.text = currentDialogueSet.topDialogues[currentIndex];
        dialogue2.text = currentDialogueSet.bottomDialogues[currentIndex];

        switch (gameManager.malusDaily)
        {
            case 1:

                currentDialogueSet.topDialogues.Add(warningTwoMalusTop[currentIndex]);
                currentDialogueSet.bottomDialogues.Add(warningTwoMalusBottom[currentIndex]);
                break;

            case 2:

                currentDialogueSet.topDialogues.Add(warningTwoMalusTop[currentIndex]);
                currentDialogueSet.bottomDialogues.Add(warningTwoMalusBottom[currentIndex]);
                break;

            default:
                break;
        }

        if(gameManager.malus >= fired)
        {
            currentDialogueSet.topDialogues.Add(firedDialogueTop[currentIndex]);
            currentDialogueSet.bottomDialogues.Add(firedDialogueBottom[currentIndex]);
        }

        if (currentIndex == currentDialogueSet.topDialogues.Count - 1)
        {
            buttonSkip.text = "Next Scene";
        }
    }
    
    private int DetermineMalusLevel(int malusDaily)
    {
        if (malusDaily == 0) return 0;
        if (malusDaily == 1) return 1;
        if (malusDaily == 2) return 2;
        return 4; // Licenziamento
    }

    private void LoadNextScene()
    {
        if (gameManager.hasStarted)
        {
            gameManager.day++;
            gameManager.hasStarted = false;
            SceneManager.LoadScene("02-BossInterview");
        }
        else
        {
            fade.FadeEffect();
            gameManager.malusDaily = 0;
            SceneManager.LoadScene("03-Letter");
        }
    }
}