using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region FIELDS
    private Image image;
    public enum WordSelector
    {
        GREEN,
        YELLOW,
        RED
    }
    [SerializeField]
    private WordSelector wordSelectorType;
    [HideInInspector]
    public WordData wordData;
    private WordData[] wordDataArray;
    public bool obscured = false;
    private bool isPointerOver = false;
    #endregion

    #region UNITY_CALLS
    void Start()
    {
        image = GetComponent<Image>();
        AssignWordData();
    }

    void AssignWordData()
    {
        wordData = wordDataArray.FirstOrDefault(wd => wd.name == wordSelectorType.ToString());
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isPointerOver)
            {
                image.color = new Color(0, 0, 0, 1);
                obscured = true;
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (isPointerOver)
            {
                image.color = new Color(0, 0, 0, 0);
                obscured = true;
            }
        }
    }

    //expression-bodied syntax
    public void OnPointerEnter(PointerEventData pointerEventData) => isPointerOver = true;

    public void OnPointerExit(PointerEventData pointerEventData) => isPointerOver = false;

    #endregion
}