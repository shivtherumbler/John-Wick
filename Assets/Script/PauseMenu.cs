using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Resume();
        Destroy(GameObject.Find("Select Time"));
        Destroy(GameObject.Find("Scores"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Scene");
        Resume();
    }

    public void HowtoPlay()
    {
        SceneManager.LoadScene("Controls Scene");
        Resume();
    }

    public void Story()
    {
        SceneManager.LoadScene("Story Scene");
        Resume();
    }

    public void RestartScene()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Main Scene"));
            Resume();

        }

        if (SceneManager.GetActiveScene().name == "DLC Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("DLC Scene"));
            Resume();

        }

        if (SceneManager.GetActiveScene().name == "Car Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Car Scene"));
            Resume();

        }

        if (SceneManager.GetActiveScene().name == "Infinite Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Infinite Scene"));
            Resume();

        }

        if (SceneManager.GetActiveScene().name == "Timer Mode")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Timer Mode"));
            Resume();

        }
    }

        IEnumerator LoadYourAsyncScene(string SceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (asyncLoad.progress < 1)
        {
            
            yield return new WaitForEndOfFrame();
        }
    }

}
