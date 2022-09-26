using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAssignmentBehaviour
{
    public IAssignment Context { get; set; }
    public void Start();

    public void Tick();

    public void Exit();

    public void SetContext(IAssignment ctx);
}
