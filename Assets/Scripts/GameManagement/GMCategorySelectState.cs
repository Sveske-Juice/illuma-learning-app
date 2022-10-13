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
            GameObject categoryBtn = GameObject.Instantiate( GameManager.Instance.CategoryHolder, GameManager.Instance.CategoryContainer.transform.position, 
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

        // Hide Category Select Menu
        HUDSystem.Instance.SetMenuActiveState(HUDSystem.Instance.CategorySelectMenu, false);
    }

    private void OnCategoryBtnClick(EAssignmentCategory category)
    {
        Debug.Log($"Selected category {category}");
    }
}
