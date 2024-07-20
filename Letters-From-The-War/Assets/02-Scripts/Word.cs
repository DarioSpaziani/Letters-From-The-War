using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    public bool obscured = false;
    private bool isPointerOver = false;
    
    void Start()
    {
        image = GetComponent<Image>();
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

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        isPointerOver = false;
    }
}
