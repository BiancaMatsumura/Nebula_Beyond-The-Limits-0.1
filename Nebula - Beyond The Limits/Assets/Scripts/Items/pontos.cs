using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontos : MonoBehaviour
{
    

    public Text pointsText;


    public void Setup(int pontos)
    {

        pointsText.text = pontos.ToString() + " POINTS";

    }
}
