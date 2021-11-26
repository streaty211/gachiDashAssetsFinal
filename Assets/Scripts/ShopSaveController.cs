using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShopSaveController : MonoBehaviour
{
    public Memes memes;

    public void Load()
    {
        memes = JsonUtility.FromJson<Memes>(File.ReadAllText(Application.streamingAssetsPath + "/SaveModels.json"));
    }

    public void Save()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/SaveModels.json", JsonUtility.ToJson(memes));
    }

    [System.Serializable]
    public class Memes
    {
        public bool[] isBuy;
    }
}
