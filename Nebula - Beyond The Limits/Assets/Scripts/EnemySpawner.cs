using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy ;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 20)
        {
            xPos = Random.Range(-16, 13);
            zPos = Random.Range(19, 19);
            Instantiate(theEnemy, new Vector3 (xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount += 1;
        }
    }
}