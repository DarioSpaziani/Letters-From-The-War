using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Word", menuName = "ScriptableObjects/Data", order = 1)]
public class WordData : ScriptableObject
{
    public enum wordCategory { GREEN, YELLOW, RED };

    public wordCategory category;

    [Range(-0.2f, 0.2f)]
    public float comprensibility = 0f;
    [Range(-0.2f, 0.2f)]
    public float dailyPerfomance = 0f;

    public string word;
}
