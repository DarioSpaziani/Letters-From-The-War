using TMPro;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    #region FIELDS
    private GameManager gameManager;
    public TextMeshProUGUI headlineText;

    #region CLASS_DATA
    [System.Serializable]
    public class DayRange
    {
        public float minRangeFirstTitle;
        public float maxRangeFirstTitle;
        public float minRangeSecondTitle;
        public float maxRangeSecondTitle;
        public float minRangeThirdTitle;
        public float maxRangeThirdTitle;
        public float minRangeFourthTitle;
        public float maxRangeFourthTitle;
    }

    [System.Serializable]
    public class DayDescriptions
    {
        public string descriptionFirstRange;
        public string descriptionSecondRange;
        public string descriptionThirdRange;
        public string descriptionFourthRange;
    }

    [System.Serializable]
    public class DayData
    {
        public DayRange range;
        public DayDescriptions descriptions;
    }
    #endregion

    #region DAYS
    [Header("Day One")]
    public DayData dayOne;

    [Header("Day Two")]
    public DayData dayTwo;

    [Header("Day Three")]
    public DayData dayThree;

    [Header("Day Four")]
    public DayData dayFour;

    [Header("Day Five")]
    public DayData dayFive;

    [Header("Day Six")]
    public DayData daySix;

    [Header("Day Seven")]
    public DayData daySeven;

    private DayData[] dayData = new DayData[6]; // 0-6 (7 elementi)
    #endregion
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        dayData = new DayData[] { dayOne, dayTwo, dayThree, dayFour, dayFive, daySix, daySeven };
    }

    private void Start()
    {
        ShowTextDescriptions();
        Debug.Log(gameManager.day);
        gameManager.day++;

        Debug.Log("day after increment : " + gameManager.day);
    }

    private void ShowTextDescriptions()
    {
        if (gameManager.day >= 1 && gameManager.day < dayData.Length)
        {
            Debug.Log("day dentro ShowText() prima di diminuirlo : " + gameManager.day);
            DayData currentDay = dayData[gameManager.day];
            int knowledgeIndex = GetKnowledgeIndex(gameManager.day, gameManager.knowledge);

            Debug.Log("day dentro ShowText() : " + gameManager.day);
            switch (knowledgeIndex)
            {
                case 0:
                    headlineText.text = currentDay.descriptions.descriptionFirstRange;
                    break;
                case 1:
                    headlineText.text = currentDay.descriptions.descriptionSecondRange;
                    break;
                case 2:
                    headlineText.text = currentDay.descriptions.descriptionThirdRange;
                    break;
                case 3:
                    headlineText.text = currentDay.descriptions.descriptionFourthRange;
                    break;
                default:
                    Debug.LogError($"Invalid knowledge index: {knowledgeIndex}");
                    break;
            }
        }
    }

    private int GetKnowledgeIndex(int day, int knowledge)
    {
        if (day < 1 || day >= dayData.Length)
        {
            return 0;
        }

        DayRange range = dayData[day-1].range;

        if (knowledge >= range.minRangeFirstTitle && knowledge <= range.maxRangeFirstTitle) return 0;
        if (knowledge > range.minRangeSecondTitle && knowledge <= range.maxRangeSecondTitle) return 1;
        if (knowledge > range.minRangeThirdTitle && knowledge <= range.maxRangeThirdTitle) return 2;
        if (knowledge > range.minRangeFourthTitle && knowledge <= range.maxRangeFourthTitle) return 3;

        return 0;
    }
    #endregion
}