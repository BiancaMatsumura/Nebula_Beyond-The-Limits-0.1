using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliquiaController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

        }


    }
}
