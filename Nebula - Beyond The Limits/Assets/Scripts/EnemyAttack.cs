using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAt : MonoBehaviour
{
    public float attackRange = 3f; // Dist�ncia m�nima para ataque
    public int damage = 10; // Dano do ataque

    public void Attack()
    {
        // L�gica de ataque aqui
        Debug.Log("Enemy attacks!");
    }
}
