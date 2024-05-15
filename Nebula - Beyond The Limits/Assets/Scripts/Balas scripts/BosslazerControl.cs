using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BosslazerControl : MonoBehaviour
{
   public float destructionDelay = 0f;
    private Animator laserAnimation;
    private Transform laserpoint;
    private Transform playerTransform;
    private Transform bossMoviment;
    public float speed;
    private SpaceShip spaceShip;
    public int damage;
    public void SetFirePoint(Transform firePoint)
    {
        laserpoint = firePoint;
    }
    private void Start()
    {
        StartCoroutine(DestroyAfterDelay(destructionDelay));
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        GameObject bossobject = GameObject.FindGameObjectWithTag("Enemy");
        if (bossobject != null) 
        {
            bossMoviment = bossobject.transform;
        }


         if (playerTransform != null)
        {            
            transform.LookAt(playerTransform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }   
        laserAnimation = GetComponent<Animator>();
        laserAnimation.SetBool("startLaser", true);
        
    }

    private void Update()
    {
         
        if(bossMoviment!=null)
        {
            transform.position= Vector3.MoveTowards(transform.position,bossMoviment.position,10);
        }
        

    }

    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, destructionDelay);

           
        }

      
    }

    
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
    public void StartLaser()
    {
        laserAnimation.SetBool("startLaser", true);
    }
} 