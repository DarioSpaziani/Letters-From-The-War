using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public float speedImage;
    public Image imageTutorial;
    public float timerWait;
    void Start()
    {
        FadeEffectTutorial();
    }
    public void FadeEffectTutorial()
    {
        StartCoroutine(FadeTutorial());
    }

    public IEnumerator FadeTutorial()
    {
        imageTutorial.canvasRenderer.SetAlpha(0f);
        yield return new WaitForSeconds(timerWait);
        imageTutorial.CrossFadeAlpha(1.0f, speedImage, false);
    }
}
