using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public float tempoLevel;
    public GameObject VictoryBackground;
    public Text timerText;
    public GameObject tempoTotal;
    

    private void Start()
    {
        tempoTotal.GetComponent<WarningPanel>().tempoTotal = tempoLevel;
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

        if (tempoLevel <= 89)
        {
            timerText.color = Color.red;
            
        }
        if (tempoLevel == 0)
        {
            Time.timeScale = 0f;
            VictoryBackground.SetActive(true);            
        }

        int minutes = Mathf.FloorToInt(tempoLevel / 60);
        int seconds = Mathf.FloorToInt(tempoLevel % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

