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

        // Instantiate Category Holder prefabs based on the categories specified in the gamemanager
        for (int i = 0; i < GameManager.Instance.AssignmentCategories.Length; i++)
        {
            // Create category button as child of the container in the scroll view
            GameObject categoryBtn = GameObject.Instantiate( GameManager.Instance.CategoryHolder, Vector3.zero, 
                                    Quaternion.identity, GameManager.Instance.CategoryContainer.transform);

            // Set the newly created button's category to display
            categoryBtn.GetComponentInChildren<CategoryButton>().DisplayCategory = GameManager.Instance.AssignmentCategories[i].DisplayCategory;
        }

        // Subscribe to the event raised when clicked on a category button
        CategoryButton.OnCategorySelect += OnCategoryBtnClick;

        // Show Category Select Menu
        HUDSystem.Instance.SetMenuActiveState(HUDSystem.Instance.CategorySelectMenu, true);
    }

    public override void Exit()
    {
        base.Exit();

        // Unsubscribe to the event raised when clicked on a category button
        CategoryButton.OnCategorySelect -= OnCategoryBtnClick;

        // Hide Category Select Menu
        HUDSystem.Instance.SetMenuActiveState(HUDSystem.Instance.CategorySelectMenu, false);

        // Delete all the category buttons
        int childrenCount = GameManager.Instance.CategoryContainer.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject.Destroy(GameManager.Instance.CategoryContainer.transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Gets called when the user presses a category button.
    /// </summary>
    /// <param name="category">The category that the user decided. </param>
    private void OnCategoryBtnClick(EAssignmentCategory category)
    {
        Debug.Log($"Selected category {category}");

        // Switch state to set select
        GameManager.Instance.SwitchState(new GMSetSelect(category));
    }
}
