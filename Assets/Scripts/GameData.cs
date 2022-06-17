using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameData : MonoBehaviour
{

    public int HighestLevelPlayed;
    public int HighestPartPlayed;

    public int LastLevel;
    public int LastPart;

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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        if (!PlayerPrefs.HasKey("HighestLevel") || !PlayerPrefs.HasKey("HighestPart"))
        {
            SetHighestLevel(1, 1);
        }
        getHighestLevel();

        if (!PlayerPrefs.HasKey("LastLevel")
            || !PlayerPrefs.HasKey("LastPart")
            || !PlayerPrefs.HasKey("Ch1_Good")
            || !PlayerPrefs.HasKey("Ch1_Bad")
            || !PlayerPrefs.HasKey("Ch2_Good")
            || !PlayerPrefs.HasKey("Ch2_Bad"))
        {
            resetData();
        }
        LoadData();
    }

    public void resetCh1Progress()
    {
        PlayerPrefs.SetInt("Ch1_Good", 0);
        PlayerPrefs.SetInt("Ch1_Bad", 0);
        LoadData();
    }
    public void resetCh2Progress()
    {
        PlayerPrefs.SetInt("Ch2_Good", 0);
        PlayerPrefs.SetInt("Ch2_Bad", 0);
        LoadData();
    }

    public void SaveCurrentData(int currLevel, int currPart)
    {
        if(currLevel > 8)
        {
            currLevel = 1;
            if(currPart + 1 == 3)
            {
                currPart = 2;
            }
            else
            {
                currPart = currPart+1;
            }
        }
        PlayerPrefs.SetInt("LastLevel", currLevel);
        PlayerPrefs.SetInt("LastPart", currPart);
        PlayerPrefs.SetInt("Ch1_Good", ch1ScoreGood);
        PlayerPrefs.SetInt("Ch1_Bad", ch1ScoreBad);
        PlayerPrefs.SetInt("Ch2_Good", ch2ScoreGood);
        PlayerPrefs.SetInt("Ch2_Bad", ch2ScoreBad);
        LoadData();
    }

    public void resetData()
    {
        PlayerPrefs.SetInt("LastLevel", 1);
        PlayerPrefs.SetInt("LastPart", 1);
        resetCh1Progress();
        resetCh2Progress();
        LoadData();
    }

    public void LoadData()
    {
        LastLevel = PlayerPrefs.GetInt("LastLevel");
        LastPart = PlayerPrefs.GetInt("LastPart");
        ch1ScoreBad = PlayerPrefs.GetInt("Ch1_Bad");
        ch1ScoreGood = PlayerPrefs.GetInt("Ch1_Good");
        ch2ScoreBad = PlayerPrefs.GetInt("Ch2_Bad");
        ch2ScoreGood = PlayerPrefs.GetInt("Ch2_Good");
        getHighestLevel();
    }

    public void SetHighestLevel(int LevelKey, int PartKey){
        PlayerPrefs.SetInt("HighestLevel", LevelKey);
        HighestLevelPlayed = LevelKey;
        PlayerPrefs.SetInt("HighestPart", PartKey);
        HighestPartPlayed = PartKey;
        LoadData();
    }
    private void getHighestLevel()
    {
        HighestLevelPlayed = PlayerPrefs.GetInt("HighestLevel");
        HighestPartPlayed = PlayerPrefs.GetInt("HighestPart");
    }
    internal bool isCurrentLevelAndPartHigher(int currentLevel, int currentPart)
    {
        if (HighestPartPlayed < currentPart)
        {
            
            return true;
        }
        else
        {
            if (HighestLevelPlayed < currentLevel)
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
