using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] public static Shop _shop;
    [Header("Models")]
    [SerializeField] private GameObject[] models;
    [SerializeField] public int selectModel;

    [Header("Price")]
    [SerializeField] private int[] price;
    [SerializeField] private Text[] priceText;
    //[SerializeField] private Text[] factorText;

    [Header("Buttons")]
    [SerializeField] private GameObject[] buyButtons;



    [Header("Money")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    [Header("ShopSaveController")]
    [SerializeField] private ShopSaveController _shopSaveController;

    private string _achivementName13 = "NEW_ACHIEVEMENT_1_13", _achivementName14 = "NEW_ACHIEVEMENT_1_14", _achivementName15 = "NEW_ACHIEVEMENT_1_15";

    private void Awake() => _shopSaveController.Load();

    private void Start()
    {

        
        _shop = this;
        models[PlayerPrefs.GetInt("ModelIndex")].SetActive(true);
        //PlayerPrefs.DeleteKey("ModelIndex");
        //PlayerPrefs.DeleteKey("Money");
        if (PlayerPrefs.HasKey("ModelIndex") == false)
            PlayerPrefs.SetInt("ModelIndex", 0);


        for (int i = 0; i < _shopSaveController.memes.isBuy.Length; i++)
        {
            if (_shopSaveController.memes.isBuy[i] == true)
            {
                priceText[i].text = null;
                buyButtons[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        money = PlayerPrefs.GetInt("Money");
        moneyText.text = "cups: " + money.ToString();

        if (_shopSaveController.memes.isBuy[4] == true)
        {
            bool ach13 = Steamworks.SteamUserStats.SetAchievement(_achivementName13);
            Debug.Log(message: "Is achievement" + _achivementName13 + "status updated: " + ach13);
            bool _isStatsStored13 = Steamworks.SteamUserStats.StoreStats();
            Debug.Log(message: "Is stats stored:" + _isStatsStored13);
        }

        if (_shopSaveController.memes.isBuy[9] == true)
        {
            bool ach14 = Steamworks.SteamUserStats.SetAchievement(_achivementName14);
            Debug.Log(message: "Is achievement" + _achivementName14 + "status updated: " + ach14);
            bool _isStatsStored14 = Steamworks.SteamUserStats.StoreStats();
            Debug.Log(message: "Is stats stored:" + _isStatsStored14);
        }

        if (_shopSaveController.memes.isBuy[13] == true)
        {
            bool ach15 = Steamworks.SteamUserStats.SetAchievement(_achivementName15);
            Debug.Log(message: "Is achievement" + _achivementName14 + "status updated: " + ach15);
            bool _isStatsStored15 = Steamworks.SteamUserStats.StoreStats();
            Debug.Log(message: "Is stats stored:" + _isStatsStored15);
        }
    }

    public void BuyModels(int index)
    {
        if (_shopSaveController.memes.isBuy[index] == false)
        {
            if (money >= price[index])
            {
                foreach (GameObject m in models)
                {
                    m.SetActive(false);
                }

                models[index].SetActive(true);

                _shopSaveController.memes.isBuy[index] = true;
                _shopSaveController.Save();

                priceText[index].text = null;
                buyButtons[index].SetActive(false);

                money = money - price[index];
                //moneyText.text = "cups:" + money.ToString();
                PlayerPrefs.SetInt("Money", money);
                PlayerPrefs.SetInt("ModelIndex", index);

            }
        }
        
    }
        

    public void LookAndSelectModels(int index)
    {
        foreach (GameObject m in models)
        {
            m.SetActive(false);
        }

        models[index].SetActive(true);

        if (_shopSaveController.memes.isBuy[index] == true)
        {
            selectModel = index;
            PlayerPrefs.SetInt("ModelIndex", index);
        }
    }
}
