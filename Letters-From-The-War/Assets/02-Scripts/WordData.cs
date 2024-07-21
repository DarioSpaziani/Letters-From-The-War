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

    public void SetValue()
    {
        if (category == wordCategory.GREEN)
        {
            comprensibilityWordObscured = 0f;
            comprensibilityWordNotObscured = 0.2f;
            dailyPerfomanceWordObscured = 0f;
            dailyPerfomanceWordNotObscured = 0.2f;
        }

        if (category == wordCategory.YELLOW)
        {
            comprensibilityWordObscured = 1f;
            comprensibilityWordNotObscured = 2f;
            dailyPerfomanceWordObscured = 2f;
            dailyPerfomanceWordNotObscured = 1f;
        }

        if (category == wordCategory.RED)
        {
            comprensibilityWordObscured = 1f;
            comprensibilityWordNotObscured = 3f;
            dailyPerfomanceWordObscured = 3f;
            dailyPerfomanceWordNotObscured = 2f;
        }
    }
}
