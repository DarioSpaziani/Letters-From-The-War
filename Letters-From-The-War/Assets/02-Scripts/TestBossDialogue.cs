using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestBossDialogue : MonoBehaviour
{
    public List<string> bossDialogue1 = new List<string>();
    public List<string> bossDialogue2 = new List<string>();

    public TextMeshProUGUI dialogue1;
    public TextMeshProUGUI dialogue2;

    private int i = 0;

    private void Start()
    {
        dialogue1.text = bossDialogue1[i];
        dialogue2.text = bossDialogue2[i];
    }



    public void Ahead()
    {
        if (i < bossDialogue1.Count - 1 || i < bossDialogue2.Count - 1) 
        {
            i++;
            dialogue1.text = bossDialogue1[i];
            dialogue2.text = bossDialogue2[i];
        }
    }
}
