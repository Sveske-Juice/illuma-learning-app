using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContainerLoader : MonoBehaviour
{
    /// <summary>
    /// Gets called from a derived instance's Load method, 
    /// and will print debug info about what container is being loaded.
    /// </summary>
    /// <param name="containerName">The name of the container being loaded.</param>
    public virtual void Load(string containerName)
    {
        Debug.Log($"Loading element with container named: {containerName}");
    }
}
