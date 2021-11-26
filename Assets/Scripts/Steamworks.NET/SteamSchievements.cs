using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SteamSchievements : MonoBehaviour
{
    private bool _isStatsRecieved;
    private bool _isAchievementCleared;
    private bool _isAchievementStatusUpdated;
    private bool _isStatsStored;
    private string _achivementName = "NEW_ACHIEVEMENT_1_15";


    void Start()
    {
        RequestStats();
        //PlayerPrefs.DeleteAll();
        //ClearAchievents(_achivementName);
        //SetAchievement(_achivementName);
    }

    private void RequestStats()
    {
        _isStatsRecieved = Steamworks.SteamUserStats.RequestCurrentStats();
        Debug.Log(message: "Is stats recieved: " + _isStatsRecieved);
    }

    private void ClearAchievents(string achName)
    {
        _isAchievementCleared = Steamworks.SteamUserStats.ClearAchievement(achName);

        Debug.Log(message: "Is achievent" + achName + "cleared: " + _isAchievementCleared);

        StoreStats();
    }

    public void SetAchievement(string achName)
    {
        _isAchievementStatusUpdated = Steamworks.SteamUserStats.SetAchievement(achName);
        Debug.Log(message: "Is achievement" + achName + "status updated: " + _isAchievementStatusUpdated);

        StoreStats();
    }

    public void StoreStats()
    {
        _isStatsStored = Steamworks.SteamUserStats.StoreStats();

        Debug.Log(message: "Is stats stored:" + _isStatsStored);
    }
}
