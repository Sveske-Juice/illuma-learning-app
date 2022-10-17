using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMAssignmentSelect : GMBaseState
{
    public GMAssignmentSelect(AssignmentSet assignment)
    {
        m_Assignment = assignment;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    /* Members. */
    private AssignmentSet m_Assignment;
}
