using System;
using UnityEngine;

/// <summary>
/// The abstract/base class for all assignment behaviours. It will be the super class
/// for fx the TextAssignment Behaviour.
/// </summary>
public abstract class AssignmentBaseBehaviour<ContainerType> : MonoBehaviour, IPlayable where ContainerType : AssignmentBaseObject
{
    /* Members. */
    public static event Action OnIncorrectAnswer;
    public static event Action OnCorrectAnswer;

    protected ContainerType m_Ctx;

    /// <summary>
    /// Sets the context so the behaviour implementation 
    /// has access to the data container.
    /// </summary>
    /// <param name="ctx">The context to set to the this behaviour instance. </param>
    protected virtual void SetContext(ContainerType ctx)
    {
        m_Ctx = ctx;
    }

    public virtual void Load(ContainerType container)
    {
        // Set the context so the this behaviour has access to the data container
        SetContext(container);
    }

    /// <summary>
    /// Gets called when the assignment should start being played.
    /// Gets called from the playing state game manager once the 
    /// assignment has been constructed and loaded with its context.
    /// </summary>
    public virtual void Play()
    {
        Debug.Log($"Starting play of assignment with index: {m_Ctx.AssignmentIdx}");
    }
}

// Default type
public abstract class AssignmentBaseBehaviour : AssignmentBaseBehaviour<AssignmentBaseObject> { }