using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class minibossController : MonoBehaviour
{
    public int vida = 80;    
    public GameObject explosion;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject explosionPrefab;
    public GameObject Reliquia;
    private float fireRate = 4f;
    private float nextFireTime = 0f;
    public SpaceShip player;
    private float fMinX = -10f;
    private float fMaxX = 10f;
    int Direction = -1;
    float fEnemyX = 0;
    public GameObject sprEnemy;

    void Update()
    {   
      switch( Direction )
    {
            case -1:
                // Moving Left
                if( fEnemyX > fMinX )
                {
                    fEnemyX -= 0.05f;
                }
                else
                {
                    // Hit left boundary, change direction
                    Direction = 1;
            
                }
                break;
            case 1:
                // Moving Right
                if( fEnemyX < fMaxX )
                {
                    fEnemyX += 0.05f;
                }
                else
                {
                    // Hit right boundary, change direction
                    Direction = -1;
                }
                break;
        }
 
        sprEnemy.transform.localPosition = new Vector3( fEnemyX , 0.0f , 20.0f );
        
                
        if (Time.time >= nextFireTime)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.tag = "EnemyAttack";


            nextFireTime = Time.time + 1f / fireRate;
        }

    }    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {           
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
            DropReliquia();

            if (FindObjectOfType<SpaceShip>() != null)
            {
                FindObjectOfType<SpaceShip>().EnemyDestroyed();
            }

        }

    }

    void DropReliquia()
    {
        Vector3 position = transform.position;
        GameObject Reliq = Instantiate(Reliquia, position, Quaternion.identity);
    }

}
