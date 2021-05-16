using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenToggle : MonoBehaviour
{
    public Toggle toggles;

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if(isFullScreen == true)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if(isFullScreen == false)
        {
            Screen.SetResolution(1600, 900, false);
        }

        Debug.Log("Fullscreen is: " + isFullScreen);
    }

    private void Start()
    {
        bool IsOn = false;
        if (PlayerPrefs.GetInt("IsOn") == 1)
        {
            IsOn = true;
        }
        else
        {
            IsOn = false;
        }
        toggles.isOn = IsOn;
    }

    private void Update()
    {
        if (toggles.isOn)
        {
            PlayerPrefs.SetInt("IsOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("IsOn", 0);
        }
    }
}
