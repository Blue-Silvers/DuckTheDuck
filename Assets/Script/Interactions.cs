using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Object is takeable or not.
    [SerializeField, Range(0, 1)]
    public int canBeTaken;
    public GameObject hasToInteractWith;

    [SerializeField, Range(0, 5)]
    public int interactionType = 0; //0 = remove, 1 = combine , 2 = AnimationPlayer, 

    public GameObject result;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ( transform.position.y < -50)
        {
            GameObject LaF = GameObject.Find("LostAndFound");
            transform.position = LaF.transform.position;
            Debug.Log("Lost and Founded");
            rb.velocity = (Vector3.zero);
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
        if (hasToInteractWith.name == interaction.name)
        {
            if (interactionType == 0)
            {
                Debug.Log("Removing ");
                InteractionLibrary.Remove(gameObject);
                Interactions redo = interaction.GetComponent<Interactions>();
                redo.Interact(redo.hasToInteractWith);
            }
            else if (interactionType == 1)
            {
                Debug.Log("Combining ");
                InteractionLibrary.Combine(result);
                InteractionLibrary.Remove(interaction);
                InteractionLibrary.Remove(gameObject);
            }
            if (interactionType == 2)
            {
                Debug.Log("Animating ");
                InteractionLibrary.Animate(interaction, result);
            }
        }
    }
}
