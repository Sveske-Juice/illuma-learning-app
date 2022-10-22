using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultipleChoiceBehaviour : AssignmentBaseBehaviour<MultipleChoiceObject>
{
    /* Members. */
    [SerializeField] private TextMeshProUGUI m_QuestionText;

    public override void Load(MultipleChoiceObject container)
    {
        base.Load(container);

        /* Initialize the prefab with container ex: question text etc. */
        m_QuestionText.text = container.Question;

        Debug.Log(container.Choices);
    }
}
