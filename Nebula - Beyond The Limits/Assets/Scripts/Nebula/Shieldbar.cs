using UnityEngine;
using UnityEngine.UI;

public class Shieldbar : MonoBehaviour
{
    public float escudo = 10;


    public float Escudo { get { return escudo; } set { escudo = Mathf.Clamp(value, 0, escudoMax); } }


    public float escudoMax = 50;

    public Image shieldbar;


    private void Start()
    {
        escudo = escudoMax;
    }

    private void Update()
    {
        UpdateShieldbar();
    }

    private void UpdateShieldbar()
    {
        shieldbar.fillAmount = escudo / escudoMax;
    }


}
