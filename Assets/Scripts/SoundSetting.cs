using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public enum SoundType
    {
        BGM, SFX
    }
    private AudioSource audioSource;
    private string audioSourceType;
    [SerializeField] private SoundType selectedSoundType;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSourceType = checkSoundType(selectedSoundType);
    }

    private void Update()
    {
        if(audioSourceType == "BGM")
        {
            audioSource.volume = GameSettings.instance.bgmVolume;
        }
        else if(audioSourceType == "SFX")
        {
            audioSource.volume = GameSettings.instance.sfxVolume;
        }
        
    }
    private string checkSoundType(SoundType soundType)
    {
        if (soundType == SoundType.BGM)
        {
            return "BGM";
        }
        else if (soundType == SoundType.SFX)
        {
            return "SFX";
        }
        return null;
    }
}