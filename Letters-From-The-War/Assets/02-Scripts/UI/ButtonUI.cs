using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public AudioManager _audioManager;
    public Sprite selectedButton,deselctedButton;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Image>().sprite = selectedButton;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Image>().sprite = deselctedButton;
    }

    public void OnClick()
    {
        _audioManager.PlayContinueSound();
    }

    public void OnClickSend()
    {
        _audioManager.PlaySendSound();
    }
}