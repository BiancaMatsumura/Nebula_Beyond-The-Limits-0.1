using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Painéis")]
    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject optionPanel;

    [Header("Slider Audio")]
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Image soundFillImage;
    [SerializeField] private Image musicFillImage;



    [Header("Listas Audio")]
    [SerializeField] private List<AudioSource> soundAudioSources;
    [SerializeField] private List<AudioSource> musicAudioSources;

    private List<float> initialSoundVolumes = new List<float>();
    private List<float> initialMusicVolumes = new List<float>();

    private void Start()
    {
        soundSlider.value = soundSlider.maxValue;
        musicSlider.value = musicSlider.maxValue;

        if (soundAudioSources.Count > 0)
        {
            foreach (AudioSource soundAudioSource in soundAudioSources)
                initialSoundVolumes.Add(soundAudioSource.volume);

            soundSlider.value = initialSoundVolumes[0];
        }

        if (musicAudioSources.Count > 0)
        {
            foreach (AudioSource musicAudioSource in musicAudioSources)
                initialMusicVolumes.Add(musicAudioSource.volume);

            musicSlider.value = initialMusicVolumes[0];
        }

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


    public void SetSoundVolume(float volume)
    {
        SetVolume(soundAudioSources, initialSoundVolumes, volume, soundFillImage);
    }

    public void SetMusicVolume(float volume)
    {
        SetVolume(musicAudioSources, initialMusicVolumes, volume, musicFillImage);
    }

    void SetVolume(List<AudioSource> audioSources, List<float> initialVolumes, float volume, Image fillImage)
    {
        for (int i = 0; i < audioSources.Count; i++)
            audioSources[i].volume = volume * initialVolumes[i];

        fillImage.transform.localScale = new Vector3(volume, 1f, 1f);
    }

    public void ResetVolumes()
    {
        ResetVolume(soundAudioSources, initialSoundVolumes, soundFillImage);
        ResetVolume(musicAudioSources, initialMusicVolumes, musicFillImage);
    }

    void ResetVolume(List<AudioSource> audioSources, List<float> initialVolumes, Image fillImage)
    {
        for (int i = 0; i < audioSources.Count; i++)
            audioSources[i].volume = initialVolumes[i];

        fillImage.transform.localScale = new Vector3(initialVolumes[0], 1f, 1f);
    }

}
