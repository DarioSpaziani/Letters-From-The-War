using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDialogue : MonoBehaviour
{
    public List<string> bossDialogue1 = new List<string>();
    public List<string> bossDialogue2 = new List<string>();

    public TextMeshProUGUI dialogue1;
    public TextMeshProUGUI dialogue2;
    public TextMeshProUGUI buttonSkip;

    #region Feedback Lists
    public List<string> bossFeedbackDialogueZeroTop;
    public List<string> bossFeedbackDialogueZeroBottom;
    public List<string> bossFeedbackDialogueOneTop;
    public List<string> bossFeedbackDialogueOneBottom;
    public List<string> bossFeedbackDialogueTwoTop;
    public List<string> bossFeedbackDialogueTwoBottom;
    public List<string> bossFeedbackDialogueThreeTop;
    public List<string> bossFeedbackDialogueThreeBottom;
    #endregion

    private int currentIndex = 0;

    private Dictionary<int, (List<string> top, List<string> bottom)> dialogueSet;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        InitializeDialogue();
        if (bossDialogue1.Count > 0 && bossDialogue2.Count > 0)
        {
            UpdateDialogues();
        }
        else
        {
            Debug.LogWarning("Dialogue lists are empty or not assigned.");
        }
    }
    private void InitializeDialogue()
    {
        dialogueSet = new Dictionary<int, (List<string> top, List<string> bottom)>
        {
            { 0, (bossFeedbackDialogueZeroTop, bossFeedbackDialogueZeroBottom) },
            { 1, (bossFeedbackDialogueOneTop, bossFeedbackDialogueOneBottom) },
            { 2, (bossFeedbackDialogueTwoTop, bossFeedbackDialogueTwoBottom) },
            { 3, (bossFeedbackDialogueThreeTop, bossFeedbackDialogueThreeBottom) }
        }; 
    }

    public void CycleDialogue()
    {
        int dialogueSetKey = DetermineDialogueSetKey();
        if (currentIndex < dialogueSet[dialogueSetKey].top.Count -1 && currentIndex < dialogueSet[dialogueSetKey].bottom.Count - 1)
        {
            currentIndex++;
            UpdateDialogues();
        }
        else
        {
            gameManager.hasStarted = false;
            LoadNextScene();
        }
    }

    public int DetermineDialogueSetKey()
    {
        if(gameManager.malus == 0)
        {
            return 0;
        }
        if(gameManager.malus > 0 && gameManager.malus <= 5)
        {
            return 1;
        }
        if(gameManager.malus > 5 && gameManager.malus <= 10)
        {
            return 2;
        }
        if(gameManager.malus > 10 && gameManager.malus <= 15)
        {
            return 3;
        }
        return 0;
    }

    private void UpdateDialogues()
    {
        int dialogueSetKey = DetermineDialogueSetKey();
        var (topList, bottomList) = dialogueSet[dialogueSetKey];
        if (gameManager.hasStarted)
        {
            dialogue1.text = bossDialogue1[currentIndex];
            dialogue2.text = bossDialogue2[currentIndex];
        }
        else
        {
            dialogue1.text= topList[currentIndex];
            dialogue2.text= bottomList[currentIndex];
        }
        if (currentIndex == bossDialogue1.Count - 1 || currentIndex == bossDialogue2.Count - 1)
        {
            buttonSkip.text = "Next Scene";
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("02-Letter");
    }
}
