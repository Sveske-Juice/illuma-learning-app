using System;
using UnityEngine;
using TMPro;

public class CategoryButton : MonoBehaviour
{
    /* Members. */
    private EAssignmentCategory m_DisplayCategory;

    public static event Action<EAssignmentCategory> OnCategorySelect;

    /* Getters/Setters. */
    /// <summary>
    /// The category to display on the button. Also serves as the button's
    /// way of raising an event with the specified category (DisplayCategory) on the click.
    /// </summary>
    public EAssignmentCategory DisplayCategory { get { return m_DisplayCategory; } set { m_DisplayCategory = value; SetBtnText(value.ToString()); } }

    /// <summary>
    /// Sets the buttons text value.
    /// </summary>
    /// <param name="txt">The string to display on the button.</param>
    private void SetBtnText(string txt)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }
}
