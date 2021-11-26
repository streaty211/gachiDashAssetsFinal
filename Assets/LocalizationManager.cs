using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private string currentLanguage;
    private Dictionary<string, string> localizedText;
    public static bool isReady = false;
    public delegate void ChangeLangText();
    public event ChangeLangText OnLanguageChanged;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Belarusian)
            {
                PlayerPrefs.SetString("Language", "ru_RU");
            }
            else if (Application.systemLanguage == SystemLanguage.French)
            {
                PlayerPrefs.SetString("Language", "fr_FR");
            }
            else if (Application.systemLanguage == SystemLanguage.Italian)
            {
                PlayerPrefs.SetString("Language", "it_IT");
            }
            else if (Application.systemLanguage == SystemLanguage.German)
            {
                PlayerPrefs.SetString("Language", "ger_DE");
            }
            else if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                PlayerPrefs.SetString("Language", "spa_ES");
            }
            else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
            {
                PlayerPrefs.SetString("Language", "chi_ZH");
            }
            else if (Application.systemLanguage == SystemLanguage.Arabic)
            {
                PlayerPrefs.SetString("Language", "ar_AR");
            }
            else if (Application.systemLanguage == SystemLanguage.Czech)
            {
                PlayerPrefs.SetString("Language", "cs_CS");
            }
            else if (Application.systemLanguage == SystemLanguage.Dutch)
            {
                PlayerPrefs.SetString("Language", "nl_NL");
            }
            else if (Application.systemLanguage == SystemLanguage.Greek)
            {
                PlayerPrefs.SetString("Language", "el_EL");
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                PlayerPrefs.SetString("Language", "ja_JA");
            }
            else if (Application.systemLanguage == SystemLanguage.Norwegian)
            {
                PlayerPrefs.SetString("Language", "no_NO");
            }
            else if (Application.systemLanguage == SystemLanguage.Portuguese)
            {
                PlayerPrefs.SetString("Language", "pt_PT");
            }
            else if (Application.systemLanguage == SystemLanguage.Romanian)
            {
                PlayerPrefs.SetString("Language", "ro_RO");
            }
            else if (Application.systemLanguage == SystemLanguage.Swedish)
            {
                PlayerPrefs.SetString("Language", "sv_SV");
            }
            else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
            {
                PlayerPrefs.SetString("Language", "chi_CHI");
            }
            else if (Application.systemLanguage == SystemLanguage.Ukrainian)
            {
                PlayerPrefs.SetString("Language", "uk_UK");
            }
            else if (Application.systemLanguage == SystemLanguage.Bulgarian)
            {
                PlayerPrefs.SetString("Language", "bg_BG");
            }
            else if (Application.systemLanguage == SystemLanguage.Danish)
            {
                PlayerPrefs.SetString("Language", "da_DA");
            }
            else if (Application.systemLanguage == SystemLanguage.Finnish)
            {
                PlayerPrefs.SetString("Language", "fi_FI");
            }
            else if (Application.systemLanguage == SystemLanguage.Hungarian)
            {
                PlayerPrefs.SetString("Language", "hu_HU");
            }
            else if (Application.systemLanguage == SystemLanguage.Korean)
            {
                PlayerPrefs.SetString("Language", "ko_KO");
            }
            else if (Application.systemLanguage == SystemLanguage.Polish)
            {
                PlayerPrefs.SetString("Language", "pl_PL");
            }
            else if (Application.systemLanguage == SystemLanguage.Thai)
            {
                PlayerPrefs.SetString("Language", "th_TH");
            }
            else if (Application.systemLanguage == SystemLanguage.Turkish)
            {
                PlayerPrefs.SetString("Language", "tr_TR");
            }
            else if (Application.systemLanguage == SystemLanguage.Vietnamese)
            {
                PlayerPrefs.SetString("Language", "vi_VI");
            }
            else
            {
                PlayerPrefs.SetString("Language", "en_US");
            }
        }
        currentLanguage = PlayerPrefs.GetString("Language");

        LoadLocalizedText(currentLanguage);
        Debug.Log(currentLanguage);
    }

    public void LoadLocalizedText(string langName)
    {
        string path = Application.streamingAssetsPath + "/Languages/" + langName + ".json";

        string dataAsJson;

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(path);
            while (!reader.isDone) { }

            dataAsJson = reader.text;
        }
        else
        {
            dataAsJson = File.ReadAllText(path);
        }

        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

        localizedText = new Dictionary<string, string>();
        for (int i = 0; i < loadedData.items.Length; i++)
        {
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
        }

        PlayerPrefs.SetString("Language", langName);
        isReady = true;
        OnLanguageChanged?.Invoke();
    }

    public string GetLocalizedValue(string key)
    {
        if (localizedText.ContainsKey(key))
        {
            return localizedText[key];
        }
        else
        {
            throw new Exception("Localized text with key \"" + key + "\" not found");
        }
    }

    public string CurrentLanguage
    {
        get
        {
            return currentLanguage;
        }
        set
        {

            PlayerPrefs.SetString("Language", value);
            currentLanguage = PlayerPrefs.GetString("Language");
            LoadLocalizedText(currentLanguage);
        }
    }

    public bool IsReady
    {
        get
        {
            return isReady;
        }
    }
}
