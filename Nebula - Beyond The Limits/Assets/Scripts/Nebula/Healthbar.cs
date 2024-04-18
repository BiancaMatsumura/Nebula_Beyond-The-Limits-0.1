using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public float vida = 10;


    public float Health { get { return vida; } set { vida = Mathf.Clamp(value, 0, vidaMaxima); } }


    public float vidaMaxima = 50;

    public Image healthBar;


    private void Start()
    {
        vida = vidaMaxima;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = vida / vidaMaxima;
    }


}
