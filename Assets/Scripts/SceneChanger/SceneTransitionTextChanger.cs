using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionTextChanger : MonoBehaviour
{
    [SerializeField] private Text partText;
    [SerializeField] private Text levelText;
    // Start is called before the first frame update
    void Update()
    {
        if(SceneDataBringer.instance!= null)
        {
            partText.text = "PART." + SceneDataBringer.instance.getPartStringRoman();
            levelText.text = "NO." + SceneDataBringer.instance.getLevelStringRoman();
        }
    }

}
