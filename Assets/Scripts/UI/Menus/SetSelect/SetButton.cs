using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetButton : MonoBehaviour
{
    /* Members. */
    private int m_SetIdx;
    private int m_CategoryIdx;

    /// <summary>
    /// Event that gets raised when user clicks on a assignment set to train on.
    /// </summary>
    public static event Action<int, int> OnSetSelect;

    /* Getters/Setters. */
    /// <summary>
    /// The index in the assignment set array this set button corresponds to.
    /// </summary>
    public int SetIdx { get { return m_SetIdx; } set { m_SetIdx = value; } }
    public int CategoryIdx { get { return m_CategoryIdx; } set { m_CategoryIdx = value; } }

    /// <summary>
    /// Sets the buttons text value.
    /// </summary>
    /// <param name="txt">The string to display on the button.</param>
    public void SetBtnText(string txt)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }

    public void OnClick()
    {
        OnSetSelect?.Invoke(CategoryIdx, SetIdx);        
    }
}
