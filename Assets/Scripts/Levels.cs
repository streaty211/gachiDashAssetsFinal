using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    int levelUnlock;
    public Button[] buttons;

    

    // Start is called before the first frame update
    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels", 1);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i < levelUnlock; i++)
        {
            buttons[i].interactable = true;
        }
    }


    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
