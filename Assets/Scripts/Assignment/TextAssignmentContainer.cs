using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data container for text assignments.
/// </summary>
[System.Serializable]
public class TextAssignmentContainer
{
    /* Members. */
    public string m_Question;
    public string[] m_CorrectAnswers;

    /* Getters/Setters. */
    public string Question { get { return m_Question; } set { m_Question  = value; } }
    public string[] CorrectAnswers { get { return m_CorrectAnswers; } set { m_CorrectAnswers  = value; } }
}
