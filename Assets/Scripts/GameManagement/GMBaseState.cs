using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for every game state behaviour. Every game state
///  behaviour will derive from this base class and do its logic.
/// </summary>
public abstract class GMBaseState
{
    /// <summary>
    /// Gets called when the state this method
    /// belongs to gets activated.
    /// </summary>
    public virtual void Enter()
    {
        Debug.Log($"Entered new state: {GameManager.Instance.CurrentGameState}");
    }

    /// <summary>
    /// Gets called every frame while the state this 
    /// method belongs to is active.
    /// </summary>
    public virtual void Tick()
    {

    }

    /// <summary>
    /// Gets called when the state this method
    /// belongs to gets deactivated.
    /// </summary>
    public virtual void Exit()
    {
        Debug.Log($"Exited state: {GameManager.Instance.CurrentGameState}");
    }

    /// <summary>
    /// Checks if the current state should switch to a
    /// different state. Calling this method depends on
    /// the implementation in the state. Often it will
    /// get called in the active state's Tick().
    /// </summary>
    protected virtual void CheckSwitchState()
    {

    }
}
