using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class InteractionLibrary
{
    public static void Remove(GameObject obj)
    {
        Debug.Log("Destroying: " +  obj.name);
        GameObject.Destroy(obj);
    }
    public static void Combine(GameObject combined)
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (combined != null) 
        {
            player.inventory = combined;
            player.inventoryInteractions = combined.GetComponent<Interactions>();
        }
    }

    public static void Animate(GameObject interactable, GameObject result)
    {
        Debug.Log("Play");
        if (interactable != null) 
        { 
            interactable.GetComponent<Animation>().Play();
        }
        result.GetComponent<Animation>().Play();
    }


}
