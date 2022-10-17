using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentSelectDisplay : DisplayMenuBase
{
    protected override void OnGameStateChanged(GMBaseState state)
    {
        if (state is GMAssignmentSelect)
        {
            Display();
        }
        else
        {
            Hide();
        }
    }

    protected override void Display()
    {
        base.Display();
    }

    protected override void Hide()
    {
        base.Hide();
    }
}
