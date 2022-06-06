using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastLevelButton : MonoBehaviour
{
    [SerializeField] private int buttonPart;
    [SerializeField] private int buttonLevel;
    
    //This script is just to disable the button if the last level isn't played yet
    void Update()
    {
        if (buttonPart < GameData.instance.lastPartPlayed)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            if (buttonLevel < GameData.instance.lastLevelPlayed)
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
        
    }
}
