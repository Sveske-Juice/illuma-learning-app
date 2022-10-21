using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour, IButton
{
    /// <summary>
    /// Event that gets raised when the check button is clicked.
    /// </summary>
    public static event Action OnCheckClick;
    public void OnClick()
    {
        OnCheckClick?.Invoke();
    }
}
