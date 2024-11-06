using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuCanvas : MonoBehaviour
{
    #region FIELDS
    
    public static OptionsMenuCanvas Instance;
    private static bool isMenuEnabled;
    
    #endregion
    
    #region UNITY CALLS

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        ToggleMenu(false);
        isMenuEnabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuEnabled = !isMenuEnabled;
            ToggleMenu(isMenuEnabled);
        }
    }
    
    public void ToggleMenu(bool toggle)
    {
        Instance.gameObject.GetComponent<Canvas>().enabled = toggle;
        Instance.gameObject.GetComponent<CanvasScaler>().enabled = toggle;
        Instance.gameObject.GetComponent<GraphicRaycaster>().enabled = toggle;
        Time.timeScale = toggle ? 0 : 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("00-Menu");
        Time.timeScale = 1;
    }
    
    #endregion
}
