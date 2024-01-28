using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleScript : MonoBehaviour
{
    [SerializeField] private GameObject particules;

    void Awake()
    {
        particules.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        particules.SetActive(true);
        Invoke("StopParticules", 0.5f);
    }

    void StopParticules()
    {
        particules.SetActive(false);
    }
}
