using System;
using System.Collections.Generic;
using UnityEngine;

public class GMPlayingState : GMBaseState
{
    /* Memebers. */
    private IPlayable m_AssignmentBehaviour;

    public override void Enter()
    {
        base.Enter();

        m_AssignmentBehaviour = GameManager.Instance.AssignmentContainer.CreateAssignment(GameManager.Instance.AssignmentParent);

        // If no one created a valid behaviour
        if (m_AssignmentBehaviour == null)
        {
            // WTF happened??
            Debug.LogError("Could not create assignment behaviour.");
            return;
        }
        Debug.Log($"Playing assignment named: {GameManager.Instance.AssignmentContainer.Name}");

        // Play the assignment
        m_AssignmentBehaviour.Play();
    }
}
