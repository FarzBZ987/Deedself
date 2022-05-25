using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    //Shown on inspector, just select the level and the part
    [SerializeField, Range(1, 3)] private int Part;
    [SerializeField, Range(1, 7)] private int Level;

    //This variable is only used to load the scene based on its name
    private string LevelName;
    
    void Start()
    {
        //Declaring the level name
        LevelName = "Part " + Part.ToString() + " - Level " + Level.ToString();

        //Log to see the name, could be safely deleted
        Debug.Log("Level Name : " + LevelName);
    }
    public void LoadLevel()
    {
        //Load the level based on the declared part and level before
        SceneManager.LoadScene(LevelName);
    }
}
