using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;

    [Header("Movement Speed")]
    public float movementSpeed = 1f;
    private float horizontal;
    private float vertical;

    public AudioSource audioPlayer;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Inputs();

        MoveCharachter();
        
    }

    void Inputs()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void MoveCharachter()
   {
        direction = new Vector3(horizontal, 0f,vertical).normalized;
        controller.Move(direction * movementSpeed * Time.fixedDeltaTime);
   }

   public void OnTriggerEnter(Collider other) 
   {
        if (other.gameObject.CompareTag("Item")) 
        {
            audioPlayer.Play();
        }
   }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
