using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("Options")] 
    public Slider volume;
    public AudioMixer mixer;

    [Header("Panels")] 
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    
    private void Awake()
    {
        // Corrección en el nombre del evento: onValueChanged
        volume.onValueChanged.AddListener(changeVolumen);
    }
    
    public void play(string level)
    {
        SceneManager.LoadScene(level);
    }
    
    public void exit()
    {
        Application.Quit();
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        panel.SetActive(true);
    }
    
    public void changeVolumen(float v)
    {
        mixer.SetFloat("Volume", v);
    }
}
