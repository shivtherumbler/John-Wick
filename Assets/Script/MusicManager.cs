using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    static bool AudioBegin = false;
    public AudioSource music;

    void Awake()
    {   

        if (!AudioBegin)
        {
            music.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }


    [System.Obsolete]
    void Update()
        {
            if (Application.loadedLevelName == "Main Scene")
            {
                music.Stop();
                AudioBegin = false;
            }

            if (Application.loadedLevelName == "Story Scene")
            {
            music.Stop();
            AudioBegin = false;
            }

            if (Application.loadedLevelName == "Credits Scene")
            {
            music.Stop();
            AudioBegin = false;
            }
    }

    void Start()
    {
        if(FindObjectsOfType<AudioSource>().Length == 0)
        {
            Instantiate(music);
        }
        if(GameObject.FindGameObjectsWithTag("Music").Length>2)
            {
            Destroy(GameObject.Find("Music"));
        }
    }
}

