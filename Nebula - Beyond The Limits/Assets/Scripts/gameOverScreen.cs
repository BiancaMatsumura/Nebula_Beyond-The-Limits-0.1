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
    Time.timeScale = 0f;
}

    public void RestartButton() 
    {
        SceneManager.LoadScene("fase1");
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }
}
