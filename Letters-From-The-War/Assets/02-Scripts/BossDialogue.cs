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
    public List<string> bossFeedbackDialogueATop;
    public List<string> bossFeedbackDialogueABottom;
    public List<string> bossFeedbackDialogueBTop;
    public List<string> bossFeedbackDialogueBBottom;
    public List<string> bossFeedbackDialogueCTop;
    public List<string> bossFeedbackDialogueCBottom;
    public List<string> bossFeedbackDialogueDTop;
    public List<string> bossFeedbackDialogueDBottom;
    public List<string> bossFeedbackDialogueETop;
    public List<string> bossFeedbackDialogueEBottom;
    public List<string> bossFeedbackDialogueFTop;
    public List<string> bossFeedbackDialogueFBottom;
    public List<string> bossFeedbackDialogueGTop;
    public List<string> bossFeedbackDialogueGBottom;
    #endregion

    private int currentIndex = 0;

    private Dictionary<int, (List<string> top, List<string> bottom)> dialogueSet;

    private GameManager gameManager;
    private Fade fade;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        fade = FindObjectOfType<Fade>();
    }

    private void Start()
    {
        if (!gameManager.hasStarted)
        {
            StartCoroutine(fade.FadeReverse());
        }
        
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
            { 0, (bossFeedbackDialogueATop, bossFeedbackDialogueABottom) },
            { 1, (bossFeedbackDialogueBTop, bossFeedbackDialogueBBottom) },
            { 2, (bossFeedbackDialogueCTop, bossFeedbackDialogueCBottom) },
            { 3, (bossFeedbackDialogueDTop, bossFeedbackDialogueDBottom) }
        }; 
    }

    public void CycleDialogue()
    {
        int dialogueSetKey = DetermineDialogueSetKey();
        if (!fade.isFadeEnded)
        {
            if (currentIndex < dialogueSet[dialogueSetKey].top.Count - 1 && currentIndex < dialogueSet[dialogueSetKey].bottom.Count - 1)
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