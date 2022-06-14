using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.SimpleLocalization;

public class GameManager : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject finalPanel;
    public GameObject pausePanel;
    public Animator[] anim;
    public string badChoiceKey;
    public string goodChoiceKey;

    private string lastButtonChoice;
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
        lastButtonChoice = choice;
        
        hideChoicePanel();
    }


    //from here for localization
    public void LocalizeGood(){

        finalText.text = LocalizationManager.Localize(goodChoiceKey);

    }

    public void LocalizeBad(){

        finalText.text = LocalizationManager.Localize(badChoiceKey);

    }
    //until here

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
                        // finalText.text = goodChoiceKey;

                        LocalizeGood();  //for localization

                        break;
                    //case "neutral":
                        //finalText.text = neutralChoiceText;
                        //break;
                    case "bad":
                        // finalText.text = badChoiceKey;

                        LocalizeBad(); //for localization
                        
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
        if(lastButtonChoice == "good")
        {
            if(SceneDataBringer.instance.getPartStringRoman() == "I")
            {
                GameData.instance.ch1ScoreGood--;
            }else if(SceneDataBringer.instance.getPartStringRoman() == "II")
            {
                GameData.instance.ch2ScoreGood--;
            }else if (SceneDataBringer.instance.getPartStringRoman() == "III")
            {
                GameData.instance.ch3ScoreGood--;
            }
        }
        if (lastButtonChoice == "bad")
        {
            if (SceneDataBringer.instance.getPartStringRoman() == "I")
            {
                GameData.instance.ch1ScoreBad--;
            }
            else if (SceneDataBringer.instance.getPartStringRoman() == "II")
            {
                GameData.instance.ch2ScoreBad--;
            }
            else if (SceneDataBringer.instance.getPartStringRoman() == "III")
            {
                GameData.instance.ch3ScoreBad--;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addScorePart1()
    {
        if (lastButtonChoice == "good")
        {
            GameData.instance.ch1ScoreGood++;
        }
        else if (lastButtonChoice == "bad") 
        {
            GameData.instance.ch1ScoreBad++;
        }
    }public void addScorePart2()
    {
        if (lastButtonChoice == "good")
        {
            GameData.instance.ch2ScoreGood++;
        }
        else if (lastButtonChoice == "bad") 
        {
            GameData.instance.ch2ScoreBad++;
        }
    }public void addScorePart3()
    {
        if (lastButtonChoice == "good")
        {
            GameData.instance.ch3ScoreGood++;
        }
        else if (lastButtonChoice == "bad") 
        {
            GameData.instance.ch3ScoreBad++;
        }
    }
}
