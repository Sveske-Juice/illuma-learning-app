using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text Input Assignment", menuName = "Assignment/Question/TextInput")]
public class TextInputObject : QuestionBaseObject
{
    [SerializeField] private GameObject m_AssignmentHolderPrefab;
    // TODO use delegate or something
    public override IPlayable CreateAssignment(Transform assignmentParent)
    {
        TextInputBehaviour behaviour = Instantiate( m_AssignmentHolderPrefab, Vector3.zero, 
                                                    Quaternion.identity, assignmentParent)
                                                    .GetComponent<TextInputBehaviour>();
        behaviour.Load(this);
        return behaviour;
    }
}
