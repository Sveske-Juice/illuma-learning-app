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
        m_Category = category;
    }

    /* Members. */
    private EAssignmentCategory m_Category;

    /* Getters/Setters. */

    public override void Enter()
    {
        base.Enter();

        
    }
}
