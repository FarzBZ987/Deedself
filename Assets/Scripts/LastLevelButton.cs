using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastLevelButton : MonoBehaviour
{
    [SerializeField] private int buttonLevel;
    // Update is called once per frame
    void Update()
    {
        if(GameData.instance.lastLevelPlayed > buttonLevel)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
