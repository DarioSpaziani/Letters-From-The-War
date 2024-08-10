using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    private GameManager gameManager;

    #region Journal Image
    //public Image imageJournal;
    //private Dictionary<int, List<Sprite>> journalImage;
    //private List<Sprite> currentJournalImage;
    //public List<Sprite> journalImageList;
    #endregion

    #region Journal Description
    public TextMeshProUGUI topDescription;

    private Dictionary<int, List<string>> journalMainDescription;

    private List<string> currentTopDescription;

    public Dictionary<int, List<string>> currentJournalA;
    public Dictionary<int, List<string>> currentJournalB;
    public Dictionary<int, List<string>> currentJournalC;
    public Dictionary<int, List<string>> currentJournalD;
    public Dictionary<int, List<string>> currentJournalE;
    public Dictionary<int, List<string>> currentJournalF;
    public Dictionary<int, List<string>> currentJournalG;
    public List<string> journalDescriptionA1;
    public List<string> journalDescriptionA2;
    public List<string> journalDescriptionA3;
    public List<string> journalDescriptionA4;
    public List<string> journalDescriptionB1;
    public List<string> journalDescriptionB2;
    public List<string> journalDescriptionB3;
    public List<string> journalDescriptionB4;
    public List<string> journalDescriptionC1;
    public List<string> journalDescriptionC2;
    public List<string> journalDescriptionC3;
    public List<string> journalDescriptionC4;
    public List<string> journalDescriptionD1;
    public List<string> journalDescriptionD2;
    public List<string> journalDescriptionD3;
    public List<string> journalDescriptionD4;
    public List<string> journalDescriptionE1;
    public List<string> journalDescriptionE2;
    public List<string> journalDescriptionE3;
    public List<string> journalDescriptionE4;
    public List<string> journalDescriptionF1;
    public List<string> journalDescriptionF2;
    public List<string> journalDescriptionF3;
    public List<string> journalDescriptionF4;
    public List<string> journalDescriptionG1;
    public List<string> journalDescriptionG2;
    public List<string> journalDescriptionG3;
    public List<string> journalDescriptionG4;
    #endregion

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if(currentTopDescription == null)
        {
            return;
        }
    }

    private void Start()
    {
        InitializeJournal();
        //ShowImageDescription();
        ShowTextDescription();
    }

    private void InitializeJournal()
    {
        journalMainDescription = new Dictionary<int, List<string>>
        {
            { 0, (currentTopDescription)},
            { 1, (currentTopDescription)},
            { 2, (currentTopDescription)},
            { 3, (currentTopDescription)},
        };

        //journalImage = new Dictionary<int, List<Sprite>>()
        //{
        //    { 0, journalImageList},
        //    { 1, journalImageList},
        //    { 2, journalImageList},
        //    { 3, journalImageList},
        //    { 4, journalImageList},
        //};
    }

    public int DetermineJournalDescription()
    {
        if(gameManager.knowledge == 0)
        {
            return 0;
        }
        if (gameManager.knowledge == 1)
        {
            return 1;
        }
        if (gameManager.knowledge == 2)
        {
            return 2;
        }
        if (gameManager.knowledge == 3)
        {
            return 3;
        }
        if (gameManager.knowledge == 4)
        {
            return 4;
        }
        return 0;
    }

    #region SHOW METHODS
    //public void ShowImageDescription()
    //{
    //    int journalSetKey = DetermineJournalDescription();
    //    if (journalImage.ContainsKey(journalSetKey) && journalImage[journalSetKey].Count > journalSetKey)
    //    {
    //        imageJournal.sprite = journalImage[journalSetKey][journalSetKey];
    //    }
    //    else
    //    {
    //        Debug.LogWarning($"No journal image available for key {journalSetKey} at index {journalSetKey}");
    //    }
    //}

    public void ShowTextDescription()
    {
        int journalSetKey = DetermineJournalDescription();


        if (journalMainDescription.ContainsKey(journalSetKey))
        {
            var topList = journalMainDescription[journalSetKey];
            if (topList.Count > 0)
            {
                topDescription.text = topList[0];
            }
            else
            {
                Debug.LogWarning("No top description available for this key.");
            }
        }
        else
        {
            Debug.LogError($"No journal description at key {journalSetKey}.");
        }
    }
    #endregion
}