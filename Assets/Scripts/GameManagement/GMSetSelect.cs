using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager Set Select State is active when
/// the user needs to pick an assignment set to
/// train on. </summary>
public class GMSetSelect : GMBaseState
{
    /// <summary>
    /// Constructor of Set Select state.
    /// </summary>
    /// <param name="category">The category in which the assignment sets lies within. </param>
    public GMSetSelect(EAssignmentCategory category)
    {
        Category = category;
    }

    /* Members. */
    private EAssignmentCategory m_Category;

    /* Getters/Setters. */
    public EAssignmentCategory Category { get; private set; }

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
    /// <param name="setIdx">The index in the assignment set array the user clicks on. </param>
    private void OnSetSelection(int setIdx)
    {

    }
}
