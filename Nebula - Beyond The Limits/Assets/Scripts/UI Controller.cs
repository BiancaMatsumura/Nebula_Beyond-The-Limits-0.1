using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenuPanel;
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
    }

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
