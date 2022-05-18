using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveLoadManager : MonoBehaviour 
{

                public InputField inputField;
                public Text textOutput;
               
                public void TombolSave(){
                                string nama = inputField.text;
                               
                                PlayerPrefs.SetString("Name", nama);
                }
               
                public void TombolLoad(){
                                string loadNama = PlayerPrefs.GetString("Name");
                               
                                textOutput.text = "" + loadNama;
                }

}