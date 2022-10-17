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

    private void Display()
    {
        Menu.SetActive(true);
    }

    private void Hide()
    {
        Menu.SetActive(false);
    }
}
