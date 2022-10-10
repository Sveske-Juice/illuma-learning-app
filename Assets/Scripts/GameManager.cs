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
    }
    }

    [SerializeField] private AssignmentCategoryContainer[] m_AssignmentCategories;
    private GameState m_GameState = GameState.ASSIGNMENT_SET_SELECT;
    private void Awake()
    {
        Instance = this;
    }
}
