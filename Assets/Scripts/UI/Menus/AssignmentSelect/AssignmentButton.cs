using System;
using UnityEngine;
using TMPro;

public class AssignmentButton : MonoBehaviour
{
    /* Members. */
    private int assignmentIdx;

    /// <summary>
    /// Event that gets raised when user clicks on an assignment to train.
    /// </summary>
    public static event Action<int> OnAssignmentSelect;

    /* Getters/Setters. */
    /// <summary>
    /// The category to display on the button. Also serves as the button's
    /// way of raising an event with the specified category (DisplayCategory) on the click.
    /// </summary>
    public int AssignmentIdx { get { return assignmentIdx; } set { assignmentIdx = value; SetBtnText((value + 1).ToString()); } }

    /// <summary>
    /// Sets the buttons text value.
    /// </summary>
    /// <param name="txt">The string to display on the button.</param>
    private void SetBtnText(string txt)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }

    public void OnClick()
    {
        OnAssignmentSelect?.Invoke(AssignmentIdx);        
    }
}
