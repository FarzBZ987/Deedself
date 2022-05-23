using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelPlayed : MonoBehaviour
{
    //This script is used for saving last level
    [SerializeField] private int CurrentLevel;
    
    private void Start()
    {
        if (GameData.instance.isCurrentLevelHigher(CurrentLevel))
        {
            GameData.instance.SetLastLevel(CurrentLevel);
        }
        Destroy(gameObject);
    }
}
