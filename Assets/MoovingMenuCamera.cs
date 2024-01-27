using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingMenuCamera : MonoBehaviour
{
    SpriteRenderer Freezing;
    bool changeFreezing;

    private void Start()
    {
        Freezing = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (changeFreezing == true)
        {
            Freezing.color = new Color(255, 255, 255, Mathf.SmoothStep(Freezing.color.a, 1f, 0.02f));   
            if(Freezing.color.a >= 0.8f)
            {
                changeFreezing = false;
            }
        }
        else if (changeFreezing == false)
        {
            Freezing.color = new Color(255, 255, 255, Mathf.SmoothStep(Freezing.color.a, 0.3f, 0.02f));
            if (Freezing.color.a <= 0.4f)
            {
                changeFreezing = true;
            }
        }

    }
}
