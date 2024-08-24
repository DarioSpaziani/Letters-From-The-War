using UnityEngine;

public class SelectionContainer : MonoBehaviour
{
    #region UNITY_CALLS
    void Start()
    {
        MainMenuManager._selectionContainer = this;
        gameObject.SetActive(false);
    }
    #endregion
}
