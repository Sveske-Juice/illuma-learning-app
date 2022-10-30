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
    [SerializeField] protected GameObject m_MenuParent;

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

    /// <summary>
    /// Sets the menu active so it can be seen in-game.
    /// </summary>
    protected virtual void Display()
    {
        Debug.Log($"Displaying menu named: {Menu.name}");

        // Show menu
        Menu.SetActive(true);
    }

    /// <summary>
    /// Sets the menu inactive so it can't be seen in-game.
    /// </summary>
    protected virtual void Hide()
    {
        Debug.Log($"Hiding menu named: {Menu.name}");

        // Delete all the category buttons
        int childrenCount = m_MenuParent.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject.Destroy(m_MenuParent.transform.GetChild(i).gameObject);
        }

        // Hide menu
        Menu.SetActive(false);
    }
}
