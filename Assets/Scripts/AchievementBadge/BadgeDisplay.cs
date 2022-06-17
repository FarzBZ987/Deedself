using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Image BadgeImage;

    [SerializeField] private int Progress_Part1_AchieveBadge;
    [SerializeField] private int Progress_Part2_AchieveBadge;


    private void Awake()
    {
        if (!HasProgress())
        {
            resetProgress();
        }
        BadgeImage = GetComponent<Image>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        getProgress();
        if (BadgePartGetString() == "Part 1")
        {
            SetBadgeDisplay(Progress_Part1_AchieveBadge);
        }
        else if (BadgePartGetString() == "Part 2")
        {
            SetBadgeDisplay(Progress_Part2_AchieveBadge);
        }
        
    }

    private void Update()
    {
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
                BadgeImage.sprite = BadBadge;
                break;
            case 1:
                BadgeImage.sprite = NeutralBadge;
                break;
            case 2:
                BadgeImage.sprite = GoodBadge;
                break;
            default:
                Debug.Log("Not Found");
                BadgeImage.sprite = BadBadge;
                break;
        }
    }
    private void resetProgress()
    {
        PlayerPrefs.SetInt("Progress_Part1_AchieveBadge", 0);
        PlayerPrefs.SetInt("Progress_Part2_AchieveBadge", 0);
        getProgress();
    }
    private void getProgress()
    {
        Progress_Part1_AchieveBadge = PlayerPrefs.GetInt("Progress_Part1_AchieveBadge");
        Progress_Part2_AchieveBadge = PlayerPrefs.GetInt("Progress_Part2_AchieveBadge");
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
