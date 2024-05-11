using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class victoryScreen : MonoBehaviour
{
    public Text pointsText;

    public LevelLoader levelLoader;

    private void Update()
    {
       
    }
    public void Setup(int pontos)
    {
       
        pointsText.text = pontos.ToString() + " POINTS";
    }

    public void NextStage(string nomeCena)
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