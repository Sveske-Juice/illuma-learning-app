using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME should derive from dislpay menu base 
// but to lazy to change display menu base
public class IncorrectAnswerMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_Menu;

    private void OnEnable()
    {
        Debug.LogWarning("Subbed");
        AssignmentBaseBehaviour.OnIncorrectAnswer += ShowMenu;
    }

    private void OnDisable()
    {
        AssignmentBaseBehaviour.OnIncorrectAnswer -= ShowMenu;
    }

    private void ShowMenu()
    {
        Debug.Log("SHowing menu");
        StartCoroutine(DisplayMenu());
    }
    private IEnumerator DisplayMenu()
    {
        
        m_Menu.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        m_Menu.SetActive(false);
    }
}
