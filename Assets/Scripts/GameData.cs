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
    public bool CheckTotalScoreIs8(int part)
    {
        switch (part)
        {
            case 1:
                if(ch1ScoreBad + ch1ScoreGood == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 2:
                if (ch2ScoreBad + ch2ScoreGood == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }

    public int getScoring(int part)
    {
        switch (part)
        {
            case 1:
                if(Mathf.Abs(ch1ScoreBad - ch1ScoreGood) <= 2)
                {
                    return 1;
                }
                else if(ch1ScoreGood > ch1ScoreBad){
                    return 2;
                }
                else
                {
                    return 0;
                }
            case 2:
                if (Mathf.Abs(ch2ScoreBad - ch2ScoreGood) <= 2)
                {
                    return 1;
                }
                else if (ch2ScoreGood > ch2ScoreBad)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            default:
                return 0;
        }
    }
}
