using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelectDisplay : DisplayMenuBase
{
    protected override void OnGameStateChanged(GMBaseState state)
    {
        if (state is GMSetSelect)
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

    }

    private void Hide()
    {

    }
}
