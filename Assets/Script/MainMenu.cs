using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Loading Scene")
        {
            StartCoroutine(MainScene());
        }

        if (SceneManager.GetActiveScene().name == "Loading Scene 2")
        {
            StartCoroutine(ArcadeScene());
        }
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        SceneManager.LoadScene("Loading Scene");
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Loading Scene");
        Time.timeScale = 1;
    }

    public void Arcade()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        SceneManager.LoadScene("Loading Scene 2");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void BonusClip()
    {
        SceneManager.LoadScene("Bonus Scene");
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

}
