using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SetObject : ScriptableObject
{
    /* Members. */
    [SerializeField] private string m_SetName;
    [SerializeField] private AssignmentBaseObject[] m_Assignments;

    /* Getters/Setters. */
    public string Name => m_SetName;
    public AssignmentBaseObject[] Assignments => m_Assignments;
}
