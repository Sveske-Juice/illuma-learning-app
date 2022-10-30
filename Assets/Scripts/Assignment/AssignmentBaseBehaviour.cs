using System;
using UnityEngine;

/// <summary>
/// The abstract/base class for all assignment behaviours. It will be the super class
/// for fx the TextAssignment Behaviour.
/// </summary>
public abstract class AssignmentBaseBehaviour<ContainerType> : MonoBehaviour, IPlayable where ContainerType : AssignmentBaseObject
{
    /* Members. */

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

    /// <summary>

    /// Loads a container on to a assignment behaviour. For example in
    /// a QuestionAssignment, this method will set the question text etc.
    /// It will also call base.BaseLoad() for common loading logic.
    /// </summary>
    /// <param name="container">The data container (SO) to load into this behaviour. </param>

    public virtual void Load(ContainerType container)
    {
        /*
        Common code that needs to be run for all sub-classes.
        Will set the context (data container (SO)), so each
        behaviour can reference it with m_Ctx.
        */
        // Set the context so the this behaviour has access to the data container
        SetContext(container);

        // Subscribe to the assignments events raised when answer is incorrect/correct
        AssignmentBaseObject.OnIncorrectAnswer += IncorrectAnswer;
        AssignmentBaseObject.OnCorrectAnswer += CorrectAnswer;
    }

    protected virtual void IncorrectAnswer()
    {
        Debug.Log("incorrect");
    }

    protected virtual void CorrectAnswer()
    {
        Debug.Log("Correct");
    }

    /// <summary>
    /// Will start playing the assignment
    /// </summary>
    public virtual void Play()
    {
        /* Common code that gets run for all sub-classes. */
        Debug.Log($"Starting play of assignment with index: {m_Ctx.AssignmentIdx}");
    }
}

// Default type
public abstract class AssignmentBaseBehaviour : AssignmentBaseBehaviour<AssignmentBaseObject> { }