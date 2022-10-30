using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour, IButton
{
    public void OnClick()
    {
        GameManager.Instance.CommandHandler.UndoCommand();
        GameManager.Instance.CommandHandler.ExecuteCommand();
    }
}
