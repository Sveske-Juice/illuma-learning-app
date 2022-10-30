using UnityEngine;
using System;

public abstract class AssignmentBaseObject : ScriptableObject
{
    /* Members. */
    [SerializeField] protected string m_AssignmentName;
    protected int m_AssignmentIdx;
    public static Action OnIncorrectAnswer;
    public static Action OnCorrectAnswer;

    /* Getters/Setters. */
    public string Name => m_AssignmentName;

    /*  NOTE: This field will be set automatically externally. I 
        think this is okay because there will only be one instance
        for each scriptable object assignment. 
    */
    public int AssignmentIdx { get { return m_AssignmentIdx; } set { m_AssignmentIdx = value; } }

    /// <summary>
    /// The prefab for the assignment menu/window that will
    /// be displayed when the assignment is created. Will be
    /// different for each assignment, thats why it's abstract
    /// </summary>
    protected abstract GameObject m_AssignmentHolderPrefab { get; }

    /// <summary>
    /// Factory method that creates a prefab that is different based on what 
    /// BehaviourType and ContainerType is specified. The prefab is specified
    /// by the abstract m_AssignmentHolderPrefab property. This method will get
    /// called from derived classes' abstract CreateAssignment(Transform) method.
    /// </summary>
    /// <typeparam name="BehaviourType">
    /// The behaviour type to create. They all derive from AssignmentBaseBehaviour.</typeparam>
    /// <typeparam name="ContainerType">
    /// The type of the data container (SO) the behaviour consists of. Will also be the
    ///  type of container that will be loaded into the behaviour to initalize it.</typeparam>
    protected IPlayable CreateAssignment<BehaviourType, ContainerType>(Transform assignmentParent, ContainerType container)
        where BehaviourType : AssignmentBaseBehaviour<ContainerType> where ContainerType : AssignmentBaseObject
    {
        BehaviourType behaviour = Instantiate(  m_AssignmentHolderPrefab, Vector3.zero, 
                                                Quaternion.identity, assignmentParent)
                                                .GetComponent<BehaviourType>();
        behaviour.Load(container);
        return behaviour;
    }

    /// <summary>
    /// Each sub-class of AssignmentBaseObject needs to decide which assignment is created.
    /// Will call the base.CreateAssignment() factory method with the correct type for that
    /// specific container. That way each container decides which behaviour to instantiate.
    /// </summary>
    /// <param name="assignmentParent">The parent the instantiated assignment will be a child of. </param>
    public abstract IPlayable CreateAssignment(Transform assignmentParent);
}
