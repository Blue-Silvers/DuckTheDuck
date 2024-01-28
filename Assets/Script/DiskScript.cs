using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskScript : MonoBehaviour
{
    [SerializeField] private AudioSource speaker;
    [SerializeField] private AudioClip[] trackList;
    private int interactions = 0;

    void Start()
    {
        speaker = GetComponent<AudioSource>();
        speaker.PlayOneShot(trackList[interactions],1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            interactions++;
            PlayASong();
        }
    }

    void PlayASong()
    {
        interactions++;
        AudioClip clip = trackList[interactions];
        speaker.PlayOneShot(clip);
    }
}
