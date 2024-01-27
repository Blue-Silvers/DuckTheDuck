using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timmer : MonoBehaviour
{
    [SerializeField] private float timeToEscape = 600f;
    [SerializeField] TextMeshProUGUI timerTxt;


    void Update()
    {
        if(timeToEscape > 11)
        {
            timeToEscape -= Time.deltaTime;
        }
        else if (timeToEscape > 0)
        {
            timerTxt.color = Color.red;
            /*if (timerTxt.color == Color.white)
            {
                timerTxt.color = Color.red;
            }
            else
            {
                timerTxt.color = Color.white;
            }*/
            //Jouer TikTaK
            timeToEscape -= Time.deltaTime;
        }
        else if (timeToEscape <= 0)
        {
            SceneManager.LoadScene("GameOver");
            timeToEscape = 0;
        }

        timerTxt.text = string.Format("{00:00}:{01:00}", Mathf.FloorToInt(timeToEscape/60), Mathf.FloorToInt(timeToEscape % 60));
    }

}
