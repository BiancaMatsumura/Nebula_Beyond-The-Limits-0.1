using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    [SerializeField] public GameObject explosion;
    public AudioSource DanoNave;
    public AudioSource Laser;

    public int vida = 50;

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float moveDistance = 10f; // Distância que o inimigo vai percorrer

    [Header("Laser")]
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    public int laserDamage = 10; // Quantidade de dano causado pelo laser

    private LineRenderer laserLine;
    private GameObject player; // Referência para o jogador
    private Vector3 initialPosition;
    private bool movingForward = true;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player"); // Encontrar o jogador pelo tag
        laserLine.enabled = false; // Desativa o laser no início
        initialPosition = transform.position;
    }

    void Start()
    {
        InvokeRepeating("FireRaycast", 0, fireRate);
        StartCoroutine(MoveEnemy());
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

    void FireRaycast()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized; // Calcula a direção do jogador em relação à posição atual
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, gunRange))
            {
                laserLine.SetPosition(0, transform.position); // Define a posição inicial do laser como a posição do objeto atual (provavelmente a arma)
                if (hit.collider != null && hit.point != Vector3.zero)
                {
                    laserLine.SetPosition(1, hit.point);
                    if (hit.collider.CompareTag("Player")) // Verifica se o objeto atingido é o jogador
                    {
                        SpaceShip playerScript = hit.collider.GetComponent<SpaceShip>(); // Obtém o script do jogador
                        if (playerScript != null)
                        {
                            playerScript.TakeDamage(laserDamage); // Causa dano ao jogador
                        }
                    }
                }
                Laser.Play();
            }
            else
            {
                laserLine.SetPosition(0, transform.position);
                laserLine.SetPosition(1, transform.position + direction * gunRange);
            }
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            DanoNave.Play();
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

            if (FindObjectOfType<SpaceShip>() != null)
            {
                FindObjectOfType<SpaceShip>().EnemyDestroyed();
            }

        }

    }



}
