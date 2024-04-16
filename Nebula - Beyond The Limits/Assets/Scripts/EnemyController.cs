using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float nextFireTime = 0f;

    [SerializeField] private float _maxLenght;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Time.time >= nextFireTime)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);



            nextFireTime = Time.time + 1f / fireRate;
        }

    
    }
    
}
