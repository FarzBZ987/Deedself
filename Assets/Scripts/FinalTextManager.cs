using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class FinalTextManager : MonoBehaviour
{
    [SerializeField] private Text MessageText;
    [SerializeField] private Image badgeObject;
    [SerializeField] private int EndingPart;


    [Header("Good ending")]
    [SerializeField] private string GoodEndingText;
    [SerializeField] private Sprite GoodEndingBadge;

    [Header("Neutral Ending")]
    [SerializeField] private string NeutralEndingText;
    [SerializeField] private Sprite NeutralEndingBadge;

    [Header("Bad Ending")]
    [SerializeField] private string BadEndingText;
    [SerializeField] private Sprite BadEndingBadge;

    // Use this for initialization
    void Start()
    {
        

        if(GameData.instance != null)
        {
            if(GameData.instance.getScoring(EndingPart) == 0)
            {
                LocalizeBad();
                badgeObject.sprite = BadEndingBadge;
            }
            if (GameData.instance.getScoring(EndingPart) == 1)
            {
                LocalizeNeutral();
                badgeObject.sprite = NeutralEndingBadge;
            }
            if (GameData.instance.getScoring(EndingPart) == 2)
            {
                LocalizeGood();
                badgeObject.sprite = GoodEndingBadge;
            }
            if (!PlayerPrefs.HasKey("Progress_Part" + EndingPart.ToString() + "_AchieveBadge"))
            {
                PlayerPrefs.SetInt("Progress_Part" + EndingPart.ToString() + "_AchieveBadge", GameData.instance.getScoring(EndingPart));
            }
            else
            {
                if (PlayerPrefs.GetInt("Progress_Part" + EndingPart.ToString() + "_AchieveBadge") > GameData.instance.getScoring(EndingPart)){
                    PlayerPrefs.SetInt("Progress_Part" + EndingPart.ToString() + "_AchieveBadge", GameData.instance.getScoring(EndingPart));
                }
            }
        }
    }
    public void LocalizeGood()
    {

        MessageText.text = LocalizationManager.Localize(GoodEndingText);

    }
    public void LocalizeNeutral()
    {

        MessageText.text = LocalizationManager.Localize(NeutralEndingText);

    }
    public void LocalizeBad()
    {

        MessageText.text = LocalizationManager.Localize(BadEndingText);

    }
    
}
