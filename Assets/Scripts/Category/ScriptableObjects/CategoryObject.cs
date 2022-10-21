using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Category", menuName = "Category")]
[System.Serializable]
public class CategoryObject : ScriptableObject
{
    /* Members. */
    [SerializeField] private string m_CategoryName;
    [SerializeField] private SetObject[] m_Sets;

    /* Getters/Setters. */
    public string Name => m_CategoryName;
    public SetObject[] Sets => m_Sets;
}
