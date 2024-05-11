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
    public GameObject victoryPanel;
    public AudioSource victorySom;

    private bool victoryDisplayed = false;

    private void Start()
    {
        tempoTotal.GetComponent<WarningPanel>().tempoTotal = tempoLevel;
        tempoTotal.GetComponent<WarningPanel>().tempoAparecerPainel = warningAtivar;
       
    }

    void Update()
    {
        tempoLevel -= Time.deltaTime;

        if (!victoryDisplayed && tempoLevel <= 0)
        {
            tempoLevel = 0;
            Time.timeScale = 0f;
            victorySom.Play();
            victoryPanel.SetActive(true);
            victoryDisplayed = true;
        }

        if (tempoLevel <= warningAtivar)
        {
            timerText.color = Color.red;
            
        }
 

        int minutes = Mathf.FloorToInt(tempoLevel / 60);
        int seconds = Mathf.FloorToInt(tempoLevel % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

