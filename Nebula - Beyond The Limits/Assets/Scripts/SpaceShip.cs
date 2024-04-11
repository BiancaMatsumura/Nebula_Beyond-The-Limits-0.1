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
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void MoveCharachter()
   {
        direction = new Vector3(horizontal, 0f).normalized;
        controller.Move(direction * movementSpeed * Time.fixedDeltaTime);
   }
}
