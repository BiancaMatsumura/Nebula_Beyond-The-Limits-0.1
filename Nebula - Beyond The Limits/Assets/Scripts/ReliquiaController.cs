using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliquiaController : MonoBehaviour
{
    public DialogController dialogController;
    public AudioSource levelUpSom;
    public GameObject victoryPanel;

    private void Start()
    {
       
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            levelUpSom.Play();
            
            Destroy(gameObject);
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }


    }
}
