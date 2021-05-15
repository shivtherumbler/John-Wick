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
        
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        SceneManager.LoadScene("Main Scene");
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main Scene");
        Time.timeScale = 1;
    }

    public void Arcade()
    {
        SceneManager.LoadScene("Infinite Scene");
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
}
