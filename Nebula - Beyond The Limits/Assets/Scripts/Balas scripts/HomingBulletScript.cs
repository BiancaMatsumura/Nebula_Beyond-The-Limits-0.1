using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HomingBulletScript : MonoBehaviour
    {
    public float speed= 5f;
    public Transform nebulTarget;
    private Transform playerTransform;
    public float destructionDelay=5f;
    public SpaceShip spaceShip;
    public int damage;

  
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(DestroyAfterDelay(destructionDelay));
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    
        spaceShip=GetComponent<SpaceShip>();

    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 0.4){
            Destroy(gameObject);
        }
    
       
        if (playerTransform != null)
        {            
            transform.LookAt(playerTransform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
             transform.position= Vector3.MoveTowards(transform.position,playerTransform.position,speed*Time.deltaTime);
        }
        

    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    

    
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
          
        }
    }


}

    


