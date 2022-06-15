using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SFXController : MonoBehaviour
    {
        [SerializeField] private AudioSource SFXOutput;
        [SerializeField] private AudioClip[] SFX;
        
        public void playSFX(int SFXIndex)
        {
            if(SFX.Length > 0) {
                if(SFXIndex >= SFX.Length)
                {
                    SFXIndex = SFX.Length - 1;
                }
                if(SFXIndex < 0)
                {
                    SFXIndex = 0;
                }
                SFXOutput.PlayOneShot(SFX[SFXIndex]);
            }   
        }
    }
}