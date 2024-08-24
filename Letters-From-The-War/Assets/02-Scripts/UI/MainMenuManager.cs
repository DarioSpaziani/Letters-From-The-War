public class MainMenuManager
{
    #region VARIABLES
    public static MainMenuManager Instance;
    public static TitleContainer _titleContainer;
    public static SelectionContainer _selectionContainer;
    #endregion

    #region UNITY_CALLS
    public static void OnAnyKeyPressed()
    {
        _titleContainer.gameObject.SetActive(false);
        _selectionContainer.gameObject.SetActive(true);
    }
    #endregion
}
