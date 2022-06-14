using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeDisplay : MonoBehaviour
{
    public enum BadgePart
    {
        Part_1, Part_2
    }
    [SerializeField] BadgePart badgePart;

    [SerializeField] private Sprite BadBadge;
    [SerializeField] private Sprite NeutralBadge;
    [SerializeField] private Sprite GoodBadge;

    private SpriteRenderer spriteRenderer;

    private int Progress_Part1_AchieveBadge;
    private int Progress_Part2_AchieveBadge;


    private void Awake()
    {
        if (!HasProgress())
        {
            resetProgress();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        getProgress();
        if (BadgePartGetString() == "Part 1")
        {
            SetBadgeDisplay(Progress_Part1_AchieveBadge);
        }else if(BadgePartGetString() == "Part 2")
        {
            SetBadgeDisplay(Progress_Part2_AchieveBadge);
        }
    }

    private string BadgePartGetString()
    {
        if(badgePart == BadgePart.Part_1)
        {
            return "Part 1";
        }else if(badgePart == BadgePart.Part_2)
        {
            return "Part 2";
        }
        return null;
    }

    private void SetBadgeDisplay(int BadgePart)
    {
        switch (BadgePart)
        {
            case 0:
                spriteRenderer.sprite = BadBadge;
                break;
            case 1:
                spriteRenderer.sprite = NeutralBadge;
                break;
            case 2:
                spriteRenderer.sprite = GoodBadge;
                break;
            default:
                spriteRenderer.sprite = BadBadge;
                break;
        }
    }
    private void resetProgress()
    {
        PlayerPrefs.SetInt("Progress_Part1_AchieveBadge", 0);
        PlayerPrefs.SetInt("Progress_Part2_AchieveBadge", 0);
    }
    private void getProgress()
    {
        Progress_Part1_AchieveBadge = PlayerPrefs.GetInt("Progress_Part1_AchieveBadge");
        Progress_Part1_AchieveBadge = PlayerPrefs.GetInt("Progress_Part2_AchieveBadge");
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
}
