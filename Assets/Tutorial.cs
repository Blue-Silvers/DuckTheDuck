using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tuto;
    void Start()
    {
        tuto.SetActive(true);
        Invoke("disableTutorial", 60f);
    }

    void disableTutorial()
    {
        tuto.SetActive(false);
    }
}
