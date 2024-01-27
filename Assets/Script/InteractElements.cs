using System;
using UnityEditor;
using UnityEngine;

public static class InteractionLibrary
{
    public static GameObject[] GOLibrary;
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

}
