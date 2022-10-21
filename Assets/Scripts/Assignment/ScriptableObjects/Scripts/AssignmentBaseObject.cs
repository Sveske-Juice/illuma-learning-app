using UnityEngine;

public abstract class AssignmentBaseObject : ScriptableObject
{
    /* Members. */
    [SerializeField] protected string m_AssignmentName;

    /* Getters/Setters. */
    public string Name => m_AssignmentName;
}
