using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour 
{
    public int NumberOfGems { get; private set; }
    public gameOverScreen gameOverScreen;

    public pontos pontos;

    public UnityEvent<playerInventory> OnGemCollected;

    public void GemCollected() 
    {
        NumberOfGems++;
        OnGemCollected.Invoke(this);
    }

        public void GameOver()
        {
             gameOverScreen.Setup(NumberOfGems);
             pontos.Setup(NumberOfGems);
        }
}