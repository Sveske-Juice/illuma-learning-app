using System;
using UnityEngine;
using TMPro;

public class AssignmentButton : ContainerLoader, IButton
{
    /* Members. */
    private AssignmentBaseObject m_AssociatedAssignment;

    /// <summary>
    /// Event that gets raised when user clicks on an assignment to train.
    /// </summary>
    public static event Action<AssignmentBaseObject> OnAssignmentSelect;

    /* Getters/Setters. */
    /// <summary>
    /// The assignment data container this button corresponds to.
    /// </summary>
    public AssignmentBaseObject AssociatedAssignment { get { return m_AssociatedAssignment; } set { m_AssociatedAssignment = value; } }

    /// <summary>
    /// Loads an assignment data container into the UI element.
    /// It will set the display text aswell as setting up events
    /// for when the button is pressed.
    /// </summary>
    /// <param name="assignment">The assignment data container to load.</param>
    public void Load(AssignmentBaseObject assignment)
    {
        AssociatedAssignment = assignment;

        // If the assignment has a name show it, otherwise show its index
        if (assignment.Name.Length > 0)
        {
            SetBtnText(assignment.Name);
        }
        else
        {
            // Set button text with an offset of 1 to avoid zero-indexing
            SetBtnText((assignment.AssignmentIdx + 1).ToString());
        }

        base.Load(assignment.Name);
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
    /// assignment this button corresponds to.
    /// </summary>
    public void OnClick()
    {
        OnAssignmentSelect?.Invoke(AssociatedAssignment);        
    }
}
