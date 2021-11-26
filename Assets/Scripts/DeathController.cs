using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{
    public Text deathOnLevel;
    public Text Money;
    private string _achivementName10 = "NEW_ACHIEVEMENT_1_10", _achivementName11 = "NEW_ACHIEVEMENT_1_11";
    [SerializeField] private SteamSchievements _steamAchievements;
    private int deathSumm;

    // Start is called before the first frame update
    void Start()
    {

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel == 0)
            Money.text = "Cups:" + PlayerPrefs.GetInt("Money").ToString();
        if (currentLevel == 2)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death1").ToString();
        if (currentLevel == 3)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death2").ToString();
        if (currentLevel == 4)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death3").ToString();
        if (currentLevel == 5)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death4").ToString();
        if (currentLevel == 6)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death5").ToString();
        if (currentLevel == 7)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death6").ToString();
        if (currentLevel == 8)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death7").ToString();
        if (currentLevel == 9)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death8").ToString();
        if (currentLevel == 10)
            deathOnLevel.text = "Death: " + PlayerPrefs.GetInt("death9").ToString();

        deathSumm = PlayerPrefs.GetInt("death1") + PlayerPrefs.GetInt("death2") + PlayerPrefs.GetInt("death3") + PlayerPrefs.GetInt("death4") + PlayerPrefs.GetInt("death5") + PlayerPrefs.GetInt("death6") +
            PlayerPrefs.GetInt("death7") + PlayerPrefs.GetInt("death8") + PlayerPrefs.GetInt("death9");

        if (PlayerPrefs.GetInt("death1") == 100 || PlayerPrefs.GetInt("death2") == 100 || PlayerPrefs.GetInt("death3") == 100 || PlayerPrefs.GetInt("death4") == 100 || PlayerPrefs.GetInt("death5") == 100 ||
            PlayerPrefs.GetInt("death6") == 100 || PlayerPrefs.GetInt("death7") == 100 || PlayerPrefs.GetInt("death8") == 100 || PlayerPrefs.GetInt("death9") == 100)
        {
            bool ach10 = Steamworks.SteamUserStats.SetAchievement(_achivementName10);
            Debug.Log(message: "Is achievement" + _achivementName10 + "status updated: " + ach10);
            _steamAchievements.StoreStats();
        }

        if (deathSumm == 1000)
        {
            bool ach11 = Steamworks.SteamUserStats.SetAchievement(_achivementName11);
            Debug.Log(message: "Is achievement" + _achivementName11 + "status updated: " + ach11);
            _steamAchievements.StoreStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel == 10)
            Money.text = "Cups:" + PlayerPrefs.GetInt("Money").ToString();
    }
}
