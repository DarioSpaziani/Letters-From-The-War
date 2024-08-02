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
    public List<string> bossFeedbackDialogueZero;
    public List<string> bossFeedbackDialogueZeroOne;
    public List<string> bossFeedbackDialogueOne;
    public List<string> bossFeedbackDialogueOneOne;
    public List<string> bossFeedbackDialogueTwo;
    public List<string> bossFeedbackDialogueTwoOne;
    public List<string> bossFeedbackDialogueThree;
    public List<string> bossFeedbackDialogueThreeOne;
    #endregion

    private int currentIndex = 0;

    private void Start()
    {
        if(GameManager.Instance.malus == 0)
        {
            dialogue1.text = bossFeedbackDialogueZero[currentIndex];
            dialogue2.text = bossFeedbackDialogueZero[currentIndex];
        }
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
        if(GameManager.Instance.malus == 0)
        {
            dialogue1.text = bossFeedbackDialogueOne[currentIndex];
        }

        dialogue1.text = bossDialogue1[currentIndex];
        dialogue2.text = bossDialogue2[currentIndex];

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
            dialogue1.text = bossFeedbackDialogueZero[currentIndex];
            dialogue2.text = bossFeedbackDialogueZero[currentIndex];
        }
        if(GameManager.Instance.malus >= 1 && GameManager.Instance.malus <= 6)
        {
            dialogue1.text = bossFeedbackDialogueOne[currentIndex];
            dialogue2.text = bossFeedbackDialogueOne[currentIndex];
        }
        if (GameManager.Instance.malus >= 7 && GameManager.Instance.malus <= 15)
        {
            dialogue1.text = bossFeedbackDialogueTwo[currentIndex];
            dialogue2.text = bossFeedbackDialogueTwo[currentIndex];
        }
        if(GameManager.Instance.malus >= 16 && GameManager.Instance.malus <= 20)
        {
            dialogue1.text = bossFeedbackDialogueThree[currentIndex];
            dialogue2.text = bossFeedbackDialogueThree[currentIndex];
        }
    }
}
