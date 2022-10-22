using System;
using UnityEngine;
using TMPro;

public class ChoiceButton : ContainerLoader, IButton
{
    public static event Action<int> OnChoiceClick;
    /* Members. */
    private int m_ChoiceIdx;

    // TODO maybe move to a choice container instead
    public void Load(MultipleChoiceObject container, int choiceIdx)
    {
        m_ChoiceIdx = choiceIdx;
        SetBtnText(container.Choices[choiceIdx]);
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
