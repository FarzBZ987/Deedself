using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    [Range(0, 1)] public float bgmVolume;
    [Range(0, 1)] public float sfxVolume;

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
            PlayerPrefs.SetFloat("bgmVolume", 1f);
            PlayerPrefs.SetFloat("sfxVolume", 1f);
            LoadSettings();
        }
        else
        {
            LoadSettings();
        }
        DontDestroyOnLoad(this);
    }

    private void LoadSettings()
    {
        bgmVolume = PlayerPrefs.GetFloat("bgmVolume");
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }
}
