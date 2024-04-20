using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);
    public Transform player;
    public GameObject explosionPrefab;

    private SpaceShip playerSpaceShip;



    private void Start()
    {
        playerSpaceShip = FindObjectOfType<SpaceShip>();

        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {

        while (playerSpaceShip != null && playerSpaceShip.vida > 0)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            
            EnemyController enemyController = enemyObject.GetComponent<EnemyController>();
            enemyController.explosionPrefab = explosionPrefab;

            
            Vector3 directionToPlayer = (player.position - spawnPosition).normalized;

            
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            
            enemyObject.transform.rotation = lookRotation;

            yield return new WaitForSeconds(spawnInterval);
        }

    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x += Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        spawnPosition.z += Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f);
        return spawnPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
