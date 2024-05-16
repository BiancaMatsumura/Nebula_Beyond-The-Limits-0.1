using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class minibossController : MonoBehaviour
{
    public int vida = 80;    
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
    public GameObject homingBulletPrefab;
    public GameObject lazerPrefab;
    private float fireChose;
    public AudioSource levelUpSom;
    public GameObject victoryPanel;
    public DialogController dialogController;


    void Update()
    {   
      switch(fireChose)
      {
        case 1:
        TiroNormal();
        break;
        case 2:
        TiroTeleguiado();
        break;
        case 3:
        TiroLazer();
        break; 
      }

      
      switch( Direction )
      {
            case -1:
                
                if( fEnemyX > fMinX )
                {
                    fEnemyX -= 0.025f;
                }
                else
                {
                    
                    Direction = 1;
            
                }
                break;
            case 1:
                
                if( fEnemyX < fMaxX )
                {
                    fEnemyX += 0.025f;
                }
                else
                {
                    
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
    void FixedUpdate()
    {
        fireChose=Random.Range(0,4);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {           
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        vida -= damageAmount;
        

        if (vida <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
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
        Reliq.GetComponent<ReliquiaController>().dialogController = dialogController;
        Reliq.GetComponent<ReliquiaController>().levelUpSom = levelUpSom;
        Reliq.GetComponent<ReliquiaController>().victoryPanel = victoryPanel;
    }
    
    void TiroNormal()
    {
        if (Time.time >= nextFireTime)
        {

            GameObject LazerPrefab = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletPrefab.tag = "EnemyAttack";
            nextFireTime = Time.time + 1f / fireRate;
        }
    
    
    }

    void TiroTeleguiado()
    {
         if (Time.time >= nextFireTime)
         {

            GameObject LazerPrefab = Instantiate(homingBulletPrefab, firePoint.position, firePoint.rotation);
            homingBulletPrefab.tag = "EnemyAttack";
            nextFireTime = Time.time + 1f / fireRate;
         } 

    }
    
    void TiroLazer()
    {
        if (Time.time >= nextFireTime)
        {

            GameObject LazerPrefab = Instantiate(lazerPrefab, firePoint.position, firePoint.rotation);
            LazerPrefab.tag = "EnemyAttack";
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

}
