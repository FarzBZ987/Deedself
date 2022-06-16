using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalizationSceneLoadNext : MonoBehaviour
{

    [SerializeField, Range(1, 2)] private int endingPart;
    [SerializeField] private float delay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delayedLevelTransition", delay);
    }
    private void delayedLevelTransition() {
        if (endingPart == 1)
        {
            if (SceneDataBringer.instance != null)
            {
                SceneDataBringer.instance.setPartAndLevel(2, 1);
                SceneManager.LoadScene("TransisiLevel");
                if (GameData.instance != null)
                {
                    GameData.instance.resetCh2Progress();
                }
            }
        }else if(endingPart == 2)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
