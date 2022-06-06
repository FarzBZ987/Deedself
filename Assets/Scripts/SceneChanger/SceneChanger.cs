using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [HideInInspector] public bool isNewGame;
    [HideInInspector] public bool isContinue;
    [HideInInspector, Range(1, 3)] public int part;
    [HideInInspector, Range(1, 7)] public int level;

    public void sceneChange()
    {
        if (part > 3)
        {
            part = 3;
        }
        if(part < 1)
        {
            part = 1;
        }
        if (level > 8)
        {
            level = 8;
        }
        if (level < 1)
        {
            level = 1;
        }
        if (isNewGame)
        {
            SceneDataBringer.instance.setPartAndLevel(1, 1);
            SceneManager.LoadScene("NewGame");
        }
        else
        {
            if (isContinue)
            {
                level = PlayerPrefs.GetInt("LastLevel");
                part = PlayerPrefs.GetInt("LastPart");
            }
            SceneDataBringer.instance.setPartAndLevel(part, level);
            SceneManager.LoadScene("NewGame");

        }
    }
}
