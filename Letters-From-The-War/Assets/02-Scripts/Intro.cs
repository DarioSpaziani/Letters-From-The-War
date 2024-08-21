using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textMPRO;
    private Fade fade;

    void Start()
    {
        fade = FindObjectOfType<Fade>();
        if(textMPRO == null)
        {
            return;
        }
        else
        {
            textMPRO.alpha = 0f;
        }
    }

    void Update()
    {
        if (textMPRO != null)
        {
            textMPRO.alpha += 0.002f;
        }
    }

    public void SkipIntro()
    {
        fade.StartCoroutine(fade.CheckFadeAndLoadScene("02-BossInterview"));
    }

}