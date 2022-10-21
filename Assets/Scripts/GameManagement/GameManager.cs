using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SubjectManager))]
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
    /// Event that gets raised when the game state changes, 
    /// passing the new state to the subscribed delegate.
    /// </summary>
    public static event Action<GMBaseState> OnGameStateChange;

    /* Members. */
    private GMBaseState m_CurrentGameState;
    private ISubjectHolder m_SubjectHolder;
    [SerializeField] private AssignmentFactory m_AssignmentFactory;

    /* Getters/Setters. */
    public GMBaseState CurrentGameState => m_CurrentGameState;
    public AssignmentFactory AssignmentFactory => m_AssignmentFactory;

    // TODO support for more subjects (dont use Subjects[0]), fine for now tho
    public CategoryObject[] AssignmentCategories => m_SubjectHolder.Subjects[0].Categories;

    private void Awake()
    {
        // Singleton: Set this instance to the only one
        Instance = this;

        m_SubjectHolder = GetComponent<ISubjectHolder>();

        if (m_AssignmentFactory == null)
        {
            Debug.LogError("No assignment factory connected to the gamemanager!");
        }
    }

    private void Start()
    {
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
        m_CurrentGameState = newState;
        newState.Enter();

        OnGameStateChange?.Invoke(newState);
    }

}
