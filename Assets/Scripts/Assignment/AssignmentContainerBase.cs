using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AssignmentContainerBase
{
    [SerializeField] protected string m_Name;

    public string Name { get { return m_Name; } set { m_Name = value; } }
}
