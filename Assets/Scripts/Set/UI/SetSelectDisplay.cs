using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetSelectDisplay : DisplayMenuBase
{
    /* Members. */
    [SerializeField] private GameObject m_SetHolder;
    [SerializeField] private GameObject m_SetContainer;

    protected override void OnGameStateChanged(GMBaseState state)
    {
        // Try to cast to GMSelect state
        GMSetSelect setState = state as GMSetSelect;
        if (setState != null)
        {
            // If the new state is set select, then display the menu
            Display(GameManager.Instance.Category);
        }
        else
        {
            // If the new state is not set select, then hide the menu
            Hide();
        }
    }

    private void Display(AssignmentCategory category)
    {
        Debug.Log($"Displaying assignment sets of category: {category}");
        CategoryObject[] categories = GameManager.Instance.AssignmentCategories;

        // Find the index of the category to display
        int categoryIdx = FindCategoryIdx(categories, category);
        if (categoryIdx < 0)
            return;
        
        // The assignment sets under that category.
        SetObject[] sets = categories[categoryIdx].Sets;

        // Create set holders based on the assignment sets
        for (int i = 0; i < sets.Length; i++)
        {
            SetObject set = sets[i];

            // If the set haven't been givin a value from the editor
            if (set == null)
                continue;

            // Create set button as child of the container in the scroll view
            GameObject setBtn = GameObject.Instantiate( m_SetHolder, Vector3.zero, 
                                    Quaternion.identity, m_SetContainer.transform);

            // Load the new button with the assignment set data container (sets display text etc.)
            setBtn.GetComponentInChildren<SetButton>().Load(set);
        }

        base.Display();
    }

    protected override void Hide()
    {
        // TODO remove content

        base.Hide();
    }

    /// <summary>
    /// Finds the index of the specified category 
    /// in the assignment categories array.
    /// </summary>
    /// <param name="categories">The array to search.</param>
    /// <param name="category">The category to find.</param>
    private int FindCategoryIdx(CategoryObject[] categories, AssignmentCategory category)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            if (categories[i].Category == category)
            {
                return i;
            }
        }
        return -1;
    }
}
