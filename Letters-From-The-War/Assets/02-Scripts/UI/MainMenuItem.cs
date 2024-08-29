using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuItem : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerDownHandler
{
    #region FIELDS
    private RectTransform _iconTransform;
    private TMP_Text _text;
    private const int _HIGHLITED_ICON_ROTATION = 45;
    
    [Header("Image Parameters")]
    [SerializeField] private Color _baseTextColor;
    [SerializeField] private Color _highlitedTextColor;
    [SerializeField] private Color _clickedTextColor;
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        _iconTransform = GetComponentInChildren<Image>().rectTransform;
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void NewGame() => SceneManager.LoadScene("01-Intro");

    public void ContinueGame(){}

    public void ShowCredits() {}

    public void Quit() 
    {
        Application.Quit();
    }
    
    #region Pointer Events Management
    public void OnPointerEnter(PointerEventData eventData) => ToggleHighlited(true);
    
    public void OnPointerExit(PointerEventData eventData) => ToggleHighlited(false);

    public void OnPointerDown(PointerEventData eventData) => ToggleClicked(true);
  
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

    //forma if contratta usando operatore ternario
    private void ToggleClicked(bool toggle) => _text.color = toggle ? _clickedTextColor : _baseTextColor;
    #endregion
    #endregion
}