using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 10f;
    public int dano = 10;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            gameObject.GetComponent<vidaJogador>().TakeDamage(dano);

            
            Destroy(gameObject);
        }
        
    }
    
}

