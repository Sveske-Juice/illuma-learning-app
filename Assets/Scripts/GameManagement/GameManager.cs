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
    private CommandHandler m_CommandHandler = new CommandHandler();
    private GMBaseState m_CurrentGameState;
    private ISubjectHolder m_SubjectHolder;
    [SerializeField] private Transform m_AssignmentParent;

    private SetObject m_AssignmentSet;
    private AssignmentCategory m_Category;
    private AssignmentBaseObject m_AssignmentContainer;

    /* Getters/Setters. */
    public CommandHandler CommandHandler => m_CommandHandler;
    public GMBaseState CurrentGameState => m_CurrentGameState;

    // TODO support for more subjects (dont use Subjects[0]), fine for now tho
    public CategoryObject[] AssignmentCategories => m_SubjectHolder.Subjects[0].Categories;
    public Transform AssignmentParent => m_AssignmentParent;

    /// <summary>The selected Assignment set in the current category. </summary>
    public SetObject AssignmentSet { get { return m_AssignmentSet; } set { m_AssignmentSet = value; } }
    
    /// <summary>The category in which the current assignment set lie within. </summary>
    public AssignmentCategory Category { get { return m_Category; } set { m_Category = value; } }

    /// <summary>The Assignment Container the current running assignment behaviour coresponds to. </summary>
    public AssignmentBaseObject AssignmentContainer { get { return m_AssignmentContainer; } set { m_AssignmentContainer = value; } }

    private void Awake()
    {
        // Singleton: Set this instance to the only one
        Instance = this;

        m_SubjectHolder = GetComponent<ISubjectHolder>();
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
