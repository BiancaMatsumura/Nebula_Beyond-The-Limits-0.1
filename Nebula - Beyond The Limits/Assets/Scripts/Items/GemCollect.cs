using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {

        playerInventory playerInventory= other.GetComponent<playerInventory>();

        if (playerInventory != null) 
        {  
            playerInventory.GemCollected();
            gameObject.SetActive(false);
        }
    }
}
