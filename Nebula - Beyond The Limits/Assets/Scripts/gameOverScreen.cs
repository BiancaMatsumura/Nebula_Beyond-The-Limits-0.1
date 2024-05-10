using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public LevelLoader levelLoader;
    public void Setup(int pontos)
    {
        gameObject.SetActive(true);
        pointsText.text = pontos.ToString()+ " POINTS";
    }

    public void RestartButton(string nomeCena) 
    {
        Time.timeScale = 1f;
        levelLoader.Transition(nomeCena);
    }

    public void MenuButton(string nomeCena)
    {
        Time.timeScale = 1f;
        levelLoader.Transition(nomeCena);
    }
}
