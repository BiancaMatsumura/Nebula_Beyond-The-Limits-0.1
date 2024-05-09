using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    public float tempoTotal;
    public float tempoAparecerPainel;
    private bool painelAtivado = false;
    public GameObject warningPanel;


    void Start()
    {

    } 
    void Update()
    {

        tempoTotal -= Time.deltaTime;

        
        if (tempoTotal <= 1f)
        {
            
            warningPanel.SetActive(false);
        }

       
        if (tempoTotal <= 31f && !painelAtivado)
        {
            
            warningPanel.SetActive(true);
           
            painelAtivado = true;
        }

    }
}
