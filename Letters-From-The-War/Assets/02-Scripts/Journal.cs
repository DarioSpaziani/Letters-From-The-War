using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public Image imageJournal;
    public TextMeshProUGUI topDescription;
    public TextMeshProUGUI bottomDescription;

    private Dictionary<int, (List<string> top, List<string> bottom)> journalDescription;
    private Dictionary<int, List<Sprite>> journalImage;
    private GameManager gameManager;

    private List<string> currentTopDescription;
    private List<string> currentBottomDescription;
    private List<Sprite> currentJournalImage;

    public List<Sprite> journalImageList;

    public List<string> journalDescriptionZeroTop;
    public List<string> journalDescriptionZeroBottom;
    public List<string> journalDescriptionOneTop;
    public List<string> journalDescriptionOneBottom;
    public List<string> journalDescriptionTwoTop;
    public List<string> journalDescriptionTwoBottom;
    public List<string> journalDescriptionThreeTop;
    public List<string> journalDescriptionThreeBottom;
    public List<string> journalDescriptionFourTop;
    public List<string> journalDescriptionFourBottom;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        InitializeJournal();
        ShowDescription();
    }

    private void InitializeJournal()
    {
        journalDescription = new Dictionary<int, (List<string> top, List<string> bottom)>
        {
            { 0, (journalDescriptionZeroTop, journalDescriptionZeroBottom)},
            { 1, (journalDescriptionOneTop, journalDescriptionOneBottom)},
            { 2, (journalDescriptionTwoTop, journalDescriptionTwoBottom)},
            { 3, (journalDescriptionThreeTop, journalDescriptionThreeBottom)},
            { 4, (journalDescriptionFourTop, journalDescriptionFourBottom)},
        };

        journalImage = new Dictionary<int, List<Sprite>>()
        {
            { 0, journalImageList},
            { 1, journalImageList},
            { 2, journalImageList},
            { 3, journalImageList},
            { 4, journalImageList},
        };
    }
    public int DetermineJournalDescription()
    {
        if(gameManager.malus == 0)
        {
            return 0;
        }
        if (gameManager.malus > 1 && gameManager.malus <= 3)
        {
            return 1;
        }
        if (gameManager.malus > 3 && gameManager.malus <= 6)
        {
            return 2;
        }
        if (gameManager.malus > 6 && gameManager.malus <= 9)
        {
            return 3;
        }
        if (gameManager.malus > 9 && gameManager.malus <= 12)
        {
            return 4;
        }
        return 0;
    }

    public void ShowDescription()
    {
        int journalSetKey = DetermineJournalDescription();
        if (journalImage.ContainsKey(journalSetKey) && journalImage[journalSetKey].Count > journalSetKey)
        {
            imageJournal.sprite = journalImage[journalSetKey][journalSetKey];
        }
        else
        {
            Debug.LogError($"No journal image available for key {journalSetKey} at index {journalSetKey}");
        }

        if (journalDescription.ContainsKey(journalSetKey))
        {
            var(topList,bottomList) = journalDescription[journalSetKey];
            if (topList.Count > 0)
            {
                topDescription.text = topList[0];
            }
            else
            {
                Debug.LogWarning("No top description available for this key.");
            }
            if (bottomList.Count > 0)
            {
                bottomDescription.text = bottomList[0];
            }
            else
            {
                Debug.LogWarning("No bottom description available for this key.");
            }
        }
        else
        {
            Debug.LogError($"No journal description at key {journalSetKey}.");
        }

    }
}
