using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeValue;
    public float winValue;
    public Text timerText;
    public Text winText;
    public GameObject time;
    public GameObject currentTimer;
    public GameObject winTime;
    public GameObject winTimer;
    public GameObject Pause;
    int i = 0;

    // Update is called once per frame
    private void Update()
    {
        
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            winValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            winValue = 0;
        } 
       
        if (timeValue == 0)
        {
                if(i == 0)
            {

                SceneManager.LoadScene("Timer Mode Lose");
                currentTimer.SetActive(false);
                i++;

            }
            
        }

        if (SceneManager.GetActiveScene().name == "Timer Win")
        {
            winTimer.SetActive(true);
            currentTimer.SetActive(false);
            Time.timeScale = 0f;
            

        }

        else
        {
            winTimer.SetActive(false);
        }

       

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        winText.text = string.Format("Congratulations, you beat the game with {0:00}:{1:00}:{2:000} left", minutes, seconds, milliseconds);
    }

    public void ThreeMin()
    {
       
        timeValue = 180;
        winValue = 180;
        time.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void FiveMin()
    {
        
        timeValue = 300;
        winValue = 300;
        time.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void EightMin()
    {

        timeValue = 480;
        winValue = 480;
        time.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void TenMin()
    {
        
        timeValue = 600;
        winValue = 600;
        time.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    private void Awake()
    {

        DontDestroyOnLoad(winTime);

    }
}
