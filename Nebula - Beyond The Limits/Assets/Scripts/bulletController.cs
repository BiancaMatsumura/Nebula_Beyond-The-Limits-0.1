using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 10f;
    public int dano = 10;


    private void Start()
    {

        

    }

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

            Debug.Log("Colisão com inimigo");
        }

        Debug.Log("Colisão");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        direction.z = -direction.z;

        transform.forward = direction;

        Debug.Log("Direção da bala: " + transform.forward);
    }




}

