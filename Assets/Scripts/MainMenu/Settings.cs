using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void setResolution1920()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void setResolution1280()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen = false);
    }
}