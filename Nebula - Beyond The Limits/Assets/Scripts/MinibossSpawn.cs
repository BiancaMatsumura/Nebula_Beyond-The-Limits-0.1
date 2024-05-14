using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float tempoTotal;
    public float tempoSpawn; 
    private GameObject objectToDisSpawn;

    void Update()
   {
        tempoTotal -= Time.deltaTime;
        if (tempoTotal <= tempoSpawn) 
        {
            canSpawn();
        }
    }

    void canSpawn()
    {
        Instantiate(objectToSpawn,transform.position,transform.rotation);
    }
}
