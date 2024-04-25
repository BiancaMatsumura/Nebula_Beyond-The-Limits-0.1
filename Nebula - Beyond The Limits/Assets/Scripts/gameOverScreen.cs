using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int pontos)
    {
        gameObject.SetActive(true);
        pointsText.text = pontos.ToString()+ " POINTS";
    }

    public void RestartButton() 
    {
        Time.timeScale = 1f;                    
        SceneManager.LoadScene("fase1");
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}
