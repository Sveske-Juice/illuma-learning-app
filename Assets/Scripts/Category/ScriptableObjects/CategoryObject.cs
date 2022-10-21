using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Category", menuName = "Category")]
public class CategoryObject : ScriptableObject
{
    /* Members. */
    [SerializeField] private string m_CategoryName;
    [SerializeField] private AssignmentCategory m_Category;
    [SerializeField] private SetObject[] m_Sets;

    /* Getters/Setters. */
    public string Name => m_CategoryName;
    public AssignmentCategory Category => m_Category;
    public SetObject[] Sets => m_Sets;
}
