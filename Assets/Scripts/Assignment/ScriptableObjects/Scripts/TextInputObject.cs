using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text Input Assignment", menuName = "Assignment/Question/TextInput")]
public class TextInputObject : QuestionBaseObject
{
    protected override GameObject m_AssignmentHolderPrefab => Resources.Load<GameObject>("Prefabs/UI/TextInputAssignment");

    public override IPlayable CreateAssignment(Transform assignmentParent)
    {
        return base.CreateAssignment<TextInputBehaviour, TextInputObject>(assignmentParent, this);
    }
}
