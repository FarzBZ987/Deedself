using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject finalPanel;
    public GameObject pausePanel;
    public Animator[] anim;
    public string badChoiceText;
    public string goodChoiceText;
    //public string neutralChoiceText;
    public Text finalText;

    
    public static GameManager instance;

    

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        hideChoicePanel();
        finalPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
    void Start()
    {
        
    }

    public void selectedChoiceButton(string choice)
    {
        setAnimTrigger(choice);
        
        hideChoicePanel();
    }

    private void setAnimTrigger(string choice)
    {
        if(anim.Length > 0) {
            
            for (int i = 0; i < anim.Length; i++)
            {
                //Debug.Log(i.ToString());
                anim[i].SetTrigger(choice);
                switch (choice)
                {
                    case "good":
                        finalText.text = goodChoiceText;
                        break;
                    //case "neutral":
                        //finalText.text = neutralChoiceText;
                        //break;
                    case "bad":
                        finalText.text = badChoiceText;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public void hideChoicePanel()
    {
        choicePanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        
    }

    public void Resume()
    {
        
        pausePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    public void showChoicePanel(){
        choicePanel.SetActive(true);
        
    }
    public void showFinalPanel()
    {
        finalPanel.SetActive(true);
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
