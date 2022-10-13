using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSystem : MonoBehaviour
{
    /* Singleton pattern. */
    private static HUDSystem m_Instance;
    public static HUDSystem Instance { get 
    {
        if (m_Instance != null)
            return m_Instance;
        Debug.LogError("HUD System is null"); 
        return null;
    }
    private set
    {
        m_Instance = value;
    }}

    /* Members, */
    [SerializeField] private GameObject m_CategorySelectMenu;

    /* Getters/Setters. */
    public GameObject CategorySelectMenu { get { return m_CategorySelectMenu; } private set { m_CategorySelectMenu = value; } }

    private void Awake()
    {
        Instance = this;
    }
    
    /// <summary>
    /// Shows or hides a menu specified by 'menu'.
    /// </summary>
    /// <param name="menu">The menu object to show or hide. </param>
    /// <param name="state">The state which determines if the menu should
    /// be shown or hidden. True will show the menu, and false will hide. </param>
    public void SetMenuActiveState(GameObject menu, bool state)
    {
        if (menu == null)
            return;
        menu.SetActive(state);
    }
}
