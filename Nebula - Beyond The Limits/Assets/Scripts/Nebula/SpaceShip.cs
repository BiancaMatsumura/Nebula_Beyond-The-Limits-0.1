using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private CharacterController controller;
    [SerializeField] GameObject explosion;
    private Vector3 direction;

    [Header("Movement Speed")]
    public float movementSpeed = 1f;
    private float horizontal;
    private float vertical;

    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;

    public int vida = 100;

    public GameObject gameOverPanel;

    public GameObject bulletPrefab;
    public Transform firePoint;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        Inputs();

        MoveCharachter();

             if (Input.GetButtonDown("Fire1"))
             {
                  Shoot(); 
             }


    }

        void Inputs()
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        void MoveCharachter()
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            controller.Move(direction * movementSpeed * Time.fixedDeltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                audioPlayer.Play();
            }
            else if (other.gameObject.CompareTag("EnemyAttack"))
            {
                TakeDamage(10);
                Destroy(other.gameObject);

            }
        }

        void TakeDamage(int damageAmount)
        {
            vida -= damageAmount;
            audioPlayer2.Play();

            if (vida <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Die();
            }

        }
        void Die()
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }

    void Shoot() 
    {

        Instantiate(bulletPrefab, transform.position, transform.rotation);

        Debug.Log("Atirei");

    }


   
}





