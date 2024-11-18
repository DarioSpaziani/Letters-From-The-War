using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    #region FIELDS
    private GameManager gameManager;
    public TextMeshProUGUI headlineText;
    private Button NextScene;
    private const int FIRST_TITLE = 0;
    private const int SECOND_TITLE = 1;
    private const int THIRD_TITLE = 2;
    private const int FOURTH_TITLE = 3;
    public int knowledgeIndex;

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
        [TextArea(3, 10)]
        public string descriptionFirstRange;
        [TextArea(3, 10)]
        public string descriptionSecondRange;
        [TextArea(3, 10)]
        public string descriptionThirdRange;
        [TextArea(3, 10)]
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
    public DayData dayZero;

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

    private DayData[] dayData = new DayData[7]; // 0-6 (7 elementi)
    #endregion
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        dayData = new DayData[] { dayZero, dayOne, dayTwo, dayThree, dayFour, dayFive, daySix, daySeven };
        knowledgeIndex = GetKnowledgeIndex(gameManager.day, gameManager.knowledge);
    }

    private void Start()
    {
        ShowTextDescriptions();
    }

    private void ShowTextDescriptions()
    {
        DayData currentDay = dayData[gameManager.day];
        

        switch (knowledgeIndex)
        {
            case FIRST_TITLE:
                headlineText.text = currentDay.descriptions.descriptionFirstRange;
                break;
            case SECOND_TITLE:
                headlineText.text = currentDay.descriptions.descriptionSecondRange;
                break;
            case THIRD_TITLE:
                headlineText.text = currentDay.descriptions.descriptionThirdRange;
                break;
            case FOURTH_TITLE:
                headlineText.text = currentDay.descriptions.descriptionFourthRange;
                break;
            default:
                Debug.LogError($"Invalid knowledge index: {knowledgeIndex}");
                break;
        }

    }

    private int GetKnowledgeIndex(int day, int knowledge)
    {
        DayRange range = dayData[day].range;

        if (knowledge <= range.maxRangeFirstTitle) return FIRST_TITLE;
        if (knowledge <= range.maxRangeSecondTitle) return SECOND_TITLE;
        if (knowledge <= range.maxRangeThirdTitle) return THIRD_TITLE;
        if (knowledge <= range.maxRangeFourthTitle) return FOURTH_TITLE;

        return FIRST_TITLE;
    }
    #endregion
}