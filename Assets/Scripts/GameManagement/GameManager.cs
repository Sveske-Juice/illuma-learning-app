using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    /* Singleton pattern. */
    private static GameManager m_Instance;
    public static GameManager Instance { get 
    {
        if (m_Instance != null)
            return m_Instance;
        Debug.LogError("GameManager is null"); 
        return null;
    }
    private set
    {
        m_Instance = value;
    }}

    /// <summary>
    /// Event that gets raised when the game state changes.
    /// </summary>
    public static event Action<GMBaseState> OnGameStateChange;

    /* Members. */
    [SerializeField] private AssignmentCategoryContainer[] m_AssignmentCategories;
    private GMBaseState m_CurrentGameState;

    /* Getters/Setters. */
    /// <summary>
    /// The assignment categories can for example be multiplication, addition etc.
    /// They all consists of assignment sets.
    /// </summary>
    public AssignmentCategoryContainer[] AssignmentCategories { get { return m_AssignmentCategories; } private set { m_AssignmentCategories = value; } }
    public GMBaseState CurrentGameState { get { return m_CurrentGameState; } private set { m_CurrentGameState = value; } }

    private void Awake()
    {
        // Singleton: Set this instance to the only one
        Instance = this;

        // Set the start state to category selection
        SwitchState(new GMCategorySelectState());
    }


    private void Update()
    {
        // Each frame tick the current state
        CurrentGameState.Tick();
    }

    /// <summary>
    /// Switches the game to a new state.
    /// It will first exit the current state (if its not null), 
    /// and then enter the new state.
    /// </summary>
    /// <param name="newState">The new game state to switch to.</param>
    public void SwitchState(GMBaseState newState)
    {
        CurrentGameState?.Exit();
        CurrentGameState = newState;
        newState.Enter();

        OnGameStateChange?.Invoke(newState);
    }

}
