using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeUpdater : MonoBehaviour
{

    public enum BadgePart
    {
        Part_1, Part_2
    }
    [SerializeField] BadgePart WillSaveTo;
    private int HighestScore;

    private void Awake()
    {
        if (!HasProgress())
        {
            resetProgress();
        }
        HighestScore = PlayerPrefs.GetInt(BadgePartGetString_ForPlayerPrefs());
        UpdateBadgeProgress();
    }

    private void Start()
    {
        
    }

    private void UpdateBadgeProgress()
    {
        if (GameData.instance != null)
        {
            Debug.Log("GameData Found!");
            if (GameData.instance.CheckTotalScoreIs8(PartGetInt())){
                int currentScore = GameData.instance.getScoring(PartGetInt());
                if (currentScore > HighestScore)
                {
                    PlayerPrefs.SetInt(BadgePartGetString_ForPlayerPrefs(), currentScore);
                }
            }
        }
    }
    private bool HasProgress()
    {
        if (!PlayerPrefs.HasKey("Progress_Part1_AchieveBadge") || !PlayerPrefs.HasKey("Progress_Part2_AchieveBadge"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private string BadgePartGetString_ForPlayerPrefs()
    {
        if (WillSaveTo == BadgePart.Part_1)
        {
            return "Progress_Part1_AchieveBadge";
        }
        else if (WillSaveTo == BadgePart.Part_2)
        {
            return "Progress_Part2_AchieveBadge";
        }
        return null;
    }
    private int PartGetInt()
    {
        if (WillSaveTo == BadgePart.Part_1)
        {
            return 1;
        }
        else if (WillSaveTo == BadgePart.Part_2)
        {
            return 2;
        }
        return 0;
    }
    private void resetProgress()
    {
        PlayerPrefs.SetInt("Progress_Part1_AchieveBadge", 0);
        PlayerPrefs.SetInt("Progress_Part2_AchieveBadge", 0);
    }
}
