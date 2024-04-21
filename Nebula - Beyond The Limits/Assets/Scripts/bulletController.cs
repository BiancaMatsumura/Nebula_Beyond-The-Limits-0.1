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
        if(transform.position.z < 0.4){
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

            Debug.Log("Colisï¿½o com inimigo");
        }

        Debug.Log("Colisï¿½o");
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

