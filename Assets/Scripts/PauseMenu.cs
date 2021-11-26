using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    AudioSource myAudioSuorce;
    VideoPlayer myVideoPlayer;

    // Update is called once per frame
    void Update()
    {
        myAudioSuorce = GameObject.FindObjectOfType<AudioSource>();
        myVideoPlayer = GameObject.FindObjectOfType<VideoPlayer>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        myAudioSuorce.Play();
        myVideoPlayer.Play();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        myAudioSuorce.Pause();
        if (SceneManager.GetActiveScene().buildIndex == 10)
            myVideoPlayer.Pause();

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
