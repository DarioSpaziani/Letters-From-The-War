using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Sprite selectedButton,deselctedButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Image>().sprite = selectedButton;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Image>().sprite = deselctedButton;
    }
}