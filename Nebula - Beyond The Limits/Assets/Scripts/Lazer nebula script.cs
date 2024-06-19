using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Lazernebulascript : MonoBehaviour
{public float destructionDelay = 1.0f;
    public int dano = 5;
    public SpaceShip player;
    private Animator NebulaLazerAnim;
    private float speed =100f;
         private void Start()
    {


        NebulaLazerAnim = GetComponent<Animator>();
        NebulaLazerAnim.SetBool("startLaser", true);

    }

    private void Update()
    {

        GameObject nebula= GameObject.FindGameObjectWithTag("Player");
        if (nebula != null)
        {   
            Vector3 nebulaPOS = nebula.transform.position;
            transform.position = Vector3.MoveTowards(transform.position,nebulaPOS,speed);
            
        }
    } 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject, destructionDelay);
            StopLaser();
            
        }

    }
    
    
    public void StartLaser()
    {
        NebulaLazerAnim.SetBool("startLaser", true);

    }


    public void StopLaser()
    {
        NebulaLazerAnim.SetBool("startLaser", false);
    }
}
