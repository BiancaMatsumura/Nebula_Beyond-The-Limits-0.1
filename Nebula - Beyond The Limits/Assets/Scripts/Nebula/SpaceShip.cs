using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private playerInventory inventory;
    private CharacterController controller;
    [SerializeField] GameObject explosion;
    private Vector3 direction;

    [Header("Movement Speed")]
    public float movementSpeed = 1f;
    private float horizontal;
    private float vertical;

    [Header("Audios")]
    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;
    public AudioSource audioPlayer3;
    

    
    public int vida = 100;

    public GameObject gameOverPanel;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public Healthbar healthbar;

    void Start()
    {
        inventory = GetComponent<playerInventory>();
        controller = GetComponent<CharacterController>();
        healthbar = FindObjectOfType<Healthbar>();

    }


    void Update()
    {
         Inputs();
             if (Input.GetButtonDown("Fire1"))
             {  
                audioPlayer3.Play();
                Shoot(); 
             }
    }
    void FixedUpdate()
    {
        MoveCharachter();
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
                   else if (other.gameObject.CompareTag("ItemCura"))
                   {
                          ItemCura itemCura = other.gameObject.GetComponent<ItemCura>();
                         if (itemCura != null)
                         {
                
                              vida += itemCura.quantidadeCura;

                
                                 vida = Mathf.Min(vida, 50);

                
                                if (healthbar != null)
                                 healthbar.Health = vida;

                    
                              Destroy(other.gameObject);
                              audioPlayer.Play();

                         }
                   }
        }

        public void TakeDamage(int damageAmount)
        {
            vida -= damageAmount;
            audioPlayer2.Play();

            if (vida <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Die();
            }

             healthbar.Health = vida;    

        }
        void Die()
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.GetComponent<gameOverScreen>().Setup(inventory.NumberOfGems);
            }
        }

    void Shoot() 
    {

        Instantiate(bulletPrefab, transform.position, transform.rotation);

        Debug.Log("Atirei");

    }


   
}





