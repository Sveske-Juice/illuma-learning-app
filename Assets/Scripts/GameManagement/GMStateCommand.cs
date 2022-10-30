using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: as for the new(), see https://stackoverflow.com/questions/14696904/cannot-create-an-instance-of-the-variable-type-item-because-it-does-not-have-t
public class GMStateCommand<TState> : ICommand where TState : GMBaseState, new()
{
    public void Execute()
    {
        Debug.Log($"Executing GM state command with type {typeof(TState).FullName}");
        GameManager.Instance.SwitchState(new TState());
    }

    public void Undo()
    {
        Debug.Log($"Undoing GM state command with type {typeof(TState).FullName}");
    }
}
