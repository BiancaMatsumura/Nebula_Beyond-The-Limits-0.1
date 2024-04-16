using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour 
{
    public int NumberOfGems { get; private set; }
    [SerializeField] private GameObject PauseMenuPanel;

    

    public UnityEvent<playerInventory> OnGemCollected;

    public void GemCollected() 
    {
        NumberOfGems++;
        OnGemCollected.Invoke(this);
    }


}