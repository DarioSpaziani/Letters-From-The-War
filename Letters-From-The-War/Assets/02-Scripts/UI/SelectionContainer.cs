using UnityEngine;

public class SelectionContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainMenuManager._selectionContainer = this;
        gameObject.SetActive(false);
    }
}
