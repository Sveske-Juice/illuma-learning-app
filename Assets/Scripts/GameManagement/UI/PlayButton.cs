using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IButton
{
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
