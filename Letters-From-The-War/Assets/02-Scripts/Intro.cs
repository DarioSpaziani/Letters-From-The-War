using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textMPRO;
    private float timer = 10f;

    public GameObject IntroText;
    public GameObject BossDialogue;

    void Start()
    {
        IntroText.SetActive(true);
        BossDialogue.SetActive(false);
        textMPRO.alpha = 0f;
    }

    void Update()
    {
        textMPRO.alpha += 0.002f;
    }

    public void IntroDialogue()
    {
        IntroText.SetActive(false);
        BossDialogue.SetActive(true);
    }
}
