using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager Set Select State is active when
/// the user needs to pick an assignment set to train. 
/// </summary>
public class GMSetSelect : GMBaseState
{
    /* Members. */
    

    /* Getters/Setters. */

    public override void Enter()
    {
        base.Enter();

        // Subscribe to the event raised when clicked on a set button
        SetButton.OnSetSelect += OnSetSelection;
    }

    public override void Exit()
    {
        base.Exit();

        // Unsubscribe to the event raised when clicked on a set button
        SetButton.OnSetSelect -= OnSetSelection;
    }

    /// <summary>
    /// Gets called when the user clicks on a assignment set button.
    /// Will handle going to the next state of showing each assignment
    /// in that state.
    /// </summary>
    /// <param name="set">The set the user clicks on. </param>
    private void OnSetSelection(SetObject set)
    {
        Debug.Log($"Chose set: {set.Name}");

        // Switch state to set Assignment select
        GameManager.Instance.AssignmentSet = set;
        GameManager.Instance.CommandHandler.AddCommand(new GMStateCommand<GMAssignmentSelect>());
    }
}
