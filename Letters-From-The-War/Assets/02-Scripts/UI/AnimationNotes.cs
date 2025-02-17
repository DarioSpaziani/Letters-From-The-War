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
        Debug.Log("StartAnimNotes");
        animatorNotes.SetBool("isStarted", true);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isOpen)
        {
            Debug.Log("Pointer Down");
            animatorNotes.SetBool("isOpen", true);
            isOpen = true;
        }
        else
        {
            Debug.Log("Pointer UP");
            animatorNotes.SetBool("isOpen", false);
            isOpen = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        animatorNotes.SetBool("isHover", true);
        animatorNotes.SetBool("isStarted", false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        animatorNotes.SetBool("isHover", false);
    }
}
