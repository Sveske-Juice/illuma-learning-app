using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentSelectDisplay : DisplayMenuBase
{
    /* Members. */
    [SerializeField] private GameObject m_AssignmentHolder;
    [SerializeField] private Transform m_AssignmentContainer;

    protected override void OnGameStateChanged(GMBaseState state)
    {
        GMAssignmentSelect assState = state as GMAssignmentSelect;
        if (assState != null) {
            Display(assState.Assignments);
        }
        else
        {
            Hide();
        }
    }

    // TODO make generic
    private void Display(TextAssignmentContainer[] assignments)
    {
        for (int i = 0; i < assignments.Length; i++)
        {
            assignments[i].AssignmentIdx = i;
            GameObject assignmentBtn = Instantiate(m_AssignmentHolder, Vector3.zero, Quaternion.identity, m_AssignmentContainer);
            
            // Load the new button with the assignment data container (sets display text etc.)
            assignmentBtn.GetComponentInChildren<AssignmentButton>().Load(assignments[i]);
        }

        base.Display();
    }

    protected override void Hide()
    {
        base.Hide();
    }
}
