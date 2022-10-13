using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AssignmentCategoryContainer
{
    /* Members. */
    private EAssignmentCategory m_DisplayCategory;
    private AssignmentSet[] m_AssignmentSets;

    /* Getters/Setters. */
    public EAssignmentCategory DisplayCategory { get { return m_DisplayCategory; } private set { m_DisplayCategory = value; } }
}
