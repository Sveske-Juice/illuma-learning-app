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
            Display(setState.Category);
        }
        else
        {
            // If the new state is not set select, then hide the menu
            Hide();
        }
    }

    private void Display(EAssignmentCategory category)
    {
        Debug.Log($"Displaying assignment sets of category: {category}");
        AssignmentCategoryContainer[] categories = GameManager.Instance.AssignmentCategories;

        // Find the index of the category to display
        int categoryIdx = FindCategoryIdx(categories, category);
        if (categoryIdx < 0)
            return;
        
        // The assignment sets under that category.
        AssignmentSet[] sets = categories[categoryIdx].AssignmentSets;

        // Create set holders based on the assignment sets
        for (int i = 0; i < sets.Length; i++)
        {
            // Create set button as child of the container in the scroll view
            GameObject setBtn = GameObject.Instantiate( m_SetHolder, Vector3.zero, 
                                    Quaternion.identity, m_SetContainer.transform);
            SetButton btnComp = setBtn.GetComponentInChildren<SetButton>();
            btnComp.SetIdx = i;
            btnComp.CategoryIdx = categoryIdx;
            btnComp.SetBtnText(sets[i].Name);
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
    private int FindCategoryIdx(AssignmentCategoryContainer[] categories, EAssignmentCategory category)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            if (categories[i].DisplayCategory == category)
            {
                return i;
            }
        }
        return -1;
    }
}
