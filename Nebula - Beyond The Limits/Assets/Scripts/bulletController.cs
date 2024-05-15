  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public SpaceShip spaceShip;


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

       
    }




}

