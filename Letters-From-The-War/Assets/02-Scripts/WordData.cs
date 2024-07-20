using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Word", menuName = "ScriptableObjects/Data", order = 1)]
public class WordData : ScriptableObject
{
    public enum wordCategory { GREEN, YELLOW, RED };

    public wordCategory category;

    public float comprensibilityWordObscured = 0f;
    public float comprensibilityWordNotObscured = 0f;
    public float dailyPerfomanceWordObscured = 0f;
    public float dailyPerfomanceWordNotObscured = 0f;
}
