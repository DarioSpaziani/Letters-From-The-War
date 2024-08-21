using UnityEngine;

public class MainMenuManager
{
    public static MainMenuManager Instance;
    public static TitleContainer _titleContainer;
    public static SelectionContainer _selectionContainer;

    public static void OnAnyKeyPressed()
    {
        _titleContainer.gameObject.SetActive(false);
        _selectionContainer.gameObject.SetActive(true);
    }
}
