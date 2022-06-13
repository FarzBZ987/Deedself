using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class VolumeViewUpdater : MonoBehaviour
    {
        public enum VolumeType
        {
            BGM, SFX
        }
        private VolumeType volumeType;
        private Text text;
        void Start()
        {
            text = GetComponent<Text>();
        }
        // Update is called once per frame
        void Update()
        {

            if(GameSettings.instance != null)
            {
                if(getVolumeType() == "BGM")
                {
                    text.text = (GameSettings.instance.bgmVolume * 100).ToString() + "%";
                }
                else if(getVolumeType() == "SFX")
                {
                    text.text = (GameSettings.instance.sfxVolume * 100).ToString() + "%";
                }
            }
        }
        private string getVolumeType()
        {
            if(volumeType == VolumeType.BGM)
            {
                return "BGM";
            }else if(volumeType == VolumeType.SFX)
            {
                return "SFX";
            }
            return null;
        }
    }
}