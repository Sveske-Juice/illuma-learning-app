using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME should derive from dislpay menu base 
// but to lazy to change display menu base
// note if i ever come back: maybe use an
// abstract delegate for the event to act on
public class CorrectAnswerMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_Menu;
    [SerializeField] private float m_ShowTime = 1.5f;

    private void OnEnable()
    {
        AssignmentBaseObject.OnCorrectAnswer += ShowMenu;
    }

    private void OnDisable()
    {
        AssignmentBaseObject.OnCorrectAnswer -= ShowMenu;
    }

    private void ShowMenu()
    {
        StartCoroutine(DisplayMenu());
    }
    private IEnumerator DisplayMenu()
    {
        
        m_Menu.SetActive(true);
        yield return new WaitForSecondsRealtime(m_ShowTime);
        m_Menu.SetActive(false);
    }
}
