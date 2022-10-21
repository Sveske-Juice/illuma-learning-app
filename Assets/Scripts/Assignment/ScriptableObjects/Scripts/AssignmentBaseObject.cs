using UnityEngine;

public abstract class AssignmentBaseObject : ScriptableObject
{
    /* Members. */
    [SerializeField] protected string m_AssignmentName;
    protected int m_AssignmentIdx;

    /* Getters/Setters. */
    public string Name => m_AssignmentName;

    /*  NOTE: This field will be set automatically externally. I 
        think this is okay because there will only be one instance
        for each scriptable object assignment. */
    public int AssignmentIdx { get { return m_AssignmentIdx; } set { m_AssignmentIdx = value; } }
}
