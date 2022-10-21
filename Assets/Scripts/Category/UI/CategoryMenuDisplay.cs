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
    [SerializeField] private GameObject m_CategoryHolder;
    [SerializeField] private GameObject m_CategoryContainer;
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

    protected override void Display()
    {
        // Instantiate Category Holder prefabs based on the categories specified in the gamemanager
        for (int i = 0; i < GameManager.Instance.AssignmentCategories.Length; i++)
        {
            CategoryObject categoryContainer = GameManager.Instance.AssignmentCategories[i];

            // Create category button as child of the container in the scroll view
            GameObject categoryBtn = GameObject.Instantiate( m_CategoryHolder, Vector3.zero, 
                                    Quaternion.identity, m_CategoryContainer.transform);

            // Load the new button with the category data container (sets display text etc.)
            categoryBtn.GetComponentInChildren<CategoryButton>().Load(categoryContainer);
        }

        base.Display();
    }

    protected override void Hide()
    {
        // Delete all the category buttons
        int childrenCount = m_CategoryContainer.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject.Destroy(m_CategoryContainer.transform.GetChild(i).gameObject);
        }

        base.Hide();
    }
}
