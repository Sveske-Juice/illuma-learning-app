using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager Category Select State is active when
/// the user needs to pick a category to train.
/// </summary>
public class GMCategorySelectState : GMBaseState
{
    public override void Enter()
    {
        base.Enter();

        // Subscribe to the event raised when clicked on a category button
        if (!GameManager.GameLoaded) // FIXME se gm for info
            CategoryButton.OnCategorySelect += OnCategoryBtnClick;
    }

    public override void Exit()
    {
        base.Exit();

        // Unsubscribe to the event raised when clicked on a category button
        CategoryButton.OnCategorySelect -= OnCategoryBtnClick;
    }

    /// <summary>
    /// Gets called when a category button is clicked.
    /// </summary>
    /// <param name="categoryContainer">The category data container corresponding to the clicked button. </param>
    private void OnCategoryBtnClick(CategoryObject categoryContainer)
    {
        string displayText = categoryContainer.Category.ToString();
        Debug.Log($"Selected category: {displayText}");

        
        GameManager.Instance.Category = categoryContainer.Category;
        GameManager.Instance.CommandHandler.AddCommand(new GMStateCommand<GMSetSelect>());
    }
}
