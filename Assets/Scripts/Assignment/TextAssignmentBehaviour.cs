using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssignmentBehaviour : MonoBehaviour
{
    // Reference to the assignment this behaviour belongs to
    private IAssignment m_Context;
    public IAssignment Ctx { get { return m_Context; } set { m_Context = value; }}
    void Start()
    {
        print("Starting text assignment behaviour");
        print($"My name is: {Ctx.Name}");
    }

    void Update()
    {
        //print("Ticking text ass beh");
    }
}