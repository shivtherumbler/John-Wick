using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class InGameMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    private AudioSource music;
    public AudioClip clip;
    public AudioMixer audioMixer;
    public AudioMixerGroup mixerGroup;
    public Slider slide;

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
            if (Application.loadedLevelName == "Infinite Scene")
            {
                music = gameObject.AddComponent<AudioSource>();
                music.clip = clip;
                int randomStartTime = Random.Range(0, clip.samples - 1); //clip.samples is the lengh of the clip in samples
                music.timeSamples = randomStartTime;

            }

            if (Application.loadedLevelName == "Timer Mode")
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

        if (Application.loadedLevelName == "Story Scene")
        {
            music.Stop();
            AudioBegin = false;
        }

        if (Application.loadedLevelName == "Game Over Scene")
        {
            music.Stop();
            AudioBegin = false;
        }

        if (Application.loadedLevelName == "Arcade Death")
        {
            music.Stop();
            AudioBegin = false;
        }

        if (Application.loadedLevelName == "Timer Mode Lose")
        {
            music.Stop();
            AudioBegin = false;
        }

        if (Application.loadedLevelName == "Timer Win")
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
        music.outputAudioMixerGroup = mixerGroup;

        float volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        slide.value = volume;

    }

    public void SetVolume (float volume)
        {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
