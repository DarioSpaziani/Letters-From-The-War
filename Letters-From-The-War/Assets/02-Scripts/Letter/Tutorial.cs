using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    #region FIELDS

    [SerializeField] private float speedImage;
    [SerializeField] private float timerWait;
    public Image imageTutorial;
    
    #endregion

    #region UNITY_CALLS
    
    void Start()
    {
        StartCoroutine(FadeTutorial());
    }

    public IEnumerator FadeTutorial()
    {
        imageTutorial.canvasRenderer.SetAlpha(0f);
        yield return new WaitForSeconds(timerWait);
        imageTutorial.CrossFadeAlpha(1.0f, speedImage, false);
    }

    #endregion
}
