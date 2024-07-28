using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Word", menuName = "ScriptableObjects/Data", order = 1)]
public class WordData : ScriptableObject
{
    public enum wordCategory { GREEN, YELLOW, RED };

    public wordCategory category;

    public float comprensibilityWordObscured;
    public float comprensibilityWordNotObscured;
    public float dailyPerfomanceWordObscured;
    public float dailyPerfomanceWordNotObscured;
}
