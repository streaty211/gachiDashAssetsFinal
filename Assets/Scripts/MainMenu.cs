using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextScene;

    public void playGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
