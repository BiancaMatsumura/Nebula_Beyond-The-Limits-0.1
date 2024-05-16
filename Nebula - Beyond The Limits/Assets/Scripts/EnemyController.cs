using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     [SerializeField] public AudioSource audioSource;
    [SerializeField] public GameObject explosion;

    public int vida = 10;

    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject GemModel;
    public GameObject explosionPrefab;

    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;

    public SpaceShip player;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.z < 0.4){
            overBoundery();
        }


        if (Time.time >= nextFireTime)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.tag = "EnemyAttack";
            bullet.GetComponent<bulletController>().spaceShip = player;


            nextFireTime = Time.time + 1f / fireRate;

            audioSource.Play();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            audioPlayer2.Play();
            TakeDamage(10);

        }
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            DropGem();
            player.TakeDamage(10);

            if (FindObjectOfType<SpaceShip>() != null)
            {
                FindObjectOfType<SpaceShip>().EnemyDestroyed();
            }

        }
    }

    void overBoundery(){

        player.TakeDamage(10);
        Destroy(gameObject);
    }

    private void DropGem()
    {
        Vector3 position = transform.position;
        GameObject Gem = Instantiate(GemModel, position, Quaternion.identity);
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




}
