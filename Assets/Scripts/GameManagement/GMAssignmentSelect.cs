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
    /* Members. */
    private SetObject m_AssignmentSet;
    public GMAssignmentSelect(SetObject set)
    {
        m_AssignmentSet = set;
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

    /* Getters/Setters. */
    public AssignmentBaseObject[] Assignments => m_AssignmentSet.Assignments;

    private void OnAssignmentSelect(AssignmentBaseObject associatedAssignment)
    {
        Debug.Log($"Chose to train on assignment named: {associatedAssignment.Name}");

        GameManager.Instance.SwitchState(new GMPlayingState(associatedAssignment));
    }
}
