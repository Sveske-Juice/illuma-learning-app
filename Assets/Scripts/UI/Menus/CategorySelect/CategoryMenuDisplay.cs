using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will make sure that the category select menu is showed
/// when its the correct state. It will handle creating the buttons,
/// showing and hiding the menu. 
/// </summary>
public class CategoryMenuDisplay : DisplayMenuBase
{
    protected override void OnGameStateChanged(GMBaseState state)
    {
        if (state is GMCategorySelectState)
        {
            Display();
        }
        else
        {
            Hide();
        }
    }

    private void Display()
    {
        // Instantiate Category Holder prefabs based on the categories specified in the gamemanager
        for (int i = 0; i < GameManager.Instance.AssignmentCategories.Length; i++)
        {
            // Create category button as child of the container in the scroll view
            GameObject categoryBtn = GameObject.Instantiate( GameManager.Instance.CategoryHolder, Vector3.zero, 
                                    Quaternion.identity, GameManager.Instance.CategoryContainer.transform);

            // Set the newly created button's category to display
            categoryBtn.GetComponentInChildren<CategoryButton>().DisplayCategory = GameManager.Instance.AssignmentCategories[i].DisplayCategory;
        }

        // Show the menu
        Menu.SetActive(true);
    }

    private void Hide()
    {
        // Delete all the category buttons
        int childrenCount = Menu.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject.Destroy(GameManager.Instance.CategoryContainer.transform.GetChild(i).gameObject);
        }

        // Hide the menu
        Menu.SetActive(false);
    }
}
