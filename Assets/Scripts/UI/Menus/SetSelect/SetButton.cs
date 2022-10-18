using System;
using UnityEngine;
using TMPro;

public class SetButton : ContainerLoader
{
    /* Members. */
    private AssignmentSetContainer m_AssociatedSet;

    /// <summary>
    /// Event that gets raised when user clicks on a assignment set to train on.
    /// </summary>
    public static event Action<AssignmentSetContainer> OnSetSelect;

    /* Getters/Setters. */
    /// <summary>
    /// The assignments set data container this button corresponds to.
    /// </summary>
    public AssignmentSetContainer AssociatedSet { get { return m_AssociatedSet; } set { m_AssociatedSet = value; } }

    /// <summary>
    /// Loads an assignment set data container into the UI element.
    /// It will set the display text aswell as setting up events
    /// for when the button is pressed.
    /// </summary>
    /// <param name="setContainer">The assignment set data container to load.</param>
    public void Load(AssignmentSetContainer setContainer)
    {
        AssociatedSet = setContainer;

        // Sets the display text of the button to the name of the set container
        SetBtnText(setContainer.Name);

        base.Load(setContainer.Name);
    }

    /// <summary>
    /// Sets the buttons text value.
    /// </summary>
    /// <param name="txt">The string to display on the button.</param>
    public void SetBtnText(string txt)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }

    /// <summary>
    /// Gets called when clicked on the button. 
    /// It will raise an event passing the associated
    /// assignment set this button corresponds to.
    /// </summary>
    public void OnClick()
    {
        OnSetSelect?.Invoke(AssociatedSet);        
    }
}
