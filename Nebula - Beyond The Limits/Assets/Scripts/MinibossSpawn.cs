using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float tempoTotal;
    public float tempoSpawn; 
    private bool Spawned = false;
    public GameObject explosionPrefab;
    public GameObject victoryPanel;
    public AudioSource victorySom;
    public AudioSource levelUpSom;
    public SpaceShip player;
    public DialogController dialogController;

    void Update()
   {
        tempoTotal -= Time.deltaTime;
        if (tempoTotal <= tempoSpawn) 
        {   
            canSpawn();
            Spawned = true;
        }
    }

    void canSpawn()
    {
        objectToSpawn.GetComponent<minibossController>().explosionPrefab = explosionPrefab;
        objectToSpawn.GetComponent<minibossController>().levelUpSom = levelUpSom;
        objectToSpawn.GetComponent<minibossController>().victoryPanel = victoryPanel;
        objectToSpawn.GetComponent<minibossController>().dialogController = dialogController;
        objectToSpawn.GetComponent<minibossController>().player = player;

        if(Spawned == false)
        {
            Instantiate(objectToSpawn,transform.position,transform.rotation);
        }
    }
}          
            