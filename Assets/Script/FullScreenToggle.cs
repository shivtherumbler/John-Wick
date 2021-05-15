using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{
    
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        Debug.Log("Fullscreen is: " + isFullScreen);
    }
}
