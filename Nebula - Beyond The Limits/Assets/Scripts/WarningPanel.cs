using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    public float tempoTotal;

    public float tempoAparecerPainel;

    private bool painelAtivado = false;

    public GameObject warningPanel;

    public AudioSource somAlarme;

    void Start()
    {

    } 
    void Update()
    {

        tempoTotal -= Time.deltaTime;

        
        if (tempoTotal <= tempoAparecerPainel - 3f)
        {
            
            warningPanel.SetActive(false);
            somAlarme.Stop();
        }

       
        if (tempoTotal <= tempoAparecerPainel && !painelAtivado)
        {
            
            warningPanel.SetActive(true);
            somAlarme.Play();
           
            painelAtivado = true;
        }

    }
}
