using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallangeController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public GameObject[] challanges;
    public float frequency = 0.1f;
    float counter = 0.0f;
    public Transform challangesSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomChallange();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= -0.9f)
            GenerateRandomChallange();
        else
            counter -= Time.deltaTime * frequency;

        GameObject currentChild;
        for(int i = 0; i < transform.childCount;i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            Scrollchallange(currentChild);

            if(currentChild.transform.position.x < -40.0f)
            {
                Destroy(currentChild);
            }
        }
    }
    void Scrollchallange(GameObject currentChallange)
    {
        currentChallange.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);

    }

    void GenerateRandomChallange()
    {
        GameObject newChallenge = Instantiate(challanges[Random.Range(0, challanges.Length)], challangesSpawnPoint.position, Quaternion.identity) as GameObject;
        newChallenge.transform.parent = transform;
        counter = 1.0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
