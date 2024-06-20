using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerInventory : MonoBehaviour 
{
    public int NumberOfGems  { get; private set; }
    public gameOverScreen gameOverScreen;

    public pontos pontos;

    public UnityEvent<playerInventory> OnGemCollected;
    
    void Start()
    {      
       
        
    }
    void FixedUpdate()
    {   
    
      
    }
    public void GemCollected() 
    {      
        OnGemCollected.Invoke(this);
        ReliquiaData.numeroDReliquia += 1; 

    }

        public void GameOver()
        {
             
             pontos.Setup(NumberOfGems);
        }
}