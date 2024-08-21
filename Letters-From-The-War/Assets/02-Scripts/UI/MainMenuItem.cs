using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuItem : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerDownHandler
{
    private RectTransform _iconTransform;
    private TMP_Text _text;
    private const int _HIGHLITED_ICON_ROTATION = 45;
    
    [Header("Image Parameters")]
    [SerializeField] private Color _baseTextColor;
    [SerializeField] private Color _highlitedTextColor;
    [SerializeField] private Color _clickedTextColor;

    private void Awake()
    {
        _iconTransform = GetComponentInChildren<Image>().rectTransform;
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToggleHighlited(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToggleHighlited(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleClicked(true);
    }

    private void ToggleHighlited(bool toggle)
    {
        if (toggle)
        {
            _iconTransform.Rotate(0,0,_HIGHLITED_ICON_ROTATION);
            _text.color = _highlitedTextColor;
        }
        else
        {
            _iconTransform.Rotate(0,0,-_HIGHLITED_ICON_ROTATION);
            _text.color = _baseTextColor;
        }
    }

    private void ToggleClicked(bool toggle)
    {
        if (toggle)
        {
            _text.color = _clickedTextColor;
        }
        else
        {
            _text.color = _baseTextColor;
        }
    }
    
}
