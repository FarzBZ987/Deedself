using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject levelMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
        levelMenu.SetActive(false);
    }

    public void gosettingmenu()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void golevelmenu()
    {
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void backToMenu()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
        settingMenu.SetActive(false);
        Debug.Log("Kembali");
    }

    public void continueGame()
    {
    }

    public void startGame()
    {
        SceneManager.LoadScene("NewGame");
    }

    public void exitgame()
    {
        Application.Quit();
    }

    public void setResolution1920()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void setResolution1280()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen = false);
    }
}