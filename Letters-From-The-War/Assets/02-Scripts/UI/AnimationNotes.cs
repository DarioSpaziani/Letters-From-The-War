using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationNotes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public bool isOpen;
    public bool isHover;
    public Animator animatorNotes;

    private void Start()
    {
        isHover = false;
        isOpen = false;
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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        animatorNotes.SetBool("isHover", false);
    }
}
