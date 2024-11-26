using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region FIELDS

    private GameManager gameManager;

    #endregion

    #region UNITY_CALLS



    public void Retry()
    {
        SceneManager.LoadScene("00-Menu");
    }

    #endregion
}
