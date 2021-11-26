using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Videos : MonoBehaviour
{
    public static int pscore;

    public List<GameObject> BackMem = new List<GameObject>();

    public Text scoreText;

    private int index;

    int Min = 0;
    [SerializeField] int Max = 1900;
    private int a;

    private void Start()
    {
        pscore = 0;
        ison.onScoreChange += rand;
        //scoreText.gameObject.SetActive(true);
        index = PlayerPrefs.GetInt("ModelIndex");
    }

    private void Update()
    {


    }

    public void rand()
    {
        //pscore++;
        //scoreText.text = pscore.ToString();
        ScoreIncrement();
        rnggen();
        
        //Destroy();
    }


    public void rnggen()
    {
        if (pscore % 5 == 0 || pscore == 1)
        {
            a = Random.Range(Min, Max);

            for (int counter = 0; counter < BackMem.Count; counter++)
            {
                BackMem[counter].SetActive(false);
            }

            if (0 < a && a < 100)
            {
                BackMem[0].SetActive(true);
            }
            else if (100 < a && a < 200)
            {
                BackMem[1].SetActive(true);
            }
            else if (200 < a && a < 300)
            {

                BackMem[2].SetActive(true);
            }
            else if (300 < a && a < 400)
            {
                
                BackMem[3].SetActive(true);
            }
            else if (400 < a && a < 500)
            {
                
                BackMem[4].SetActive(true);
            }
            else if (500 < a && a < 600)
            {
                BackMem[5].SetActive(true);
            }
            else if (600 < a && a < 700)
            {
                BackMem[6].SetActive(true);
            }
            else if (700 < a && a < 800)
            {
                BackMem[7].SetActive(true);
            }
            else if (800 < a && a < 900)
            {
                BackMem[8].SetActive(true);
            }
            else if (900 < a && a < 1000)
            {
                BackMem[9].SetActive(true);
            }
            else if (1000 < a && a < 1100)
            {
                BackMem[10].SetActive(true);
            }
            else if (1100 < a && a < 1200)
            {
                BackMem[11].SetActive(true);
            }
            else if (1200 < a && a < 1300)
            {
                BackMem[12].SetActive(true);
            }
            else if (1300 < a && a < 1400)
            {
                BackMem[13].SetActive(true);
            }
            else if (1400 < a && a < 1500)
            {
                BackMem[14].SetActive(true);
            }
            else if (1500 < a && a < 1600)
            {
                BackMem[15].SetActive(true);
            }
            else if (1600 < a && a < 1700)
            {
                BackMem[16].SetActive(true);
            }
            else if (1700 < a && a < 1800)
            {
                BackMem[16].SetActive(true);
            }
            else if (1800 < a && a < 1900)
            {
                BackMem[16].SetActive(true);
            }
            else if (1900 < a && a < 2000)
            {
                BackMem[16].SetActive(true);
            }
        }

    }
    public void otpiska()
    {
        ison.onScoreChange -= rand;
    }

    void ScoreIncrement()
    {
        //pscore++;
        //scoreText.text = pscore.ToString();
        
        if (index == 0 || index == 1)
        {
            pscore++;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
        }
            
        else if (index == 2)
        {
            pscore += 2;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 2);
        }

        else if (index == 3)
        {
            pscore += 3;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 3);
        }

        else if (index == 4)
        {
            pscore += 4;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 4);
        }

        else if (index == 5)
        {
            pscore += 6;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 6);
        }

        else if (index == 6)
        {
            pscore += 7;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 7);
        }

        else if (index == 7)
        {
            pscore += 8;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 8);
        }

        else if (index == 8)
        {
            pscore += 9;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 9);
        }

        else if (index == 9)
        {
            pscore += 11;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 11);
        }

        else if (index == 10)
        {
            pscore += 12;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 12);
        }

        else if (index == 11)
        {
            pscore += 13;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 13);
        }

        else if (index == 12)
        {
            pscore += 14;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 14);
        }

        else if (index == 13)
        {
            pscore += 101;
            scoreText.text = pscore.ToString();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 101);
        }

    }

}
