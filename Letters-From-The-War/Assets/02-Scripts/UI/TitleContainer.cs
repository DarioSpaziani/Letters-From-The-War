using UnityEngine;

public class TitleContainer : MonoBehaviour
{
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
}
