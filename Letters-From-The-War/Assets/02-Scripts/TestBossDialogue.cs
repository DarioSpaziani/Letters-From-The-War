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

    private int currentIndex = 0;

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
}
