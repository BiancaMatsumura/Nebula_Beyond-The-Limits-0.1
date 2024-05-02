using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEscudo : MonoBehaviour
{

    public int quantidadeEscudo = 5;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            SpaceShip spaceShip = other.GetComponent<SpaceShip>();

            if (spaceShip != null) 
            {                
                spaceShip.escudo += quantidadeEscudo;
                
                spaceShip.escudo = Mathf.Min(spaceShip.escudo, 50);

               
                if (spaceShip.shieldbar != null)
                    spaceShip.shieldbar.escudo = spaceShip.escudo;


            }

            Destroy(gameObject);

        }
    }
}
