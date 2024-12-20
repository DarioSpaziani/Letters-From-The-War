using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region FIELDS

    private Image image;
    public WordData wordData;
    public bool obscured = false;
    private bool isPointerOver = false;
    private FillerList filler;
    #endregion

    #region UNITY_CALLS

    void Start()
    {
        image = GetComponent<Image>();
        filler = FindObjectOfType<FillerList>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isPointerOver)
            {
                image.color = new Color(0, 0, 0, 1);
                obscured = true;
                filler.SyncObscuredStates();
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (isPointerOver)
            {
                image.color = new Color(0, 0, 0, 0);
                obscured = false;
                filler.SyncObscuredStates();
            }
        }
    }

    //expression-bodied syntax
    public void OnPointerEnter(PointerEventData pointerEventData) => isPointerOver = true;

    public void OnPointerExit(PointerEventData pointerEventData) => isPointerOver = false;

    #endregion
}