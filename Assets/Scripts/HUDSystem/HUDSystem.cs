using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSystem : MonoBehaviour
{
    /* Members, */
    [SerializeField] private GameObject m_CategorySelectMenu;

    /* Getters/Setters. */
    public GameObject CategorySelectMenu { get { return m_CategorySelectMenu; } private set { m_CategorySelectMenu = value; } }

    public void SetMenuActiveState(GameObject menu, bool state)
    {
        if (menu == null)
            return;
        menu.SetActive(state);
    }
}
