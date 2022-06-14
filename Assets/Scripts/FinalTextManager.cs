using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTextManager : MonoBehaviour
{
    [SerializeField] private Text MessageText;
    [SerializeField] private SpriteRenderer badgeObject;
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
                MessageText.text = BadEndingText;
                badgeObject.sprite = BadEndingBadge;
            }
            if (GameData.instance.getScoring(EndingPart) == 1)
            {
                MessageText.text = NeutralEndingText;
                badgeObject.sprite = NeutralEndingBadge;
            }
            if (GameData.instance.getScoring(EndingPart) == 2)
            {
                MessageText.text = GoodEndingText;
                badgeObject.sprite = GoodEndingBadge;
            }
        }
    }
    
}
