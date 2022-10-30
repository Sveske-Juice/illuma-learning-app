using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour, IButton
{
    public void OnClick()
    {
        // FIXME // TODO bad way to check if we should get to 
        // homescreen but no time to make better
        if (GameManager.Instance.CommandHandler.CommandLength <= 1)
        {
            GameManager.GameLoaded = true;
            SceneManager.LoadScene("Homescreen");
            return;
        }
        GameManager.Instance.CommandHandler.UndoCommand();
        GameManager.Instance.CommandHandler.ExecuteCommand();
    }
}
