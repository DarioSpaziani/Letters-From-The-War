using UnityEngine;

public class TitleContainer : MonoBehaviour
{
    #region UNITY_CALLS
    private void Start()
    {
        MainMenuManager._titleContainer = this;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            MainMenuManager.OnAnyKeyPressed();
        }
    }
    #endregion
}
