using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subject", menuName = "Subject")]
public class SubjectObject : ScriptableObject
{
    /* Members. */
    [SerializeField] private string m_SubjectName;
    [SerializeField] private CategoryObject[] m_Categories;

    /* Getters/Setters. */
    public string Name => m_SubjectName;
    public CategoryObject[] Categories => m_Categories;
}
