using UnityEngine;

[System.Serializable]
public class AssignmentSetContainer
{
    /* Members, */
    [SerializeField] private string m_Name;
    
    // TODO make more generic for other types of assignments
    [SerializeField] private TextAssignmentContainer[] m_Assignments;

    private int m_CategoryIdx;
    private int m_SetIdx;

    /* Getters/Setters. */
    public string Name { get { return m_Name; } private set { m_Name = value; } }
    public TextAssignmentContainer[] Assignments { get { return m_Assignments; } private set { m_Assignments = value; } }

    /// <summary>
    /// The index in the category array this data container corresponds to.
    /// </summary>
    public int CategoryIdx { get { return m_CategoryIdx; } set { m_CategoryIdx = value; } }

    /// <summary>
    /// The index in the assignment set array this data container corresponds to.
    /// </summary>
    public int SetIdx { get { return m_SetIdx; } set { m_SetIdx = value; } }
}
