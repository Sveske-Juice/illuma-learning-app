using System;
using UnityEngine;
using TMPro;

public class CategoryButton : ContainerLoader
{
    /* Members. */
    private AssignmentCategoryContainer m_AssociatedCategory;

    /// <summary>
    /// Event that gets raised when user clicks on a category to train.
    /// Passing the category data container so the subscribers know the context.
    /// </summary>
    public static event Action<AssignmentCategoryContainer> OnCategorySelect;

    /* Getters/Setters. */

    /// <summary>
    /// The category data container this button corresponds to. Usefull for 
    /// when the user clicks so the correct category will be chosen
    /// </summary>
    public AssignmentCategoryContainer AssociatedCategory { get { return m_AssociatedCategory; } set { m_AssociatedCategory = value; SetBtnText(value.ToString()); } }

    /// <summary>
    /// Loads a category data container into the UI element.
    /// It will set the display text aswell as setting up events
    /// for when the button is pressed.
    /// </summary>
    /// <param name="categoryContainer">The category data container to load.</param>
    public void Load(AssignmentCategoryContainer categoryContainer)
    {
        AssociatedCategory = categoryContainer;

        // Sets the button's display text to the category
        string displayText = categoryContainer.DisplayCategory.ToString();
        SetBtnText(displayText);

        base.Load(displayText);
    }

    /// <summary>
    /// Sets the buttons text value.
    /// </summary>
    /// <param name="txt">The string to display on the button.</param>
    private void SetBtnText(string txt)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }

    /// <summary>
    /// Gets called when clicked on the button. 
    /// It will raise an event passing the associated
    /// category data container this button corresponds to.
    /// </summary>
    public void OnClick()
    {
        OnCategorySelect?.Invoke(AssociatedCategory);        
    }
}
