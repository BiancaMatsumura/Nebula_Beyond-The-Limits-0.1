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
        if (PlayerPrefs.HasKey("ReliquiaN"))
        {
            numeroReliquia = PlayerPrefs.GetInt("ReliquiaN");
        }
        GemCounter.text = numeroReliquia.ToString();
        
    }


}
