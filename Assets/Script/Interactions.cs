using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Object is takable or not.
    [SerializeField, Range(0, 1)]
    public int canBeTaken;

    public string interactWith = "none";

    [SerializeField, Range(0, 1)]
    public int interactionType = 0; //0 = remove, 1 = combine 

    public GameObject result;

    public void InInventory(Vector3 position, Quaternion rotation)
    {
        if (canBeTaken == 1)
        {
            transform.position = position;
            transform.rotation = rotation;
        }
    }

    public void Interact(GameObject interaction)
    {
        if (interactWith == interaction.name)
        {
            if (interactionType == 0)
            {
                InteractionLibrary.Remove(interaction);
            }
            if (interactionType == 1)
            {
                InteractionLibrary.Combine(result);
                InteractionLibrary.Remove(interaction);
            }
            GameObject.Destroy(gameObject);
        }
    }
}
