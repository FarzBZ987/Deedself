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

    public int getLevelInt()
    {
        return level;
    }
    public int getPartInt()
    {
        return part;
    }

    public string getLevelStringRoman()
    {
        return numberToRoman(level);
    }

    public string getPartStringRoman()
    {
        return numberToRoman(part);
    }

    public string getLevelAndPartAsString()
    {
        return "Part " + part.ToString() + " - Level " + level.ToString();
    }

    private string numberToRoman(int numInput)
    {
        switch (numInput)
        {
            case 1:
                return "I";
            case 2:
                return "II";
            case 3:
                return "III";
            case 4:
                return "IV";
            case 5:
                return "V";
            case 6:
                return "VI";
            case 7:
                return "VII";
            case 8:
                return "VIII";
            default:
                return null;
        }
    }
}
