using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    int NumberOfGems = 0;
    public gameOverScreen gameOverScreen;
    [SerializeField] public GameObject PauseMenuPanel;
    public AudioSource audioplayer;
    public void carregaCena(string nomeCena) 
    {
        SceneManager.LoadScene(nomeCena);
        Time.timeScale = 1f;
    }

    public void sairJogo() 
    {       
        Application.Quit();
    }

    public void Restart(string nomeFase)
    {
        SceneManager.LoadScene(nomeFase);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        audioplayer.Play();
    }

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        audioplayer.Stop();
    }


        public void GameOver()
    {
        gameOverScreen.Setup(NumberOfGems);
        Time.timeScale = 0f;
        PauseMenuPanel.SetActive(false); 
    }

}
