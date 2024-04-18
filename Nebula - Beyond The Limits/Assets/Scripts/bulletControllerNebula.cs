using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControllerNebula : MonoBehaviour
{
    public float speed = 10f;
    public int dano = 10;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

            Debug.Log("Colisão com inimigo");
        }

        Debug.Log("Colisão");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }





}

