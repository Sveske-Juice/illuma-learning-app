using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AssignmentContainerBase
{
    /* Members. */
    [SerializeField] protected string m_Name;
    private int m_AssignmentIdx;

    /* Getters/Setters. */
    public string Name { get { return m_Name; } set { m_Name = value; } }
    
    /// <summary>
    /// The index in the assignment array of this set. 
    /// Will be used as the displayed text on the button.
    /// </summary>
    public int AssignmentIdx { get { return m_AssignmentIdx; } set { m_AssignmentIdx = value; } }
}
