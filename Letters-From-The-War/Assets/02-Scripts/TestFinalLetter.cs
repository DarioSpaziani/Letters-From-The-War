using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestFinalLetter : MonoBehaviour
{
    public List<Word> finalLetter = new List<Word>();
    public List<string> letterList = new List<string>();

    public TextMeshProUGUI textToShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            letterList.Clear();
            textToShow.text = "";
            for (int i = 0; i <= finalLetter.Count - 1; i++)
            {
                string word = finalLetter[i].GetComponentInChildren<TextMeshProUGUI>().text;
                letterList.Add(word);
                Debug.Log(word);

                textToShow.text += word + " ";
            }
        }
    }
}
