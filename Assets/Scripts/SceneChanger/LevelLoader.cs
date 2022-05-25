using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //This variable is only used to load the scene based on its name
    private string LevelName;

    public void LoadLevel()
    {
        //Declaring the level name, look at SceneDataBringer.cs
        if(SceneDataBringer.instance != null)
        {
            LevelName = SceneDataBringer.instance.getLevelAndPartAsString();
        }
        else
        {
            Debug.Log("SceneDataBringer not found! Playing part 1 level 1");
            LevelName = "Part 1 - Level 1";
        }

        //Log to see the name, could be safely deleted
        Debug.Log("Level Name : " + LevelName);
        //Load the level based on the declared part and level before
        SceneManager.LoadScene(LevelName);
    }
}
