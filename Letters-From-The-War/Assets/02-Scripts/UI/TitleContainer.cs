using System.Collections;
using UnityEngine;

public class TitleContainer : MonoBehaviour
{
    #region FIELDS

    [Header("Title Screen")] [SerializeField]
    private GameObject _pressAnyKeyObject;

    [SerializeField] private GameObject _lettersFTWObject;
    [SerializeField] private Animator _lettersAnimation;

    [Header("Main Menu Screen")] [SerializeField]
    private GameObject _menuItemsContainer;

    #endregion

    #region UNITY_CALLS

    private void Start()
    {
        MainMenuManager._titleContainer = this;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            OnAnyKeyPressed();
        }
    }

    public void OnAnyKeyPressed()
    {
        _lettersAnimation.SetTrigger("MovePositionImage");
        _pressAnyKeyObject.SetActive(false);
        StartCoroutine(WaitAnimation());
    }

    private IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(_lettersAnimation.GetCurrentAnimatorStateInfo(0).speed);
        _menuItemsContainer.SetActive(true);
    }

    #endregion
}