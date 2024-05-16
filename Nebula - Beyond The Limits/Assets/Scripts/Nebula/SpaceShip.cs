using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [Header("Informaçoes do Player")]
    public int vida = 50;
    public int escudo = 20;
    public float movementSpeed = 1f;
    public int pontos = 0;
 
    public int enemiesDestroyed = 0;
    public float spreadAngle = 15f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Healthbar healthbar;
    public Shieldbar shieldbar;
    public pontos pontosScript;


    [Header("Audios / FX")]
    public AudioSource ItemPickup;
    public AudioSource DanoNave;
    public AudioSource Laser;
    public AudioSource gameOverSom;
    [SerializeField] AudioSource Explosao;
    [SerializeField] GameObject explosion;

    [Header("Paineis")]
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject optionPanel;
    public gameOverScreen gameOverScreen;
    public victoryScreen victoryScreen;
    public DialogController dialogController;


    private playerInventory inventory;
    

    private CharacterController controller;


    private Vector3 direction;

    private float horizontal;

    private float vertical;


    void Start()
    {
        inventory = GetComponent<playerInventory>();
        controller = GetComponent<CharacterController>();
        healthbar = FindObjectOfType<Healthbar>();
        shieldbar = FindObjectOfType<Shieldbar>();

        
    }


    void Update()
    {
        Inputs();

        if (!PauseMenuPanel.activeSelf && !optionPanel.activeSelf && !victoryPanel.activeSelf && Input.GetButtonDown("Fire1"))
        {
            Laser.Play();
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
            ItemPickup.Play();
            

        }
        else if (other.gameObject.CompareTag("EnemyAttack"))
        {
            TakeDamage(5);
            

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
                ItemPickup.Play();
                
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {   
        if(escudo == 0)
        {
            vida -= damageAmount;
             DanoNave.Play();
            healthbar.Health = vida;
            

            if (vida <= 0)
            {
                 Instantiate(explosion, transform.position, Quaternion.identity);
                 Destroy(gameObject);
                  Die();
            }


        }   else if (escudo >= 0)
            {   
                 escudo -= damageAmount;
                 DanoNave.Play();
                 shieldbar.escudo = escudo;
                 dialogController.TriggerDialog(1);
        }
    }
    void Die()
    {
        if (gameOverPanel != null)
        {
            gameOverSom.Play();
            gameOverPanel.SetActive(true);
            gameOverScreen.Setup(pontos);
            Time.timeScale = 0f;
        }



    }

    void Shoot()
    {
        int numberOfGems = inventory.NumberOfGems;

        if (numberOfGems == 1) 
        {
            ShootTripleTriangle();
        }
        else
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        
    }

    public void ShootTripleTriangle()
    {

        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            float rotationAngle = spreadAngle * (i - 1);
            bullet.transform.Rotate(0, rotationAngle, 0);
        }
    }


    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        
        pontos += 100;
        pontosScript.Setup(pontos);
        victoryScreen.Setup(pontos);
        
    }

}






