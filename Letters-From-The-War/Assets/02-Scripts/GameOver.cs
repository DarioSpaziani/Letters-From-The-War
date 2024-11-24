using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region FIELDS

    private GameManager gameManager;

    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.malus = 0;
        gameManager.knowledge = 0;
        gameManager.day = 0;
        gameManager.hasStarted = true;
        gameManager.malusDaily = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene("00-Menu");
    }

    #endregion
}
