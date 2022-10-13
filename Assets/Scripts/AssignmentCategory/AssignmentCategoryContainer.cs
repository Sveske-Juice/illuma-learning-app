using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AssignmentCategoryContainer
{
    /* Members. */
    [SerializeField] private EAssignmentCategory m_DisplayCategory;
    [SerializeField] private AssignmentSet[] m_AssignmentSets;

    /* Getters/Setters. */
    public EAssignmentCategory DisplayCategory { get { return m_DisplayCategory; } private set { m_DisplayCategory = value; } }
}
