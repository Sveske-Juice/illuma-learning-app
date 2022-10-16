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
    private EAssignmentCategory m_ChosenAssignmentCategory;

    /* Getters/Setters. */
    public AssignmentCategoryContainer[] AssignmentCategories { get { return m_AssignmentCategories; } private set { m_AssignmentCategories = value; } }
    public GMBaseState CurrentGameState { get { return m_CurrentGameState; } private set { m_CurrentGameState = value; } }
    public EAssignmentCategory ChosenAssignmentCategory { get { return m_ChosenAssignmentCategory; } set { m_ChosenAssignmentCategory = value; } }

    private void Awake()
    {
        Instance = this;
        SwitchState(new GMCategorySelectState());
    }


    private void Update()
    {
        CurrentGameState.Tick();
    }

    public void SwitchState(GMBaseState newState)
    {
        CurrentGameState?.Exit();
        CurrentGameState = newState;
        newState.Enter();

        OnGameStateChange?.Invoke(newState);
    }

}
