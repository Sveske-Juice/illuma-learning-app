using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject assSetHolder;
    public GameObject assLoader;
    public GameObject assHolder;
    public static GameManager Instance { get; set; }
    public static GameObject AssHolder { get { return Instance.assHolder; } set { Instance.assHolder = value; }}

    void Awake()
    {

    }
}
