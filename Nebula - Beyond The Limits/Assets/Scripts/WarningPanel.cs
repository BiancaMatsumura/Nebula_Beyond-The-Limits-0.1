using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    public float tempoTotal = 10f;
    public float tempoAparecerPainel = 5f;
    public GameObject warningPanel;
    private bool painelAtivado = false;


    void Start()
    {
        tempoAparecerPainel = tempoTotal - 5f;
    }

    
    void Update()
    {

        tempoTotal -= Time.deltaTime;

        
        if (tempoTotal <= 1f)
        {
            
            warningPanel.SetActive(false);
        }

       
        if (tempoTotal <= 6f && !painelAtivado)
        {
            
            warningPanel.SetActive(true);
           
            painelAtivado = true;
        }
    }
}
