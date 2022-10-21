using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentFactory : MonoBehaviour
{
    [SerializeField] private Transform m_AssignmentContainer;

    [SerializeField] private GameObject m_TextAssignmentHolder;
    private void OnEnable()
    {
        GMPlayingState.CreateAssignment += CreateAssignment;
    }

    private void OnDisable()
    {
        GMPlayingState.CreateAssignment -= CreateAssignment;
    }

    private IAssignment CreateAssignment(AssignmentContainerBase container)
    {
        TextAssignmentContainer textAssignment = container as TextAssignmentContainer;
        if (textAssignment != null)
        {
            TextAssignmentBehaviour behaviour = Instantiate(    m_TextAssignmentHolder, Vector3.zero, 
                                                                Quaternion.identity, m_AssignmentContainer)
                                                                .GetComponent<TextAssignmentBehaviour>();
            behaviour.Load(textAssignment);
            return behaviour;                                                      
        }
        return null;
    }
}
