using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuCanvas : MonoBehaviour
{
    #region FIELDS
    
    public static OptionsMenuCanvas Instance;
    private static bool isMenuEnabled;
    private GameManager _gameManager;
    
    #endregion
    
    #region UNITY CALLS

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;

        _gameManager = FindObjectOfType<GameManager>();
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
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.malus = 0;
        _gameManager.knowledge = 0;
        _gameManager.day = 0;
        _gameManager.hasStarted = true;
        _gameManager.malusDaily = 0;
        SceneManager.LoadScene("00-Menu");
        Time.timeScale = 1;

    }
    
    #endregion
}
