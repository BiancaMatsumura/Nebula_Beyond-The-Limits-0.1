using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
{

    gameObject.SetActive(true);
    pointsText.text = score.ToString()+ " POINTS";
}

    public void RestartButton() 
    {
        SceneManager.LoadScene("fase1");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("menu");
    }
}
