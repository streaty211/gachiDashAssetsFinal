using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    public int score;
    public GameObject[] video;
    private int randomVideo;
    private int isVideoPlaying;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.FindObjectOfType<Player>().score;
        
        if (score % 10 == 0 && score != 0 && isVideoPlaying != 1)
        {
            randomVideo = Random.Range(0, 8);
            video[randomVideo].SetActive(true);
            isVideoPlaying = 1;
            Invoke("StopGame", 6.0f);

        }

        
    }

    void StopGame()
    {
        video[randomVideo].SetActive(false);
        isVideoPlaying = 0;
    }
    

}
