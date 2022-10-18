using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AssignmentCategoryContainer
{
    /* Members. */
    [SerializeField] private EAssignmentCategory m_DisplayCategory;
    [SerializeField] private AssignmentSetContainer[] m_AssignmentSets;

    /* Getters/Setters. */
    public EAssignmentCategory DisplayCategory { get { return m_DisplayCategory; } private set { m_DisplayCategory = value; } }

    /// <summary>
    /// The assignmnent sets that exist in each category. For example under the multiplication
    /// category there can be an assignment set about multiplying with 0.
    /// </summary>
    public AssignmentSetContainer[] AssignmentSets { get { return m_AssignmentSets; } private set { m_AssignmentSets = value; } }
}
