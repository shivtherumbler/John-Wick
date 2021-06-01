using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject slider;
    public GameObject NewGame;
    public GameObject Select;
    public GameObject buttons;
    public GameObject modes;
    public GameObject back;
    public Text loading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        slider.SetActive(true);
        loading.enabled = true;
        buttons.SetActive(false);
        modes.SetActive(false);
        back.SetActive(false);
        //SceneManager.LoadScene("Loading Scene");
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Main Scene"));

        }

        if (SceneManager.GetActiveScene().name == "Story Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Main Scene"));

        }
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        //SceneManager.LoadScene("Loading Scene");
        slider.SetActive(true);
        loading.enabled = true;
        buttons.SetActive(false);
        modes.SetActive(false);
        back.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Main Scene"));

        }

        if (SceneManager.GetActiveScene().name == "Story Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Main Scene"));

        }

        if (SceneManager.GetActiveScene().name == "Game Over Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Main Scene"));

        }

        Time.timeScale = 1;
    }

    public void Arcade()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        slider.SetActive(true);
        loading.enabled = true;
        buttons.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            //StartCoroutine(ArcadeScene());
            Destroy(GameObject.Find("Scores"));
            StartCoroutine(LoadYourAsyncScene("Infinite Scene"));

        }

        if (SceneManager.GetActiveScene().name == "Arcade Death")
        {
            //StartCoroutine(MainScene());
            Destroy(GameObject.Find("Scores"));
            StartCoroutine(LoadYourAsyncScene("Infinite Scene"));

        }
        Time.timeScale = 1;
        // SceneManager.LoadScene("Loading Scene 2");
    }

    public void Controls()
    {
        //SceneManager.LoadScene("Controls Scene");
        slider.SetActive(true);
        loading.enabled = true;
        buttons.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Controls Scene"));

        }
    }

    public void Credits()
    {
        //SceneManager.LoadScene("Credits Scene");
        slider.SetActive(true);
        loading.enabled = true;
        buttons.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Credits Scene"));

        }

        if (SceneManager.GetActiveScene().name == "Win Scene")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Credits Scene"));

        }

        if (SceneManager.GetActiveScene().name == "Timer Win")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Credits Scene"));

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(GameObject.Find("Scores"));
        Destroy(GameObject.Find("Select Time"));
    }

    public void BonusClip()
    {
        SceneManager.LoadScene("Bonus Scene");
    }

    public void Story()
    {
        SceneManager.LoadScene("Story Scene");
    }

    public void SelectMode()
    {
        modes.SetActive(true);
        buttons.SetActive(false);

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(NewGame);

    }

    public void Back()
    {
        modes.SetActive(false);
        buttons.SetActive(true);

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Select);

    }

    public void TimeTrial()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        slider.SetActive(true);
        loading.enabled = true;
        buttons.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Timer Mode"));

        }

        if (SceneManager.GetActiveScene().name == "Timer Mode Lose")
        {
            //StartCoroutine(MainScene());
            StartCoroutine(LoadYourAsyncScene("Timer Mode"));

        }
        Destroy(GameObject.Find("Select Time"));

        Time.timeScale = 1;
    }

    IEnumerator MainScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Main Scene");
    }

    IEnumerator ArcadeScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Infinite Scene");
    }

    IEnumerator LoadYourAsyncScene(string SceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (asyncLoad.progress < 1)
        {
            slider.GetComponent<Slider>().value = asyncLoad.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
