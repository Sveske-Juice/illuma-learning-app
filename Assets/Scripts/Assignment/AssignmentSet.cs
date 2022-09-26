using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentSet : MonoBehaviour
{
    // List of all assignment objects in this assignment set
    private IList<IAssignment> m_Assignments = new List<IAssignment>();

    // Current playing assignemnt index
    private int m_AssIdx = 0;

    public void Init(IList<IAssignment> assignments, int assIdx)
    {
        m_Assignments = assignments;
        m_AssIdx = assIdx;
    }
    public void Init(IList<IAssignment> assignments)
    {
        m_Assignments = assignments;
    }

    private void Start()
    {
        print("Assignment set starting");
        GameManager.Instance.assLoader.GetComponent<AssignmentLoader>().Load(m_Assignments[m_AssIdx]);
    }
}
