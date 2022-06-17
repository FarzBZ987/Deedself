using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [HideInInspector] public bool isNewGame;
    [HideInInspector] public bool isContinue;
    [HideInInspector, Range(1, 3)] public int part;
    [HideInInspector, Range(1, 8)] public int level;

    public void sceneChange()
    {
        Debug.Log("Button Pressed");
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
            if(GameData.instance != null)
            {
                GameData.instance.resetCh1Progress();
                GameData.instance.resetCh2Progress();
            }
        }
        else
        {
            if (GameData.instance != null)
            {
                GameData.instance.LoadData();
                if (isContinue)
                {
                    Debug.Log("Continue button pressed");
                    level = GameData.instance.LastLevel;
                    part = GameData.instance.LastPart;
                    if(part == 1)
                    {
                        if (level > 1)
                        {
                            SceneDataBringer.instance.setPartAndLevel(part, level);
                            SceneManager.LoadScene("TransisiLevel");
                        }
                        else
                        {
                            GameData.instance.resetCh1Progress();
                        }
                    }
                    if (part == 2)
                    {
                        if (level > 1)
                        {
                            SceneDataBringer.instance.setPartAndLevel(part, level);
                            SceneManager.LoadScene("TransisiLevel");
                        }
                        else
                        {
                            GameData.instance.resetCh2Progress();
                        }
                    }
                }
                else
                {
                    SceneDataBringer.instance.setPartAndLevel(part, level);
                    SceneManager.LoadScene("TransisiLevel");
                    if (level == 1 && part == 2)
                    {
                        GameData.instance.resetCh2Progress();
                    }
                }
            }   
        }
    }
}
