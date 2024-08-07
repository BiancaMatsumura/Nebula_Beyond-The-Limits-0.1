using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    [SerializeField] public GameObject explosion;
    public AudioSource DanoNave;
    public AudioSource Laser;
    public GameObject ShieldModel;
    public SpaceShip spaceShip;

    public int vida = 50;
    private int bulletTD;
    private int laserTD;

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float moveDistance = 10f;

    [Header("Laser")]
    public GameObject laserPrefab;
    public Transform laserPoint;
    private float laserLifetime = 3f;

    private GameObject player; 
    private Vector3 initialPosition;
    private bool movingForward = true;
    private GameObject currentLaser;
    private float lastLaserTime;
    private Transform playerTransform;

    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player"); 
        
        initialPosition = transform.position;
        currentLaser = null;
    }

    void Start()
    {        
        if(PlayerPrefs.HasKey("bulletDamage") || PlayerPrefs.HasKey("laserDamage"))
        {
            bulletTD = PlayerPrefs.GetInt("bulletDamage");
            laserTD = PlayerPrefs.GetInt("laserDamage");

        }
        StartCoroutine(MoveEnemy());
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    IEnumerator MoveEnemy()
    {
       
        while (Vector3.Distance(transform.position, initialPosition + transform.forward * moveDistance) > 0.1f)
        {
            if (movingForward)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            yield return null;
        }
        movingForward = false;
    }

    private void Update()
    {
        
        if (currentLaser == null && Time.time - lastLaserTime >= laserLifetime && movingForward == false)
        {         
            if (playerTransform != null)
            {            
            transform.LookAt(playerTransform.position);
            }
            
            currentLaser = Instantiate(laserPrefab, laserPoint.position, laserPoint.rotation);
            
            currentLaser.GetComponent<LaserController>().player = spaceShip;



            lastLaserTime = Time.time;
            Laser.Play();

           
            StartCoroutine(DestroyLaserAfterDelay(currentLaser, laserLifetime));
        }
    }

    IEnumerator DestroyLaserAfterDelay(GameObject laser, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        if (laser != null)
        {
            Destroy(laser);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lazer"))
            {
                TakeDamage(laserTD);
              
            }
        
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            DanoNave.Play();
            TakeDamage(bulletTD);

        }

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            DropShield();
            spaceShip.TakeDamage(10);
            if (currentLaser != null)
            {
                Destroy(currentLaser);
            }
            if (FindObjectOfType<SpaceShip>() != null)
            {
                FindObjectOfType<SpaceShip>().EnemyDestroyed();
            }
            
        }
    }

    private void DropShield()
    {
        Vector3 position = transform.position;
        GameObject Shield = Instantiate(ShieldModel, position, Quaternion.identity);
    }

    public void TakeDamage(int damageAmount)
    {
        vida -= damageAmount;


        if (vida <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            DropShield();
            if (currentLaser != null)
            {
                Destroy(currentLaser);
            }


            if (FindObjectOfType<SpaceShip>() != null)
            {
                FindObjectOfType<SpaceShip>().EnemyDestroyed();
            }

        }

    }



}
