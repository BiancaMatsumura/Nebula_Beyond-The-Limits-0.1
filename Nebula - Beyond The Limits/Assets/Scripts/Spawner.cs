using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float range;
    public float interval;
    private float counter = 0;

    private int spawnedEnimiesCount = 0;
    
    public GameObject explosion;

    public GameObject ObjectToSpawn;

    public SpaceShip player;

    public AudioSource audioSource;
    
    public AudioSource audioPlayer;

    public AudioSource audioPlayer2;
    
    public int MaxEnemies;
    

    void Update()
    {
        if(spawnedEnimiesCount <= MaxEnemies){
            canSpawn();
        }       
    }

    void canSpawn(){
        counter += Time.deltaTime;
        if (counter > interval){
            GameObject spawnedObject = Instantiate(ObjectToSpawn, new Vector3(transform.position.x + Random.Range(-range, range),transform.position.y,transform.position.z), transform.rotation);            
            spawnedObject.GetComponent<EnemyController>().explosion = explosion;
            spawnedObject.GetComponent<EnemyController>().player = player;
            spawnedObject.GetComponent<EnemyController>().audioSource = audioSource;
            spawnedObject.GetComponent<EnemyController>().audioPlayer = audioPlayer;
            spawnedObject.GetComponent<EnemyController>().audioPlayer2 = audioPlayer2;
            counter = 0;
            spawnedEnimiesCount++;
        }
    }

}

