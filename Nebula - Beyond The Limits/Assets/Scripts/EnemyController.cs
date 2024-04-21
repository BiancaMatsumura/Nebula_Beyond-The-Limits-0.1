using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public GameObject explosion;

    public int vida = 10;

    public float speed = 5f;
    public Transform player;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public AudioClip bulletSound;
    public AudioClip dano;

    private void Start()
    {
        
        player = FindClosestPlayer();

        SpaceShip.OnPlayerDestroyed += OnPlayerDestroyed;

    }


    public SpaceShip player;

    void Update()
    {

        
        if (player != null)
        {
            
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }


        if(transform.position.z < 0.4){
            overBoundery();
        }


        if (Time.time >= nextFireTime)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.tag = "EnemyAttack";


            nextFireTime = Time.time + 1f / fireRate;

            audioSource.Play();
        }

    }

    void FireBullet()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        
        bullet.transform.rotation = Quaternion.LookRotation(directionToPlayer);

        
        nextFireTime = Time.time + 1f / fireRate;

       
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            AudioSource.PlayClipAtPoint(dano, transform.position);
            TakeDamage(10);
            Debug.Log("dano ao inimigo");
        }
    }

    void overBoundery(){

        player.TakeDamage(10);
        Destroy(gameObject);
    }

    void TakeDamage(int damageAmount)
    {
                 vida -= damageAmount;


                if (vida <= 0)
                {
            
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);

                    if(FindObjectOfType<SpaceShip>() != null)
                    {
                        FindObjectOfType<SpaceShip>().EnemyDestroyed();
                    }
                    
                }


    }

    private Transform FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Transform closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject playerObj in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerObj.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestPlayer = playerObj.transform;
                closestDistance = distanceToPlayer;
            }
        }

        return closestPlayer;
    }


    void OnDestroy()
    {
        
        SpaceShip.OnPlayerDestroyed -= OnPlayerDestroyed;
    }

    void OnPlayerDestroyed()
    {
        
        Destroy(gameObject);
    }

}
