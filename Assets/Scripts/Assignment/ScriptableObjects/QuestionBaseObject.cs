using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestionBaseObject : AssignmentBaseObject
{
    /* Members. */
    [SerializeField] protected string m_Question;
    [SerializeField] protected string[] m_CorrectAnswers;

    /* Getters/Setters. */
    public string Question => m_Question;
    public string[] CorrectAnswers => m_CorrectAnswers;
}
