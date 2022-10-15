using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class that will subscribe to game state changes. Classes implementing this
/// will handle displaying a menu defined by 'm_Menu' based on game state changes.
/// For example when going to the main menu screen there will be a class implementing this
/// abstract class, that will trigger when changing to menu state and show the main menu.
/// </summary>
public abstract class DisplayMenuBase : MonoBehaviour
{
    /* Members. */
    [SerializeField] private GameObject m_Menu;

    /* Getters/Setters. */
    protected GameObject Menu { get { return m_Menu; } set { m_Menu = value; } }

    protected virtual void OnEnable()
    {
        // Subsribe to game state change event
        GameManager.OnGameStateChange += OnGameStateChanged;
    }

    protected virtual void OnDisable()
    {
        // Unsubsribe to game state change event
        GameManager.OnGameStateChange -= OnGameStateChanged;
    }

    /// <summary>
    /// Gets called when the game state changes.
    /// Used to know when to display a menu.
    /// </summary>
    /// <param name="state">The new state the game is changing to.</param>
    protected abstract void OnGameStateChanged(GMBaseState state);
}
