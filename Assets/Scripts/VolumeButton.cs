using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeButton : MonoBehaviour
{
    public void sfxUp()
    {
        if(GameSettings.instance != null)
        {
            GameSettings.instance.sfxUp();
        }
    }
    public void sfxDown()
    {
        if(GameSettings.instance != null)
        {
            GameSettings.instance.sfxDown();
        }
    }
    public void bgmUp()
    {
        if(GameSettings.instance != null)
        {
            GameSettings.instance.bgmUp();
        }
    }
    public void bgmDown()
    {
        if(GameSettings.instance != null)
        {
            GameSettings.instance.bgmDown();
        }
    }
}
