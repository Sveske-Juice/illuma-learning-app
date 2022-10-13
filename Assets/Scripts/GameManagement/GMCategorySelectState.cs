using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCategorySelectState : GMBaseState
{
    public override void Enter()
    {
        base.Enter();

        // Instantiate Category Holder prefabs based on the categories specified in the gamemanager
        

        // Show Category Select Menu
        HUDSystem.Instance.SetMenuActiveState(HUDSystem.Instance.CategorySelectMenu, true);
    }

    public override void Exit()
    {
        base.Exit();

        // Hide Category Select Menu
        HUDSystem.Instance.SetMenuActiveState(HUDSystem.Instance.CategorySelectMenu, false);
    }
}
