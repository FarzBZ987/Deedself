using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameData : MonoBehaviour
{

    public string lastLevelPlayed;

    [Header("Chapter 1 scores")]
    public int ch1ScoreGood;
    //public int ch1ScoreNeutral;
    public int ch1ScoreBad;

    [Header("Chapter 2 scores")]
    public int ch2ScoreGood;
    //public int ch2ScoreNeutral;
    public int ch2ScoreBad;

    [Header("Chapter 3 scores")]
    public int ch3ScoreGood;
    //public int ch3ScoreNeutral;
    public int ch3ScoreBad;

    public static GameData instance;

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
        DontDestroyOnLoad(this);
    }

    public void lastSceneUpdate(){
        lastLevelPlayed = SceneManager.GetActiveScene().ToString();
    }
}
