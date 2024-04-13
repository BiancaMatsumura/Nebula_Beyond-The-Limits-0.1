using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
 [SerializeField] private Image _healthimage;


 public void UpdateHealthbar(float maxHealth, float currentHealth) {

    _healthimage.fillAmount = currentHealth/maxHealth;

 }
}
