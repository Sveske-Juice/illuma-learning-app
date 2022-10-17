using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager Category Select State is active when
/// the user needs to pick a category to train on.
/// </summary>
public class GMCategorySelectState : GMBaseState
{
    public override void Enter()
    {
        base.Enter();

        // Subscribe to the event raised when clicked on a category button
        CategoryButton.OnCategorySelect += OnCategoryBtnClick;
    }

    public override void Exit()
    {
        base.Exit();

        // Unsubscribe to the event raised when clicked on a category button
        CategoryButton.OnCategorySelect -= OnCategoryBtnClick;
    }

    /// <summary>
    /// Gets called when the user presses a category button.
    /// </summary>
    /// <param name="category">The category that the user decided. </param>
    private void OnCategoryBtnClick(EAssignmentCategory category)
    {
        Debug.Log($"Selected category: {category}");

        // Switch state to set select
        GameManager.Instance.SwitchState(new GMSetSelect(category));
    }
}
