using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{

    public int vida = 10;
    public float speed = 5f;
    public int damageAmount = 10;

    [SerializeField] public GameObject explosion;

    public AudioSource DanoNave;

    private Transform playerTransform;
    public GameObject GemModel;

    void Start()
    {
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    void Update()
    {
        
        if (playerTransform != null)
        {            
            transform.LookAt(playerTransform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpaceShip player = other.gameObject.GetComponent<SpaceShip>();

            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("PlayerAttack"))
        {
            if (DanoNave != null)
            {
                DanoNave.Play();
            }

            TakeDamage(10);
        }

    }

    void TakeDamage(int damageAmount)
    {
        vida -= damageAmount;


        if (vida <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            DropGem();
           

            if (FindObjectOfType<SpaceShip>() != null)
            {
                FindObjectOfType<SpaceShip>().EnemyDestroyed();
            }

        }

    }

    private void DropGem()
    {
        Vector3 position = transform.position;
        GameObject Gem = Instantiate(GemModel, position, Quaternion.identity);
    }

}
     
