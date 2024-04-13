using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _initialHealth;
    [SerializeField] private GameObject _explosion;

    [SerializeField] private Healthbar _healthbar;
    private float _currentHealth;


    private void Awake() {
        _currentHealth = _initialHealth;

        _healthbar.UpdateHealthbar(_initialHealth,_currentHealth);
    }

    public void ApplyDamage(float damage) {
        if(_currentHealth <= 0) return;

        _currentHealth -= damage;
        _healthbar.UpdateHealthbar(_initialHealth,_currentHealth);   
         
        if(_currentHealth <= 0) {
            Destruct();
        }


    }

    private void Destruct() {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}