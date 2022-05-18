using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void exitgame()
    {
        Application.Quit();
    }
}