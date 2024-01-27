using System;
<<<<<<< Updated upstream
=======
using Unity.VisualScripting;
>>>>>>> Stashed changes
using UnityEditor;
using UnityEngine;

public static class InteractionLibrary
{
    public static void Remove(GameObject interactable)
    {
        GameObject.Destroy(interactable);
    }
    public static void Combine(GameObject combined)
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.inventory = combined;
        player.inventoryInteractions = combined.GetComponent<Interactions>();
        combined.transform.localScale = Vector3.one * 0.5f;
    }

<<<<<<< Updated upstream
=======
    public static void Animate(GameObject interactable, GameObject result)
    {
        Debug.Log("Play");
        if (interactable != null) 
        { 
            interactable.GetComponent<Animation>().Play();
        }
        result.GetComponent<Animation>().Play();
    }

>>>>>>> Stashed changes
}
