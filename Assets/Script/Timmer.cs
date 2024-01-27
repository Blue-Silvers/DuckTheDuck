using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timmer : MonoBehaviour
{
    [SerializeField] private float timeToEscape = 600f;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if(timeToEscape > 10)
        {
            timeToEscape -= Time.deltaTime;
        }
        else if (timeToEscape > 0)
        {
            if(timerTxt.color == Color.white)
            {
                timerTxt.color = Color.red;
            }
            else
            {
                timerTxt.color = Color.white;
            }
            //Jouer TikTaK
            timeToEscape -= Time.deltaTime;
        }
        else if (timeToEscape <= 0)
        {
            gameOverScreen.SetActive(true);
            timeToEscape = 0;
        }

        timerTxt.text = string.Format("{00:00}:{01:00}", Mathf.FloorToInt(timeToEscape/60), Mathf.FloorToInt(timeToEscape % 60));
    }

}
