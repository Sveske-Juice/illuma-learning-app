using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentFactory : MonoBehaviour
{
    [SerializeField] private Transform m_AssignmentContainer;
    [SerializeField] private GameObject m_TextAssignmentHolder;

    public IPlayable CreateAssignment<BehaviourType, ContainerType>(AssignmentBaseObject container) 
        where BehaviourType : AssignmentBaseBehaviour<ContainerType> where ContainerType : AssignmentBaseObject
    {
        BehaviourType behaviour = Instantiate(  m_TextAssignmentHolder, Vector3.zero, 
                                                Quaternion.identity, m_AssignmentContainer)
                                                .GetComponent<BehaviourType>();
        behaviour.Load(container as ContainerType);
        return behaviour;
    }
}
