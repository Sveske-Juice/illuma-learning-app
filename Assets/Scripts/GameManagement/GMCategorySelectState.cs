using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCategorySelectState : GMBaseState
{
    public override void Enter()
    {
        base.Enter();

        // Show Category Select Menu
        HUDSystem.Instance.SetMenuActiveState(HUDSystem.Instance.CategorySelectMenu, true);
    }
}
