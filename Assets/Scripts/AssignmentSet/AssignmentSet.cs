using UnityEngine;

[System.Serializable]
public class AssignmentSet
{
    /* Members, */
    [SerializeField] private string m_Name;
    
    // TODO make more generic for other types of assignments
    [SerializeField] private TextAssignmentContainer[] m_Assignments;

    /* Getters/Setters. */
    public string Name { get { return m_Name; } private set { m_Name = value; } }
    public TextAssignmentContainer[] Assignments { get { return m_Assignments; } private set { m_Assignments = value; } }
}
