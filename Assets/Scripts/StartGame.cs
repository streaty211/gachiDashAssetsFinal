using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabModels;
    private int selectModel;



    private void Start()
    {
        selectModel = selectModel = PlayerPrefs.GetInt("ModelIndex");
        //Instantiate(prefabModels[Shop._shop.selectModel], Vector3.zero, Quaternion.identity);
        Instantiate(prefabModels[selectModel], Vector3.zero, Quaternion.identity);
    }

}
