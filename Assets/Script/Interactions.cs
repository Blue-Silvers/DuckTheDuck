using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Object is takable or not.
    [SerializeField, Range(0, 1)]
    public int canBeTaken;

    public string interactWith;

    public void InInventory(Vector3 position, Quaternion rotation)
    {
        if (canBeTaken == 1)
        {
            transform.position = position;
            transform.rotation = rotation;
        }
    }

    public void Interact(string interaction)
    {
        if  (interaction == interactWith)
        {
             Debug.Log("Interacted");
        }
    }
}
