using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCategorySelectState : GMBaseState
{
    public override void Enter()
    {
        base.Enter();

        // Instantiate Category Holder prefabs based on the categories specified in the gamemanager
        for (int i = 0; i < GameManager.Instance.AssignmentCategories.Length; i++)
        {
            GameObject categoryBtn = GameObject.Instantiate( GameManager.Instance.CategoryHolder, GameManager.Instance.CategoryContainer.transform.position, 
                                    Quaternion.identity, GameManager.Instance.CategoryContainer.transform);
            categoryBtn.GetComponentInChildren<CategoryButton>().DisplayCategory = GameManager.Instance.AssignmentCategories[i].DisplayCategory;
        }

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
