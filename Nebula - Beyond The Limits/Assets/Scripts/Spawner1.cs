using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public float range;
    public float interval;
    private float counter = 0;

    private int spawnedEnemiesCount = 0;

    public GameObject explosion;
    public GameObject enemyPrefab; 
    public SpaceShip player;
    public AudioSource audioSource;
    public AudioSource audioPlayer;
    public AudioSource audioPlayer2;
    public int maxEnemies;

    void Update()
    {
        if (spawnedEnemiesCount < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        counter += Time.deltaTime;
        if (counter > interval)
        {
            GameObject spawnedObject = Instantiate(enemyPrefab,
                new Vector3(transform.position.x + Random.Range(-range, range),
                            transform.position.y,
                            transform.position.z),
                transform.rotation);

            EnemyController1 enemyController = spawnedObject.GetComponent<EnemyController1>(); 
            enemyController.explosion = explosion;
             
            counter = 0;
            spawnedEnemiesCount++;
        }
    }
}


