using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject finalPanel;
    public Animator anim;
    public string WrongChoiceText;
    public string RightChoiceText;
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
    }
    void Start()
    {
        
    }

  

    public void wrongChoice()
    {
        
    }
    public void rightChoice()
    {
        
    }

    public void selectedChoiceButton([SerializeField] bool isRightChoice)
    {
        if(isRightChoice)
        {
            anim.SetTrigger("Choice1");
            finalText.text = RightChoiceText;
            Time.timeScale = 1;
        }else
        {
            anim.SetTrigger("Choice2");
            finalText.text = WrongChoiceText;
            Time.timeScale = 1;
        }
        hideChoicePanel();
    }

    public void hideChoicePanel()
    {
        choicePanel.SetActive(false);
    }

    public void showChoicePanel(){
        choicePanel.SetActive(true);
        Time.timeScale = 0;
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
