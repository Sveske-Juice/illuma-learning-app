using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentSet : MonoBehaviour
{
    // List of all assignment objects in this assignment set
    private IList<Assignment> m_Assignments = new List<Assignment>();
    private AssignmentCategory m_AssignmentCategory;

    // Current playing assignemnt index
    private int m_AssIdx = 0;

    public void Init(IList<Assignment> assignments, int assIdx, AssignmentCategory assignmentCategory)
    {
        m_Assignments = assignments;
        m_AssIdx = assIdx;
        m_AssignmentCategory = assignmentCategory;
    }
    public void Init(IList<Assignment> assignments, AssignmentCategory assignmentCategory)
    {
        m_Assignments = assignments;
        m_AssignmentCategory = assignmentCategory;
    }
    public void Init(IList<Assignment> assignments)
    {
        m_Assignments = assignments;
    }



    private void Start()
    {
        print("Assignment set starting");
        GameManager.Instance.assLoader.GetComponent<AssignmentLoader>().Load(m_Assignments[m_AssIdx]);
    }
}
