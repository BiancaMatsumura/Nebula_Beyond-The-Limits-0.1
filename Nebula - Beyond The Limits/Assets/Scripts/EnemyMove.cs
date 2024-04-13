using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Velocidade do inimigo

    void Update()
    {
        // Movimentação básica do inimigo
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
