using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static AssignmentSet mult;
    public GameObject assSetHolder;
    public GameObject assLoader;
    public GameObject assHolder;
    public static GameManager Instance { get; set; }
    public static GameObject AssHolder { get { return Instance.assHolder; } set { Instance.assHolder = value; }}

    void Awake()
    {
        print("Starting gm");
        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        IList<IAssignment> multAss = new List<IAssignment>() { new TextAssignment("test text assingment") };
        mult = assSetHolder.AddComponent<AssignmentSet>();
        mult.Init(multAss);
    }
}
