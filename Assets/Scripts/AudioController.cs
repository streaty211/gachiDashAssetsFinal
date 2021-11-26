using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audio_;
    
    // Start is called before the first frame update
    private void Start()
    {
        audio_ = GameObject.FindObjectOfType<AudioSource>();
        if (!PlayerPrefs.HasKey("volume"))
            audio_.volume = 1;
    }

    // Update is called once per frame
    private void Update()
    {

        audio_.volume = PlayerPrefs.GetFloat("volume");
    }
}
