using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class victoryScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int pontos)
    {   
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        pointsText.text = pontos.ToString() + " POINTS";
    }

    public void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("fase2");
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}