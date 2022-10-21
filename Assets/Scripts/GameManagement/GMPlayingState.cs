using System;
using System.Collections.Generic;
using UnityEngine;

public class GMPlayingState : GMBaseState
{
    /* Memebers. */
    private AssignmentBaseObject m_AssignmentContainer;
    private IPlayable m_AssignmentBehaviour;

    //public static event Func<AssignmentBaseObject, AssignmentBaseBehaviour> CreateAssignment;

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

        
        if (m_AssignmentContainer is TextInputObject)
        {
            m_AssignmentBehaviour = GameManager.Instance.AssignmentFactory.CreateAssignment<TextInputBehaviour, TextInputObject>(m_AssignmentContainer);
        }
        
        Debug.Log(m_AssignmentContainer);

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
