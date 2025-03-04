using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
   
public class Notes : MonoBehaviour
{
    [System.Serializable]
    class Content
    {
        [TextArea (3,10)]
        public string description;
    }

    [SerializeField] private List<Content> notes;
    [SerializeField] private TextMeshProUGUI notesText;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        notesText.text = "";
        notesText.text = notes[gameManager.day-1].description;
         
    }
}
