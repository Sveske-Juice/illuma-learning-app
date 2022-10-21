using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectManager : MonoBehaviour, ISubjectHolder
{
    /* Members. */
    [Header("Subjects in the game:")]
    [SerializeField] private SubjectObject[] m_Subjects;

    /* Getters/Setters. */
    public SubjectObject[] Subjects => m_Subjects;
}
