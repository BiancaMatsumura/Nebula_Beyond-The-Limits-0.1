using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public float tempoLevel;
    public float warningAtivar;

    public Text timerText;

    public GameObject tempoTotal;
    public GameObject VictoryBackground;


    private void Start()
    {
        tempoTotal.GetComponent<WarningPanel>().tempoTotal = tempoLevel;
        tempoTotal.GetComponent<WarningPanel>().tempoAparecerPainel = warningAtivar;
       
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

        if (tempoLevel <= warningAtivar)
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

