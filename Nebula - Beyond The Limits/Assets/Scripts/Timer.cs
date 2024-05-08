using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    [SerializeField] float tempoLevel;


    public Text timerText;


    private void Start()
    {
        
    }

    void Update()
    {
        if (tempoLevel > 0)
        {
            tempoLevel -= Time.deltaTime;
        }
        else if (tempoLevel <= 0)
        {
            tempoLevel = 0;
            
        }

        if (tempoLevel <= 6)
        {
            timerText.color = Color.red;
            
        }

        int minutes = Mathf.FloorToInt(tempoLevel / 60);
        int seconds = Mathf.FloorToInt(tempoLevel % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

