using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationNotes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public bool isOpen;
    public bool isHover;
    public bool isStarted;
    public Animator animatorNotes;
    private Fade fade;

    private void Awake()
    {
        fade = FindObjectOfType<Fade>();    
        animatorNotes.enabled = false;
    }

    private void Start()
    {
        isHover = false;
        isOpen = false;
        isStarted = false;

        StartCoroutine(StartAnimNotes());
    }

    public IEnumerator StartAnimNotes()
    {
        yield return new WaitForSeconds(fade.timeFadeReverseLetter);
        animatorNotes.enabled = true;
        animatorNotes.SetBool("isStarted", true);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isOpen)
        {
            animatorNotes.SetBool("isOpen", true);
            isOpen = true;
        }
        else
        {
            animatorNotes.SetBool("isOpen", false);
            isOpen = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animatorNotes.SetBool("isHover", true);
        animatorNotes.SetBool("isStarted", false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animatorNotes.SetBool("isHover", false);
    }
}
