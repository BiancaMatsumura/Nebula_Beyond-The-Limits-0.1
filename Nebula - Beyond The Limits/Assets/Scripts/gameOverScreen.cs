using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public SpaceShip player;
    public int pontos;
    public LevelLoader levelLoader;


    private void Update()
    {
        pontos = player.pontos;
        pointsText.text = pontos.ToString() + " POINTS";
    }


}
