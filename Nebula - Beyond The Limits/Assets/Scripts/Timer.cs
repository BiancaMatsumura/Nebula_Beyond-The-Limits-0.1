using System.Collections;
using System.Collections.Generic;
using System.Transactions;
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

    private bool started = false;

    private void Start()
    {
        tempoTotal.GetComponent<WarningPanel>().tempoTotal = tempoLevel;
        tempoTotal.GetComponent<WarningPanel>().tempoAparecerPainel = warningAtivar;
        StartTimer();
       
    }

    void Update()
    {
        if(started)
        {
            tempoLevel -= Time.deltaTime;
            UpdateTime();

            if (tempoLevel <= warningAtivar)
            {
                timerText.color = Color.red;

            }
            if (tempoLevel<=0)
            {
                GameOver();
            }
        }

    }

    public void StartTimer()
    {
        started = true;
    }

    public void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(tempoLevel / 60);
        int seconds = Mathf.FloorToInt(tempoLevel % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        tempoLevel = 0;
        UpdateTime();
        started = false;
        victoryPanel.SetActive(true);
        victorySom.Play();
        Time.timeScale = 0;

    }
}

