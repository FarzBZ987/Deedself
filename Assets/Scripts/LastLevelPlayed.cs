using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelPlayed : MonoBehaviour
{
    //This script is used for saving last level
    [SerializeField] private int CurrentLevel;
    [SerializeField] private int CurrentPart;

    private void Update()
    {
        if (GameData.instance.isCurrentLevelAndPartHigher(CurrentLevel, CurrentPart))
        {
            GameData.instance.SetHighestLevel(CurrentLevel, CurrentPart);
        }
        GameData.instance.SaveCurrentData(CurrentLevel, CurrentPart);
        
        Destroy(gameObject);
    }
}
