using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] private AssignmentCategory[] m_AssignmentCategories;
    private GameState m_GameState = GameState.ASSIGNMENT_SET_SELECT;

    private void Start()
    {
        
    }
}
