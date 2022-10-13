using System.Collections;
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

    /* Members. */
    [SerializeField] private AssignmentCategoryContainer[] m_AssignmentCategories;
    
    private GMBaseState m_CurrentGameState;

    /* Getters/Setters. */
    public GMBaseState CurrentGameState { get { return m_CurrentGameState; } private set { m_CurrentGameState = value; } }
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
    }

}
