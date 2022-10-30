using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultipleChoiceBehaviour : AssignmentBaseBehaviour<MultipleChoiceObject>
{
    /* Members. */
    [SerializeField] private TextMeshProUGUI m_QuestionText;
    [SerializeField] private GameObject m_ChoicePrefab;
    [SerializeField] private Transform m_ChoiceGridParent;

    private void OnEnable()
    {
        ChoiceButton.OnChoiceClick += OnChoiceSelect;
    }

    private void OnDisable()
    {
        ChoiceButton.OnChoiceClick -= OnChoiceSelect;
    }

    public override void Load(MultipleChoiceObject container)
    {
        base.Load(container);

        /* Initialize the prefab with container ex: question text etc. */
        m_QuestionText.text = container.Question;

        // Create multiple choice buttons
        for (int i = 0; i < container.Choices.Length; i++)
        {
            ChoiceButton choiceButton = Instantiate(m_ChoicePrefab, Vector3.zero, Quaternion.identity, m_ChoiceGridParent).GetComponent<ChoiceButton>();
            choiceButton.Load(container, i);
        }
    }

    private void OnChoiceSelect(int choiceIdx)
    {
        string choice = m_Ctx.Choices[choiceIdx];
        Debug.Log($"Selected choice: {choice}");

        // Validate answer
        for (int i = 0; i < m_Ctx.CorrectAnswers.Length; i++)
        {
            if (choice == m_Ctx.CorrectAnswers[i])
            {
                AssignmentBaseObject.OnCorrectAnswer?.Invoke();
            }
            else
            {
                AssignmentBaseObject.OnIncorrectAnswer?.Invoke();
            }
        }
    }
}
