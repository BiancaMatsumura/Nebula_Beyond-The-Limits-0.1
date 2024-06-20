using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    private TextMeshProUGUI GemCounter;
    private int numeroReliquia;


    
    void Start()
    {
        GemCounter = GetComponent<TextMeshProUGUI>();
    }

   void Update()
    {       
        numeroReliquia = ReliquiaData.numeroDReliquia;
        GemCounter.text = numeroReliquia.ToString();
        
    }


}
