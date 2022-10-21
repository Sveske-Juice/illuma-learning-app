using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextAssignmentBehaviour : AssignmentBase<TextInputObject>
{
    /* Members. */
    [SerializeField] private TextMeshProUGUI m_QuestionText;
    [SerializeField] private TMP_InputField m_InputField;

    /// <summary>
    /// Stores the state of the text assignment. Used for the assignment's FSM.
    /// </summary>
    private TextAssignmentState m_State = TextAssignmentState.Paused;

    public override void Load(TextInputObject container)
    {
        base.Load(container);

        /* Initialize the prefab with container ex: question text etc. */
        m_QuestionText.text = m_Ctx.Question;

    }

    public override void Play()
    {
        base.Play();

        m_State = TextAssignmentState.BeginAnimation;

        // Subscribe to event when clicked on check button
        CheckButton.OnCheckClick += CheckResult;
    }

    private void OnDisable()
    {
        CheckButton.OnCheckClick -= CheckResult;
    }

    private void Update()
    {
        switch (m_State)
        {
            case TextAssignmentState.Paused:
                break;

            case TextAssignmentState.BeginAnimation:
                BeginAnimate();
                break;

            case TextAssignmentState.EndAnimation:
                EndAnimate();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Gets called every frame the text assignment is showing the ending animation.
    /// </summary>
    private void EndAnimate()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets called every frame the text assignment is showing the begin animation.
    /// It will show fruits moving in to position of the visual representation.
    /// </summary>
    private void BeginAnimate()
    {

    }

    /// <summary>
    /// Will check if whats typed in the input field is a correct answer.
    /// </summary>
    protected void CheckResult()
    {
        string answer = m_InputField.text;
        Debug.Log($"Answer: {answer}");
        
        // TODO sanitize input answer
        for (int i = 0; i < m_Ctx.CorrectAnswers.Length; i++)
        {
            if (answer == m_Ctx.CorrectAnswers[i])
                Debug.Log("CORRECT!");
        }
    }
}