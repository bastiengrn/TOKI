using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaineMenu : MonoBehaviour
{
    public string SampleScene;
    
    public GameObject SettingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        SettingsWindow.SetActive(false);
    }

    public void QuiteGame()
    {
        Application.Quit();
        
    }
}
