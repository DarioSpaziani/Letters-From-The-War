using System.Collections;
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
    private bool hasStarted = true;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        hasStarted = true;
    }

    private void Start()
    {
        if (bossDialogue1.Count > 0 && bossDialogue2.Count > 0)
        {
            UpdateDialogues();
        }
        else
        {
            Debug.LogWarning("Dialogue lists are empty or not assigned.");
        }
    }

    public void Dialogue()
    {
        if (hasStarted) 
        {
            if (currentIndex < bossDialogue1.Count - 1 && currentIndex < bossDialogue2.Count - 1)
            {
                currentIndex++;
                UpdateDialogues();
            }
        }
        else
        {
            LoadNextScene();
        }
    }

    private void UpdateDialogues()
    {
        if (hasStarted) {
            dialogue1.text = bossDialogue1[currentIndex];
            dialogue2.text = bossDialogue2[currentIndex];
            

        }
        else
        {
            if (gameManager.malus == 0)
            {
                dialogue1.text = bossFeedbackDialogueZeroTop[currentIndex];
                dialogue2.text = bossFeedbackDialogueZeroBottom[currentIndex];
            }
            else if (gameManager.malus == 1)
            {
                dialogue1.text = bossFeedbackDialogueOneTop[currentIndex];
                dialogue2.text = bossFeedbackDialogueOneBottom[currentIndex];
            }
            else if (gameManager.malus == 2)
            {
                dialogue1.text = bossFeedbackDialogueTwoTop[currentIndex];
                dialogue2.text = bossFeedbackDialogueTwoBottom[currentIndex];
            }
        }

        if (currentIndex >= bossDialogue1.Count - 1)
        {
            hasStarted = false;
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

    private void BossFeedback()
    {
        if(gameManager.malus == 0)
        {
            dialogue1.text = bossFeedbackDialogueZeroTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueZeroTop[currentIndex];
        }
        if(gameManager.malus >= 1 && gameManager.malus <= 6)
        {
            dialogue1.text = bossFeedbackDialogueOneTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueOneTop[currentIndex];
        }
        if (gameManager.malus >= 7 && gameManager.malus <= 15)
        {
            dialogue1.text = bossFeedbackDialogueTwoTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueTwoTop[currentIndex];
        }
        if(gameManager.malus >= 16 && gameManager.malus <= 20)
        {
            dialogue1.text = bossFeedbackDialogueThreeTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueThreeTop[currentIndex];
        }
    }
}
