using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The abstract/base class for all assignment behaviours. It will be the super class
/// for fx the TextAssignment Behaviour.
public abstract class AssignmentBase : MonoBehaviour
{
    protected AssignmentContainerBase m_Ctx;

    public virtual void SetContext(AssignmentContainerBase ctx)
    {
        m_Ctx = ctx;
    }
}
