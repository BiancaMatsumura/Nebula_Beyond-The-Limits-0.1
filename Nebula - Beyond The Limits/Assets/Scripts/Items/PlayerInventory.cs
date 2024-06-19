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
    
    void Start()
    {

        NumberOfGems = PlayerPrefs.GetInt("ReliquiaN");
    }
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
        OnGemCollected.Invoke(this);
        NumberOfGems++;
        
        
        
    }

        public void GameOver()
        {
             
             pontos.Setup(NumberOfGems);
        }
}