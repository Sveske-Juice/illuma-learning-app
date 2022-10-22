using System;
using UnityEngine;
using TMPro;

public class ChoiceButton : ContainerLoader, IButton
{
    public static event Action<int> OnChoiceClick;
    /* Members. */
    private int m_ChoiceIdx;

    // TODO optimise to load a choice container instead
    public void Load(MultipleChoiceObject container, int choiceIdx)
    {
        string choice = container.Choices[choiceIdx];
        base.Load(choice);
        
        m_ChoiceIdx = choiceIdx;
        SetBtnText(choice);
    }

    public void OnClick()
    {
        OnChoiceClick?.Invoke(m_ChoiceIdx);
    }

    /// <summary>
    /// Sets the buttons text value.
    /// </summary>
    /// <param name="txt">The string to display on the button.</param>
    public void SetBtnText(string txt)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }
}
