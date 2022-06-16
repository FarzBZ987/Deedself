using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextButtonForLastLevelPerPart : MonoBehaviour
{

    [Range(1, 2)] public int part;

    // Use this for initialization

    public void NextButton()
    {
        if(GameData.instance != null)
        {
            if (GameData.instance.CheckTotalScoreIs8(part))
            {
                if(part == 1)
                {
                    SceneManager.LoadScene("Part1Ending");
                }else if (part == 2)
                {
                    SceneManager.LoadScene("Part2Ending");
                }
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
