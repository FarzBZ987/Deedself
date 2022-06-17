using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class customSplashScreen : MonoBehaviour
{
    private Image targetImage;
    [SerializeField] private Color invisibleColor;
    [SerializeField] private Color visibleColor;
    private bool fadingIn;
    private bool fadingOut;
    [SerializeField] private float imageInDelay = 1;
    [SerializeField] private float imageOutDelay = 4;
    [SerializeField] private float loadMainMenuDelay = 8;

    private void Awake()
    {
        targetImage = GetComponent<Image>();
        targetImage.color = invisibleColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("startFadeIn", imageInDelay);
        Invoke("startFadeOut", imageOutDelay);
        Invoke("goToMenu", loadMainMenuDelay);
    }

    private void Update()
    {
        if (fadingIn)
        {
            fadeIn();
        }
        if (fadingOut)
        {
            fadeOut();
        }

        
    }

    private void startFadeIn()
    {
        fadingIn = true;
    }

    private void startFadeOut()
    {
        fadingIn = false;
        fadingOut = true;
    }
    private void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void fadeIn()
    {
        targetImage.color = Color.Lerp(targetImage.color, visibleColor, 1 * Time.deltaTime);
    }
    private void fadeOut()
    {
        targetImage.color = Color.Lerp(targetImage.color, invisibleColor, 1 * Time.deltaTime);
    }
}
