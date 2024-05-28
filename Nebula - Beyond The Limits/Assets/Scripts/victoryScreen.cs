using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class victoryScreen : MonoBehaviour
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