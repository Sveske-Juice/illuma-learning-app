using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager Assignment Select State is active when
/// the user needs to pick an assignment to train or 
/// continue where they left off last time.
/// </summary>
public class GMAssignmentSelect : GMBaseState
{
    public GMAssignmentSelect(AssignmentSet assignment)
    {
        m_AssignmentSet = assignment;
    }

    public override void Enter()
    {
        base.Enter();

        // Subscribe to the vent raised when clicked on the assignment to train
        AssignmentButton.OnAssignmentSelect += OnAssignmentSelect;
    }

    public override void Exit()
    {
        base.Exit();

        // Unsubscribe to the vent raised when clicked on the assignment to train
        AssignmentButton.OnAssignmentSelect -= OnAssignmentSelect;
    }

    /* Members. */
    private AssignmentSet m_AssignmentSet;

    /* Getters/Setters. */
    // TODO make generic type of assignment
    public TextAssignmentContainer[] Assignments { get { return m_AssignmentSet.Assignments; } }

    private void OnAssignmentSelect(int assignmentIdx)
    {
        TextAssignmentContainer assignment = Assignments[assignmentIdx];
        Debug.Log($"Chose to train: {assignment.Question}");
    }
}
