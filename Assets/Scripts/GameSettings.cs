using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    [Range(0, 100)] public int bgmVolume;
    [Range(0, 100)] public int sfxVolume;

    public static GameSettings instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("hasRun"))
        {
            PlayerPrefs.SetInt("hasRun", 1);
            PlayerPrefs.SetInt("bgmVolume", 100);
            PlayerPrefs.SetInt("sfxVolume", 100);
        }
        LoadSettings();
        
        DontDestroyOnLoad(this);
    }

    private void LoadSettings()
    {
        bgmVolume = PlayerPrefs.GetInt("bgmVolume");
        sfxVolume = PlayerPrefs.GetInt("sfxVolume");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("bgmVolume", bgmVolume);
        PlayerPrefs.SetInt("sfxVolume", sfxVolume);
    }

    public void sfxDown()
    {
        sfxVolume = sfxVolume - 10 <= 0 ? 0 : sfxVolume - 10;
        SaveSettings();
    }
    public void sfxUp()
    {
        sfxVolume = sfxVolume + 10 >= 100 ? 100 : sfxVolume + 10;
        SaveSettings();
    }
    public void bgmDown()
    {
        bgmVolume = bgmVolume - 10 <= 0 ? 0 : bgmVolume - 10;
        SaveSettings();
    }
    public void bgmUp()
    {
        bgmVolume = bgmVolume + 10 >= 100 ? 100 : bgmVolume + 10;
        SaveSettings();
    }

    public float getSFX()
    {
        float i;
        i = sfxVolume;
        return i / 100;
    }
    public float getBGM()
    {
        float i;
        i = bgmVolume;
        return i / 100;
    }
}
