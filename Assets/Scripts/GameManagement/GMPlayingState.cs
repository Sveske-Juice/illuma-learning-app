using System;
using System.Collections.Generic;
using UnityEngine;

public class GMPlayingState : GMBaseState
{
    /* Memebers. */
    private AssignmentBaseObject m_AssignmentContainer;
    private IAssignment m_AssignmentBehaviour;

    public static event Func<AssignmentBaseObject, IAssignment> CreateAssignment;

    /// <summary>
    /// Constructor of the playing assignment game state.
    /// </summary>
    /// <param name="assignmentContainer">The assignment data container that will be played.</param>
    public GMPlayingState(AssignmentBaseObject assignmentContainer)
    {
        m_AssignmentContainer = assignmentContainer;
    }

    public override void Enter()
    {
        base.Enter();

        // Raise event that someone should create the assignment behaviour
        m_AssignmentBehaviour = CreateAssignment?.Invoke(m_AssignmentContainer);

        // If no one created a valid behaviour
        if (m_AssignmentBehaviour == null)
        {
            // WTF happened??
            Debug.LogError("Could not create assignment behaviour, maybe because no one was subscribed to the create assignment event (assignment factory)");
            return;
        }

        // Play the assignment
        m_AssignmentBehaviour.Play();
    }
}
