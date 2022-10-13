using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will make sure that the category select menu is showed
/// when its the correct state. It will handle creating the buttons,
/// showing and hiding the menu. 
/// </summary>
public class CategoryMenuDisplay : MonoBehaviour
{
    /* Members. */
    [SerializeField] private GameObject m_CategoryMenu;

    /* Getters/Setters. */


    private void OnEnable()
    {
        // Subsribe to game state change event
        GameManager.OnGameStateChange += OnGameStateChanged;
    }

    private void OnDisable()
    {
        // Unsubsribe to game state change event
        GameManager.OnGameStateChange -= OnGameStateChanged;
    }

    /// <summary>
    /// Gets called when the state changes. If the new state is
    /// CategorySelect state it will show the category select menu, 
    /// else delete previos category buttons and hide it.
    /// </summary>
    /// <param name="state">The new state the game is changin to. </param>
    private void OnGameStateChanged(GMBaseState state)
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
        m_CategoryMenu.SetActive(true);
    }

    private void Hide()
    {
        // Delete all the category buttons
        int childrenCount = GameManager.Instance.CategoryContainer.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject.Destroy(GameManager.Instance.CategoryContainer.transform.GetChild(i).gameObject);
        }

        // Hide the menu
        m_CategoryMenu.SetActive(false);
    }
}
