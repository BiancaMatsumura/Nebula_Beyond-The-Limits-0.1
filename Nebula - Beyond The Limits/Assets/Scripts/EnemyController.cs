using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject explosion;

    public int vida = 10;

    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Time.time >= nextFireTime)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


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
    }

    void TakeDamage(int damageAmount)
    {
        vida -= damageAmount;
        

        if (vida <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
          
        }

    }




}
