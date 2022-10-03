using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssignment : Assignment
{
    public TextAssignment(string name)
    {
        Name = name;
        Debug.Log($"Created text assignment: {Name}");
    }
    public TextAssignment()
    {
        Name = "Assignment";
    }

    public void Start()
    {
        Debug.Log($"Starting text assignment: {Name}");
        // Create Behavior class
        
    }

    public void Tick()
    {
        Debug.Log($"Ticking {Name}");
    }

    public void Exit()
    {
        Debug.Log($"Exiting text assignment: {Name}");
    }
}
