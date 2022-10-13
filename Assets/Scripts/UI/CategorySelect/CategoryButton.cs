using System;
using UnityEngine;
using TMPro;

public class CategoryButton : MonoBehaviour
{
    /* Members. */
    private EAssignmentCategory m_DisplayCategory;

    public static event Action<EAssignmentCategory> OnCategorySelect;

    /* Getters/Setters. */
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
