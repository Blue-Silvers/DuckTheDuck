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
        player.inventory = combined;
        player.inventoryInteractions = combined.GetComponent<Interactions>();
    }

    public static void Animate(GameObject interactable, GameObject result)
    {
        Debug.Log("Animate: " + interactable.name + " and " + result.name);
        if (interactable != null) 
        { 
            Animation intAnim = interactable.GetComponent<Animation>();
            intAnim.Play(intAnim.clip.name);
        }
        Animation resAnim = result.GetComponent<Animation>();
        resAnim.Play(resAnim.clip.name);
    }
}
