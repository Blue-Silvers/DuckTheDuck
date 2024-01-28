using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWaiting : MonoBehaviour
{
    [SerializeField] GameObject button;
    void Start()
    {
        button.SetActive(false);
        Invoke("SpawnButton", 8f);
    }

    public void SpawnButton()
    {
        button.SetActive(true);
    }
}
