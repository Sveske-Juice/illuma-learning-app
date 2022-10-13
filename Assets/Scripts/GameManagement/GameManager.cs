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
    [SerializeField] private GameObject m_CategoryHolder;
    [SerializeField] private GameObject m_CategoryContainer;
    private GMBaseState m_CurrentGameState;

    /* Getters/Setters. */
    public AssignmentCategoryContainer[] AssignmentCategories { get { return m_AssignmentCategories; } private set { m_AssignmentCategories = value; } }
    public GameObject CategoryHolder { get { return m_CategoryHolder; } private set { m_CategoryHolder = value; } }
    public GameObject CategoryContainer { get { return m_CategoryContainer; } private set { m_CategoryContainer = value; } }
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
