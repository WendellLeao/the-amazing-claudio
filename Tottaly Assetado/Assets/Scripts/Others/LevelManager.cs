using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PanelPause;

    public AudioSource pressButton;
    public void Pause()
    {
        Time.timeScale = 0;
        PanelPause.SetActive(true);
        pressButton.Play();
    }
    public void Retomar()
    {
        Time.timeScale = 1;
        PanelPause.SetActive(false);
        pressButton.Play();
    }

    public void Menu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        pressButton.Play();
    }
}
