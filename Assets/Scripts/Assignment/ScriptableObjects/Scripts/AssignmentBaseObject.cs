using UnityEngine;

public abstract class AssignmentBaseObject : ScriptableObject
{
    /* Members. */
    [SerializeField] protected string m_AssignmentName;
    protected int m_AssignmentIdx;

    /* Getters/Setters. */
    public string Name => m_AssignmentName;

    // FIXME This field will be set externally. I know this shouldn't be done, 
    // but i have no clue otherwise as to how keep track of the assignment index.
    // I don't want to manually set the index but rather be set automatically. 
    public int AssignmentIdx { get { return m_AssignmentIdx; } set { m_AssignmentIdx = value; } }
}
