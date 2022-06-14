using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseUi;
    public GameObject settingUi;

    public void Pause()
    {
        pauseUi.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("PAUSED");
    }

    public void ResumeGame()
    {
        pauseUi.SetActive(false);
        Time.timeScale = 1;
    }

    public void BacktoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void gosettingmenu()
    {
        pauseUi.SetActive(false);
        settingUi.SetActive(true);
    }

    public void back()
    {
        settingUi.SetActive(false);
        pauseUi.SetActive(true);
    }
}