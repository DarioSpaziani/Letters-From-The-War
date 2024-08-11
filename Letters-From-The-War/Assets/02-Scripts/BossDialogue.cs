using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDialogue : MonoBehaviour
{
    private GameManager gameManager;
    private Fade fade;

    public TextMeshProUGUI dialogue1;
    public TextMeshProUGUI dialogue2;
    public TextMeshProUGUI buttonSkip;

    [System.Serializable]
    public class DialogueSet
    {
        public List<string> topDialogues;
        public List<string> bottomDialogues;
    }

    [System.Serializable]
    public class DailyDialogue
    {
        public DialogueSet zeroMalus;
        public DialogueSet oneMalus;
        public DialogueSet twoMalus;
        public DialogueSet threeMalus;
        public DialogueSet fourMalus;
    }

    public DayOne dayOne;
    public DayTwo dayTwo;
    public DayThree dayThree;
    public DayFour dayFour;
    public DayFive dayFive;
    public DaySix daySix;
    public DaySeven daySeven;

    private List<DailyDialogue> dailyDialogues;

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
            dayOne, dayTwo, dayThree, dayFour, dayFive, daySix, daySeven
        };
    }

    private void Start()
    {
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
        int currentDay = Mathf.Clamp(gameManager.day - 1, 0, dailyDialogues.Count - 1);
        DailyDialogue dailyDialogue = dailyDialogues[currentDay];

        int malusLevel = DetermineMalusLevel(gameManager.malus);
        switch (malusLevel)
        {
            case 0: return dailyDialogue.zeroMalus;
            case 1: return dailyDialogue.oneMalus;
            case 2: return dailyDialogue.twoMalus;
            case 3: return dailyDialogue.threeMalus;
            case 4: return dailyDialogue.fourMalus;
            default: return dailyDialogue.zeroMalus;
        }
    }

    private int DetermineMalusLevel(int malus)
    {
        if (malus == 0) return 0;
        if (malus <= 2) return 1;
        if (malus <= 4) return 2;
        if (malus <= 6) return 3;
        return 4; // Licenziamento
    }

    private void UpdateDialogues()
    {
        DialogueSet currentDialogueSet = GetCurrentDialogueSet();
        dialogue1.text = currentDialogueSet.topDialogues[currentIndex];
        dialogue2.text = currentDialogueSet.bottomDialogues[currentIndex];

        if (currentIndex == currentDialogueSet.topDialogues.Count - 1)
        {
            buttonSkip.text = "Next Scene";
        }
    }

    private void LoadNextScene()
    {
        if (gameManager.hasStarted)
        {
            SceneManager.LoadScene("02-BossInterview");
            gameManager.hasStarted = false;
        }
        else
        {
            fade.FadeEffect();
            SceneManager.LoadScene("03-Letter");
        }
    }
}