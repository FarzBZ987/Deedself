using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    private float sliderVal;
    public enum SliderType
    {
        BGM, SFX
    }

    public SliderType selectedSliderType;
    private void Update()
    {
        
    }

    public void onSliderChange()
    {
        sliderVal = GetComponent<Slider>().value;
        if (checkSliderType(selectedSliderType) == "BGM")
        {
            GameSettings.instance.bgmVolume = sliderVal;
        }else if(checkSliderType(selectedSliderType) == "SFX")
        {
            GameSettings.instance.sfxVolume = sliderVal;
        }
    }

    string checkSliderType(SliderType sliderType)
    {
        if(sliderType == SliderType.BGM)
        {
            return "BGM";
        }else if(sliderType == SliderType.SFX)
        {
            return "SFX";
        }
        return null;
    }

}
