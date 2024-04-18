using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCura : MonoBehaviour
{

    public int quantidadeCura = 5;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            SpaceShip spaceShip = other.GetComponent<SpaceShip>();

            if (spaceShip != null) 
            {
                
                spaceShip.vida += quantidadeCura;
                
                spaceShip.vida = Mathf.Min(spaceShip.vida, 50);

                
                if (spaceShip.healthbar != null)
                    spaceShip.healthbar.Health = spaceShip.vida;


            }

            Destroy(gameObject);

        }
    }
}
