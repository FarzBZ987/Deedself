using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevePlayed : MonoBehaviour
{
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
