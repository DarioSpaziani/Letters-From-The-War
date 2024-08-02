using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBossDialogue : MonoBehaviour
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

    private void Awake()
    {
        hasStarted = true;
    }

    private void Start()
    {
        Debug.Log("hasStarted : " + hasStarted);
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
        if (currentIndex < bossDialogue1.Count - 1 && currentIndex < bossDialogue2.Count - 1)
        {
            currentIndex++;
            UpdateDialogues();
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
            hasStarted = false;
        }
        else
        {
            if (GameManager.Instance.malus == 0)
            {
                dialogue1.text = bossFeedbackDialogueZeroTop[currentIndex];
                dialogue2.text = bossFeedbackDialogueZeroBottom[currentIndex];
            }
            else if (GameManager.Instance.malus == 1)
            {
                dialogue1.text = bossFeedbackDialogueOneTop[currentIndex];
                dialogue2.text = bossFeedbackDialogueOneBottom[currentIndex];
            }
            else if (GameManager.Instance.malus == 2)
            {
                dialogue1.text = bossFeedbackDialogueTwoTop[currentIndex];
                dialogue2.text = bossFeedbackDialogueTwoBottom[currentIndex];
            }
        }
        
        //dialogue1.text = bossDialogue1[currentIndex];
        //dialogue2.text = bossDialogue2[currentIndex];

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
        if(GameManager.Instance.malus == 0)
        {
            dialogue1.text = bossFeedbackDialogueZeroTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueZeroTop[currentIndex];
        }
        if(GameManager.Instance.malus >= 1 && GameManager.Instance.malus <= 6)
        {
            dialogue1.text = bossFeedbackDialogueOneTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueOneTop[currentIndex];
        }
        if (GameManager.Instance.malus >= 7 && GameManager.Instance.malus <= 15)
        {
            dialogue1.text = bossFeedbackDialogueTwoTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueTwoTop[currentIndex];
        }
        if(GameManager.Instance.malus >= 16 && GameManager.Instance.malus <= 20)
        {
            dialogue1.text = bossFeedbackDialogueThreeTop[currentIndex];
            dialogue2.text = bossFeedbackDialogueThreeTop[currentIndex];
        }
    }
}
