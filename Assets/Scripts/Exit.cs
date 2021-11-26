using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject ExitMenuUI;
    AudioSource audio_;
    public int currentlevel;
    [SerializeField] private SteamSchievements _steamAchievements;
    private string _achivementName1 = "NEW_ACHIEVEMENT_1_0", _achivementName2 = "NEW_ACHIEVEMENT_1_1", _achivementName3 = "NEW_ACHIEVEMENT_1_2",
        _achivementName4 = "NEW_ACHIEVEMENT_1_3", _achivementName5 = "NEW_ACHIEVEMENT_1_4", _achivementName6 = "NEW_ACHIEVEMENT_1_5", _achivementName7 = "NEW_ACHIEVEMENT_1_6", 
        _achivementName8 = "NEW_ACHIEVEMENT_1_7";

    private void Start()
    {
        audio_ = GameObject.FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExitMenuUI.SetActive(true);
            audio_.Stop();
            UnlockLevel();
            if (SceneManager.GetActiveScene().buildIndex == 9)
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 30000);
            else
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 300);
        }
    }

    public void UnlockLevel()
    {
        currentlevel = SceneManager.GetActiveScene().buildIndex - 1;

        if (currentlevel == 1)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName1);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 2)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName2);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 3)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName3);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 4)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName4);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 5)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName5);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 6)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName6);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 7)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName7);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }
        else if (currentlevel == 8)
        {
            bool ach1 = Steamworks.SteamUserStats.SetAchievement(_achivementName8);
            Debug.Log(message: "Is achievement" + _achivementName1 + "status updated: " + ach1);
            _steamAchievements.StoreStats();
        }


        if (currentlevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentlevel + 1);
        }
    }
}
