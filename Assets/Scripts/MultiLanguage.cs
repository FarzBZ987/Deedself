using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguage : MonoBehaviour
{
    
    private void Awake(){
        LocalizationManager.Read();

        LoadLang();
    
    }


    public void LoadLang(){
        string langload = PlayerPrefs.GetString("languageprefs");

        LocalizationManager.Language = langload;

    }


    public void Language(string language){

        PlayerPrefs.SetString("languageprefs", language);
        
        string langlo = PlayerPrefs.GetString("languageprefs");
        
        LocalizationManager.Language = langlo;
    }
}
