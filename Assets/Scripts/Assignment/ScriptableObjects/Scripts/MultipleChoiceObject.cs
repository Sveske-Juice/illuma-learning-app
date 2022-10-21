using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Multiple Choice Assignment", menuName = "Assignment/Question/MultipleChoice")]
public class MultipleChoiceObject : QuestionBaseObject
{
    /* Members. */
    [SerializeField] private string[] m_Choices;

    /* Getters/Setters. */
    public string[] Choices => m_Choices;
}
