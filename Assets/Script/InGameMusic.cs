using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    private AudioSource music;
    public AudioClip clip;

    [System.Obsolete]
    void Awake()
    {

        if (!AudioBegin)
        {
            if (Application.loadedLevelName == "Main Scene")
            { 
            music = gameObject.AddComponent<AudioSource>();
            music.clip = clip;
            int randomStartTime = Random.Range(0, clip.samples - 1); //clip.samples is the lengh of the clip in samples
            music.timeSamples = randomStartTime;
           
        } 
            music.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }


    [System.Obsolete]
    void Update()
    {
        if (Application.loadedLevelName == "Main Menu")
        {
            music.Stop();
            AudioBegin = false;
        }

        if (Application.loadedLevelName == "End Scene")
        {
            music.Stop();
            AudioBegin = false;
        }

        if (Application.loadedLevelName == "Game Over Scene")
        {
            music.Stop();
            AudioBegin = false;
        }

    }

    void Start()
    {
        if (FindObjectsOfType<AudioSource>().Length == 0)
        {
            Instantiate(music);
        }
        if (GameObject.FindGameObjectsWithTag("Game Music").Length > 2)
        {
            Destroy(GameObject.Find("InGameMusic"));
        }

        music = GetComponent<AudioSource>();

    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
