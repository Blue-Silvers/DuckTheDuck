using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Object is takeable or not.
    [SerializeField, Range(0, 1)]
    public int canBeTaken;

    public GameObject interactWith;

<<<<<<< Updated upstream
    [SerializeField, Range(0, 1)]
    public int interactionType = 0; //0 = remove, 1 = combine 

    public GameObject result;
=======
    [SerializeField, Range(0, 10)]
    public int interactionType = 0; //0 = remove, 1 = combine , 2 = AnimationPlayer, 3 = ThrowingInteractions(animation), 

    public GameObject result;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
>>>>>>> Stashed changes

    private void Update()
    {
        if ( transform.position.y < -50)
        {
            GameObject LaF = GameObject.Find("LostAndFound");
            transform.position = LaF.transform.position;
        }
    }

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
        if (interactWith == interaction)
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
<<<<<<< Updated upstream
=======
        if (interactionType == 2)
        {
            InteractionLibrary.Animate(interaction, result);
        }
>>>>>>> Stashed changes
    }
}
