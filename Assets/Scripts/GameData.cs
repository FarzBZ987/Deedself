using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameData : MonoBehaviour
{

    public int lastLevelPlayed;
    public int lastPartPlayed;


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
        if (!PlayerPrefs.HasKey("LastLevel") || !PlayerPrefs.HasKey("LastPart"))
        {
            SetLastLevel(1, 1);
        }
        getLastLevel();
        
        
    }
    
    public void SetLastLevel(int LevelKey, int PartKey){
        PlayerPrefs.SetInt("LastLevel", LevelKey);
        lastLevelPlayed = LevelKey;
        PlayerPrefs.SetInt("LastPart", PartKey);
        lastPartPlayed = PartKey;
    }
    private void getLastLevel()
    {
        lastLevelPlayed = PlayerPrefs.GetInt("LastLevel");
        lastPartPlayed = PlayerPrefs.GetInt("LastPart");
    }
    internal bool isCurrentLevelAndPartHigher(int currentLevel, int currentPart)
    {
        if (lastPartPlayed < currentPart)
        {
            
            return true;
        }
        else
        {
            if (lastLevelPlayed < currentLevel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
