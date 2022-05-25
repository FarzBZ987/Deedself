using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataBringer : MonoBehaviour
{
    private int level;
    private int part;
    public static SceneDataBringer instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    
    public void setPartAndLevel(int inputPart, int inputLevel)
    {
        level = inputLevel;
        part = inputPart;
    }
    public string getLevelAndPartAsString()
    {
        return "Part " + part.ToString() + " - Level" + level.ToString();
    }
}
