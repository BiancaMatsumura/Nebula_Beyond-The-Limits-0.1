 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float destructionDelay = 1.0f;
    private Animator laserAnimation;
    private Transform laserpoint;
    private Transform playerTransform;
    public float speed;
    private SpaceShip spaceShip;
    public int damage;
    public void SetFirePoint(Transform firePoint)
    {
        laserpoint = firePoint;
    }
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
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
        
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          Destroy(gameObject, destructionDelay);

        }

    }

    public void StartLaser()
    {
        laserAnimation.SetBool("startLaser", true);
    }


}
