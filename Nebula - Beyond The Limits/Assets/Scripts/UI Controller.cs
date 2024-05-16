using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Painéis")]
    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject optionPanel;
    public LevelLoader levelLoader;

    [Header("Slider Audio")]
    public AudioMixer mixer;
    [SerializeField] private Slider FXVol;
    [SerializeField] private Slider musicVol;



    private void Start()
    {
        

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuPanel.activeSelf)
            {
                
                Resume();
            }
            else
            {
                
                Pause();
            }
        }
    }



    public void CarregarCena(string nomeCena) 
    {
        levelLoader.Transition(nomeCena);
        Time.timeScale = 1f;
    }

    public void sairJogo() 
    {       
        Application.Quit();
    }

    public void Restart(string nomeFase)
    {
        levelLoader.Transition(nomeFase);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        optionPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;


    }

    public void Option()
    {
        PauseMenuPanel.SetActive(false);
        optionPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void MusicVolChange()
    {
        mixer.SetFloat("MusicVol", musicVol.value);
    }

    public void FXVolChange()
    {
        mixer.SetFloat("FXVol", FXVol.value);
    }


}
