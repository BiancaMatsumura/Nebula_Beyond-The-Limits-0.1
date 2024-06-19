using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour 
{
    public int NumberOfGems  { get; private set; }
    public gameOverScreen gameOverScreen;

    public pontos pontos;

    public UnityEvent<playerInventory> OnGemCollected;
    
    void Update()
    {
        if(NumberOfGems != 0)
        {
        PlayerPrefs.SetInt("ReliquiaN",NumberOfGems);
        PlayerPrefs.Save();
        }
    }
    public void GemCollected() 
    {      
        NumberOfGems++;
        OnGemCollected.Invoke(this);
        
        
    }

        public void GameOver()
        {
             
             pontos.Setup(NumberOfGems);
        }
}