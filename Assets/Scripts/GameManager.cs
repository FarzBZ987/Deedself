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

    private bool isPaused;
    private string lastButtonChoice;
    //public string neutralChoiceText;
    public Text finalText;
    private bool alreadyOpenFinalMessage = false;
    
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
    }
    void Start()
    {
        alreadyOpenFinalMessage = false;
        
    }

    public void selectedChoiceButton(string choice)
    {
        if (!isPaused)
        {
            setAnimTrigger(choice);
            lastButtonChoice = choice;
            hideChoicePanel();
        }
        
    }

    //from here for localization
    public void LocalizeGood()
    {

        finalText.text = LocalizationManager.Localize(goodChoiceKey);

    }

    public void LocalizeBad()
    {

        finalText.text = LocalizationManager.Localize(badChoiceKey);

    }
    //until here

    public void pauseGame()
    {
        isPaused = true;
    }
    public void unpauseGame()
    {
        isPaused = false;
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
                        LocalizeGood();
                        //finalText.text = goodChoiceKey;
                        break;
                    //case "neutral":
                        //finalText.text = neutralChoiceText;
                        //break;
                    case "bad":
                        LocalizeBad();
                        //finalText.text = badChoiceKey;
                        break;

                    default:
                        break;
                }
            }
        }
        if (SceneDataBringer.instance != null)
        {
            int currentLevel;
            int currentPart;
            currentLevel = SceneDataBringer.instance.getLevelInt();
            currentPart = SceneDataBringer.instance.getPartInt();
            if (GameData.instance != null)
            {
                if (currentLevel == 8 && currentPart == 1)
                {
                    GameData.instance.SaveCurrentData(1, 2);
                }
                else
                {
                    GameData.instance.SaveCurrentData(currentLevel + 1, currentPart);
                }
            }
        }
        else
        {
            Debug.Log("SceneDataBringer Not Found");
        }
    }

    public void hideChoicePanel()
    {
        choicePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        if (alreadyOpenFinalMessage)
        {
            if(SceneDataBringer.instance != null)
            {
                int currentLevel;
                int currentPart;
                currentLevel = SceneDataBringer.instance.getLevelInt();
                currentPart = SceneDataBringer.instance.getPartInt();
                if(GameData.instance != null)
                {
                    if (currentLevel == 8 && currentPart == 1)
                    {
                        GameData.instance.SaveCurrentData(1, 2);
                    }
                    else
                    {
                        GameData.instance.SaveCurrentData(currentLevel + 1, currentPart);
                    }
                }
            }
        }
        SceneManager.LoadScene("MainMenu");
    }
    public void showChoicePanel(){
        choicePanel.SetActive(true);
        
    }
    public void showFinalPanel()
    {
        alreadyOpenFinalMessage = true;
        finalPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void restartGame()
    {
        if(SceneDataBringer.instance != null)
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
            //GameData.instance.SaveCurrentData(SceneDataBringer.instance.getLevelInt(), SceneDataBringer.instance.getPartInt());
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
        GameData.instance.SaveCurrentData(SceneDataBringer.instance.getLevelInt()+1, SceneDataBringer.instance.getPartInt());
    }
    public void addScorePart2()
    {
        if (lastButtonChoice == "good")
        {
            GameData.instance.ch2ScoreGood++;
        }
        else if (lastButtonChoice == "bad") 
        {
            GameData.instance.ch2ScoreBad++;
        }
        GameData.instance.SaveCurrentData(SceneDataBringer.instance.getLevelInt()+1, SceneDataBringer.instance.getPartInt());
    }
    public void addScorePart3()
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
