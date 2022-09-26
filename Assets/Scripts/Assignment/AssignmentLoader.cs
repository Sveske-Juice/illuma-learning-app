using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentLoader : MonoBehaviour
{
    private GameObject assHolder;

    private void Start()
    {
        assHolder = GameManager.AssHolder;
    }

    public void Load(IAssignment assignment)
    {
        TextAssignmentBehaviour obj = assHolder.AddComponent<TextAssignmentBehaviour>();
        obj.Ctx = assignment;
    }
}
